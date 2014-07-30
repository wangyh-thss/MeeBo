using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public partial class user_OthersPage : System.Web.UI.Page
{
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if(Session["otherName"] == null)
            this.RegisterClientScriptBlock("E", "<script language=javascript>history.go(-2);</script>");
        if (IsPostBack)
            this.btnID = Request.Form["__EVENTARGUMENT"];

        UserDB targetUser = new UserDB();
        targetUser.SearchByID("user", (Guid)Session["otherName"]);
        this.userHead.ImageUrl = targetUser.HeadPortrait;
        this.user_nickname.InnerText = targetUser.Nickname;
        this.likesNum.InnerText = targetUser.LikesNum.ToString();
        this.fansNum.InnerText = targetUser.FansNum.ToString();
        this.newsNum.InnerText = targetUser.NewsNum.ToString();
        if (targetUser.Gender == false)
            this.gender.InnerText = "女";
        else
            this.gender.InnerText = "男";
        this.birthday.InnerText = targetUser.Birthday.ToLongDateString().ToString();

        NewsDB newsDb = new NewsDB();
        NewsDB newsInfo = new NewsDB();
        NewsDB originNewsInfo = new NewsDB();
        SaveDB saveDb = new SaveDB();
        DataSet newsSet = newsDb.SearchUnDeleteByUserID((Guid)Session["otherName"], "newsSet");
        List<JObject> JList = new List<JObject>();
        foreach (DataRow singleNews in newsSet.Tables["newsSet"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            if (singleNews["NIsTransmit"].ToString() == "False")
            {
                newsInfo.SearchByID((Guid)singleNews["NID"], "news");
                singleNewsInfo.Add(new JProperty("type", "MeeBo"));
                singleNewsInfo.Add(new JProperty("content", newsInfo.ContentT));
                singleNewsInfo.Add(new JProperty("MeeboID", newsInfo.ID));
                if (newsInfo.ContentP != string.Empty)
                {
                    string[] picUrl = newsInfo.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("time", newsInfo.Date));
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
                singleNewsInfo.Add(new JProperty("time", newsInfo.Date));
                singleNewsInfo.Add(new JProperty("praiseNum", newsInfo.ProNum));
                singleNewsInfo.Add(new JProperty("comNum", newsInfo.ComNum));
                singleNewsInfo.Add(new JProperty("transNum", newsInfo.TransmitNum));
                singleNewsInfo.Add(new JProperty("saveNum", newsInfo.SaveNum));
                singleNewsInfo.Add(new JProperty("isSave", saveDb.isSaved((Guid)Session["id"], newsInfo.ID)));
                singleNewsInfo.Add(new JProperty("originUser", originNewsInfo.userNickName));
                singleNewsInfo.Add(new JProperty("originContent", originNewsInfo.ContentT));
                if (originNewsInfo.ContentP != string.Empty)
                {
                    string[] picUrl = originNewsInfo.ContentP.Split(';');
                    singleNewsInfo.Add(new JProperty("originpictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
                }
                singleNewsInfo.Add(new JProperty("originTime", originNewsInfo.Date));
            }
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
        string json = array.ToString();
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getMeebo(" + json + ")", true);
        LikeDB likeDb = new LikeDB();
        if(likeDb.isPraise((Guid)Session["id"], (Guid)Session["otherName"]))
            Page.ClientScript.RegisterStartupScript(this.GetType(), "change", "changeBtnText(true);" + "getMeebo(" + json + ")", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "change", "changeBtnText(false);" + "getMeebo(" + json + ")", true);
        
    }
    protected void like_Click(object sender, EventArgs e)
    {
        LikeDB likeDb = new LikeDB();
        if(likeDb.isPraise((Guid)Session["id"], (Guid)Session["otherName"]))
        {
            likeDb.Delete((Guid)Session["id"], (Guid)Session["otherName"]);
        }
        else
        {
            likeDb.FanID = (Guid)Session["id"];
            likeDb.StarID = (Guid)Session["otherName"];
            likeDb.Insert();
        }
        Response.Redirect("~/user/OthersPage.aspx");
    }
}