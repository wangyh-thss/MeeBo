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

public partial class user_MyMeeBo : System.Web.UI.Page
{
    protected NewsDB newsDb;
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
        {
            btnID = Request.Form["__EVENTARGUMENT"];
        }
        newsDb = new NewsDB();
        UserDB user = new UserDB();
        NewsDB newsInfo = new NewsDB();
        NewsDB originNewsInfo = new NewsDB();
        UserDB originUser = new UserDB();
        SaveDB saveDb = new SaveDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet newsSet = newsDb.SearchUnDeleteByUserID((Guid)Session["id"], "news");
        user.SearchByID("user", (Guid)Session["id"]);
        foreach (DataRow singleNews in newsSet.Tables["news"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            if (singleNews["NIsTransmit"].ToString() == "False")
            {
                newsInfo.SearchByID((Guid)singleNews["NID"], "news");
                singleNewsInfo.Add(new JProperty("type", "Meebo"));
                singleNewsInfo.Add(new JProperty("content", newsInfo.ContentT));
                singleNewsInfo.Add(new JProperty("MeeboID", newsInfo.ID));
                if (newsInfo.ContentP != string.Empty)
                {
                    string[] picUrl = newsInfo.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("time", newsInfo.Date.ToString()));
                singleNewsInfo.Add(new JProperty("praiseNum", newsInfo.ProNum));
                singleNewsInfo.Add(new JProperty("comNum", newsInfo.ComNum));
                singleNewsInfo.Add(new JProperty("transNum", newsInfo.TransmitNum));
                singleNewsInfo.Add(new JProperty("saveNum", newsInfo.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], newsInfo.ID)));
                }
            else
            {
                newsInfo.SearchByID((Guid)singleNews["NID"], "news");
                originNewsInfo.SearchByID(newsInfo.From, "originNews");
                singleNewsInfo.Add(new JProperty("type", "trans"));
                singleNewsInfo.Add(new JProperty("content", newsInfo.TransmitInf));
                singleNewsInfo.Add(new JProperty("MeeboID", newsInfo.ID));
                singleNewsInfo.Add(new JProperty("time", newsInfo.Date.ToString()));
                singleNewsInfo.Add(new JProperty("praiseNum", newsInfo.ProNum));
                singleNewsInfo.Add(new JProperty("comNum", newsInfo.ComNum));
                singleNewsInfo.Add(new JProperty("transNum", newsInfo.TransmitNum));
                singleNewsInfo.Add(new JProperty("saveNum", newsInfo.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], newsInfo.ID)));
                originUser.SearchByID("user", originNewsInfo.UserID);
                singleNewsInfo.Add(new JProperty("originUser", originUser.Nickname));
                singleNewsInfo.Add(new JProperty("originUserID", originUser.ID));
                singleNewsInfo.Add(new JProperty("originContent", originNewsInfo.ContentT));
                if (originNewsInfo.ContentP != string.Empty)
                {
                    string[] picUrl = originNewsInfo.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("originpictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("originTime", originNewsInfo.Date.ToString()));
            }
            JList.Add(singleNewsInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getMeebo(" + json + ")", true);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
    }
    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }

    protected void zan_Click(object sender, EventArgs e)
    {
        PraiseDB praiseDb = new PraiseDB();
        praiseDb.UserID = (Guid)Session["id"];
        praiseDb.NewsID = new Guid(this.btnID);
        praiseDb.isCheck = false;
        NewsDB newsDb = new NewsDB();
        newsDb.SearchByID(new Guid(this.btnID), "result");
        praiseDb.NewsUserID = newsDb.UserID;
        praiseDb.Insert();
        Response.Redirect("~/user/MyMeeBo.aspx");
    }

    protected void repost_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnID);
        Session["commentType"] = "repost";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void comment_Click(object sender, EventArgs e)
    {
        Session["commentMeeboID"] = new Guid(this.btnID);
        Session["commentType"] = "comment";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void save_Click(object sender, EventArgs e)
    {
        SaveDB saveDb = new SaveDB();
        if (saveDb.isSaved((Guid)Session["id"], new Guid(this.btnID)))
            saveDb.Delete((Guid)Session["id"], new Guid(this.btnID));
        else
        {
            saveDb.UserID = (Guid)Session["id"];
            saveDb.NewsID = new Guid(this.btnID);
            saveDb.Insert();
        }
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/MyMeeBo.aspx");
    }

    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
}