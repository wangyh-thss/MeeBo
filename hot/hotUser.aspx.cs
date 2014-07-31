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

public partial class hot_hotUser : System.Web.UI.Page
{
    protected UserDB hotUser;
    protected string btnUserID;
    protected void Page_Load(object sender, EventArgs e)
    {
        hotUser = new UserDB();
        if (IsPostBack)
        {
            btnUserID = Request.Form["__EVENTARGUMENT"];
        }
        List<JObject> JList = new List<JObject>();
        int num = 0;
        DataSet hotUserSet = hotUser.Search10ByFansNum("hotUser");
        foreach (DataRow singleUser in hotUserSet.Tables["hotUser"].Rows)
        {
            JObject singleUserInfo = new JObject();
            singleUserInfo.Add(new JProperty("head", singleUser["UHeadPortrait"].ToString().Replace("~", "..")));
            singleUserInfo.Add(new JProperty("nickname", singleUser["UNickname"]));
            singleUserInfo.Add(new JProperty("userID", singleUser["UID"]));
            singleUserInfo.Add(new JProperty("gender", singleUser["UGender"]));
            singleUserInfo.Add(new JProperty("birthday", ((DateTime)singleUser["UBirthday"]).ToLongDateString().ToString()));
            singleUserInfo.Add(new JProperty("fansNum", singleUser["UFansNum"]));
            singleUserInfo.Add(new JProperty("likesNum", singleUser["ULikesNum"]));
            singleUserInfo.Add(new JProperty("newsNum", singleUser["UNewsNum"]));
            JList.Add(singleUserInfo);
            num++;
        }
        JArray array = new JArray(
                from item in JList
                select new JObject(item)
                );
        string json = array.ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "getUsers(" + json + ")", true);
        UserDB user = new UserDB();
        if (Session["id"] != null)
        {
            user.SearchByID("user", (Guid)Session["id"]);
            this.myName.InnerText = user.Nickname;
            this.head_potrait.ImageUrl = user.HeadPortrait;
            this.LikeNum.InnerText = user.LikesNum.ToString();
            this.FansNum.InnerText = user.FansNum.ToString();
            this.MeeBoNum.InnerText = user.NewsNum.ToString();
        }
    }
    protected void go_user_Click(object sender, EventArgs e)
    {
        Session["otherName"] = new Guid(this.btnUserID);
        Response.Redirect("~/user/OthersPage.aspx");
    }

    protected void search_click(object sender, EventArgs e)
    {
        //Response.Cookies.Add(new HttpCookie("SearchWord", this.find_content.Text));
        Session["searchWord"] = this.find_content.Text;
        Response.Redirect("~/SearchPage/SearchMeebo.aspx");
    }
}