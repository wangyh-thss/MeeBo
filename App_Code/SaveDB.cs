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
        public DateTime Date { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;
        UserDB thisUser = new UserDB();
        NewsDB thisNews = new NewsDB();

        //添加一条收藏
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Save]", "thisSave");
            DataRow row = ds.Tables["thisSave"].NewRow();
            ID = Guid.NewGuid();
            row["SID"] = ID;
            row["SUID"] = UserID;
            row["SNID"] = NewsID;
            Date = DateTime.Now;
            row["SDate"] = Date;
            ds.Tables["thisSave"].Rows.Add(row);
            thisUser.ChangeSaveNewsNum(UserID, 1);
            thisNews.ChangeSaveNum(NewsID, 1);
            data.UpdateData("select * from [Save] ", ds, "thisSave");
            return ID;
        }

        //删除一条收藏
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Save] where SID = @SID", prams, "thisSave");
            if (ds.Tables["thisSave"].Rows.Count == 1 )
            {
                thisUser.ChangeSaveNewsNum(new Guid(ds.Tables["thisSave"].Rows[0]["SUID"].ToString()), -1);
                thisNews.ChangeSaveNum(new Guid(ds.Tables["thisSave"].Rows[0]["SNID"].ToString()), -1);
                ds.Tables["thisSave"].Clear();
            }
            data.UpdateData("select * from [Save] where SID = @SID", prams, ds, "thisSave");
        }

        //删除一条收藏
        public void Delete(Guid thisUserID, Guid thisNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SUID",SqlDbType.UniqueIdentifier,16,thisUserID),
                data.MakeInParam("@SNID",SqlDbType.UniqueIdentifier,16,thisNewsID),
			};
            DataSet ds = data.GetData("select * from [Save] where (SUID = @SUID) AND (SNID = @SNID)", prams, "thisSave");
            if (ds.Tables["thisSave"].Rows.Count == 1)
            {
                thisUser.ChangeSaveNewsNum(thisUserID, -1);
                thisNews.ChangeSaveNum(thisNewsID, -1);
                ds.Tables["thisSave"].Clear();
            }
            data.UpdateData("select * from [Save] where (SUID = @SUID) AND (SNID = @SNID)", prams, ds, "thisSave");
        }

        //删除某用户的所有收藏
        public void DeleteByUser(Guid thisUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SUID",SqlDbType.UniqueIdentifier,16,thisUserID),
			};
            DataSet ds = data.GetData("select * from [Save] where SUID = @SUID", prams, "thisSave");
            foreach (DataRow SaveRow in ds.Tables["thisSave"].Rows)
            {
                thisNews.ChangeSaveNum(new Guid(SaveRow["SNID"].ToString()), -1);
            }
            thisUser.ChangeSaveNewsNum(thisUserID, -ds.Tables["thisSave"].Rows.Count);
            ds.Tables["thisSave"].Clear();
            data.UpdateData("select * from [Save] where SUID = @SUID", prams, ds, "thisSave");
        }

        //删除某条MeeBo的所有收藏
        public void DeleteByNews(Guid thisNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SNID",SqlDbType.UniqueIdentifier,16,thisNewsID),
			};
            DataSet ds = data.GetData("select * from [Save] where SNID = @SNID", prams, "thisSave");
            foreach (DataRow SaveRow in ds.Tables["thisSave"].Rows)
            {
                thisUser.ChangeSaveNewsNum(new Guid(SaveRow["SUID"].ToString()), -1);
            }
            thisNews.ChangeSaveNum(thisNewsID, -ds.Tables["thisSave"].Rows.Count);
            ds.Tables["thisSave"].Clear();
            data.UpdateData("select * from [Save] where SNID = @SNID", prams, ds, "thisSave");
        }

        //搜索某条收藏
        public DataSet SearchByID(string tbName, Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [Save] where SID = @SID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            ID = myID;
            if (ds.Tables[tbName].Rows.Count > 0)
            {
                UserID = new Guid(ds.Tables[tbName].Rows[0]["SUID"].ToString());
                NewsID = new Guid(ds.Tables[tbName].Rows[0]["SNID"].ToString());
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["SDate"].ToString()).Date;
            }
            return ds;
        }

        //搜索某用户的所有收藏
        public DataSet SearchByUserID(string tbName,Guid myUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SUID",SqlDbType.UniqueIdentifier,16,myUserID),
			};
            DataSet ds = data.GetData("select * from [Save] where SUID = @SUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某条MeeBo的所有收藏
        public DataSet SearchByNewsID(string tbName,Guid myNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SNID",SqlDbType.UniqueIdentifier,16,myNewsID),
			};
            DataSet ds = data.GetData("select * from [Save] where SNID = @SNID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //判断某用户是否收藏了某MeeBo
        public Boolean isSaved(Guid myUserID, Guid myNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SUID",SqlDbType.UniqueIdentifier,16,myUserID),
                data.MakeInParam("@SNID",SqlDbType.UniqueIdentifier,16,myNewsID),
			};
            DataSet ds = data.GetData("select * from [Save] where (SUID = @SUID) AND (SNID = @SNID)", prams, "thisSave");
            return (ds.Tables["thisSave"].Rows.Count > 0);
        }
    }
}