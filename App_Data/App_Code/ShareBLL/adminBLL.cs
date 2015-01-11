using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// adminBLL 的摘要说明
/// </summary>
public class adminBLL
{

    /// <summary>
    /// 注册
    /// </summary>
    /// <returns></returns>
    public static bool admin_Resgister(adminModel am)
    {
        if (adminDAL.admin_Resgister(am) > 0)
            return true;
        return false;
    }


    /// <summary>
    /// 登陆
    /// </summary>
    /// <returns></returns>
    public static bool  admin_Login(adminModel am)
    {
        if (adminDAL.admin_Login(am) > 0)
            return true;
        return false;
    }



}