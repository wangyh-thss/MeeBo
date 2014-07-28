using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using MeeboDb;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class user_PersonalPage : System.Web.UI.Page
{
    protected NewsDB news;
    protected UserDB user;
    protected string btnNewsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        news = new NewsDB();
        user = new UserDB();
        if(IsPostBack)
        {
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        }
        else
        {
            LikeDB like = new LikeDB();
            JArray array = new JArray();
            int num = 0;
            if (Session["name"] == null)
                Response.Redirect("~/Login.aspx");
            user.SearchByName((string)Session["name"], "result");
            DataSet follow = like.SearchByFanID("follow", (Guid)Session["id"]);
            foreach(DataRow followUser in follow.Tables["follow"].Rows)
            {
                DataSet singlePerson = news.SearchByUserID((Guid)followUser["UID"], "singlePerson");
                foreach(DataRow singleNews in singlePerson.Tables["singlePerson"].Rows)
                {
                    if((bool)singleNews["NDelete"] == true)
                        continue;
                    JObject singleNewsInfo = new JObject();
                    singleNewsInfo.Add(new JProperty("head", (string)followUser["UHeadPortrait"]));
                    singleNewsInfo.Add(new JProperty("nickname", (string)followUser["UNickname"]));
                    singleNewsInfo.Add(new JProperty("MeeboID", (string)singleNews["NID"]));
                    singleNewsInfo.Add(new JProperty("content", (string)singleNews["NContentT"]));
                    singleNewsInfo.Add(new JProperty("pictures", (string)singleNews["NContentP"]));
                    singleNewsInfo.Add(new JProperty("time", (string)singleNews["NDate"]));
                    singleNewsInfo.Add(new JProperty("praise", (string)singleNews["NProNum"]));
                    singleNewsInfo.Add(new JProperty("comment", (string)singleNews["NComNum"]));
                    singleNewsInfo.Add(new JProperty("repost", (string)singleNews["NTransmitNum"]));
                    singleNewsInfo.Add(new JProperty("save", (string)singleNews["NSaveNum"]));
                    array.Add(singleNewsInfo);
                    num++;
                }
            }
            array.OrderByDescending(p => p["time"]);

            string json = array.ToString();
        }
    }

    protected void SendOut_Click(object sender, EventArgs e)
    {
        string MeeboToSend = this.send_content.Text;
        if (MeeboToSend == string.Empty)
        {

        }
        else
        {
            SenINfoDB sensWordDB = new SenINfoDB();
            DataSet sensWordSet = sensWordDB.GetAll("sensWord");
            foreach (DataRow word in sensWordSet.Tables["sensWord"].Rows)
            {
                if (MeeboToSend.Contains((string)word["SenInfo"]))
                {
                    Response.Write("<script>alert('含有敏感词，不予发布')</script>");
                    return;
                }
            }
            news.ContentT = MeeboToSend;
            Regex topicRegex = new Regex("#[^\"]*#");
            news.Topic = topicRegex.Match(MeeboToSend).Value.Replace("#", "");
            Regex atRegex = new Regex("@[^\x20]* ");
            MatchCollection atSomeone = atRegex.Matches(MeeboToSend);
            news.CallNum = atSomeone.Count;
            for (int i = 0; i < atSomeone.Count; i++)
            {
                string atNickname = atSomeone[i].ToString().Replace("@", "");
            }
            Session["picNum"] = 0;
            news.Insert();
        }
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
            if (SelectImg.PostedFile.ContentLength > 4200000)
            {
                Response.Write("<script>alert('文件过大，请上传不超过4MB的图片')</script>");
                return;
            }

            string filename = SelectImg.FileName;
            string path = "~/headImg/MeeBoPic_" + (string)Session["name"] + '_' + filename;
            if (Session["picNum"] == null || (int)Session["picNum"] == 0)
                Session["picNum"] = 1;
            else
                Session["picNum"] = (int)Session["picNum"] + 1;
            /*
            if ((int)Session["picNum"] == 1)
                this.pic1.ImageUrl = path;
            else if ((int)Session["picNum"] == 2)
                this.pic2.ImageUrl = path;
            else if ((int)Session["picNum"] == 3)
                this.pic3.ImageUrl = path;
            else if ((int)Session["picNum"] == 4)
                this.pic4.ImageUrl = path;
            else if ((int)Session["picNum"] == 5)
                this.pic5.ImageUrl = path;
            else
            {
                Response.Write("<script>alert('最多只能上传5张图片')</script>");
                Session["picNum"] = 5;
                return;
            }
             */
            SelectImg.PostedFile.SaveAs(Server.MapPath(path));

        }
        else
        {
            return;
        }
    }

    protected void zan_Click(object sender, EventArgs e)
    {
        PraiseDB praiseDb = new PraiseDB();
        praiseDb.UserID = (Guid)Session["id"];
        praiseDb.NewsID = new Guid(this.btnNewsID);
        praiseDb.isCheck = false;
        NewsDB newsDb = new NewsDB();
        newsDb.SearchByID(new Guid(this.btnNewsID), "result");
        newsDb.ChangeProNum(new Guid(this.btnNewsID), 1);
        praiseDb.NewsUserID = newsDb.UserID;
        praiseDb.Insert();
    }

    protected void repost_Click(object sender, EventArgs e)
    {

    }

    protected void comment_Click(object sender, EventArgs e)
    {

    }

    protected void save_Click(object sender, EventArgs e)
    {
        SaveDB saveDb = new SaveDB();
        saveDb.UserID = (Guid)Session["id"];
        saveDb.NewsID = new Guid(this.btnNewsID);
        saveDb.Insert();
        NewsDB newsDb = new NewsDB();
        newsDb.ChangeSaveNum(new Guid(this.btnNewsID), 1);
    }
}

