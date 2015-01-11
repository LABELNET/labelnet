using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// resBLL 的摘要说明
/// </summary>
public class resBLL
{
	public resBLL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 添加资源信息
    /// </summary>
    /// <param name="rm"></param>
    /// <returns></returns>
    public static bool addRes(resModel rm)
    {
        if (resDAL.addRes(rm) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// 修改信息
    /// </summary>
    /// <param name="rm"></param>
    /// <returns></returns>
    public static bool updateRes(resModel rm)
    {
        if (resDAL.updateRes(rm) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// 查询所有信息
    /// </summary>
    /// <returns></returns>
    public static List<resModel> selectRes()
    {
        return resDAL.selectRes();
    }

    /// <summary>
    /// 单个信息
    /// </summary>
    /// <param name="rid"></param>
    /// <returns></returns>
    public static resModel selectRes(int rid)
    {
        return resDAL.selectRes(rid);
    }
}