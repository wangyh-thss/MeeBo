using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class user_MySave : System.Web.UI.Page
{
    protected SaveDB saveDb;
    protected string btnNewsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        saveDb = new SaveDB();
        UserDB saveUser = new UserDB();
        NewsDB saveNews = new NewsDB();
        UserDB newsUser = new UserDB();
        NewsDB originNewsInfo;
        UserDB originUser;
        if (IsPostBack)
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        DataSet saveSet = saveDb.SearchByUserID("save", (Guid)Session["id"]);
        List<JObject> JList = new List<JObject>();
        int num = 0;
        foreach (DataRow singleSave in saveSet.Tables["save"].Rows)
        {
            saveUser.SearchByID("saveUser", (Guid)singleSave["SUID"]);
            saveNews.SearchByID((Guid)singleSave["SNID"], "saveNews");
            newsUser.SearchByID("newsUser", saveNews.UserID);
            JObject singleNewsInfo = new JObject();
            if (!saveNews.IsTransmit)
            {
                singleNewsInfo.Add(new JProperty("type", "Meebo"));
                singleNewsInfo.Add(new JProperty("head", newsUser.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", newsUser.Nickname));
                singleNewsInfo.Add(new JProperty("userID", newsUser.ID));
                singleNewsInfo.Add(new JProperty("MeeboID", singleSave["SNID"].ToString()));
                singleNewsInfo.Add(new JProperty("content", saveNews.ContentT));
                if (saveNews.ContentP != string.Empty)
                {
                    string[] picUrl = saveNews.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("time", saveNews.Date.ToString()));
                singleNewsInfo.Add(new JProperty("praise", saveNews.ProNum));
                singleNewsInfo.Add(new JProperty("comment", saveNews.ComNum));
                singleNewsInfo.Add(new JProperty("repost", saveNews.TransmitNum));
                singleNewsInfo.Add(new JProperty("save", saveNews.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", true));
                singleNewsInfo.Add(new JProperty("saveTime", singleSave["SDate"]));
            }
            else
            {
                singleNewsInfo.Add(new JProperty("type", "trans"));
                singleNewsInfo.Add(new JProperty("head", newsUser.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", newsUser.Nickname));
                singleNewsInfo.Add(new JProperty("userID", newsUser.ID));
                singleNewsInfo.Add(new JProperty("MeeboID", singleSave["SNID"].ToString()));
                singleNewsInfo.Add(new JProperty("content", saveNews.TransmitInf));
                singleNewsInfo.Add(new JProperty("time", saveNews.Date.ToString()));
                singleNewsInfo.Add(new JProperty("praise", saveNews.ProNum));
                singleNewsInfo.Add(new JProperty("comment", saveNews.ComNum));
                singleNewsInfo.Add(new JProperty("repost", saveNews.TransmitNum));
                singleNewsInfo.Add(new JProperty("save", saveNews.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", true));
                originNewsInfo = new NewsDB();
                originNewsInfo.SearchByID(saveNews.From, "originNews");
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
                singleNewsInfo.Add(new JProperty("originTime", originNewsInfo.Date));
                singleNewsInfo.Add(new JProperty("saveTime", singleSave["SDate"]));

            }
            JList.Add(singleNewsInfo);
            num++;
        }
         JArray array = new JArray(
                from item in JList
                orderby item["saveTime"] descending
                select new JObject(item)
                );
            
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getMeeBo(" + json + ")", true);
        UserDB user = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
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
        Response.Redirect("~/user/Mysave.aspx");
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
        if (saveDb.isSaved((Guid)Session["id"], new Guid(this.btnNewsID)))
            saveDb.Delete((Guid)Session["id"], new Guid(this.btnNewsID));
        else
        {
            saveDb.UserID = (Guid)Session["id"];
            saveDb.NewsID = new Guid(this.btnNewsID);
            saveDb.Insert();
        }
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/Mysave.aspx");
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