<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="user_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
     <style type="text/css">
        .p1 {font-size: 120%;font-family: "Times New Roman"}
        .p2 {font-family: "Times New Roman";}
        .p3 {font-size: 60%;font-family: "Times New Roman";}
         .right_item {margin-top:5px;margin-left:10%}
         a:visited {color: #000000}
         .btn_submit {width:80px; height:30px; margin-left:40%;}
         #nickname {
             width: 175px;
         }
         #email {
             width: 175px;
         }
         #birthday {
             width: 175px;
         }
         .auto-style2 {
             width: 93px;
         }
         .auto-style3 {
             width: 375px;
         }
    </style>
</head>
<body class="background">
    <form id="registerForm" name="regform" method="post" runat="server">
    <div class="header">
        <div class="headbody">
            <div class="logo">
		        <p class="logoText">MeeBo</p>
            </div>
            <div class="head_list">
                <div class="head_item">
                    <a style="color: #fefefe" href="PersonalPage.aspx">首页</a>
                </div>
                <div class="head_item">
                    <a style="color: #fefefe" href="../hot/hot.aspx">热门</a>
                </div>
                <div class="head_item_noright">
                    <a style="color: #fefefe" href="../hot/hotTopic.aspx">话题</a>
                </div>
             </div>
             <div class="head_search">
                 <table>
                    <tr>
                        <th>
                            <asp:TextBox ID="find_content" runat="server" maxlength="20" tabindex="1"  />
                        </th>
                        <th>
                            <asp:Button ID="submit_find" Text="查找" runat="server" style="width:40px; height:20px;" tabindex="2"/>
                        </th>
                    </tr>
                 </table>
             </div>
        </div>
    </div>
    <div class="wrapper">
        <div class="left_column">
            <div class="left_item">
                <a class="p1" href="PersonalPage.aspx">首页</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href="CommentMe.aspx">评论我的</a><br /><br/>
                <a class="p2" href="AtMe.aspx">提到我的</a><br /><br/>
                <a class="p2" href="ZanMe.aspx">赞</a><br /><br/>
                <a class="p2" href="MySave.aspx">我的收藏</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href = "MyMessage.aspx">我的私信</a><br /><br/>
                <a class="p2" href ="MyMeeBo.aspx">我的MeeBo</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href ="MyTeam.aspx">分组</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href ="UserInfo.aspx" >个人信息</a><br /><br/>
                <a class="p2" href ="ChangePassword.aspx" style="color: red">修改密码</a><br /><br/>
            </div>
            <hr class="line" />
        </div>
        <div class="userInfo_box">
            <div class="right_item">
                <p class="p1">修改密码</p>
            </div>
            <hr class="line" />
            <div class="right_item">
                
                    <table class="p3" style="border-spacing:10px 24px; width: 421px; height: 300px; margin-bottom:10px;margin-left:15%; ">
                        <tr>
                            <th class="auto-style2" style="font-weight:lighter">当前密码：</th>
                            <th class="auto-style3">
                                <asp:TextBox ID="current_password" type="password" runat="server" class="W_input" maxlength="20" tabindex="3" style="margin-left: 0px" Width="200px" />
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style2" style="font-weight:lighter">修改密码：</th>
                            <th class="auto-style3">
                                <asp:TextBox ID="change_password" type="password" runat="server" class="W_input" maxlength="20" tabindex="4" Width="200px" onkeyup="this.value=this.value.replace(/[, ]/g,'')" style="ime-mode:disabled"/>
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style2" style="font-weight:lighter">确认密码：</th>
                            <th class="auto-style3">
                                <asp:TextBox ID="repeat_password" type="password" runat="server" class="W_input" maxlength="20" tabindex="5" Width="200px" onkeyup="this.value=this.value.replace(/[, ]/g,'')" style="ime-mode:disabled"/>
                            </th>
                        </tr>
                    </table>
                    <div runat="server" id="error_password" style="color:red; height: 24px; margin-left:6em;margin-top:-30px;font-size:10px;margin-left:38%;margin-bottom:30px"></div>
                    <asp:Button ID="ChangePassword" Text="保存" runat="server" style="width:60px; height:23px; margin-bottom:30px; margin-left:40%;" tabindex="9" OnClick="ChangePassword_Click"/>
                    
                
            </div>
        </div>
    </div>
        </form>
</body>
</html>

