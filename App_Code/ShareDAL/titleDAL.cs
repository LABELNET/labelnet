using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// titleDAL 的摘要说明
/// </summary>
public class titleDAL
{
    /// <summary>
    /// 添加文章
    /// </summary>
    /// <param name="tm"></param>
    /// <returns></returns>
    public static int addTitle(titleModel tm)
    {
        string cmdText = @"insert into titleTable(tname,tbody,tfenlei,tdate,tlabel,tadmin,timage) values(@tname,@tbody,@tfenlei,@tdate,@tlabel,@tadmin,@timage)";
        OleDbParameter[] param = new OleDbParameter[]{
            new OleDbParameter("@tname",tm.Tname),
            new OleDbParameter("@tbody",tm.Tbody),
            new OleDbParameter("@tfenlei",tm.Tfenlei),
            new OleDbParameter("@tdate",tm.Tdate),
            new OleDbParameter("@tlabel",tm.Tlabel),
            new OleDbParameter("@tadmin",tm.Tadmin),
            new OleDbParameter("@timage",tm.Timage)
       };
        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);
        return row;
    }

    /// <summary>
    /// 修改文章
    /// </summary>
    /// <param name="tm"></param>
    /// <returns></returns>
    public static int updateTitle(titleModel tm)
    {
        string cmdText = @"update titleTable set tname=@tname,tbody=@tbody,tfenlei=@tfenlei,tdate=@tdate,tlabel=@tlabel,tadmin=@tadmin,timage=@timage where tid=@tid";
        OleDbParameter[] param = new OleDbParameter[]{
            new OleDbParameter("@tname",tm.Tname),
            new OleDbParameter("@tbody",tm.Tbody),
            new OleDbParameter("@tfenlei",tm.Tfenlei),
            new OleDbParameter("@tdate",tm.Tdate),
            new OleDbParameter("@tlabel",tm.Tlabel),
            new OleDbParameter("@tadmin",tm.Tadmin),
            new OleDbParameter("@timage",tm.Timage),
            new OleDbParameter("@tid",tm.Tid)
       };
        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);
        return row;
    }

    /// <summary>
    /// 查询所有文章
    /// </summary>
    /// <returns></returns>
    public static List<titleModel> selectTitle()
    {
        List<titleModel> titleList = new List<titleModel>();
        string cmdText = @"select * from titleTable";
        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);
         OleDbDataReader reader = DBhelper.ExecuteReader(conn, CommandType.Text, cmdText, null);
        while (reader.Read())
        {
            titleModel tm = new titleModel();
            tm.Tid = Convert.ToInt32(reader["tid"]);
            tm.Tadmin = reader["tadmin"].ToString();
            tm.Tbody = reader["tbody"].ToString();
            tm.Tdate = reader["tdate"].ToString();
            tm.Tfenlei = reader["tfenlei"].ToString();
            tm.Timage = reader["timage"].ToString();
            tm.Tlabel = reader["tlabel"].ToString();
            tm.Tname = reader["tname"].ToString();
            tm.Tstate = Convert.ToInt32(reader["tstate"]);
            titleList.Add(tm);
        }
        reader.Close();
        conn.Close();
        return titleList;
    }

    public static titleModel selectTitle(int tid)
    {
        titleModel tm = new titleModel();
        string cmdText = @"select * from titleTable where tid=@tid";
        OleDbParameter[] param = new OleDbParameter[] { 
            new OleDbParameter("@tid",tid)
        };

        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);
        OleDbDataReader reader = DBhelper.ExecuteReader(conn, CommandType.Text, cmdText, param);
        while (reader.Read())
        {
            tm.Tid = Convert.ToInt32(reader["tid"]);
            tm.Tadmin = reader["tadmin"].ToString();
            tm.Tbody = reader["tbody"].ToString();
            tm.Tdate = reader["tdate"].ToString();
            tm.Tfenlei = reader["tfenlei"].ToString();
            tm.Timage = reader["timage"].ToString();
            tm.Tlabel = reader["tlabel"].ToString();
            tm.Tname = reader["tname"].ToString();
            tm.Tstate = Convert.ToInt32(reader["tstate"]);
        }
        reader.Close();
        conn.Close();
        return tm;
    }

}