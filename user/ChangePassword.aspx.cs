using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeeboDb;

public partial class user_ChangePassword : System.Web.UI.Page
{
    protected UserDB user = new UserDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        user.SearchByName((string)Session["name"], "result");
    }
    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        if (this.current_password.Text != user.Password)
        {
            this.error_password.InnerText = "当前密码输入错误";
            return;
        }
        if (this.change_password.Text == string.Empty)
        {
            this.error_password.InnerText = "密码不能为空";
            return;
        }
        if (this.change_password.Text.Length <= 6)
        {
            this.error_password.InnerText = "密码过于简单，请输入长度大于6位的密码";
            return;
        }
        if (this.change_password.Text != this.repeat_password.Text)
        {
            this.error_password.InnerText = "两次输入的密码不同";
            return;
        }
        user.ModifyPassword((Guid)Session["id"], this.change_password.Text);
        Response.Write("<script>alert('修改密码成功')</script>");
    }
    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
}