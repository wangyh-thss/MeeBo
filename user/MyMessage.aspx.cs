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

public partial class user_MyMessage : System.Web.UI.Page
{
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if(IsPostBack)
            this.btnID = Request.Form["__EVENTARGUMENT"];
        if (Session["msgTarget"] != null)
        {
            UserDB targetUser = new UserDB();
            targetUser.SearchByID("user", (Guid)Session["msgTarget"]);
            this.send_target.Text = targetUser.Nickname;
            Session.Remove("msgTarget");
        }
        MessageDB msgDb = new MessageDB();
        UserDB msgUser = new UserDB();
        DataSet msgSet = msgDb.SearchNewByToID((Guid)Session["id"], "newMsg");
        List<JObject> JList = new List<JObject>();
        CommentDB uncheckCom = new CommentDB();
        AtDB uncheckAt = new AtDB();
        PraiseDB uncheckZan = new PraiseDB();
        MessageDB uncheckMsg = new MessageDB();
        foreach (DataRow singleMsg in msgSet.Tables["newMsg"].Rows)
        {
            JObject singleMsgInfo = new JObject();
            msgUser.SearchByID("msgUser", (Guid)singleMsg["MFromUID"]);
            singleMsgInfo.Add(new JProperty("head", msgUser.HeadPortrait.Replace("~", "..")));
            singleMsgInfo.Add(new JProperty("nickname", msgUser.Nickname));
            singleMsgInfo.Add(new JProperty("userID", msgUser.ID));
            singleMsgInfo.Add(new JProperty("content", singleMsg["MContent"]));
            singleMsgInfo.Add(new JProperty("time", singleMsg["MDate"].ToString()));
            JList.Add(singleMsgInfo);
        }
        JArray array = new JArray(
                from item in JList
                orderby Convert.ToDateTime(item["time"]) descending
                select new JObject(item)
                );
        string json = array.ToString();
        msgDb.clearUncheck((Guid)Session["id"]);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "pageLoad(" + json + ");judgeNewMsg('" + uncheckCom.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckAt.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckZan.haveUncheck((Guid)Session["id"]).ToString() + "', '" + uncheckMsg.haveUncheck((Guid)Session["id"]).ToString() + "')", true);
        UserDB user = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
       
    }


    protected void send_out_Click(object sender, EventArgs e)
    {
        MessageDB msgDb = new MessageDB();
        UserDB toUser = new UserDB();
        toUser.SearchByNickName("toUser", this.send_target.Text);
        if(toUser.SearchNumber == 0)
        {
            Response.Write("<script>alert('用户昵称不存在');</script>");
            return;
        }
        msgDb.ToID = toUser.ID;
        msgDb.FromID = (Guid)Session["id"];
        msgDb.Content = this.send_content.Text;
        msgDb.Insert();
        Session["seeMeeboID"] = toUser.ID;
        Response.Redirect("~/user/See_MeeBo.aspx");
    }
    protected void See_Message_Click(object sender, EventArgs e)
    {
        Session["seeMeeboID"] = new Guid(this.btnID);
        Response.Redirect("~/user/See_MeeBo.aspx");
    }
    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
    protected void see_detail_btn_Click(object sender, EventArgs e)
    {
        Session["seeMeeboID"] = new Guid(this.btnID);
        Response.Redirect("~/user/See_MeeBo.aspx");
    }

    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
}