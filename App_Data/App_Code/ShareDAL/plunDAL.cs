using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// plunDAL 的摘要说明
/// </summary>
public class plunDAL
{
    /// <summary>
    ///  添加评论信息
    /// </summary>
    /// <param name="pm">评论实体</param>
    /// <returns></returns>
    public static int addPlun(plunModel pm)
    {
        string cmdText = @"insert into plunTable(pbody,pdate,ptid,pstate) values (@pbody,@pdate,@ptid,@pstate)";
        OleDbParameter[] param = new OleDbParameter[] { 
           new OleDbParameter("@pbody",pm.Pbody),
           new OleDbParameter("@pdate",pm.Pdate),
           new OleDbParameter("@ptid",pm.Ptid),
           new OleDbParameter("pstate",pm.Pstate)
        };
        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);
        return row;
    }
    /// <summary>
    /// 添加留言
    /// </summary>
    /// <param name="pm"></param>
    /// <returns></returns>
    public static int addliuyan(plunModel pm)
    {
        string cmdText = @"insert into plunTable(pbody,pdate,pturn,pstate) values (@pbody,@pdate,@pturn,@pstate)";
        OleDbParameter[] param = new OleDbParameter[] { 
           new OleDbParameter("@pbody",pm.Pbody),
           new OleDbParameter("@pdate",pm.Pdate),
           new OleDbParameter("@pturn",pm.Pturn),
           new OleDbParameter("pstate",pm.Pstate)
        };
        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);
        return row;
    }

    /// <summary>
    /// 查询留言
    /// </summary>
    /// <param name="state">为-1的为留言</param>
    /// <returns></returns>
    public static List<plunModel> selectliuyan(int state)
    {
        List<plunModel> pmList = new List<plunModel>();
        string cmdText = @"select * from plunTable where pstate=@pstate";
        OleDbParameter[] param = new OleDbParameter[] {
         new OleDbParameter("@pstate",state)
        };

        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);

        OleDbDataReader reader = DBhelper.ExecuteReader(conn, CommandType.Text, cmdText, param);
        while (reader.Read())
        {
            plunModel pm = new plunModel();
            pm.Pid = Convert.ToInt32(reader[0]);
            pm.Pbody = reader[1].ToString();
            pm.Pzan = reader[2].ToString();
            pm.Pdate = reader[3].ToString();
            pm.Pturn = reader[4].ToString();
            pm.Ptid = Convert.ToInt32(reader[5]);
            pm.Pstate = Convert.ToInt32(reader[6]);
            pmList.Add(pm);
        }
        reader.Close();
        conn.Close();
        return pmList;
    }

    /// <summary>
    /// 查询评论
    /// </summary>
    /// <param name="ptid">文章或资源对应的id</param>
    /// <param name="state">状态为1的话为文章；状态为2的话是资源</param>
    /// <returns></returns>
    public static List<plunModel> selectPlun(int ptid, int state)
    {
        List<plunModel> pmList = new List<plunModel>();
        string cmdText = @"select * from plunTable where ptid=@ptid and pstate=@pstate";
        OleDbParameter[] param = new OleDbParameter[] {
         new OleDbParameter("@ptid",ptid),
         new OleDbParameter("@pstate",state)
        };

        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);

        OleDbDataReader reader = DBhelper.ExecuteReader(conn,CommandType.Text,cmdText,param);
        while (reader.Read())
        {
            plunModel pm = new plunModel();
            pm.Pid = Convert.ToInt32(reader[0]);
            pm.Pbody = reader[1].ToString();
            pm.Pzan = reader[2].ToString();
            pm.Pdate = reader[3].ToString();
            pm.Pturn = reader[4].ToString();
            pm.Ptid = Convert.ToInt32(reader[5]);
            pm.Pstate = Convert.ToInt32(reader[6]);
            pmList.Add(pm);
        }
        reader.Close();
        conn.Close();
        return pmList;
    }
    public static List<plunModel> selectPlun()
    {
        List<plunModel> pmList = new List<plunModel>();
        string cmdText = @"select * from plunTable";
        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);

        OleDbDataReader reader = DBhelper.ExecuteReader(conn, CommandType.Text, cmdText, null);
        while (reader.Read())
        {
            plunModel pm = new plunModel();
            pm.Pid = Convert.ToInt32(reader[0]);
            pm.Pbody = reader[1].ToString();
            pm.Pzan = reader[2].ToString();
            pm.Pdate = reader[3].ToString();
            pm.Pturn = reader[4].ToString();
            pm.Ptid = Convert.ToInt32(reader[5]);
            pm.Pstate = Convert.ToInt32(reader[6]);
            pmList.Add(pm);
        }
        reader.Close();
        conn.Close();
        return pmList;
    }
}