<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="user_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人资料</title>
     <style type="text/css">
        .background {background: #c8e1f0}
        .header {width: 80%; margin: auto;}
        .userInfoform{width: 80%; margin: auto;position:relative;}
        .left_column {width: 15%; height:700px;background:#fefefe; border: 2px solid #a0b4c1;float:left; border-radius: 10px; margin-left:10%; margin-top: 20px; margin-bottom:30px;}
        .userInfo_box {width: 63%;height:700px; background:#fefefe;border: 2px solid #a0b4c1;float:left; border-radius: 10px; margin-left:2%; margin-top: 20px; margin-bottom:30px;}
        .p1 {font-size: 120%;font-family: "Times New Roman"}
        .p2 {font-family: "Times New Roman";}
        .p3 {font-size: 60%;font-family: "Times New Roman";}
        .left_item{padding-left:2em;margin-top:5px}
         .right_item {margin-top:5px;margin-left:10%}
        .line {margin-left:10%;margin-top:5px; width:80%; color:#999999}
         a {text-decoration: none;}
         a:link {color: #000000}
         a:hover {color: blue}
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
    <div class="header">
		<img src="image/logo.jpg" alt="logo(MeeBo)" style="margin:auto" />
    </div>
    <div class="userInfoForm">
        <div class="left_column">
            <div class="left_item">
                <p class="p1">个人主页</p>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2">MeeBo消息</a><br /><br/>
                <a class="p2">与我相关</a><br /><br/>
                <a class="p2">提到我的</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2">我的粉丝</a><br /><br/>
                <a class="p2">我的关注</a><br /><br/>
                <a class="p2">特别关注</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" style="color: red">我的信息</a><br /><br/>
                <a class="p2">修改密码</a><br /><br/>
            </div>
            <hr class="line" />
        </div>
        <div class="userInfo_box">
            <div class="right_item">
                <p class="p1">修改密码</p>
            </div>
            <hr class="line" />
            <div class="right_item">
                <form id="registerForm" name="regform" method="post" runat="server">
                    <table class="p3" style="border-spacing:10px 24px; width: 421px; height: 350px; margin-bottom:30px;margin-left:15%; ">
                        <tr>
                            <th class="auto-style2" style="font-weight:lighter">当前密码：</th>
                            <th class="auto-style3">
                                <asp:TextBox ID="current_password" runat="server" class="W_input" maxlength="20" tabindex="3" style="margin-left: 0px" Width="200px" />
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style2" style="font-weight:lighter">修改密码：</th>
                            <th class="auto-style3">
                                <asp:TextBox ID="change_password" runat="server" class="W_input" maxlength="20" tabindex="4" Width="200px" />
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style2" style="font-weight:lighter">确认密码：</th>
                            <th class="auto-style3">
                                <asp:TextBox ID="repeat_password" runat="server" class="W_input" maxlength="20" tabindex="5" Width="200px" />
                            </th>
                        </tr>
                    </table>
                    <div runat="server" id="error_password" style="color:red; height: 24px; margin-left:6em;margin-top:10px"></div>
                    <asp:Button ID="ChangePassword" Text="保存" runat="server" style="width:60px; height:23px; margin-bottom:30px; margin-left:40%;" tabindex="9"/>
                </form>
            </div>
        </div>
    </div>
</body>
</html>

