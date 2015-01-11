using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// plunBLL 的摘要说明
/// </summary>
public class plunBLL
{
    /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="pm"></param>
    /// <returns></returns>
    public static bool addPlun(plunModel pm)
    {
        if (plunDAL.addPlun(pm) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// 查询相关评论
    /// </summary>
    /// <param name="ptid">文章对应id</param>
    /// <param name="state">对应状态</param>
    /// <returns></returns>
    public static List<plunModel> selectPlun(int ptid, int state)
    {
         return plunDAL.selectPlun(ptid, state);
    }
    /// <summary>
    /// 评论
    /// </summary>
    /// <returns></returns>
    public static List<plunModel> selectPlun()
    {
        return plunDAL.selectPlun();
    }

    /// <summary>
    /// 增加留言
    /// </summary>
    /// <param name="pm"></param>
    /// <returns></returns>
    public static bool addliuyan(plunModel pm)
    {
        if (plunDAL.addliuyan(pm) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// 状态为-1 为留言
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public static List<plunModel> selectliuyan(int state)
    {
        return plunDAL.selectliuyan(state);
    }
}