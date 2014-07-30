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
        public DateTime Date { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;
        UserDB thisUser = new UserDB();
        NewsDB thisNews = new NewsDB();

        //添加一个赞
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Praise]", "thisPraise");
            DataRow row = ds.Tables["thisPraise"].NewRow();
            ID = Guid.NewGuid();
            row["PID"] = ID;
            row["PUID"] = UserID;
            row["PNID"] = NewsID;
            row["PNUID"] = NewsUserID;
            Date = DateTime.Now;
            row["PDate"] = Date;
            ds.Tables["thisPraise"].Rows.Add(row);
            thisNews.ChangeProNum(NewsID, 1);
            data.UpdateData("select * from [Praise] ", ds, "thisPraise");
            return ID;
        }

        //删除一个赞
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PID = @PID", prams, "thisPraise");
            if (ds.Tables["thisPraise"].Rows.Count == 1)
            {
                thisNews.ChangeProNum(new Guid(ds.Tables["thisPraise"].Rows[0]["PNID"].ToString()), -1);
                ds.Tables["thisPraise"].Rows[0].Delete(); ;
            }
            data.UpdateData("select * from [Praise] where PID = @PID", prams, ds, "thisPraise");
        }

        //删除一个赞
        public void Delete(Guid thisUserID, Guid thisNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PUID",SqlDbType.UniqueIdentifier,16,thisUserID),
                data.MakeInParam("@PNID",SqlDbType.UniqueIdentifier,16,thisNewsID),
			};
            DataSet ds = data.GetData("select * from [Praise] where (PUID = @PUID) AND (PNID = @PNID)", prams, "thisPraise");
            if (ds.Tables["thisPraise"].Rows.Count == 1)
            {
                thisNews.ChangeProNum(thisNewsID, -1);
                ds.Tables["thisPraise"].Clear();
            }
            data.UpdateData("select * from [Praise] where (PUID = @PUID) AND (PNID = @PNID)", prams, ds, "thisPraise");
        }

        //删除一个用户的所有赞
        public void DeleteByUser(Guid thisUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PUID",SqlDbType.UniqueIdentifier,16,thisUserID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PUID = @PUID", prams, "thisPraise");
            foreach (DataRow PraiseRow in ds.Tables["thisPraise"].Rows)
            {
                thisNews.ChangeProNum(new Guid(PraiseRow["PUID"].ToString()), -1);
            }
            ds.Tables["thisPraise"].Clear();
            data.UpdateData("select * from [Praise] where PUID = @PUID", prams, ds, "thisPraise");
        }

        //删除一个MeeBo的所有赞
        public void DeleteByNews(Guid thisNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PNID",SqlDbType.UniqueIdentifier,16,thisNewsID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PNID = @PNID", prams, "thisPraise");
            thisNews.ChangeProNum(thisNewsID, -ds.Tables["thisPraise"].Rows.Count);
            ds.Tables["thisPraise"].Clear();
            data.UpdateData("select * from [Praise] where PNID = @PNID", prams, ds, "thisPraise");
        }

        //搜索某条赞
        public DataSet SearchByID(string tbName, Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PID = @PID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            ID = myID;
            if (ds.Tables[tbName].Rows.Count > 0)
            {
                UserID = new Guid(ds.Tables[tbName].Rows[0]["PUID"].ToString());
                NewsID = new Guid(ds.Tables[tbName].Rows[0]["PNID"].ToString());
                isCheck = ((ds.Tables[tbName].Rows[0]["PCheck"].ToString() == "True"));
                NewsUserID = new Guid(ds.Tables[tbName].Rows[0]["PNUID"].ToString());
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["PDate"].ToString()).Date;
            }
            return ds;
        }

        //搜索某用户的所有赞
        public DataSet SearchByUserID(string tbName, Guid myNewsUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PNUID",SqlDbType.UniqueIdentifier,16,myNewsUserID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PNUID = @PNUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某用户的所有未被查看过的赞
        public DataSet SearchUnCheckByUserID(string tbName, Guid myNewsUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PNUID",SqlDbType.UniqueIdentifier,16,myNewsUserID),
                data.MakeInParam("@PCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Praise] where (PNUID = @PNUID) AND (PCheck = @PCheck)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某条MeeBo的所有赞
        public DataSet SearchByNewsID(string tbName, Guid myNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PNID",SqlDbType.UniqueIdentifier,16,myNewsID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PNID = @PNID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //判断某用户是否赞了某MeeBo
        public Boolean isPraise(Guid myUserID, Guid myNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PUID",SqlDbType.UniqueIdentifier,16,myUserID),
                data.MakeInParam("@PNID",SqlDbType.UniqueIdentifier,16,myNewsID),
			};
            DataSet ds = data.GetData("select * from [Praise] where (PUID = @PUID) AND (PNID = @PNID)", prams, "thisPraise");
            return (ds.Tables["thisPraise"].Rows.Count > 0);
        }

        //被赞用户查看过这条赞
        public void checkPraise(Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [Praise] where PID = @PID", prams, "thisPraise");
            if (ds.Tables["thisPraise"].Rows.Count == 1)
            {
                ds.Tables["thisPraise"].Rows[0]["PCheck"] = 1;
                data.UpdateData("select * from [Praise] where PID = @PID", prams, ds, "thisPraise");
            }
        }

        //被赞用户查看过这条赞
        public void checkPraise(Guid myUserID, Guid myNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PUID",SqlDbType.UniqueIdentifier,16,myUserID),
                data.MakeInParam("@PNID",SqlDbType.UniqueIdentifier,16,myNewsID),
			};
            DataSet ds = data.GetData("select * from [Praise] where (PUID = @PUID) AND (PNID = @PNID)", prams, "thisPraise");
            if (ds.Tables["thisPraise"].Rows.Count == 1)
            {
                ds.Tables["thisPraise"].Rows[0]["PCheck"] = 1;
                data.UpdateData("select * from [Praise] where (PUID = @PUID) AND (PNID = @PNID)", prams, ds, "thisPraise");
            }
        }

        //将用户的未查看全部设为查看
        public void clearUncheck(Guid myNewsUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PNUID",SqlDbType.UniqueIdentifier,16,myNewsUserID),
                data.MakeInParam("@PCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Praise] where (PNUID = @PNUID) AND (PCheck = @PCheck)", prams, "thisPraise");
            foreach (DataRow PraiseRow in ds.Tables["thisPraise"].Rows)
            {
                PraiseRow["PCheck"] = 1;
            }
            data.UpdateData("select * from [Praise] where (PNUID = @PNUID) AND (PCheck = @PCheck)", prams, ds, "thisPraise");
        }

        //用户是否有未查看
        public Boolean haveUncheck(Guid myNewsUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@PNUID",SqlDbType.UniqueIdentifier,16,myNewsUserID),
                data.MakeInParam("@PCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Praise] where (PNUID = @PNUID) AND (PCheck = @PCheck)", prams, "thisPraise");
            return (ds.Tables["thisPraise"].Rows.Count > 0);
        }

    }
}