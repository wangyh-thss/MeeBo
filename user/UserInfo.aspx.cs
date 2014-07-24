using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeeboDb;

public partial class UserInfo : System.Web.UI.Page
{
    protected UserDB user = new UserDB();
    protected string headOriginPath;
    protected string path;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        user.SearchByName((string)Session["name"], "result");
        if (IsPostBack)
        { }
        else
        {
            headOriginPath = user.HeadPortrait;
            path = this.head_potrait.ImageUrl;
            this.nickname.Text = user.Nickname;
            this.email.Text = user.Email;
            if (user.Gender == false)
                this.gender.Items.FindByValue("0").Selected = true;
            else
                this.gender.Items.FindByValue("1").Selected = true;
            string birthday = user.Birthday.ToString("d");
            string[] s = birthday.Split(new char[] { '/' });
            this.year.Items.FindByValue(s[0]).Selected = true;
            this.month.Items.FindByValue(s[1]).Selected = true;
            this.day.Items.FindByValue(s[2]).Selected = true;
            this.head_potrait.ImageUrl = headOriginPath;
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (this.nickname.Text != user.Nickname)
        {
            user.ModifyNickname((Guid)Session["id"], this.nickname.Text);
        }
        if (this.email.Text != user.Email)
        {
            user.ModifyEmail((Guid)Session["id"], this.email.Text);
        }
        if (this.gender.SelectedValue == "0" && user.Gender == true)
        {
            user.Modifygender((Guid)Session["id"], false);
        }
        if (this.gender.SelectedValue == "1" && user.Gender == false)
        {
            user.Modifygender((Guid)Session["id"], true);
        }
        string birthday = this.year.Text + '-' + this.month.Text + '-' + this.day.Text;
        DateTime birthDate = Convert.ToDateTime(birthday).Date;
        if (birthDate != user.Birthday)
        {
            user.ModifyBirthday((Guid)Session["id"], birthDate);
        }
        if (path != user.HeadPortrait)
        {
            user.ModifyHeadPortrait((Guid)Session["id"], path);
        }
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
            path = "~/headImg/" + user.Name + '_' + filename;
            SelectImg.PostedFile.SaveAs(Server.MapPath(path));
            this.head_potrait.ImageUrl = path;
        }
        else
        {
            return;
        }
    }
}