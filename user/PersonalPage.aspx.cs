using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using MeeboDb;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class user_PersonalPage : System.Web.UI.Page
{
    protected NewsDB news;
    protected UserDB user;
    protected void Page_Load(object sender, EventArgs e)
    {
        JObject array = new JObject();
        int num = 0;
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        user = new UserDB();
        user.SearchByName((string)Session["name"], "result");
        DataSet follow = ;
        foreach(DataRow followUser in follow)
        {
            DataSet singlePerson = news.SearchByUserID((Guid)followUser["UID"], "singlePerson");
            foreach(DataRow singleNews in singlePerson)
            {
                JObject singleNewsInfo = new JObject();
                singleNewsInfo.Add(new JProperty("head", (string)followUser["UHeadPortrait"]));
                singleNewsInfo.Add(new JProperty("nickname", (string)followUser["UNickname"]));
                singleNewsInfo.Add(new JProperty("content", (string)singleNews["NContentT"]));
                singleNewsInfo.Add(new JProperty("pictures", (string)singleNews["NContentP"]));
                singleNewsInfo.Add(new JProperty("time", (string)singleNews["NDate"]));
                singleNewsInfo.Add(new JProperty("praise", (string)singleNews["NProNum"]));
                singleNewsInfo.Add(new JProperty("comment", (string)singleNews["NComNum"]));
                singleNewsInfo.Add(new JProperty("repost", (string)singleNews["NTransmitNum"]));
                singleNewsInfo.Add(new JProperty("save", (string)singleNews["NSaveNum"]));
                array.Add(singleNewsInfo);
            }
        }
    }

    protected void SendOut_Click(object sender, EventArgs e)
    {
        string MeeboToSend = this.send_content.Text;
        if (MeeboToSend == string.Empty)
        {

        }
        else
        {
            Regex topicRegex = new Regex("#[^\"]*#");
            news.Topic = topicRegex.Match(MeeboToSend).Value.Replace("#", "");
            Regex atRegex = new Regex("@[^\x20]* ");
            MatchCollection atSomeone = atRegex.Matches(MeeboToSend);
            news.CallNum = atSomeone.Count;
            for (int i = 0; i < atSomeone.Count; i++)
            {
                string atNickname = atSomeone[i].ToString().Replace("@", "");
            }
        }
    }
}