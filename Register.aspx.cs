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
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string uName = Request.Form["user"];
        string uPwd = Request.Form["password"];
        if (uName == string.Empty)
        {
            Response.Write("<script type='text/javascript'>$('#error_user').innerText='用户名不可为空'</script>");
            return;
        }
        if (uPwd == string.Empty)
        {
            Response.Write("<script type='text/javascript'>$('#error_password').innerText='密码不能为空'</script>");
            return;
        }
        if (Request.Form["repeat_password"] == string.Empty)
        {
            Response.Write("<script type='text/javascript'>$('#error_label').innerText='两次输入密码不同'</script>");
            return;
        }
        UserDB user = new UserDB();
        DataSet resultSet = user.SearchByName(uName, "result");
        if (resultSet.Tables["result"].Rows.Count > 0)
        {
            Response.Write("<script type='text/javascript'>$('#error_label').innerText='用户名已被注册'</script>");
            return;
        }
        user.Name = uName;
        user.Password = uPwd;
        user.Nickname = Request.Form["form-nickName"];
        user.Email = Request.Form["form-emaim"];
        user.Birthday = Request.Form["birthday"];
        user.Insert();
    }
}