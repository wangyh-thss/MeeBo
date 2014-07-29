using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class user_CommentMe : System.Web.UI.Page
{
    protected CommentDB comDb;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        comDb = new CommentDB();
        UserDB comUser = new UserDB();
        NewsDB comNews = new NewsDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet comSet = comDb.SearchByUserID((Guid)Session["id"], "comment");
        foreach (DataRow singleComment in comSet.Tables["comment"].Rows)
        {
            comUser.SearchByID("comUser", (Guid)singleComment["CUID"]);
            comNews.SearchByID((Guid)singleComment["CUID"], "comNews");
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", comUser.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", comUser.Nickname));
            singleNewsInfo.Add(new JProperty("userID", comUser.ID));
            singleNewsInfo.Add(new JProperty("MeeboID", (string)singleComment["CNID"]));
            singleNewsInfo.Add(new JProperty("MeeboContent", comNews.ContentT));
            singleNewsInfo.Add(new JProperty("commentContent", singleComment["CContent"]));
            singleNewsInfo.Add(new JProperty("time", singleComment["CDate"]));
            
            JList.Add(singleNewsInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
        string json = array.ToString();
        comDb.clearUncheck((Guid)Session["id"]);
    }
}