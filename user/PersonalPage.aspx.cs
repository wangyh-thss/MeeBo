using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Text;
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
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        news = new NewsDB();
        user = new UserDB();
        if(IsPostBack)
        {
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        }
        LikeDB like = new LikeDB();
        SaveDB saveDb = new SaveDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        user.SearchByID("user", (Guid)Session["id"]);
        UserDB starUser;
        NewsDB originNewsInfo;
        UserDB originUser;
            
        DataSet follow = like.SearchByFanID("follow", (Guid)Session["id"]);
        foreach(DataRow followUser in follow.Tables["follow"].Rows)
        {
            DataSet singlePerson = news.SearchByUserID((Guid)followUser["LStarUID"], "singlePerson");
            foreach(DataRow singleNews in singlePerson.Tables["singlePerson"].Rows)
            {
                JObject singleNewsInfo = new JObject();
                if (singleNews["NIsTransmit"].ToString() == "False")
                {
                    starUser = new UserDB();
                    starUser.SearchByID("starUser", (Guid)followUser["LStarUID"]);
                    singleNewsInfo.Add(new JProperty("type", "Meebo"));
                    singleNewsInfo.Add(new JProperty("head", starUser.HeadPortrait.Replace("~", "..")));
                    singleNewsInfo.Add(new JProperty("nickname", starUser.Nickname));
                    singleNewsInfo.Add(new JProperty("userID", starUser.ID));
                    singleNewsInfo.Add(new JProperty("MeeboID", singleNews["NID"].ToString()));
                    singleNewsInfo.Add(new JProperty("content", singleNews["NContentT"]));
                    if (singleNews["NContentP"].ToString() != string.Empty)
                    {
                        string[] picUrl = singleNews["NContentP"].ToString().Split(';');
                        singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                    }
                    singleNewsInfo.Add(new JProperty("time", singleNews["NDate"].ToString()));
                    singleNewsInfo.Add(new JProperty("praise", singleNews["NProNum"]));
                    singleNewsInfo.Add(new JProperty("comment", singleNews["NComNum"]));
                    singleNewsInfo.Add(new JProperty("repost", singleNews["NTransmitNum"]));
                    singleNewsInfo.Add(new JProperty("save", singleNews["NSaveNum"]));
                    singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], (Guid)singleNews["NID"])));
                }
                else
                {
                    starUser = new UserDB();
                    starUser.SearchByID("starUser", (Guid)followUser["LStarUID"]);
                    singleNewsInfo.Add(new JProperty("type", "trans"));
                    singleNewsInfo.Add(new JProperty("head", starUser.HeadPortrait.Replace("~", "..")));
                    singleNewsInfo.Add(new JProperty("nickname", starUser.Nickname));
                    singleNewsInfo.Add(new JProperty("userID", starUser.ID));
                    singleNewsInfo.Add(new JProperty("MeeboID", singleNews["NID"].ToString()));
                    singleNewsInfo.Add(new JProperty("content", singleNews["NTransmitInf"]));
                    singleNewsInfo.Add(new JProperty("time", singleNews["NDate"].ToString()));
                    singleNewsInfo.Add(new JProperty("praise", singleNews["NProNum"]));
                    singleNewsInfo.Add(new JProperty("comment", singleNews["NComNum"]));
                    singleNewsInfo.Add(new JProperty("repost", singleNews["NTransmitNum"]));
                    singleNewsInfo.Add(new JProperty("save", singleNews["NSaveNum"]));
                    singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], (Guid)singleNews["NID"])));
                    originNewsInfo = new NewsDB();
                    originNewsInfo.SearchByID((Guid)singleNews["NFrom"], "originNews");
                    originUser = new UserDB();
                    originUser.SearchByID("originUser", originNewsInfo.UserID);
                    singleNewsInfo.Add(new JProperty("originUser", originUser.Nickname));
                    singleNewsInfo.Add(new JProperty("originUserID", originNewsInfo.ID));
                    singleNewsInfo.Add(new JProperty("originContent", originNewsInfo.ContentT));
                    if (originNewsInfo.ContentP != string.Empty)
                    {
                        string[] picUrl = originNewsInfo.ContentP.Split(';');
                        singleNewsInfo.Add(new JProperty("originPictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                    }
                    singleNewsInfo.Add(new JProperty("originTime", originNewsInfo.Date.ToString()));
                }
                JList.Add(singleNewsInfo);
                num++;
            }
        }
            
            
        /*
        DataSet singlePerson = news.SearchByUserID((Guid)Session["id"], "singlePerson");
        foreach (DataRow singleNews in singlePerson.Tables["singlePerson"].Rows)
        {
            if ((bool)singleNews["NDelete"] == true)
                continue;
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", user.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", user.Nickname));
            singleNewsInfo.Add(new JProperty("MeeboID", singleNews["NID"].ToString()));
            singleNewsInfo.Add(new JProperty("content", singleNews["NContentT"]));
            if (singleNews["NContentP"].ToString() != string.Empty)
            {
                string[] picUrl = singleNews["NContentP"].ToString().Split(';');
                singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url)));
            }
            singleNewsInfo.Add(new JProperty("time", singleNews["NDate"]));
            singleNewsInfo.Add(new JProperty("praise", singleNews["NProNum"]));
            singleNewsInfo.Add(new JProperty("comment", singleNews["NComNum"]));
            singleNewsInfo.Add(new JProperty("repost", singleNews["NTransmitNum"]));
            singleNewsInfo.Add(new JProperty("save", singleNews["NSaveNum"]));
            JList.Add(singleNewsInfo);
            num++;
        }
        */

        JArray array = new JArray(
            from item in JList
            orderby item["time"] descending
            select new JObject(item)
            );
            
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getMeeBo(" + json + ")", true);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
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
            news.UserID = (Guid)Session["id"];
            /*
            string picPath;
            if ((int)Session["picNum"] == 0) 
                ;
            else if ((int)Session["picNum"] == 1)
                picPath = this.pic1.ImageUrl;
            else if ((int)Session["picNum"] == 2)
                picPath = this.pic1.ImageUrl + ";" + this.pic2.ImageUrl;
            else if ((int)Session["picNum"] == 3)
                picPath = this.pic1.ImageUrl + ";" + this.pic2.ImageUrl + ";" + this.pic3.ImageUrl;
            else if ((int)Session["picNum"] == 4)
                picPath = this.pic1.ImageUrl + ";" + this.pic2.ImageUrl + ";" + this.pic3.ImageUrl + ";" + this.pic4.ImageUrl;
            else if ((int)Session["picNum"] == 5)
                picPath = this.pic1.ImageUrl + ";" + this.pic2.ImageUrl + ";" + this.pic3.ImageUrl + ";" + this.pic4.ImageUrl + ";" + this.pic5.ImageUrl;
            if (picPath != string.Empty)
                news.ContentP = picPath;
             * */
            Session["picNum"] = 0;
            Guid newsID = news.Insert();
            //查找at
            Regex atRegex = new Regex("@[^\x20]* ");
            MatchCollection atSomeone = atRegex.Matches(MeeboToSend);
            UserDB atUserNickName = new UserDB();
            AtDB atDb = new AtDB();
            for (int i = 0; i < atSomeone.Count; i++)
            {
                string atNickname = atSomeone[i].ToString().Replace("@", "");
                atUserNickName.SearchByNickName("atNickname", atNickname);
                atDb.Type = false;
                atDb.UserID = atUserNickName.ID;
                atDb.FromUserID = (Guid)Session["id"];
                atDb.FromID = newsID;
                atDb.Insert();
            }
            Response.Redirect("~/user/PersonalPage.aspx");
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
        praiseDb.NewsUserID = newsDb.UserID;
        praiseDb.Insert();
        Response.Redirect("~/user/PersonalPage.aspx");
    }

    protected void repost_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnNewsID);
        Session["commentType"] = "repost";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void comment_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnNewsID);
        Session["commentType"] = "comment";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void save_Click(object sender, EventArgs e)
    {
        SaveDB saveDb = new SaveDB();
        if(saveDb.isSaved((Guid)Session["id"], new Guid(this.btnNewsID)))
            saveDb.Delete((Guid)Session["id"], new Guid(this.btnNewsID));
        else
        {
            saveDb.UserID = (Guid)Session["id"];
            saveDb.NewsID = new Guid(this.btnNewsID);
            saveDb.Insert();
        }
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/PersonalPage.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnNewsID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
}

