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
    /// InfoDB 的摘要说明
    /// </summary>
    public class InfoDB
    {
        public InfoDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid UserID { get; set; }

        DataBase data = new DataBase();
        public int SearchNumber;

        // 发布公共消息
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Info] ", "thisInfo");
            DataRow row = ds.Tables["thisMessage"].NewRow();
            ID = Guid.NewGuid();
            row["IID"] = ID;
            row["IContent"] = Content;
            Date = DateTime.Now;
            row["IDate"] = Date;
            row["IUID"] = UserID;
            ds.Tables["thisMessage"].Rows.Add(row);
            data.UpdateData("select * from [Info] ", ds, "thisInfo");
            return ID;
        }

        //删除公共消息
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@IID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Info] where IID = @IID", prams, "thisInfo");
            ds.Tables["thisInfo"].Clear();
        }

        //修改公共消息
        public void Modify(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@IID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Info] where IID = @IID", prams, "thisInfo");
            if (ds.Tables["thisInfo"].Rows.Count == 1)
            {
                ds.Tables["thisInfo"].Rows[0]["MContent"] = Content;
                ds.Tables["thisInfo"].Rows[0]["MDate"] = DateTime.Now;
            }
            data.UpdateData("select * from [Comment] where CID = @CID", prams, ds, "thisComment");
        }

        //按ID搜索公共消息
        public DataSet SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@IID",SqlDbType.UniqueIdentifier,16,myID),
			};
            DataSet ds = data.GetData("select * from [Info] where IID = @IID", prams, tbName);
            ID = myID;
            SearchNumber = ds.Tables[tbName].Rows.Count;
            if (ds.Tables[tbName].Rows.Count == 1)
            {
                Content = ds.Tables[tbName].Rows[0]["IContent"].ToString();
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["IDate"].ToString()).Date;
                UserID = new Guid(ds.Tables[tbName].Rows[0]["IUID"].ToString());
            }
            return ds;
        }

        //搜索所有公共消息
        public DataSet SearchAll(string tbName)
        {
            DataSet ds = data.GetData("select * from [Info]",  tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

    }


}