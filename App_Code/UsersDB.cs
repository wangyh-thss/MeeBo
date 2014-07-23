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

        public void Insert()
        {
           DataSet ds = data.GetData("select * from User ","thisUser");
           DataRow row = ds.Tables["thisUser"].NewRow();
           row["UName"] = Name;
           row["UPassword"] = Password;
           row["UNickname"] = Nickname;
           row["UEmail"] = Email;
           row["UBirthday"] = Birthday;
           row["UGender"] = Gender;
           ds.Tables["thisUser"].Rows.Add(row);
           data.UpdateData("select * from User ",ds,"thisUser");
        }

        public void ModifyPassword(string thisID,string NewPassword)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.VarChar, 50,thisID),
			};
            DataSet ds = data.GetData("select UID,UPassword from User where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[1]["UPassword"] = NewPassword;
            data.UpdateData("select UID,UPassword from User", ds, "thisUser");
        }

        public void ModifyNickname(string thisID, string NewNickname)
        {
            SqlParameter[] prams = {
			data.MakeInParam("@UID",  SqlDbType.VarChar, 50,thisID),
			};
            DataSet ds = data.GetData("select UID,UNickname from User where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[1]["UNickname"] = NewNickname;
            data.UpdateData("select UID,UNickname from User", ds, "thisUser");
        }

        public void ModifyEmail(string thisID, string NewEmail)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.VarChar, 50,thisID),
			};
            DataSet ds = data.GetData("select UID,UEmail from User where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[1]["UEmail"] = NewEmail;
            data.UpdateData("select UID,UEmail from User", ds, "thisUser");
        }

        public void ModifyBirthday(string thisID, string NewBirthday)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.VarChar, 50,thisID),
			};
            DataSet ds = data.GetData("select UID,UPassword from User where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[1]["UBirthday"] = NewBirthday;
            data.UpdateData("select UID,UBirthday from User", ds, "thisUser");
        }

        public void Modifygender(string thisID, string NewGender)
        {
            SqlParameter[] prams = {
			data.MakeInParam("@UID",  SqlDbType.VarChar, 50,thisID),
			};
            DataSet ds = data.GetData("select UID,UGender from User where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Rows[1]["UGender"] = NewGender;
            data.UpdateData("select UID,UGender from User", ds, "thisUser");
        }

        public DataSet SearchByName(string MyName ,string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UName",  SqlDbType.VarChar, 50,MyName),
			};
            return (data.GetData("select * from User where name = @name", prams, tbName));
        }
    }
}