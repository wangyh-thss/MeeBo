using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeBoDB;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            string uPwd = Request.Form["form-password"];
            string uName = Request.Form["form-user"];
            DataTable result = searchByUserName(uName);
            if (result.Rows.Count > 0)
            {
                //用户名正确 检验密码和身份
                foreach (DataRow user in result.Rows)
                {
                    if (user["UPassword"] == uPwd)
                    {
                        if (user["UAdmin"] == 0)
                        {
                            //普通用户登录
                            Session["role"] = "admin";
                            Session["name"] = uName;
                            Response.Redirect("~/UserInfo.aspx");
                        }
                        else
                        {
                            //管理员登录
                            Session["role"] = "user";
                            Session["name"] = uName;
                            Response.Redirect("~/UserInfo.aspx");
                        }
                    }
                    else
                    {
                        //用户名存在，密码错误·
                        this.error_label.InnerText = "密码错误";
                    }
                }
            }
            else
            {
                //用户名密码错误
                this.error_label.InnerText = "用户不存在";
            }
        }
    }
}