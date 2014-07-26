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

        public Guid ID {get;set;}
        public string Name{get;set;}
        public string Password{ get; set; }
        public string Nickname{get;set;}
        public string Email{get;set;}
        public DateTime Birthday{get;set;}
        public Boolean Gender{get;set;}
        public string HeadPortrait {get; set;}
        public Boolean Admin {get;set;}
        public int FansNum { get; set;}
        public int LikesNum { get; set; }
        public int NewsNum { get; set; }
        public int SaveNewsNum { get; set; }
        public int MsgInNum { get; set; }
        public int MsgOutNum { get; set; }
        public int StateNum { get; set; }
        public int InfoNum { get; set; }

        DataBase data = new DataBase();

        public int SearchNumber;

        //插入新用户
        public Guid Insert()
        {
            DataSet ds = data.GetData("select * from [User] ", "thisUser");
            DataRow row = ds.Tables["thisUser"].NewRow();
            Guid newID = Guid.NewGuid();
            row["UID"] = newID;
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
            return newID;
        
        }

        //注销用户
        public void Delete(Guid thisID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select * from [User] where UID = @UID", prams, "thisUser");
            ds.Tables["thisUser"].Clear();
            data.UpdateData("select * from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改密码
        public void ModifyPassword(Guid thisID, string NewPassword)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UPassword from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UPassword"] = NewPassword;
            }
            data.UpdateData("select UID,UPassword from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改昵称
        public void ModifyNickname(Guid thisID, string NewNickname)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UNickname from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UNickname"] = NewNickname;
            }
            data.UpdateData("select UID,UNickname from [User] where UID = @UID", prams,ds, "thisUser");
        }

        //修改邮箱地址
        public void ModifyEmail(Guid thisID, string NewEmail)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UEmail from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UEmail"] = NewEmail;
            }
            data.UpdateData("select UID,UEmail from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改生日
        public void ModifyBirthday(Guid thisID, DateTime NewBirthday)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UPassword from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UBirthday"] = NewBirthday;
            }
            data.UpdateData("select UID,UPassword from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改性别
        public void Modifygender(Guid thisID, bool NewGender)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UGender from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UGender"] = NewGender;
            }
            data.UpdateData("select UID,UGender from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改头像
        public void ModifyHeadPortrait(Guid thisID, string NewHeadPortrait)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UHeadPortrait from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UHeadPortrait"] = NewHeadPortrait;
            }
            data.UpdateData("select UID,UHeadPortrait from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改粉丝数
        public void ChangeFansNum(Guid thisID, int num)
         {
             SqlParameter[] prams = 
             {
                 data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
             };
             DataSet ds = data.GetData("select UID,UFansNum from [User] where UID = @UID", prams, "thisUser");
             if (ds.Tables["thisUser"].Rows.Count == 1)
             {
                 ds.Tables["thisUser"].Rows[0]["UFansNum"] = (int)ds.Tables["thisUser"].Rows[0]["UFansNum"] + num;
             }
             data.UpdateData("select UID,UFansNum from [User] where UID = @UID", prams, ds, "thisUser");
         }

        //修改关注人数
        public void ChangeLikesNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select UID,ULikesNum from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["ULikesNum"] = (int)ds.Tables["thisUser"].Rows[0]["ULikesNum"] + num;
            }
            data.UpdateData("select UID,ULikesNum from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改meebo数
        public void ChangeNewsNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select UID,UNewsNum from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UNewsNum"] = (int)ds.Tables["thisUser"].Rows[0]["UNewsNum"] + num;
            }
            data.UpdateData("select UID,UNewsNum from [User] where UID = @UID", prams, ds, "thisUser");
         }

        //修改收藏数
        public void ChangeSaveNewsNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select UID,USaveNewsNum from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["USaveNewsNum"] = (int)ds.Tables["thisUser"].Rows[0]["USaveNewsNum"] + num;
            }
            data.UpdateData("select UID,USaveNewsNum from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改收到的私信数
        public void ChangeMsgInNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select UID,UMsgInNum from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UMsgInNum"] = (int)ds.Tables["thisUser"].Rows[0]["UMsgInNum"] + num;
            }
            data.UpdateData("select UID,UMsgInNum from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改发出的私信数
        public void ChangeMsgOutNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select UID,UMsgOutNum from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UMsgOutNum"] = (int)ds.Tables["thisUser"].Rows[0]["UMsgOutNum"] + num;
            }
            data.UpdateData("select UID,UMsgOutNum from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改系统消息数
        public void ChangeInfoNum(Guid thisID, int num)
        {
            SqlParameter[] prams = 
            {
                data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
            };
            DataSet ds = data.GetData("select UID,UInfoNum from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UInfoNum"] = (int)ds.Tables["thisUser"].Rows[0]["UInfoNum"] + num;
            }
            data.UpdateData("select UID,UInfoNum from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //修改用户状态
        public void ChangeState(Guid thisID, int NewState)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier,16,thisID),
			};
            DataSet ds = data.GetData("select UID,UState from [User] where UID = @UID", prams, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                ds.Tables["thisUser"].Rows[0]["UState"] = NewState;
            }
            data.UpdateData("select UID,UState from [User] where UID = @UID", prams, ds, "thisUser");
        }

        //通过用户名搜索
        public DataSet SearchByName(string MyName , string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UName",  SqlDbType.VarChar, 50,MyName),
			};
            DataSet ds = data.GetData("select * from [User] where UName = @UName", prams, tbName);
            if (MyName == null)
            {
                MyName = Name;
            }
            else
            {
                Name = MyName;
            }
            SearchNumber = ds.Tables[tbName].Rows.Count;
            if (ds.Tables[tbName].Rows.Count > 0)
            {
                ID = new Guid(ds.Tables[tbName].Rows[0]["UID"].ToString());
                Password = ds.Tables[tbName].Rows[0]["UPassword"].ToString();
                Nickname = ds.Tables[tbName].Rows[0]["UNickname"].ToString();
                Email = ds.Tables[tbName].Rows[0]["UEmail"].ToString();
                Birthday = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["UBirthday"].ToString()).Date;
                Gender = (ds.Tables[tbName].Rows[0]["UGender"].ToString() == "True");
                HeadPortrait = ds.Tables[tbName].Rows[0]["UHeadPortrait"].ToString();
                Admin = (ds.Tables[tbName].Rows[0]["Admin"].ToString() == "True");
                FansNum = (int)ds.Tables[tbName].Rows[0]["FansNum"];
                LikesNum = (int)ds.Tables[tbName].Rows[0]["LikesNum"];
                NewsNum = (int)ds.Tables[tbName].Rows[0]["NewsNum"];
                SaveNewsNum = (int)ds.Tables[tbName].Rows[0]["SaveNewsNum"];
                MsgInNum = (int)ds.Tables[tbName].Rows[0]["MsgInNum"];
                MsgOutNum = (int)ds.Tables[tbName].Rows[0]["MsgOutNum"];
                StateNum = (int)ds.Tables[tbName].Rows[0]["StateNum"];
                InfoNum = (int)ds.Tables[tbName].Rows[0]["InfoNum"];
            }
            return ds;
        }

        //通过ID搜索
        public DataSet SearchByID(Guid myID, string tbName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16 ,myID),
			};
            DataSet ds = data.GetData("select * from [User] where UID = @UID", prams, tbName);
            if (myID == null)
            {
                myID = ID;
            }
            else
            {
                ID = myID;
            }
            ID = myID;
            SearchNumber = ds.Tables[tbName].Rows.Count;
            if (ds.Tables[tbName].Rows.Count > 0)
            {
                Name = ds.Tables[tbName].Rows[0]["UName"].ToString();
                Password = ds.Tables[tbName].Rows[0]["UPassword"].ToString();
                Nickname = ds.Tables[tbName].Rows[0]["UNickname"].ToString();
                Email = ds.Tables[tbName].Rows[0]["UEmail"].ToString();
                Birthday = Convert.ToDateTime(ds.Tables[tbName].Rows[0]["UBirthday"].ToString()).Date;
                Gender = (ds.Tables[tbName].Rows[0]["UGender"].ToString() == "True");
                HeadPortrait = ds.Tables[tbName].Rows[0]["UHeadPortrait"].ToString();
                Admin = (ds.Tables[tbName].Rows[0]["Admin"].ToString() == "True");
                FansNum = (int)ds.Tables[tbName].Rows[0]["FansNum"];
                LikesNum = (int)ds.Tables[tbName].Rows[0]["LikesNum"];
                NewsNum = (int)ds.Tables[tbName].Rows[0]["NewsNum"];
                SaveNewsNum = (int)ds.Tables[tbName].Rows[0]["SaveNewsNum"];
                MsgInNum = (int)ds.Tables[tbName].Rows[0]["MsgInNum"];
                MsgOutNum = (int)ds.Tables[tbName].Rows[0]["MsgOutNum"];
                StateNum = (int)ds.Tables[tbName].Rows[0]["StateNum"];
                InfoNum = (int)ds.Tables[tbName].Rows[0]["InfoNum"];
            }
            return ds;
        }

        //搜索
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
            DataSet ds = data.GetData(select, prams, tbName);
            SearchNumber = ds.Tables[tbName].Rows.Count;
            return ds ;
        }

        //判断用户名是否存在
        public Boolean isInByName(string MyName)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UName",  SqlDbType.VarChar, 50,MyName),
			};
            DataSet ds = data.GetData("select * from [User] where UName = @UName", prams, "thisUser");
            return (ds.Tables["thisUser"].Rows.Count > 0);
        }

        //判断ID是否存在
        public Boolean isInByID(Guid myID)
        {
            SqlParameter[] prams = 
            {
			    data.MakeInParam("@UID",  SqlDbType.UniqueIdentifier, 16 ,myID),
			};
            DataSet ds = data.GetData("select * from [User] where UID = @UID", prams, "thisUser");
            return (ds.Tables["thisUser"].Rows.Count > 0);
        }

        //通过ID获取用户名
        public string getNameByID(Guid myID)
        {
            DataSet ds = SearchByID(myID, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                return ds.Tables["thisUser"].Rows[0]["UName"].ToString();
            }
            else return null;
        }

        //通过ID获取密码
        public string getPasswordByID(Guid myID)
        {
            DataSet ds = SearchByID(myID, "thisUser");
            if (ds.Tables["thisUser"].Rows.Count == 1)
            {
                return ds.Tables["thisUser"].Rows[0]["UPassword"].ToString();
            }
            else return null;
        }

        //通过用户名获取ID
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