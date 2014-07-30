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

public partial class SearchPage_SearchUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        UserDB userDb = new UserDB();
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet userSet = userDb.SearchMoreByNickName("user", (string)Session["searchWord"]);
        foreach (DataRow singleUser in userSet.Tables["user"].Rows)
        {
            JObject singleUserInfo = new JObject();
            userDb.SearchByID("singleUser", (Guid)singleUser["UID"]);
            singleUserInfo.Add(new JProperty("head", userDb.HeadPortrait.Replace("~", "..")));
            singleUserInfo.Add(new JProperty("nickname", userDb.Nickname));
            singleUserInfo.Add(new JProperty("followNum", userDb.LikesNum));
            singleUserInfo.Add(new JProperty("fansNum", userDb.FansNum));
            singleUserInfo.Add(new JProperty("MeeboNum", userDb.NewsNum));
            singleUserInfo.Add(new JProperty("gender", userDb.Gender));  //0(false)女 1(true)男
            singleUserInfo.Add(new JProperty("birthday", userDb.Birthday));
            JList.Add(singleUserInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby item["nickname"].ToString().Length descending
                select new JObject(item)
                );

        string json = array.ToString();
    }
}