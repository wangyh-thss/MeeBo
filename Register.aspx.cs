using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using MeeboDb;

public partial class Register : System.Web.UI.Page
{
    protected string path;
    //User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            path = this.head_potrait.ImageUrl;
    }

    protected void UploadImg_Click(object sender, EventArgs e)
    {
        if (SelectImg.PostedFile != null && SelectImg.PostedFile.ContentLength > 0)
        {
            string ext = System.IO.Path.GetExtension(SelectImg.PostedFile.FileName).ToLower();
            if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
            {
                Response.Write("<script>alert('上传文件格式不正确')</script>");
                    return;
            }
            if (SelectImg.PostedFile.ContentLength > 1050000)
            {
                Response.Write("<script>alert('文件过大，请上传不超过1MB的图片')</script>");
                return;
            }

            string filename = SelectImg.FileName;
            path = "~/headImg/" + this.email.Text + '_' + filename;
            SelectImg.PostedFile.SaveAs(Server.MapPath(path));
            this.head_potrait.ImageUrl = path;
        }
        else
        {
            return;
        }
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        string uName = this.email.Text;
        string uPwd = this.password.Text;
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
        if (uPwd.Length <= 6)
        {
            ScriptManager.RegisterStartupScript(this.error_password, typeof(string), "emptypassword", "document.getElementById('error_password').innerText = '密码过于简单，请输入长度大于6位的密码';", true);
            return;
        }
        if (this.repeat_password.Text == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this.error_repeat_password, typeof(string), "errorrepeat", "document.getElementById('error_repeat_password').innerText = '请确认密码';", true);
            return;
        }
        if (this.repeat_password.Text != uPwd)
        {
            ScriptManager.RegisterStartupScript(this.error_repeat_password, typeof(string), "errorrepeat", "document.getElementById('error_repeat_password').innerText = '两次输入密码不同';", true);
            return;
        }

        Regex emailMatch = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
        if(!emailMatch.IsMatch(uName))
        {
            ScriptManager.RegisterStartupScript(this.error_username , typeof(string), "erroremail", "document.getElementById('error_email').innerText = '邮箱格式有误';", true);
            return;
        }


        if (this.check_num.Text != Request.Cookies["CheckCode"].Value)
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
        string birthday = this.year.Text + '-' + this.month.Text + '-' + this.day.Text;
        DateTime birthDate = Convert.ToDateTime(birthday).Date;
        if (this.gender.SelectedValue == "0")
            user.Gender = false;
        else
            user.Gender = true;
        user.HeadPortrait = path;
        user.Name = uName;
        user.Password = uPwd;
        user.Nickname = this.nickname.Text;
        user.Birthday = birthDate;

        Session["id"] = user.Insert();
        Session["role"] = "user";
        Session["name"] = uName;
        
        Response.Redirect("~/user/PersonalPage.aspx");
    }
}