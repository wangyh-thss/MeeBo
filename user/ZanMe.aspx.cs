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


public partial class user_ZanMe : System.Web.UI.Page
{
    protected PraiseDB praiseDb;
    protected UserDB user;
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
            this.btnID = Request.Form["__EVENTARGUMENT"];
        praiseDb = new PraiseDB();
        user = new UserDB();
        UserDB zanUser = new UserDB();
        NewsDB zanNews = new NewsDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet praiseSet = praiseDb.SearchByUserID("praise", (Guid)Session["id"]);
        foreach(DataRow singlePraise in praiseSet.Tables["praise"].Rows)
        {
            zanUser.SearchByID("zanUser", (Guid)singlePraise["PUID"]);
            zanNews.SearchByID((Guid)singlePraise["PNID"], "zanNews");
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", zanUser.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", zanUser.Nickname));
            singleNewsInfo.Add(new JProperty("userID", zanUser.ID));
            singleNewsInfo.Add(new JProperty("MeeboID", singlePraise["PNID"]));
            singleNewsInfo.Add(new JProperty("content", zanNews.ContentT));
            singleNewsInfo.Add(new JProperty("pictures", zanNews.ContentP));
            singleNewsInfo.Add(new JProperty("time", singlePraise["PDate"].ToString()));
            singleNewsInfo.Add(new JProperty("praise", zanNews.ProNum));
            singleNewsInfo.Add(new JProperty("comment", zanNews.ComNum));
            singleNewsInfo.Add(new JProperty("repost", zanNews.TransmitNum));
            singleNewsInfo.Add(new JProperty("save", zanNews.SaveNum));
            JList.Add(singleNewsInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
        string json = array.ToString();
        praiseDb.clearUncheck((Guid)Session["id"]);


        user.SearchByID("user", (Guid)Session["id"]);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getZanMe(" + json + ")", true);
    }

    protected void go_user_Click(object sender, EventArgs e)
    {

    }

    protected void go_MeeBo_Click(object sender, EventArgs e)
    {
        Session["commentType"] = "comment";
        Session["commentMeeboID"] = new Guid(this.btnID);
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

}