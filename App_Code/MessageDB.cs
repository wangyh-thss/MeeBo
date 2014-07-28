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
    /// MessageDB 的摘要说明
    /// </summary>
    public class MessageDB
    {
        public MessageDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid FromID { get; set; }
        public Guid ToID { get; set; }
        public Boolean isCheck { get; set; }

        DataBase data = new DataBase();

        UserDB thisUser = new UserDB();
        public int SearchNumber;

        // 发布私信
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Message] ", "thisMessage");
            DataRow row = ds.Tables["thisMessage"].NewRow();
            ID = Guid.NewGuid();
            row["MID"] = ID;
            row["MContent"] = Content;
            Date = DateTime.Now;
            row["MDate"] = Date;
            row["MFromUID"] = FromID;
            row["MToUID"] = ToID;
            ds.Tables["thisMessage"].Rows.Add(row);
            data.UpdateData("select * from [Message] ", ds, "thisMessage");
            thisUser.ChangeMsgInNum(ToID, 1);
            thisUser.ChangeMsgOutNum(FromID, 1);
            return ID;
        }

        //删除私信
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@MID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Message] where MID = @MID", prams, "thisMessage");
            if (ds.Tables["thisMessage"].Rows.Count > 0)
            {
                thisUser.ChangeMsgInNum(new Guid(ds.Tables["thisMessage"].Rows[0]["MToUID"].ToString()), -1);
                thisUser.ChangeMsgOutNum(new Guid(ds.Tables["thisMessage"].Rows[0]["MFromUID"].ToString()), -1);
            }
        }

        //按ID搜索私信
        public DataSet SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@MID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [Message] where MID = @MID", prams, tbName);
            ID = myID;
            SearchNumber = ds.Tables[tbName].Rows.Count;
            if (ds.Tables[tbName].Rows.Count == 1)
            {
                Content = ds.Tables[tbName].Rows[0]["MContent"].ToString();
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["MDate"].ToString()).Date;
                FromID = new Guid(ds.Tables[tbName].Rows[0]["MFromUID"].ToString());
                ToID = new Guid(ds.Tables[tbName].Rows[0]["MToUID"].ToString());
                isCheck = (ds.Tables[tbName].Rows[0]["MCheck"].ToString() == "True");
            }
            return ds;
        }

        //按用户ID搜索他发出的私信
        public DataSet SearchByFromID(Guid myFromID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@MFromUID",  SqlDbType.UniqueIdentifier, 16 ,myFromID),
			};
            DataSet ds = data.GetData("select * from [Message] where MFromUID = @MFromUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //按用户ID搜索他收到的私信
        public DataSet SearchByToID(Guid myToID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@MToUID",  SqlDbType.UniqueIdentifier, 16 ,myToID),
			};
            DataSet ds = data.GetData("select * from [Message] where MToUID = @MToUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //将用户的未查看全部设为查看
        public void clearUncheck(Guid myToID)
        {
            SqlParameter[] prams = 
            {
			     data.MakeInParam("@MToUID",  SqlDbType.UniqueIdentifier, 16 ,myToID),
                data.MakeInParam("@MCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Message] where (MToUID = @MToUID) AND (MCheck = @MCheck)", prams, "thisMessage");
            foreach (DataRow CommentRow in ds.Tables["thisMessage"].Rows)
            {
                CommentRow["MCheck"] = 1;
            }
            data.UpdateData("select * from [Message] where (MToUID = @MToUID) AND (MCheck = @MCheck)", prams, ds, "thisMessage");
        }

        //用户是否有未查看
        public Boolean haveUncheck(Guid myToID)
        {
            SqlParameter[] prams = 
            {
			     data.MakeInParam("@MToUID",  SqlDbType.UniqueIdentifier, 16 ,myToID),
                data.MakeInParam("@MCheck",SqlDbType.Bit,1,false),
			};
            DataSet ds = data.GetData("select * from [Message] where (MToUID = @MToUID) AND (MCheck = @MCheck)", prams, "thisMessage");
            return (ds.Tables["thisMessage"].Rows.Count > 0);
        }
    }

}