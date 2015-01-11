using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// titleBLL 的摘要说明
/// </summary>
public class titleBLL
{
	public titleBLL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 添加文章信息
    /// </summary>
    /// <param name="tm"></param>
    /// <returns></returns>
    public static bool addTitle(titleModel tm)
    {
        if (titleDAL.addTitle(tm) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// 修改信息
    /// </summary>
    /// <param name="tm"></param>
    /// <returns></returns>
    public static bool updateTitle(titleModel tm)
    {
        if (titleDAL.updateTitle(tm) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// 查询信息
    /// </summary>
    /// <returns></returns>
    public static List<titleModel> selectTitle()
    {
        return titleDAL.selectTitle();
    }

    /// <summary>
    /// 根据id 查询文章内容
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    public static titleModel selectTitle(int tid)
    {
        return titleDAL.selectTitle(tid);
    }
}