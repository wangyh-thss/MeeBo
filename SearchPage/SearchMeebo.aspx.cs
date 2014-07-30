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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        NewsDB newsDb = new NewsDB();
        UserDB userDb = new UserDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet newsSet = newsDb.SearchOriginalByContent((string)Session["searchWord"], "news");
        foreach (DataRow singleNews in newsSet.Tables["singlePerson"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            userDb.SearchByID("user", (Guid)singleNews["NUserID"]);
            singleNewsInfo.Add(new JProperty("head", userDb.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", userDb.Nickname));
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
                orderby item["time"] descending
                select new JObject(item)
                );

        string json = array.ToString();
    }
}