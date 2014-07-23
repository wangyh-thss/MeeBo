using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (name.Text == string.Empty)
        {
            name_error.innerText = "用户名不能为空";
        }
        if (password.Text == string.Empty)
        {
            password_error.innerText = "密码不能为空";
        }
        if (confirm.Text == string.Empty)
        {
            confirm_error.innerText = "两次输入密码不同";
        }
        string uPwd = Request.Form["form-password"];
        string uName = Request.Form["form-user"];
        DataTable result = searchByUserName(uName);
        if (result.Rows.Count > 0)
        {
            name_error.innerText = "用户名已被注册";
            return;
        }
        user.name = uName;
        user.password = uPwd;
        user.nickName = Request.Form["form-nickName"];
        user.admin = 0;
        user.email = Request.Form["form-emaim"];
        user.fansNum = 0;
        user.likesNum = 0;
        user.newsNum = 0;
        user.savesNewsNum = 0;
        user.msgInNum = 0;
        user.msgOutNum = 0;
        Insert(user);
    }

}