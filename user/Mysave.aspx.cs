using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MeeboDb;
using Newtonsoft.Json;

public partial class user_Mysave : System.Web.UI.Page
{
    SaveDB saveDb = new SaveDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
            Response.Redirect("~/Login.aspx");
        DataSet mySave = saveDb.SearchByUserID("result", (Guid)Session["id"]);
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(mySave);
    }
}