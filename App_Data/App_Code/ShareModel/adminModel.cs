using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// adminModel 管理员
/// </summary>
public class adminModel
{
    private int _aid;
    private string _aname;
    private string _apass;

    public string Apass
    {
        get { return _apass; }
        set { _apass = value; }
    }

    public string Aname
    {
        get { return _aname; }
        set { _aname = value; }
    }
    public int Aid
    {
        get { return _aid; }
        set { _aid = value; }
    }

}