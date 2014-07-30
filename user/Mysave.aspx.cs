﻿using System;
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
        if (IsPostBack)
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        DataSet saveSet = saveDb.SearchByUserID("save", (Guid)Session["id"]);
        List<JObject> JList = new List<JObject>();
        int num = 0;
        foreach (DataRow singleSave in saveSet.Tables["save"].Rows)
        {
            saveUser.SearchByID("saveUser", (Guid)singleSave["SUID"]);
            saveNews.SearchByID((Guid)singleSave["SNID"], "saveNews");
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", saveUser.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", saveUser.Nickname));
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
            JList.Add(singleNewsInfo);
            num++;
        }
         JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
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
        saveDb.UserID = (Guid)Session["id"];
        saveDb.NewsID = new Guid(this.btnNewsID);
        saveDb.Insert();
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/Mysave.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
}