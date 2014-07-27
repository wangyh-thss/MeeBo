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
    /// PraiseDB 的摘要说明
    /// </summary>
    public class PraiseDB
    {
        public PraiseDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid NewsID { get; set; }
        public Boolean isCheck { get; set; }
        public Guid NewsUserID { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;
        UserDB thisUser = new UserDB();
        NewsDB thisNews = new NewsDB();

        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Praise]", "thisPraise");
            DataRow row = ds.Tables["thisPraise"].NewRow();
            ID = Guid.NewGuid();
            row["PID"] = ID;
            row["PUID"] = UserID;
            row["PNID"] = NewsID;
            row["PNUID"] = NewsUserID;
            ds.Tables["thisPraise"].Rows.Add(row);
            thisNews.ChangeProNum(NewsID, 1);
            data.UpdateData("select * from [Praise] ", ds, "thisPraise");
            return ID;
        }

        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PID = @PID", prams, "thisPraise");
            if (ds.Tables["thisPraise"].Rows.Count == 1)
            {
                thisUser.ChangeSaveNewsNum(thisID, -1);
                thisNews.ChangeSaveNum(thisID, -1);
                ds.Tables["thisPraise"].Clear();
            }
            data.UpdateData("select * from [Praise] where PID = @PID", prams, ds, "thisPraise");
        }

        public void Delete(Guid thisUserID, Guid thisNewsID)
        {
 
        }

        public void DeleteByUser(Guid UserID)
        {
        }

        public void DeleteByNews(Guid NewsID)
        {
        }

    }
}