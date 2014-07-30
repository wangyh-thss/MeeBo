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
    protected string btnID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        if (IsPostBack)
        {
            btnID = Request.Form["__EVENTARGUMENT"];
        }
        else
            this.search_content.Text = (string)Session["searchWord"];
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
            singleUserInfo.Add(new JProperty("userID", userDb.ID));
            singleUserInfo.Add(new JProperty("likesNum", userDb.LikesNum));
            singleUserInfo.Add(new JProperty("fansNum", userDb.FansNum));
            singleUserInfo.Add(new JProperty("newsNum", userDb.NewsNum));
            singleUserInfo.Add(new JProperty("gender", userDb.Gender));  //0(false)女 1(true)男
            singleUserInfo.Add(new JProperty("birthday", userDb.Birthday.ToLongDateString().ToString()));
            JList.Add(singleUserInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                orderby item["nickname"].ToString().Length descending
                select new JObject(item)
                );

        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getUsers(" + json + ")", true);
    }

    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnID);
        Response.Redirect("~/user/OthersPage.aspx");
    }
    protected void go_search_Click(object sender, EventArgs e)
    {
        Session["searchWord"] = this.search_content.Text;
        Response.Redirect("~/SearchPage/SearchUser.aspx");
    }
}