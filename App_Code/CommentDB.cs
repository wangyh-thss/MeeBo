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
    /// CommentDB 的摘要说明
    /// </summary>
    public class CommentDB
    {
        public CommentDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid UserID { get; set; }
        public Guid NewsID { get; set; }
        public Guid NewsUserID { get; set; }
        public Boolean isCheck { get; set; }
        DataBase data = new DataBase();

        NewsDB thisNews = new NewsDB();

        public int SearchNumber;

        // 发布评论
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Comment] ", "thisComment");
            DataRow row = ds.Tables["thisComment"].NewRow();
            ID = Guid.NewGuid();
            row["CID"] = ID;
            row["CContent"] = Content;
            Date = DateTime.Now;
            row["CDate"] = Date;
            row["CUID"] = UserID;
            row["CNUID"] = NewsUserID;
            row["CNID"] = NewsID;
            ds.Tables["thisComment"].Rows.Add(row);
            data.UpdateData("select * from [Comment] ", ds, "thisComment");
            thisNews.ChangeComNum(NewsID,1);
            return ID;
        }

        //删除评论
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CID = @CID", prams, "thisComment");
            if (ds.Tables["thisComment"].Rows.Count == 1)
            {
                thisNews.ChangeComNum(new Guid(ds.Tables["thisComment"].Rows[0]["CNID"].ToString()), -1);
                ds.Tables["thisComment"].Rows[0].Delete();
                data.UpdateData("select * from [Comment] where CID = @CID", prams, ds, "thisComment");
            }
        }

        //修改评论
        public void Modify(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CID = @CID", prams, "thisComment");
            if (ds.Tables["thisComment"].Rows.Count == 1)
            {
                ds.Tables["thisComment"].Rows[0]["CContent"] = Content;
                ds.Tables["thisComment"].Rows[0]["CDate"] = DateTime.Now;
            }
            data.UpdateData("select * from [Comment] where CID = @CID", prams, ds, "thisComment");
        }

        //按ID搜索评论
        public DataSet  SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CID",  SqlDbType.UniqueIdentifier, 16 ,myID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CID = @CID", prams, tbName);
            ID = myID;
            SearchNumber = ds.Tables[tbName].Rows.Count;
            if (ds.Tables[tbName].Rows.Count == 1)
            {
                Content = ds.Tables[tbName].Rows[0]["CContent"].ToString();
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["CDate"].ToString()).Date;
                UserID = new Guid(ds.Tables[tbName].Rows[0]["CUID"].ToString());
                NewsID = new Guid(ds.Tables[tbName].Rows[0]["CNID"].ToString());
                NewsUserID = new Guid(ds.Tables[tbName].Rows[0]["CNUID"].ToString());
                isCheck = (ds.Tables[tbName].Rows[0]["CCheck"].ToString() == "True");
            }
            return ds;
        }

        //按用户ID搜索他的被评论
        public DataSet SearchByNewsUserID(Guid myNewsUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CNUID",  SqlDbType.UniqueIdentifier, 16 ,myNewsUserID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CNUID = @CNUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //按用户ID搜索他的未读被评论
        public DataSet SearchUnCheckByNewsUserID(Guid myNewsUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CNUID",  SqlDbType.UniqueIdentifier, 16 ,myNewsUserID),
                data.MakeInParam("@CCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Comment] where (CNUID = @CNUID) AND (CCheck = @CCheck)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某条meebo的所有评论
        public DataSet SearchByNewsID(Guid myNewsID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CNID",  SqlDbType.UniqueIdentifier, 16 ,myNewsID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CNID = @CNID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某用户发的所有评论
        public DataSet SearchByUserID(Guid myUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CUID",  SqlDbType.UniqueIdentifier, 16 ,myUserID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CUID = @CUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //被评论用户查看过这条评论
        public void checkComment(Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [Comment] where CID = @CID", prams, "thisComment");
            if (ds.Tables["thisComment"].Rows.Count == 1)
            {
                ds.Tables["thisComment"].Rows[0]["CCheck"] = 1;
                data.UpdateData("select * from [Comment] where CID = @CID", prams, ds, "thisComment");
            }
        }

        //将用户的未查看全部设为查看
        public void clearUncheck(Guid myNewsUserID)
        {
            SqlParameter[] prams = 
            {
			     data.MakeInParam("@CNUID",  SqlDbType.UniqueIdentifier, 16 ,myNewsUserID),
                data.MakeInParam("@CCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Comment] where (CNUID = @CNUID) AND (CCheck = @CCheck)", prams, "thisComment");
            foreach (DataRow CommentRow in ds.Tables["thisComment"].Rows)
            {
                CommentRow["CCheck"] = 1;
            }
            data.UpdateData("select * from [Comment] where (CNUID = @CNUID) AND (CCheck = @CCheck)", prams, ds, "thisComment");
        }

        //用户是否有未查看
        public Boolean haveUncheck(Guid myNewsUserID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@CNUID",  SqlDbType.UniqueIdentifier, 16 ,myNewsUserID),
                data.MakeInParam("@CCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Comment] where (CNUID = @CNUID) AND (CCheck = @CCheck)", prams, "thisComment");
            return (ds.Tables["thisComment"].Rows.Count > 0);
        }
    }
}
   
