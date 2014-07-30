using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MeeboDb;

public partial class hot_hotTopic : System.Web.UI.Page
{
    protected string btnNewsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        }
        List<JObject> JList = new List<JObject>();
        NewsDB newsDb = new NewsDB();
        DataSet hotSet = newsDb.SearchTopicByTime(7, "hotTopic");
        foreach (DataRow singleTopic in hotSet.Tables["hotTopic"].Rows)
        {
            JObject singleTopicInfo = new JObject();
            singleTopicInfo.Add(new JProperty("topic", singleTopic["NTopic"]));
            singleTopicInfo.Add(new JProperty("newsNum", singleTopic["CountNumber"]));
            singleTopicInfo.Add(new JProperty("praiseNum", singleTopic["NProNum"]));
            singleTopicInfo.Add(new JProperty("comNum", singleTopic["NComNum"]));
            singleTopicInfo.Add(new JProperty("transNum", singleTopic["NTransmitNum"]));
            singleTopicInfo.Add(new JProperty("saveNum", singleTopic["NSaveNum"]));
            JList.Add(singleTopicInfo);
        }
        JArray array = new JArray(
            from item in JList
            orderby ((int)item["newsNum"] * 5) + ((int)item["transNum"] * 3) + ((int)item["comNum"] * 2) + (int)item["praiseNum"] descending
            select new JObject(item)
            );
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getHotTopic(" + json + ")", true);
        UserDB user = new UserDB();
        user.SearchByID("user", (Guid)Session["id"]);
        this.myName.InnerText = user.Nickname;
        this.head_potrait.ImageUrl = user.HeadPortrait;
        this.LikeNum.InnerText = user.LikesNum.ToString();
        this.FansNum.InnerText = user.FansNum.ToString();
        this.MeeBoNum.InnerText = user.NewsNum.ToString();
    }

    protected void searchTopic_btn_Click(object sender, EventArgs e)
    {
        Session["searchWord"] = this.btnNewsID;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
}