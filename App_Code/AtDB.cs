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
    /// AtDB 的摘要说明
    /// </summary>
    public class AtDB
    {
        public AtDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public Guid ID { get; set; }
        public Boolean Type { get; set; }//0代表MeeBo，1代表评论
        public Guid UserID { get; set; }//被@人的ID
        public Guid FromID { get; set; }
        public Boolean isCheck { get; set; }
        public Guid FromUserID { get; set; }//@者的ID
        public DateTime Date { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;
        UserDB thisUser = new UserDB();
        NewsDB thisNews = new NewsDB();
        CommentDB thisComment = new CommentDB();

        //添加一个@
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [At]", "thisAt");
            DataRow row = ds.Tables["thisAt"].NewRow();
            ID = Guid.NewGuid();
            row["AID"] = ID;
            row["AUID"] = UserID;
            row["AType"] = Type;
            row["AFID"] = FromID;
            row["AFUID"] = FromUserID;
            Date = DateTime.Now;
            row["ADate"] = Date;
            ds.Tables["thisAt"].Rows.Add(row);
            data.UpdateData("select * from [At] ", ds, "thisAt");
            return ID;
        }

        //删除一个@
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [At] where AID = @AID", prams, "thisAt");
            if (ds.Tables["thisAt"].Rows.Count == 1)
            {
                ds.Tables["thisAt"].Clear();
            }
            data.UpdateData("select * from [At] where AID = @AID", prams, ds, "thisAt");
        }

        //删除一个用户的所有被@
        public void DeleteByUser(Guid thisUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AUID",SqlDbType.UniqueIdentifier,16,thisUserID),
			};
            DataSet ds = data.GetData("select * from [At] where AUID = @AUID", prams, "thisAt");
            foreach (DataRow AtRow in ds.Tables["thisAt"].Rows)
            {
                thisNews.ChangeProNum(new Guid(AtRow["AUID"].ToString()), -1);
            }
            ds.Tables["thisAt"].Clear();
            data.UpdateData("select * from [At] where AUID = @AUID", prams, ds, "thisAt");
        }

        //删除一个MeeBo中的所有@
        public void DeleteByNews(Guid thisNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AFID",SqlDbType.UniqueIdentifier,16,thisNewsID),
                data.MakeInParam("@AType",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [At] where (AFID = @AFID) AND (AType = @AType)", prams, "thisAt");
            thisNews.ChangeProNum(thisNewsID, -ds.Tables["thisAt"].Rows.Count);
            ds.Tables["thisAt"].Clear();
            data.UpdateData("select * from [At] where (AFID = @AFID) AND (AType = @AType)", prams, ds, "thisAt");
        }

        //删除一个评论中的所有@
        public void DeleteByComment(Guid thisCommentID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AFID",SqlDbType.UniqueIdentifier,16,thisCommentID),
                data.MakeInParam("@AType",SqlDbType.Bit,1,true),
			};
            DataSet ds = data.GetData("select * from [At] where (AFID = @AFID) AND (AType = @AType)", prams, "thisAt");
            ds.Tables["thisAt"].Clear();
            data.UpdateData("select * from [At] where (AFID = @AFID) AND (AType = @AType)", prams, ds, "thisAt");
        }

        //删除一个用户中的所有@
        public void DeleteByFromUser(Guid thisFromUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AFUID",SqlDbType.UniqueIdentifier,16,thisFromUserID),
			};
            DataSet ds = data.GetData("select * from [At] where AFUID = @AFUID", prams, "thisAt");
            ds.Tables["thisAt"].Clear();
            data.UpdateData("select * from [At] where AFUID = @AFUID", prams, ds, "thisAt");
        }

        //搜索某条@
        public DataSet SearchByID(string tbName, Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [At] where AID = @AID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            ID = myID;
            if (ds.Tables[tbName].Rows.Count > 0)
            {
                UserID = new Guid(ds.Tables[tbName].Rows[0]["AUID"].ToString());
                FromID = new Guid(ds.Tables[tbName].Rows[0]["AFID"].ToString());
                Type = ((ds.Tables[tbName].Rows[0]["AType"].ToString() == "True"));
                isCheck = ((ds.Tables[tbName].Rows[0]["ACheck"].ToString() == "True"));
                FromUserID = new Guid(ds.Tables[tbName].Rows[0]["AFUID"].ToString());
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["ADate"].ToString()).Date;
            }
            return ds;
        }

        //搜索某用户的所有被@
        public DataSet SearchByUserID(string tbName, Guid myUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AUID",SqlDbType.UniqueIdentifier,16,myUserID),
			};
            DataSet ds = data.GetData("select * from [At] where AUID = @AUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某用户的所有未被查看过的被@
        public DataSet SearchUnCheckByUserID(string tbName, Guid myUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AUID",SqlDbType.UniqueIdentifier,16,myUserID),
                data.MakeInParam("@ACheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [At] where (AUID = @AUID) AND (ACheck = @ACheck)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某条MeeBo的所有@
        public DataSet SearchByNewsID(string tbName, Guid myNewsID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AFID",SqlDbType.UniqueIdentifier,16,myNewsID),
                data.MakeInParam("@AType",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [At] where (AFID = @AFID) AND (AType = @AType)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某条评论的所有@
        public DataSet SearchByCommentID(string tbName, Guid myCommentID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AFID",SqlDbType.UniqueIdentifier,16,myCommentID),
                data.MakeInParam("@AType",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [At] where (AFID = @AFID) AND (AType = @AType)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //被@用户查看过这条@
        public void checkAt(Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [At] where AID = @AID", prams, "thisAt");
            if (ds.Tables["thisAt"].Rows.Count == 1)
            {
                ds.Tables["thisAt"].Rows[0]["ACheck"] = 1;
                data.UpdateData("select * from [At] where AID = @AID", prams, ds, "thisAt");
            }
        }

        //将用户的未查看全部设为查看
        public void clearUncheck(Guid myUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AUID",SqlDbType.UniqueIdentifier,16,myUserID),
                data.MakeInParam("@ACheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [At] where (AUID = @AUID) AND (ACheck = @ACheck)", prams, "thisAt");
            foreach(DataRow AtRow in ds.Tables["thisAt"].Rows)
            {
                AtRow["ACheck"] = 1;
            }
            data.UpdateData("select * from [At] where (AUID = @AUID) AND (ACheck = @ACheck)", prams, ds, "thisAt");
        }

        //用户是否有未查看
        public Boolean haveUncheck(Guid myUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@AUID",SqlDbType.UniqueIdentifier,16,myUserID),
                data.MakeInParam("@ACheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [At] where (AUID = @AUID) AND (ACheck = @ACheck)", prams, "thisAt");
            return (ds.Tables["thisAt"].Rows.Count > 0);
        }
    }
}