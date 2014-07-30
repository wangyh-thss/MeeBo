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
    /// SenINfoDB 的摘要说明
    /// </summary>
    public class SenINfoDB
    {
        public SenINfoDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public string SenInfo {get;set;}
        public Guid SenInfoID { get; set; }

        DataBase data = new DataBase();

        public void Insert()
        {
            if (!ifIN(SenInfo))
            {
                DataSet ds = data.GetData("select * from [User] ", "thisSenInfo");
                DataRow row = ds.Tables["thisUser"].NewRow();
                row["SenInfoID"] = Guid.NewGuid();
                row["SenInfo"] = SenInfo;
                ds.Tables["thisSenInfo"].Rows.Add(row);
                data.UpdateData("select * from [SenInfo] ", ds, "thisSenInfo");
            }
        }

        public bool ifIN(string MySenInfo)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SenInfo",  SqlDbType.VarChar, 50,MySenInfo),
			};
            DataSet ds = data.GetData("select * from [SenInfo] where SenInfo = @SenInfo", prams, "thisSenInfo");
            return (ds.Tables["thisSenInfo"].Rows.Count > 0);
        }

        public void delete(string MySenInfo)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@SenInfo",  SqlDbType.VarChar, 50,MySenInfo),
			};
            DataSet ds = data.GetData("select * from [SenInfo] where SenInfo = @SenInfo", prams, "thisSenInfo");
            if (ds.Tables["thisSenInfo"].Rows.Count == 1)
            {
                ds.Tables["thisSenInfo"].Rows[0].Delete();
            }
            data.UpdateData("select * from [SenInfo]", ds, "thisUser");
        }

        public DataSet GetAll(string tbName)
        {
            return (data.GetData("select * from [SenInfo]", tbName));
        }
    }
}