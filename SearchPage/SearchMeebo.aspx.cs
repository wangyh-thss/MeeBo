using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MeeboDb;

public partial class SearchPage_SearchMeebp : System.Web.UI.Page
{
    protected string btnNewsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        else
            this.search_content.Text = (string)Session["searchWord"];
        NewsDB newsDb = new NewsDB();
        UserDB userDb = new UserDB();
        SaveDB saveDb = new SaveDB();
        UserDB originUser;
        NewsDB originNewsInfo;
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet newsSet = newsDb.SearchByContent((string)Session["searchWord"], "news");
        foreach (DataRow singleNews in newsSet.Tables["news"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            userDb.SearchByID("user", (Guid)singleNews["NUserID"]);
            if (singleNews["NIsTransmit"].ToString() == "False")
            {
                singleNewsInfo.Add(new JProperty("type", "Meebo"));
                singleNewsInfo.Add(new JProperty("head", userDb.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", userDb.Nickname));
                singleNewsInfo.Add(new JProperty("userID", userDb.ID));
                singleNewsInfo.Add(new JProperty("MeeboID", singleNews["NID"].ToString()));
                singleNewsInfo.Add(new JProperty("content", singleNews["NContentT"]));
                if (singleNews["NContentP"].ToString() != string.Empty)
                {
                    string[] picUrl = singleNews["NContentP"].ToString().Split(';');
                    singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("time", singleNews["NDate"]));
                singleNewsInfo.Add(new JProperty("praise", singleNews["NProNum"]));
                singleNewsInfo.Add(new JProperty("comment", singleNews["NComNum"]));
                singleNewsInfo.Add(new JProperty("repost", singleNews["NTransmitNum"]));
                singleNewsInfo.Add(new JProperty("save", singleNews["NSaveNum"]));
            }
            else
            {
                singleNewsInfo.Add(new JProperty("type", "trans"));
                singleNewsInfo.Add(new JProperty("head", userDb.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", userDb.Nickname));
                singleNewsInfo.Add(new JProperty("userID", userDb.ID));
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
                singleNewsInfo.Add(new JProperty("originUserID", originUser.ID));
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
        JArray array = new JArray(
                from item in JList
                orderby Convert.ToDateTime(item["time"]) descending
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
        if (saveDb.isSaved((Guid)Session["id"], new Guid(this.btnNewsID)))
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
    protected void go_search_Click(object sender, EventArgs e)
    {
        Session["searchWord"] = this.search_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
}