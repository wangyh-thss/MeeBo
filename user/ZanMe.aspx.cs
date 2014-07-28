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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        praiseDb = new PraiseDB();
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
            singleNewsInfo.Add(new JProperty("head", zanUser.HeadPortrait));
            singleNewsInfo.Add(new JProperty("nickname", zanUser.Nickname));
            singleNewsInfo.Add(new JProperty("MeeboID", (string)singlePraise["PNID"]));
            singleNewsInfo.Add(new JProperty("content", zanNews.ContentT));
            singleNewsInfo.Add(new JProperty("pictures", zanNews.ContentP));
            singleNewsInfo.Add(new JProperty("time", singlePraise["PDate"]));
            singleNewsInfo.Add(new JProperty("praise", zanNews.ProNum));
            singleNewsInfo.Add(new JProperty("comment", zanNews.ComNum));
            singleNewsInfo.Add(new JProperty("repost", zanNews.TransmitNum));
            singleNewsInfo.Add(new JProperty("save", zanNews.SaveNum));
            JList.Add(singleNewsInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"]
                select new JObject(item)
                );
        string json = array.ToString();
    }

}