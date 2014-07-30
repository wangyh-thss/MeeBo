﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MeeboDb;

public partial class user_MyLikes : System.Web.UI.Page
{
    protected UserDB user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        user = new UserDB();
        UserDB starUser = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);
        List<JObject> JList = new List<JObject>();
        LikeDB likeDb = new LikeDB();
        DataSet followSet = likeDb.SearchByFanID("follow", user.ID);
        foreach (DataRow singleFollow in followSet.Tables["follow"].Rows)
        {
            JObject singleUserInfo = new JObject();
            starUser.SearchByID("starUser", (Guid)singleFollow["LStarUID"]);
            singleUserInfo.Add(new JProperty("head", starUser.HeadPortrait.Replace("~", "..")));
            singleUserInfo.Add(new JProperty("nickname", starUser.Nickname));
            singleUserInfo.Add(new JProperty("userID", starUser.ID));
            singleUserInfo.Add(new JProperty("fansNum", starUser.FansNum));
            singleUserInfo.Add(new JProperty("likesNum", starUser.LikesNum));
            singleUserInfo.Add(new JProperty("newsNum", starUser.NewsNum));
            singleUserInfo.Add(new JProperty("birthday", starUser.Birthday));
            singleUserInfo.Add(new JProperty("gender", starUser.Gender));
            JList.Add(singleUserInfo);
        }
        JArray array = new JArray(
            from item in JList
            select new JObject(item)
            );
        string json = array.ToString();
    }
}