using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;

public partial class Login : System.Web.UI.Page
{
    //protected System.Web.UI.HtmlControls.HtmlGenericControl error_label;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDB userDb = new UserDB();
        if(IsPostBack)
        {
            string uPwd = Request.Form["user"];
            string uName = Request.Form["password"];
            DataSet resultSet = userDb.SearchByName(uName, "result");
            if (resultSet.Tables["result"].Rows.Count > 0)
            {
                //用户名正确 检验密码和身份
                foreach (DataRow user in resultSet.Tables["result"].Rows)
                {
                    if (user["UPassword"].ToString() == uPwd)
                    {
                        if (user["UAdmin"].ToString() == "0")
                        {
                            //普通用户登录
                            Session["role"] = "user";
                            Session["name"] = uName;
                            Session["id"] = new Guid(user["UID"].ToString());
                            Response.Redirect("~/user/UserInfo.aspx");
                        }
                        else
                        {
                            //管理员登录
                            Session["role"] = "admin";
                            Session["name"] = uName;
                            Session["id"] = new Guid(user["UID"].ToString());
                            Response.Redirect("~/user/UserInfo.aspx");
                        }
                    }
                    else
                    {
                        //用户名存在，密码错误·
                        ScriptManager.RegisterStartupScript(this.error_label, typeof(string), "error", "document.getElementById('error_label').innerText = '密码错误';", true);
                        return;
                        
                    }
                }
            }
            else
            {
                //用户名密码错误
                ScriptManager.RegisterStartupScript(this.error_label, typeof(string), "error", "document.getElementById('error_label').innerText = '用户不存在';", true);
                return;
            }
        }
    }
}