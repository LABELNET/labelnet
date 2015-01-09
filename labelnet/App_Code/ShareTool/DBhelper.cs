using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// DBhelper 的摘要说明
/// 
/// 实现数据库的操作
/// </summary>
public class DBhelper
{
    #region  CONN_STRING_NON_DTC
    //数据库连结串
    public static string CONN_STRING_NON_DTC = ConfigurationManager.ConnectionStrings["AccessString"].ConnectionString;

    // 用Hashtable缓存存储参数
    private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

    /// <summary>
    /// 执行前准备工作(对象属性赋值)
    /// </summary>
    /// <param name="cmd">SqlCommand对象</param>
    /// <param name="conn">SqlConnection对象</param>
    /// <param name="trans">SqlTransaction对象</param>
    /// <param name="cmdType">命令类型(stored procedure, text)</param>
    /// <param name="cmdText">存储过程名或T-SQL命令</param>
    /// <param name="cmdParms">参数集合</param>
    private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            { conn.Open(); }
        }
        catch
        {
            conn.Close();
            conn.Open();
        }

        cmd.Connection = conn;
        cmd.CommandText = cmdText;

        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (OleDbParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }

    /// <summary>
    /// 添加参数集合到缓存中。
    /// </summary>
    /// <param name="cacheKey">参数键值</param>
    /// <param name="cmdParms">参数集合</param>
    public static void CacheParameters(string cacheKey, params OleDbParameter[] cmdParms)
    {
        parmCache[cacheKey] = cmdParms;
    }

    /// <summary>
    /// 取得缓存参数
    /// </summary>
    /// <param name="cacheKey">参数键值</param>
    /// <returns>参数集合</returns>
    public static OleDbParameter[] GetCachedParameters(string cacheKey)
    {
        OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];

        if (cachedParms == null)
            return null;

        OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];

        for (int i = 0, j = cachedParms.Length; i < j; i++)
            clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();

        return clonedParms;
    }
    #endregion

    #region ExecuteNonQuery
    /// <summary>
    /// 通过给定的数据库连结串执行命令
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">数据库连结串</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>影响的行数</returns>
    public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {

        OleDbCommand cmd = new OleDbCommand();

        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 通过给定的SqlConnection数据库连结对象执行命令
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">SqlConnection对象</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>影响的行数</returns>
    public static int ExecuteNonQuery(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {

        OleDbCommand cmd = new OleDbCommand();

        PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 通过给定的SqlTransaction事务对象执行命令
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">SqlConnection对象</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>影响的行数</returns>
    public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {
        OleDbCommand cmd = new OleDbCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    //执行一些互相联系需要一次成功的sql语句，使用事务操作
    public static bool ExecuteStoreProcedure(string connString, String[] SqlStrings, OleDbParameter[][] cmdParms)
    {
        bool success = true;
        OleDbCommand cmd = new OleDbCommand();
        int i = 0;
        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction(); /*开始事务*/
            cmd.Connection = conn;
            cmd.Transaction = trans;
            try
            {
                foreach (String sqlstr in SqlStrings)
                {
                    cmd.CommandText = sqlstr;
                    if (cmdParms != null)
                    {
                        foreach (OleDbParameter parm in cmdParms[i])
                            cmd.Parameters.Add(parm);
                    }
                    cmd.ExecuteNonQuery();
                    i++;
                }
                cmd.Parameters.Clear();
                trans.Commit();
            }
            catch
            {
                success = false;
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        return success;
    }

    #endregion

    #region ExecuteDataTable
    /// <summary>
    /// 通过给定的数据库连结串执行命令
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  int result = ExecuteDataTable(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">数据库连结串</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>检索数据集</returns>
    public static DataTable ExecuteDataTable(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {
        OleDbCommand cmd = new OleDbCommand();

        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            cmd.Parameters.Clear();

            return dt;
        }
    }

    /*根据sql查询语句得到内存数据集*/
    public static DataSet GetDataSet(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {
        OleDbCommand cmd = new OleDbCommand();

        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }
    }


    /// <summary>
    /// 通过给定的SqlConnection数据库连结对象执行命令
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  int result = ExecuteDataTable(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">SqlConnection对象</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>检索数据集</returns>
    public static DataTable ExecuteDataTable(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {

        OleDbCommand cmd = new OleDbCommand();

        PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);

        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataTable dt = new DataTable();

        da.Fill(dt);

        cmd.Parameters.Clear();

        return dt;
    }

    /// <summary>
    /// 通过给定的SqlTransaction事务对象执行命令
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  int result = ExecuteDataTable(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">SqlConnection对象</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>检索数据集</returns>
    public static DataTable ExecuteDataTable(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {
        OleDbCommand cmd = new OleDbCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);

        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

        DataTable dt = new DataTable();

        da.Fill(dt);

        cmd.Parameters.Clear();

        return dt;
    }
    #endregion

    #region ExecuteReader
    /// <summary>
    /// 通过给定的数据库连结串执行命令，返回一个SqlDataReader对象。
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">数据库连结串</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>SqlDataReader对象</returns>
    public static OleDbDataReader ExecuteReader(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {

        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandType = cmdType;
        cmd.CommandText = cmdText;

        if (cmdParms != null)
        {
            foreach (OleDbParameter sp in cmdParms)
            {
                cmd.Parameters.Add(sp);
            }
        }
        OleDbDataReader rdr = cmd.ExecuteReader();
        return rdr;
    }
    #endregion

    #region ExecuteScalar
    /// <summary>
    /// 通过给定的数据库连结串执行命令，返回记录集第一条信息的第一列。
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">数据库连结串</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>使用Convert.To{Type}返回需要的类型</returns>
    public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {
        OleDbCommand cmd = new OleDbCommand();

        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 通过给定的SqlConnection数据库连结对象串执行命令，返回记录集第一条信息的第一列。
    /// </summary>
    /// <remarks>
    /// e.g.:  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">数据库连结串</param>
    /// <param name="commandType">命令类型(stored procedure, text, etc.)</param>
    /// <param name="commandText">存储过程名或T-SQL命令</param>
    /// <param name="commandParameters">参数集合</param>
    /// <returns>使用Convert.To{Type}返回需要的类型</returns>
    public static object ExecuteScalar(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms)
    {

        OleDbCommand cmd = new OleDbCommand();

        PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }
    #endregion





}