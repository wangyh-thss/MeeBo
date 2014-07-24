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
    /// UsersDB 的摘要说明
    /// </summary>
    public class UserDB
    {
        public UserDB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public string Name{get;set;}
        public string Password{ get; set; }
        public string Nickname{get;set;}
        public string Email{get;set;}
        public DateTime Birthday{get;set;}
        public Boolean Gender{get;set;}
        public string HeadPortrait {get; set;}

        DataBase data = new DataBase();

        public void Insert()
        {
            DataSet ds = data.GetData("select * from [User] ","thisUser");
            DataRow row = ds.Tables["thisUser"].NewRow();
            row["UID"] = Guid.NewGuid();
            row["UName"] = Name;
            row["UPassword"] = Password;
            if (Nickname == "" || Nickname == null)
            {
                Nickname = Name;
            }
            row["UNickname"] = Nickname;
            if (Email != "")
            {
                row["UEmail"] = Email;
            }
            if (Birthday != null)
            {
                row["UBirthday"] = Birthday;
            }
            row["UGender"] = Gender;
            row["UHeadPortrait"] = HeadPortrait;
            ds.Tables["thisUser"].Rows.Add(row);
            data.UpdateData("select * from [User] ", ds, "thisUser");
        }

        public void ModifyPassword(Guid thisID, string NewPassword)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UPassword from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[0]["UPassword"] = NewPassword;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public void ModifyNickname(Guid thisID, string NewNickname)
        {
            SqlParameter[] prams = {
			data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UNickname from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[0]["UNickname"] = NewNickname;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public void ModifyEmail(Guid thisID, string NewEmail)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UEmail from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[0]["UEmail"] = NewEmail;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public void ModifyBirthday(Guid thisID, DateTime NewBirthday)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UPassword from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[0]["UBirthday"] = NewBirthday;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public void Modifygender(Guid thisID, string NewGender)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UGender from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[0]["UGender"] = NewGender;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public void Modifygender(Guid thisID, Byte[] NewHeadPortrait)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UHeadPortrait from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[0]["UHeadPortrait"] = NewHeadPortrait;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public void Delete(string MyName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UName",  SqlDbType.VarChar, 50,MyName),
			};
            DataSet ds = data.GetData("select * from [User] where UName = @UName", prams, "thisUser");
            ds.Tables["thisUser"].Clear();
            data.UpdateData("select * from [User]", ds, "thisUser");
        }


        public void changeFansNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,UFansNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["UFansNum"] = (int)ds.Tables["thisUser"].Rows[0]["UFansNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }

        public void changeLikesNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,ULikesNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["ULikesNum"] = (int)ds.Tables["thisUser"].Rows[0]["ULikesNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }
        public void changeNewsNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,UNewsNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["UNewsNum"] = (int)ds.Tables["thisUser"].Rows[0]["UNewsNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }
        public void changeSaveNewsNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,USaveNewsNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["USaveNewsNum"] = (int)ds.Tables["thisUser"].Rows[0]["USaveNewsNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }
        public void changeMsgInNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,UMsgInNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["UMsgInNum"] = (int)ds.Tables["thisUser"].Rows[0]["UMsgInNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }
        public void changeMsgOutNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,UMsgOutNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["UMsgOutNum"] = (int)ds.Tables["thisUser"].Rows[0]["UMsgOutNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }
        public void changeInfoNum(Guid thisID , int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,UInfoNum from [User] where UID = @UID", prams, "thisUser");
             ds.Tables["thisUser"].Rows[1]["UInfoNum"] = (int)ds.Tables["thisUser"].Rows[0]["UInfoNum"] + num;
             data.UpdateData("select * from [User]", ds, "thisUser");
         }

        public void changeState(Guid thisID, int NewState)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UState from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[1]["UState"] = NewState;
            data.UpdateData("select * from [User]", ds, "thisUser");
        }

        public DataSet SearchByName(string MyName ,string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UName",  SqlDbType.VarChar, 50,MyName),
			};
            return (data.GetData("select * from [User] where UName = @UName", prams, tbName));
        }

        public DataSet SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16 ,myID),
			};
            return (data.GetData("select * from [User] where UID = @UID", prams, tbName));
        }

        public DataSet Search(string tbName)
        {
            string select = "select * from [User] where ";
            int i = Convert.ToInt32(Name != null) + Convert.ToInt32(Nickname != null) +
                    Convert.ToInt32(Birthday != null) + Convert.ToInt32(Gender != null);
            SqlParameter[] prams = new SqlParameter[i];
            i = 0;
            if (Name != null)
            {
                prams[i] = data.MakeInParam("@UName", SqlDbType.VarChar, 50, Name);
                i++;
                select = select + "(UName = @UName) AND ";
            }
            if (Nickname != null)
            {
                prams[i] = data.MakeInParam("@UNickname", SqlDbType.VarChar, 50, Nickname);
                i++;
                select = select + "(UNickname = @UNickname) AND ";
            }
            if (Birthday != null)
            {
                prams[i] = data.MakeInParam("@UBirthday ", SqlDbType.Date, 3, Birthday);
                i++;
                select = select + "(UBirthday  = @UBirthday ) AND ";
            }
            if (Gender != null)
            {
                prams[i] = data.MakeInParam("@UGender", SqlDbType.Bit, 1, Gender);
                i++;
                select = select + "(UGender = @UGender) AND ";
            }
            select = select.Substring(0,select.Length - 5);
            return (data.GetData(select, prams, tbName));
        }

        public string getNameByID(Guid myID)
        {
            DataSet ds = SearchByID(myID, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                return ds.Tables["thisUser"].Rows[0]["UName"].ToString();
            }
            else return null;
        }

        public string getPasswordByID(Guid myID)
        {
            DataSet ds = SearchByID(myID, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                return ds.Tables["thisUser"].Rows[0]["UPassword"].ToString();
            }
            else return null;
        }

        public string getIDByName(string MyName)
        {
            DataSet ds = SearchByName(MyName, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                return ds.Tables["thisUser"].Rows[0]["UID"].ToString();
            }
            else return null;
        }
    }
}