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
    protected string path;
    //User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void UploadImg_Click(object sender, EventArgs e)
    {
        if (SelectImg.PostedFile != null && SelectImg.PostedFile.ContentLength > 0)
        {
            string ext = System.IO.Path.GetExtension(SelectImg.PostedFile.FileName).ToLower();
            if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
                return;
            if (SelectImg.PostedFile.ContentLength > 1050000)
                return;

            string filename = SelectImg.FileName;
            path = "~/headImg/" + this.user.Text + '_' + filename;
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
        string uName = this.user.Text;
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

        if (SelectImg.HasFile)
        {
            user.HeadPortrait = path;
        }

        user.Name = uName;
        user.Password = uPwd;
        user.Nickname = this.nickname.Text;
        user.Email = this.email.Text;
        //user.Birthday = Request.Form["birthday"];
        user.Insert();
    }
}