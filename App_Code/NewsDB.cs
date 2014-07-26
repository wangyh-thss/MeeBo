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
    /// NewsDB 的摘要说明
    /// </summary>
    public class NewsDB
    {
        public NewsDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Guid ID { get; set; }
        public string ContentT { get; set; }
        public string ContentP { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public Guid UserID { get; set; }
        public int ProNum { get; set; }
        public int ComNum { get; set; }
        public int SaveNum { get; set; }
        public Boolean Delete {get;set;}
        public Guid DeleteUser {get;set;}
        public int CallNum { get; set; }
        public Guid From { get; set; }
        public string TransmitInf { get; set; }
        public int TransmitNum { get; set; }
        public string Visible { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;

        //修改收藏数
        public void ChangeSaveNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select NID,NSaveNum from [News] where NID = @NID", prams, "thisNews");
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ds.Tables["thisNews"].Rows[0]["NSaveNum"] = (int)ds.Tables["thisNews"].Rows[0]["NSaveNum"] + num;
            }
            data.UpdateData("select NID,NSaveNum from [News] where NID = @NID", prams, ds, "thisNews");
        }
    }
}