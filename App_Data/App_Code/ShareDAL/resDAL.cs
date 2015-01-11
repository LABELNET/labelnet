using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// resDAL 的摘要说明
/// </summary>
public class resDAL
{
	public resDAL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 添加资源信息
    /// </summary>
    /// <param name="rm">资源实体</param>
    /// <returns></returns>
    public static int addRes(resModel rm)
    {
        string cmdText = @"insert into resTable(rbody,rdate,rfenlei,radmin,rimage) values (@rbody,@rdate,@rfenlei,@radmin,@rimage)";
        OleDbParameter[] param = new OleDbParameter[] { 
        new OleDbParameter("@rbody",rm.Rbody),
        new OleDbParameter("@rdate",rm.Rdate),
        new OleDbParameter("@rfenlei",rm.Rfenlei),
        new OleDbParameter("@radmin",rm.Radmin),
        new OleDbParameter("@rimage",rm.Rimage)
        };
        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);
        return row;
    }
    /// <summary>
    /// 修改资源
    /// </summary>
    /// <param name="rm">资源实体</param>
    /// <returns></returns>
    public static int updateRes(resModel rm)
    {
        string cmdText = @"update resTable set rbody=@rbody,rdate=@rdate,rfenlei=@rfenlei,radmin=@radmin,rimage=@rimage where rid=@rid";
        OleDbParameter[] param = new OleDbParameter[] { 
        new OleDbParameter("@rbody",rm.Rbody),
        new OleDbParameter("@rdate",rm.Rdate),
        new OleDbParameter("@rfenlei",rm.Rfenlei),
        new OleDbParameter("@radmin",rm.Radmin),
        new OleDbParameter("@rimage",rm.Rimage),
        new OleDbParameter("@rid",rm.Rid)
        };
        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);
        return row;
    }

    /// <summary>
    /// 查询所有资源信息
    /// </summary>
    /// <returns></returns>
    public static List<resModel> selectRes()
    {
        List<resModel> rmList = new List<resModel>();
        string cmdText = @"select * from resTable";
        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);

        OleDbDataReader reader = DBhelper.ExecuteReader(conn, CommandType.Text, cmdText, null);
        while (reader.Read())
        {
            resModel rm = new resModel();
            rm.Rid = Convert.ToInt32(reader["rid"]);
            rm.Rbody = reader["rbody"].ToString();
            rm.Radmin = reader["radmin"].ToString();
            rm.Rdate = reader["rdate"].ToString();
            rm.Rfenlei = reader["rfenlei"].ToString();
            rm.Rimage = reader["rimage"].ToString();
            rm.Rstate =Convert.ToInt32(reader["rstate"]);
            rmList.Add(rm);
        }
        reader.Close();
        conn.Close();
        return rmList;
    }

    public static resModel selectRes(int rid)
    {
        resModel rm = new resModel();
        string cmdText = @"select * from resTable where rid=@rid";
        OleDbParameter[] param = new OleDbParameter[] { 
          new OleDbParameter("@rid",rid)
        };
        OleDbConnection conn = new OleDbConnection(DBhelper.CONN_STRING_NON_DTC);
        OleDbDataReader reader = DBhelper.ExecuteReader(conn, CommandType.Text, cmdText, param);
        while (reader.Read())
        {
            rm.Rid = Convert.ToInt32(reader["rid"]);
            rm.Rbody = reader["rbody"].ToString();
            rm.Radmin = reader["radmin"].ToString();
            rm.Rdate = reader["rdate"].ToString();
            rm.Rfenlei = reader["rfenlei"].ToString();
            rm.Rimage = reader["rimage"].ToString();
            rm.Rstate = Convert.ToInt32(reader["rstate"]);
        }
        reader.Close();
        conn.Close();
        return rm;
    }

}