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
        public Boolean IsDelete { get; set; }
        public Guid DeleteUser { get; set; }
        public int CallNum { get; set;}
        public Boolean IsTransmit { get; set;}
        public Guid From { get; set;}
        public string TransmitInf { get; set; }
        public int TransmitNum { get;set;}
        public string Visible {get; set;}

        DataBase data = new DataBase();

        public int SearchNumber;


        // 发布meebo
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [News] ", "thisNews");
            DataRow row = ds.Tables["thisUser"].NewRow();
            ID = Guid.NewGuid();
            row["NID"] = ID;
            if (ContentT != null)
            {
                row["NContentT"] = ContentT;
            }
            if (ContentP != null)
            {
                row["NContentP"] = ContentP;
            }
            if (Topic != null)
            {
                row["NTopic"] = Topic;
            }
            row["NDate"] = DateTime.Now;
            row["NUserID"] = UserID;
            row["NDeleteUser"] = UserID;
            if (CallNum != null)
            {
                row["NCallNum"] = CallNum;
            }
            row["NFrom"] = ID;
            if(Visible != null)
            {
                row["NVisible"] = Visible;
            }
            ds.Tables["thisNews"].Rows.Add(row);
            data.UpdateData("select * from [News] ", ds, "thisNews");
            return ID;
        }

        //删除meebo
        public void Delete(Guid thisID)
        {

        }

        //修改meebo
        public void Modify(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [News] where NID = @NID", prams, "thisNews");
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ds.Tables["thisNews"].Rows[0]["NContentT"] = ContentT;
                ds.Tables["thisNews"].Rows[0]["NContentP"] = ContentP;
                ds.Tables["thisNews"].Rows[0]["NTopic"] = Topic;
                ds.Tables["thisNews"].Rows[0]["NDate"] = DateTime.Now;
                ds.Tables["thisNews"].Rows[0]["NCallNum"] = CallNum;
                ds.Tables["thisNews"].Rows[0]["NVisible"] = Visible;
            }
            data.UpdateData("select * from [News] where NID = @NID", prams, ds, "thisNews");
        }

        //修改点赞数
        public void ChangeProNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select NID,NProNum from [News] where NID = @NID", prams, "thisNews");
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ds.Tables["thisNews"].Rows[0]["NProNum"] = (int)ds.Tables["thisNews"].Rows[0]["NProNum"] + num;
            }
            data.UpdateData("select NID,NProNum from [News] where NID = @NID", prams, ds, "thisNews");
        }

        //修改评论数
        public void ChangeComNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select NID,NComNum from [News] where NID = @NID", prams, "thisNews");
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ds.Tables["thisNews"].Rows[0]["NComNum"] = (int)ds.Tables["thisNews"].Rows[0]["NComNum"] + num;
            }
            data.UpdateData("select NID,NComNum from [News] where NID = @NID", prams, ds, "thisNews");
        }

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

        //修改转发数
        public void ChangeTransmitNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select NID,NTransmitNum from [News] where NID = @NID", prams, "thisNews");
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ds.Tables["thisNews"].Rows[0]["NTransmitNum"] = (int)ds.Tables["thisNews"].Rows[0]["NTransmitNum"] + num;
            }
            data.UpdateData("select NID,NTransmitNum from [News] where NID = @NID", prams, ds, "thisNews");
        }

        //按ID搜索Meebo
        public void  SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier, 16 ,myID),
			};
            DataSet ds = data.GetData("select * from [User] where NID = @NID", prams, tbName);
            ID = myID;
            SearchNumber = ds.Tables[tbName].Rows.Count;
            if (ds.Tables[tbName].Rows.Count == 1)
            {
                ContentT = ds.Tables[tbName].Rows[0]["NContentT"].ToString();
                ContentP = ds.Tables[tbName].Rows[0]["NContentP"].ToString();
                Topic = ds.Tables[tbName].Rows[0]["NTopic"].ToString();
                Date = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["NDate"].ToString()).Date;
                UserID = new Guid(ds.Tables[tbName].Rows[0]["NUserID"].ToString());
                ProNum = (int)ds.Tables[tbName].Rows[0]["NProNum"];
                ComNum = (int)ds.Tables[tbName].Rows[0]["NComNum"];
                SaveNum = (int)ds.Tables[tbName].Rows[0]["NSaveNum"];
                IsDelete = (ds.Tables[tbName].Rows[0]["NDelete"].ToString() == "True");
                DeleteUser = new Guid(ds.Tables[tbName].Rows[0]["NDeleteUser"].ToString());
                CallNum = (int)ds.Tables[tbName].Rows[0]["NCallNum"];
                IsTransmit = (ds.Tables[tbName].Rows[0]["NIsTransmit"].ToString() == "True");
                From = new Guid(ds.Tables[tbName].Rows[0]["NFrom"].ToString());
                TransmitInf = ds.Tables[tbName].Rows[0]["NTransmitInf"].ToString();
                TransmitNum = (int)ds.Tables[tbName].Rows[0]["NTransmitNum"];
                Visible = ds.Tables[tbName].Rows[0]["NVisible"].ToString();
            }
        }

        //转发meebo
        public Guid Transmit(Guid thisID)
        {
            DataSet ds = data.GetData("select * from [News] ", "thisNews");
            DataRow row = ds.Tables["thisUser"].NewRow();
            ID = Guid.NewGuid();
            row["NID"] = ID;
            if (ContentT != null)
            {
                row["NContentT"] = ContentT;
            }
            if (ContentP != null)
            {
                row["NContentP"] = ContentP;
            }
            if (Topic != null)
            {
                row["NTopic"] = Topic;
            }
            row["NDate"] = DateTime.Now;
            row["NUserID"] = UserID;
            row["NDeleteUser"] = UserID;
            if (CallNum != null)
            {
                row["NCallNum"] = CallNum;
            }
            row["NFrom"] = ID;
            if (Visible != null)
            {
                row["NVisible"] = Visible;
            }
            ds.Tables["thisNews"].Rows.Add(row);
            data.UpdateData("select * from [News] ", ds, "thisNews");
            return ID;
        }

    }
}