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

public partial class hot_hot : System.Web.UI.Page
{
    protected NewsDB newsDb;
    protected string btnNewsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        newsDb = new NewsDB();
        UserDB user = new UserDB();
        if (IsPostBack)
        {
            btnNewsID = Request.Form["__EVENTARGUMENT"];
        }
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet hotSet = newsDb.SearchOriginalByTime(7, "hotMeebo");
        foreach (DataRow singleNews in hotSet.Tables["hotMeebo"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            user.SearchByID("user", (Guid)singleNews["NUserID"]);
            singleNewsInfo.Add(new JProperty("head", user.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", user.Nickname));
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
            JList.Add(singleNewsInfo);
            num++;
        }
        JArray array = new JArray(
            from item in JList
            orderby (int)item["praise"]+(int)item["comment"]+(int)item["repost"]+(int)item["save"] descending
            select new JObject(item)
            );

        string json = array.ToString();
    }

    protected void zan_Click(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
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
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        Session["commentMeeboID"] = new Guid(this.btnNewsID);
        Session["commentType"] = "repost";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void comment_Click(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        Session["commentMeeboID"] = new Guid(this.btnNewsID);
        Session["commentType"] = "comment";
        Response.Redirect("~/user/MeeBoComment.aspx");
    }

    protected void save_Click(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        SaveDB saveDb = new SaveDB();
        saveDb.UserID = (Guid)Session["id"];
        saveDb.NewsID = new Guid(this.btnNewsID);
        saveDb.Insert();
        NewsDB newsDb = new NewsDB();
        Response.Redirect("~/user/PersonalPage.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
}