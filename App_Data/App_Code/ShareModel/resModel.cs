using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// resModel 实体
/// </summary>
public class resModel
{
    private int _rid;
    private string _rbody;
    private string _rdate;
    private string _rfenlei;
    private string _radmin;
    private int _rstate;
    private string _rimage;

    //图片
    public string Rimage
    {
        get { return _rimage; }
        set { _rimage = value; }
    }
    

    //状态
    public int Rstate
    {
        get { return _rstate; }
        set { _rstate = value; }
    }

 


    //资源作者
    public string Radmin
    {
        get { return _radmin; }
        set { _radmin = value; }
    }

    //资源分类
    public string Rfenlei
    {
        get { return _rfenlei; }
        set { _rfenlei = value; }
    }



    //资源日期
    public string Rdate
    {
        get { return _rdate; }
        set { _rdate = value; }
    }

    //资源内容
    public string Rbody
    {
        get { return _rbody; }
        set { _rbody = value; }
    }

    //资源id
    public int Rid
    {
        get { return _rid; }
        set { _rid = value; }
    }

}