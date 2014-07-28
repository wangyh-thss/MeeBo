﻿using System;
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
        public Boolean IsTransmit { get; set;}
        public Guid From { get; set;}
        public string TransmitInf { get; set; }
        public int TransmitNum { get;set;}
        public string Visible {get; set;}

        DataBase data = new DataBase();
        UserDB thisUser = new UserDB();

        public int SearchNumber;
        public string userName { get; set; }
        public string userNickName { get; set; }

        // 发布meebo
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [News] ", "thisNews");
            DataRow row = ds.Tables["thisNews"].NewRow();
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
            Date = DateTime.Now;
            row["NDate"] = Date;
            row["NUserID"] = UserID;
            row["NDeleteUser"] = UserID;
            row["NFrom"] = ID;
            if(Visible != null)
            {
                row["NVisible"] = Visible;
            }
            ds.Tables["thisNews"].Rows.Add(row);
            thisUser.ChangeNewsNum(UserID, -1);
            data.UpdateData("select * from [News] ", ds, "thisNews");
            return ID;
        }

        //删除meebo
        public void Delete(Guid thisID,Guid DeleteUserID)
        {
             SqlParameter[] prams = 
            {
			    data.MakeInParam("@NID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [News] where NID = @NID", prams, "thisNews");
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ds.Tables["thisNews"].Rows[0]["NIsDelete"] = true;
                ds.Tables["thisNews"].Rows[0]["NDeleteUser"] = DeleteUserID;
            }
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
        public DataSet  SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier, 16 ,myID),
			};
            DataSet ds = data.GetData("select * from [News] where NID = @NID", prams, tbName);
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
                IsTransmit = (ds.Tables[tbName].Rows[0]["NIsTransmit"].ToString() == "True");
                From = new Guid(ds.Tables[tbName].Rows[0]["NFrom"].ToString());
                TransmitInf = ds.Tables[tbName].Rows[0]["NTransmitInf"].ToString();
                TransmitNum = (int)ds.Tables[tbName].Rows[0]["NTransmitNum"];
                Visible = ds.Tables[tbName].Rows[0]["NVisible"].ToString();
            }
            return ds;
        }

        //转发meebo
        public Guid Transmit(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NID",  SqlDbType.UniqueIdentifier, 16 ,thisID),
			};
            DataSet ds = data.GetData("select * from [User] where NID = @NID", prams, "thisNews");
            ID = thisID;
            if (ds.Tables["thisNews"].Rows.Count == 1)
            {
                ContentT = ds.Tables["thisNews"].Rows[0]["NContentT"].ToString();
                ContentP = ds.Tables["thisNews"].Rows[0]["NContentP"].ToString();
                From = new Guid(ds.Tables["thisNews"].Rows[0]["NFrom"].ToString());
            }
            ds = data.GetData("select * from [News] ", "thisNews");
            DataRow row = ds.Tables["thisNews"].NewRow();
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
            IsTransmit = true;
            row["NIsTransmit"] = IsTransmit;
            row["NFrom"] = From;
            if (Visible != null)
            {
                row["NVisible"] = Visible;
            }
            ds.Tables["thisNews"].Rows.Add(row);
            if (From == thisID)
            {
                ChangeTransmitNum(thisID, 1);
            }
            else
            {
                ChangeTransmitNum(thisID, 1);
                ChangeTransmitNum(From, 1);
            }
            data.UpdateData("select * from [News] ", ds, "thisNews");
            return ID;
        }

        //按用户ID搜索Meebo
        public DataSet SearchByUserID(Guid myUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NUserID",  SqlDbType.UniqueIdentifier, 16 ,myUserID),
			};
            DataSet ds = data.GetData("select * from [News] where NUserID = @NUserID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //按用户ID搜索未被删除Meebo
        public DataSet SearchUnDeleteByUserID(Guid myUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NUserID",  SqlDbType.UniqueIdentifier, 16 ,myUserID),
                data.MakeInParam("@NIsDelete",  SqlDbType.Bit, 1 ,false),
			};
            DataSet ds = data.GetData("select * from [News] where （NUserID = @NUserID）AND (NIsDelete = @NIsDelete)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //按用户ID搜索被管理员删除Meebo
        public DataSet SearchUnDeleteByUserID(Guid myUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NUserID",  SqlDbType.UniqueIdentifier, 16 ,myUserID),
                data.MakeInParam("@NIsDelete",  SqlDbType.Bit, 1 ,true),
                data.MakeInParam("@NDeleteUser",  SqlDbType.UniqueIdentifier, 16 ,myUserID),
			};
            DataSet ds = data.GetData("select * from [News] where （NUserID = @NUserID）AND (NDeleteUser <> @NDeleteUser)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //按用户ID搜索未被删除的原创Meebo
        public DataSet SearchOriginalByUserID(Guid myUserID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NUserID",  SqlDbType.UniqueIdentifier, 16 ,myUserID),
                data.MakeInParam("@NIsDelete",  SqlDbType.Bit, 1 ,false),
                data.MakeInParam("@NIsTransmit",  SqlDbType.Bit, 1 ,false),
			};
            DataSet ds = data.GetData("select * from [News] where （NUserID = @NUserID）AND (NIsDelete = @NIsDelete) AND (NIsTransmit = @NIsTransmit )", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //按主题搜索未被删除的原创Meebo
        public DataSet SearchOriginalByUserID(string topic, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@NTopic",  SqlDbType.VarChar, 50 ,topic),
                data.MakeInParam("@NIsDelete",  SqlDbType.Bit, 1 ,false),
                data.MakeInParam("@NIsTransmit",  SqlDbType.Bit, 1 ,false),
			};
            DataSet ds = data.GetData("select * from [News] where （NTopic = @NTopic）AND (NIsDelete = @NIsDelete) AND (NIsTransmit = @NIsTransmit )", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }
    }
}