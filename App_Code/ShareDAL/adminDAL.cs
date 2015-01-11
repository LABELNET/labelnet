using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
/// <summary>
/// adminDAL 
/// 
/// </summary>
public class adminDAL
{
    /// <summary>
    /// 注册
    /// </summary>
    /// <returns></returns>
    public static int admin_Resgister(adminModel am)
    {

        string cmdText = @"insert into adminTable(aname,apass) values(@aname,@apass)";
        OleDbParameter[] param = new OleDbParameter[]{
            new OleDbParameter("@aname",am.Aname),
            new OleDbParameter("@apass",am.Apass)
       };

        int row = DBhelper.ExecuteNonQuery(DBhelper.CONN_STRING_NON_DTC, CommandType.Text, cmdText, param);

        return row;
    }


    /// <summary>
    /// 登陆
    /// </summary>
    /// <returns></returns>
    public static int admin_Login(adminModel am)
    {
        string cmdText = @"select aid from adminTable where aname=@aname and apass=@apass";
        OleDbParameter []param = new OleDbParameter[]
        {
            new OleDbParameter("@aname",am.Aname),
            new OleDbParameter("@apass",am.Apass)
        };
        int row = Convert.ToInt32(DBhelper.ExecuteScalar(DBhelper.CONN_STRING_NON_DTC,CommandType.Text,cmdText,param));
        return row;
    }

}