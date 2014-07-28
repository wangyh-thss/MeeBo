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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        newsDb = new NewsDB();
        UserDB user = new UserDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet newsSet = newsDb.SearchUnDeleteByUserID((Guid)Session["id"], "news");
        user.SearchByID("user", (Guid)Session["id"]);
        foreach (DataRow singleNews in newsSet.Tables["news"].Rows)
        {
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", user.HeadPortrait));
            singleNewsInfo.Add(new JProperty("nickname", user.Nickname));
            singleNewsInfo.Add(new JProperty("MeeboID", singleNews["NID"]));
            singleNewsInfo.Add(new JProperty("content", singleNews["NContentT"]));
            singleNewsInfo.Add(new JProperty("pictures", singleNews["NContentP"]));
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
                orderby item["time"]
                select new JObject(item)
                );
        string json = array.ToString();
    }
}