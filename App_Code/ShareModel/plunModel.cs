using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// plunModel 实体
/// </summary>
public class plunModel
{
    private int _pid;
    private string _pbody;
    private string _pzan;
    private string _pturn;
    private string _pdate;
    private int _ptid;
    private int _pstate;

    //表示状态如果为1则为文章，如果为2则为资源
    public int Pstate
    {
        get { return _pstate; }
        set { _pstate = value; }
    }
    //评论文章或者资源id
    public int Ptid
    {
        get { return _ptid; }
        set { _ptid = value; }
    }
    //评论时间
    public string Pdate
    {
        get { return _pdate; }
        set { _pdate = value; }
    }
    //转发次数
    public string Pturn
    {
        get { return _pturn; }
        set { _pturn = value; }
    }
    //赞
    public string Pzan
    {
        get { return _pzan; }
        set { _pzan = value; }
    }
    //内容
    public string Pbody
    {
        get { return _pbody; }
        set { _pbody = value; }
    }
    //评论id
    public int Pid
    {
        get { return _pid; }
        set { _pid = value; }
    }
}