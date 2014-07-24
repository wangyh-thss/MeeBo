using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;

public partial class Register : System.Web.UI.Page
{
    //User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string uName = Request.Form["user"];
            string uPwd = Request.Form["password"];
            if (uName == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.error_username, typeof(string), "errorname", "document.getElementById('error_username').innerText = '用户名不可为空';", true);
                return;
            }
            if (uPwd == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.error_password, typeof(string), "emptypassword", "document.getElementById('error_password').innerText = '密码不能为空';", true);
                return;
            }
            if (Request.Form["repeat_password"] == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this.error_repeat_password, typeof(string), "errorrepeat", "document.getElementById('error_repeat_password').innerText = '请确认密码';", true);
                return;
            }
            if (Request.Form["repeat_password"] != uPwd)
            {
                ScriptManager.RegisterStartupScript(this.error_repeat_password, typeof(string), "errorrepeat", "document.getElementById('error_repeat_password').innerText = '两次输入密码不同';", true);
                return;
            }
            if (Request.Form["check_num"] != Request.Cookies["CheckCode"].ToString())
            {
                ScriptManager.RegisterStartupScript(this.error_repeat_password, typeof(string), "errorrepeat", "document.getElementById('error_check_num').innerText = '验证码错误';", true);
                return;
            }
            UserDB user = new UserDB();
            DataSet resultSet = user.SearchByName(uName, "result");
            if (resultSet.Tables["result"].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.error_username, typeof(string), "errorname", "document.getElementById('error_username').innerText = '用户名已被注册';", true);
                return;
            }
            user.Name = uName;
            user.Password = uPwd;
            user.Nickname = Request.Form["form-nickName"];
            user.Email = Request.Form["form-emaim"];
            //user.Birthday = Request.Form["birthday"];
            user.Insert();
        }
    }
}