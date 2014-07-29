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

public partial class user_AtMe : System.Web.UI.Page
{
    protected AtDB atDb;
    protected UserDB userDb;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        atDb = new AtDB();
        userDb = new UserDB();
        NewsDB newsDb = new NewsDB();
        CommentDB commentDb = new CommentDB();
        UserDB atUser = new UserDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        userDb.SearchByName((string)Session["name"], "result");
        DataSet atNewsSet = atDb.SearchByUserID("atResult", (Guid)Session["id"]);
        foreach (DataRow singleAt in atNewsSet.Tables["atResult"].Rows)
        {
            if (singleAt["AType"].ToString() == "false")    //MeeBo
            {
                newsDb.SearchByID((Guid)singleAt["AFID"], "news");
                atUser.SearchByID("atUser", newsDb.UserID);
                JObject singleNewsInfo = new JObject();
                singleNewsInfo.Add(new JProperty("head", atUser.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", atUser.Nickname));
                singleNewsInfo.Add(new JProperty("type", "MeeBo"));
                singleNewsInfo.Add(new JProperty("MeeboID", (string)singleAt["AFID"]));
                singleNewsInfo.Add(new JProperty("content", newsDb.ContentT));
                singleNewsInfo.Add(new JProperty("pictures", newsDb.ContentP));
                singleNewsInfo.Add(new JProperty("time", singleAt["ADate"].ToString()));
                singleNewsInfo.Add(new JProperty("praise", newsDb.ProNum));
                singleNewsInfo.Add(new JProperty("comment", newsDb.ComNum));
                singleNewsInfo.Add(new JProperty("repost", newsDb.TransmitNum));
                singleNewsInfo.Add(new JProperty("save", newsDb.SaveNum));
                JList.Add(singleNewsInfo);
                num++;
            }
            else
            {
                commentDb.SearchByID((Guid)singleAt["AFID"], "comment");
                atUser.SearchByID("atUser", commentDb.UserID);
                JObject singleNewsInfo = new JObject();
                singleNewsInfo.Add(new JProperty("head", atUser.HeadPortrait.Replace("~", "..")));
                singleNewsInfo.Add(new JProperty("nickname", atUser.Nickname));
                singleNewsInfo.Add(new JProperty("type", "Comment"));
                singleNewsInfo.Add(new JProperty("CommentID", (string)singleAt["AFID"]));
                singleNewsInfo.Add(new JProperty("content", commentDb.Content));
                singleNewsInfo.Add(new JProperty("time", singleAt["ADate"].ToString()));
                JList.Add(singleNewsInfo);
                num++;
            }
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
        string json = array.ToString();
        atDb.clearUncheck((Guid)Session["id"]);
    }
}