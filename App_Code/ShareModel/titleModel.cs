using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// titleTable 的摘要说明
/// </summary>
public class titleModel
{
    private int _tid;
    private string _tname;

    public string Tname
    {
        get { return _tname; }
        set { _tname = value; }
    }
    private string _tbody;
    private string _tfenlei;
    private string _tdate;
    private string _tlabel;
    private string _tadmin;
    private string _timage;
    private int _tstate;

    //文章状态为1
    public int Tstate
    {
        get { return _tstate; }
        set { _tstate = value; }
    }
 

    //图片
    public string Timage
    {
        get { return _timage; }
        set { _timage = value; }
    }


    //文章作者
    public string  Tadmin
    {
        get { return _tadmin; }
        set { _tadmin = value; }
    }

    //文本标签
    public string Tlabel
    {
        get { return _tlabel; }
        set { _tlabel = value; }
    }

    public string Tdate
    {
        get { return _tdate; }
        set { _tdate = value; }
    }


    //文章分类
    public string Tfenlei
    {
        get { return _tfenlei; }
        set { _tfenlei = value; }
    }


    //文章内容
    public string Tbody
    {
        get { return _tbody; }
        set { _tbody = value; }
    }


    //文章id
    public int Tid
    {
        get { return _tid; }
        set { _tid = value; }
    }
}