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
            if (Group != null)
            {
                row["LGroup"] = Group;
            }
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
                ds.Tables["thisLike"].Clear();
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
            if (ds.Tables["thisPraise"].Rows.Count == 1)
            {
                thisUser.ChangeFansNum(thisStarID, -1);
                thisUser.ChangeLikesNum(thisFanID, -1);
                ds.Tables["thisPraise"].Clear();
            }
            data.UpdateData("select * from [Like] where (LStarUID = @LStarUID) AND (LFanUID = @LFanUID)", prams, ds, "thisLike");
        }

        //搜索某用户的所有关注
        public DataSet SearchByFanID(string tbName, Guid myFanID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@LFanUID",SqlDbType.UniqueIdentifier,16,myFanID),
			};
            DataSet ds = data.GetData("select * from [Like] where LFanUID = @LFanUID", prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds;
        }
    }
}