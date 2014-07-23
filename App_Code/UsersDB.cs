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
        private string name;
        private string password;
        private string nickname;
        private string email;
        private string birthday;
        private string gender;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        DataBase data = new DataBase();

        public int Insert()
        {
            SqlParameter[] prams = {
            data.MakeInParam("@UName",  SqlDbType.VarChar, 50,Name),
            data.MakeInParam("@UPassword",  SqlDbType.VarChar, 50, Password),
            data.MakeInParam("@UNickname",  SqlDbType.VarChar, 50, nickname),
            data.MakeInParam("@UEmail",  SqlDbType.VarChar, 50, Email),
            data.MakeInParam("@UBirthday",  SqlDbType.Date, 3, Birthday),
            data.MakeInParam("@UGender",  SqlDbType.Bit, 1, Gender),
			};
            return (data.RunProc("INSERT INTO User (UName,UPassword,UNickname,UEmail,UBirthday,UGender) VALUES(@UName,@UPassword,@UNickname,@UEmail,@UBirthday,@UGender)", prams));
        }

        public int ModifyPassword(string thisID,string NewPassword)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16, thisID),
            data.MakeInParam("@UPassword",  SqlDbType.VarChar, 50, NewPassword),
			};
            return (data.RunProc("update tb_admin set UPassword=@UPassword where UID=@UID", prams));
        }

        public int ModifyNickname(string thisID, string NewNickname)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16, thisID),
            data.MakeInParam("@UNickname",  SqlDbType.VarChar, 50, NewNickname),
			};
            return (data.RunProc("update tb_admin set UNickname=@UNickname where UID=@UID", prams));
        }

        public int ModifyEmail(string thisID, string NewEmail)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16, thisID),
            data.MakeInParam("@UEmail",  SqlDbType.VarChar, 50, NewEmail),
			};
            return (data.RunProc("update tb_admin set UEmail=@UEmail where UID=@UID", prams));
        }

        public int ModifyBirthday(string thisID, string NewBirthday)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16, thisID),
            data.MakeInParam("@UBirthday",  SqlDbType.Date, 3, NewBirthday),
			};
            return (data.RunProc("update tb_admin set UBirthday=@UBirthday where UID=@UID", prams));
        }

        public int Modifygender(string thisID, string NewGender)
        {
            SqlParameter[] prams = {
            data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16, thisID),
            data.MakeInParam("@UGender",  SqlDbType.Bit, 1, NewGender),
			};
            return (data.RunProc("update tb_admin set UGender=@UGender where UID=@UID", prams));
        }
    }
}