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
    /// LikeDB 的摘要说明
    /// </summary>
    public class LikeDB
    {
        public LikeDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public Guid ID { get; set; }
        public Guid FanID { get; set; }
        public Guid StarID { get; set; }
        public string Group { get; set; }

        DataBase data = new DataBase();

        UserDB thisUser = new UserDB();
        public int SearchNumber;

        //添加一条关注
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [Like]", "thisLike");
            DataRow row = ds.Tables["thisPraise"].NewRow();
            ID = Guid.NewGuid();
            row["LID"] = ID;
            row["LFanUID"] = FanID;
            row["LStarUID"] = StarID;
            if(Group == null || Group =="")
            {
                Group = "未分组";
            }
            row["LGroup"] = Group;
            ds.Tables["thisLike"].Rows.Add(row);
            thisUser.ChangeFansNum(StarID, 1);
            thisUser.ChangeLikesNum(FanID, 1);
            data.UpdateData("select * from [Like] ", ds, "thisLike");
            return ID;
        }

        //删除一个关注
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Like] where LID = @LID", prams, "thisLike");
            if (ds.Tables["thisLike"].Rows.Count == 1)
            {
                thisUser.ChangeFansNum(new Guid(ds.Tables["thisLike"].Rows[0]["LStarUID"].ToString()), -1);
                thisUser.ChangeLikesNum(new Guid(ds.Tables["thisLike"].Rows[0]["LFanUID"].ToString()), -1);
                ds.Tables["thisLike"].Rows[0].Delete();
            }
            data.UpdateData("select * from [Like] where PID = @PID", prams, ds, "thisLike");
        }

        //删除一个关注
        public void Delete(Guid thisFanID, Guid thisStarID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,thisStarID),
                data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,thisFanID),
			};
            DataSet ds = data.GetData("select * from [Like] where (LStarUID = @LStarUID) AND (LFanUID = @LFanUID)", prams, "thisLike");
            if (ds.Tables["thisPraise"].Rows.Count > 1)
            {
                thisUser.ChangeFansNum(thisStarID, -ds.Tables["thisPraise"].Rows.Count);
                thisUser.ChangeLikesNum(thisFanID, -ds.Tables["thisPraise"].Rows.Count);
                ds.Tables["thisPraise"].Clear();
            }
            data.UpdateData("select * from [Like] where (LStarUID = @LStarUID) AND (LFanUID = @LFanUID)", prams, ds, "thisLike");
        }

        //删除一个用户的所有关注
        public void DeleteByFanID(Guid thisFanID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,thisFanID),
			};
            DataSet ds = data.GetData("select * from [Like] where LFanUID = @LFanUID", prams, "thisLike");
            foreach (DataRow Save in ds.Tables["thisLike"].Rows)
            {
                thisUser.ChangeFansNum(new Guid(ds.Tables["thisLike"].Rows[0]["LStarUID"].ToString()), -1);
            }
            ds.Tables["thisLike"].Clear();
            thisUser.ChangeLikesNum(thisFanID, -ds.Tables["thisLike"].Rows.Count);
            data.UpdateData("select * from [Like] where LFanUID = @LFanUID", prams, ds, "thisLike");
        }

        //搜索某用户的所有关注
        public DataSet SearchByFanID(string tbName, Guid myFanID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,myFanID),
                data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,myFanID),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LStarUID <> @LStarUID)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某用户的所有粉丝
        public DataSet SearchByStarID(string tbName, Guid myStarID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,myStarID),
                data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,myStarID),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID <> @LFanUID) AND (LStarUID = @LStarUID)", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //搜索某用户的某分组关注
        public DataSet SearchByFanIDAndGroup(string tbName, Guid myFanID,string myGroup)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,myFanID),
                data.MakeInParam("@LGruop",SqlDbType.VarChar,50,myGroup),
                data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,myFanID),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop)AND(LStarUID <> @LStarUID) ", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }

        //判断某用户是否关注某用户
        public Boolean isPraise(Guid myFanID, Guid myStarID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,myFanID),
                data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,myStarID),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LStarUID <> @LStarUID)", prams, "thisLike");
            return (ds.Tables["thisLike"].Rows.Count > 0);
        }

        //判断用户是否有某个分组
        public Boolean haveGroup(Guid thisFanID, string thisgroup)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,thisFanID),
                data.MakeInParam("@LGruop",SqlDbType.VarChar,50,thisgroup),
                data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,thisFanID),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop)AND(LStarUID = @LStarUID) ", prams, "thisLike");
            return (ds.Tables["thisLike"].Rows.Count > 0);
        }

        //添加分组
        public void addGroup(Guid thisFanID,string thisgroup)
        {
            DataSet ds = data.GetData("select * from [Like]", "thisLike");
            DataRow row = ds.Tables["thisPraise"].NewRow();
            ID = Guid.NewGuid();
            row["LID"] = ID;
            row["LFanUID"] = thisFanID;
            row["LStarUID"] = thisFanID;
            row["LGroup"] = thisgroup;
            ds.Tables["thisLike"].Rows.Add(row);
            data.UpdateData("select * from [Like] ", ds, "thisLike");
        }

        //删除分组
        public void deleteGroup(Guid thisFanID, string thisgroup)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,thisFanID),
                data.MakeInParam("@LGruop",SqlDbType.VarChar,50,thisgroup),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop) ", prams, "thisLike");
            foreach (DataRow Save in ds.Tables["thisLike"].Rows)
            {
                Save["Group"] = "未分组";
            }
            data.UpdateData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop)",prams, ds, "thisLike");
            SqlParameter[] prams2 = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,thisFanID),
                data.MakeInParam("@LGruop",SqlDbType.VarChar,50,"未分组"),
                data.MakeInParam("@LStarUID",SqlDbType.UniqueIdentifier,16,thisFanID),
			};
            ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop) AND (LStarUID = @LStarUID)", prams2, "thisLike");
            ds.Tables["thisLike"].Clear();
            data.UpdateData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop) AND (LStarUID = @LStarUID)", prams2, ds, "thisLike");
        }

        //改变分组名
        public void changeGruopName(Guid thisFanID, string oldgroup, string newgroup)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,thisFanID),
                data.MakeInParam("@LGruop",SqlDbType.VarChar,50,oldgroup),
			};
            DataSet ds = data.GetData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop) ", prams, "thisLike");
            foreach (DataRow Save in ds.Tables["thisLike"].Rows)
            {
                Save["Group"] = newgroup;
            }
            data.UpdateData("select * from [Like] where (LFanUID = @LFanUID) AND (LGruop = @LGruop)", prams, ds, "thisLike");
        }

        //改变某条关注的分组
        public void changeGruop(Guid thisID, string thisgroup)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [Like] where LID = @LID", prams, "thisLike");
            if (ds.Tables["thisLike"].Rows.Count == 1)
            {
                ds.Tables["thisLike"].Rows[0]["LGroup"] = thisgroup;
            }
            data.UpdateData("select * from [Like] where PID = @PID", prams, ds, "thisLike");
        }
    }
}