using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace MeeboDb
{
    /// <summary>
    /// SaveDB 的摘要说明
    /// </summary>
    public class SaveDB
    {
        public SaveDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid NewsID { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;
        UserDB thisUser = new UserDB();
        NewsDB thisNews = new NewsDB();

        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Save]", "thisSave");
            DataRow row = ds.Tables["thisSave"].NewRow();
            Guid newID = Guid.NewGuid();
            row["SID"] = newID;
            row["SUID"] = UserID;
            row["SNID"] = NewsID;
            ds.Tables["thisUser"].Rows.Add(row);
            data.UpdateData("select * from [Save] ", ds, "thisSave");
            return newID;
        }

        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Save] where SID = @SID", prams, "thisSave");
            //thisUser.ChangeSaveNewsNum(thisID, -1);
            //thisNews.ChangeSaveNum(thisID, -1);
            ds.Tables["thisUser"].Clear();
            data.UpdateData("select * from [Save] where SID = @SID", prams, ds, "thisSave");
            thisUser.ChangeSaveNewsNum(thisID, -1);
        }
    }
}