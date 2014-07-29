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

public partial class user_MySave : System.Web.UI.Page
{
    protected SaveDB saveDb;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        saveDb = new SaveDB();
        UserDB saveUser = new UserDB();
        NewsDB saveNews = new NewsDB();
        DataSet saveSet = saveDb.SearchByUserID("save", (Guid)Session["id"]);
        List<JObject> JList = new List<JObject>();
        int num = 0;
        foreach (DataRow singleSave in saveSet.Tables["save"].Rows)
        {
            saveUser.SearchByID("saveUser", (Guid)singleSave["SUID"]);
            saveNews.SearchByID((Guid)singleSave["SNID"], "saveNews");
            JObject singleNewsInfo = new JObject();
            singleNewsInfo.Add(new JProperty("head", saveUser.HeadPortrait.Replace("~", "..")));
            singleNewsInfo.Add(new JProperty("nickname", saveUser.Nickname));
            singleNewsInfo.Add(new JProperty("MeeboID", singleSave["SNID"].ToString()));
            singleNewsInfo.Add(new JProperty("content", saveNews.ContentT));
            if (saveNews.ContentP != string.Empty)
            {
                string[] picUrl = saveNews.ContentP.Split(';');
                singleNewsInfo.Add(new JProperty("pictures", new JArray(from url in picUrl select url.Replace("~", ".."))));
            }
            singleNewsInfo.Add(new JProperty("time", saveNews.Date.ToString()));
            singleNewsInfo.Add(new JProperty("praise", saveNews.ProNum));
            singleNewsInfo.Add(new JProperty("comment", saveNews.ComNum));
            singleNewsInfo.Add(new JProperty("repost", saveNews.TransmitNum));
            singleNewsInfo.Add(new JProperty("save", saveNews.SaveNum));
            JList.Add(singleNewsInfo);
            num++;
        }
         JArray array = new JArray(
                from item in JList
                orderby item["time"] descending
                select new JObject(item)
                );
            
        string json = array.ToString();

        //string json = Newtonsoft.Json.JsonConvert.SerializeObject(mySave);
    }
}