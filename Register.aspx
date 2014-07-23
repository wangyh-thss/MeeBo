 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/frame.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .background {background: #c8e1f0}
        .header {width: 80%; margin: auto;}
        .register_box {width: 75%; margin: auto; background:#fefefe; padding-top: 20px; padding-left:20px; border: 2px solid; border-radius: 10px; box-shadow: 10px 10px 5px #000000;}
        .infomation_list {width: 75%; margin: auto;}
        .p1 {font-size: 150%; font-family: "Times New Roman";}
        .p2 {font-size: 150%; font-family: "华文隶书","Times New Roman"; color: #000000;}
        .submit_zoom {width: 100px; margin:auto;}
        .btn-submit { cursor: pointer;color: #ffffff;background: #e64141; border: 1px solid #528641; font-size: 14px; font-weight: bold; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; *width: 100px;*height:30px; }
        .foot_box {width: 40%; margin-left: 35%;height: 16px;margin-top: 45px; margin-bottom: 30px}
    </style>
    <title>注册MeeBo账号</title>
</head>
<body class="background">
    <div class="header">
		<img src="image/logo.jpg" alt="logo(MeeBo)" style="margin:auto" />
    </div>
    <div class="register_box">
        <div class="p1">填写以下信息加入<a class="p2">MeeBo</a>：</div>
        <ul class="infomation_list" style="padding-top: 24px">
            <li>
                <table>
                    <tr>
                        <th>
                            <a style="color: red">*</a>
                        </th>
                        <th>
                            <abbr title="必填，这将是您用于登录的信息之一，注意用户名不能与其他用户重复">&nbsp 用户名：</abbr>
                        </th>
                        <th>
                            <input id="user" name="user" type="text" class="W_input" maxlength="20" tabindex="1"/>
                        </th>
                    </tr>
                </table>
                <div runat="server" id="error_username" style="color:red; height: 24px; margin-left:6em;margin-top:10px"></div>
                <br />
            </li>
            <li>
                <table>
                    <tr>
                        <th>
                            <a style="color: red">*</a>
                        </th>
                        <th>
                            <abbr title="必填，这将是您用于登录的信息之一">&nbsp 密码：&nbsp&nbsp&nbsp&nbsp</abbr>
                        </th>
                        <th>
                            <input id="password" name="password" type="password" class="W_input" maxlength="20" tabindex="2"/>
                        </th>
                    </tr>
                </table>
                <div runat="server" id="error_password" style="color:red; height: 24px; margin-left:6em;margin-top:10px"></div>
                <br />
            </li>
            <li style="margin-left: -1em">
                <table>
                    <tr>
                        <th>
                            <a style="color: red">*</a>
                        </th>
                        <th>
                            <abbr title="必填，请确认您输入的密码无误">&nbsp 确认密码：</abbr>
                        </th>
                        <th>
                            <input id="repeat_password" name="repeat_password" type="password" class="W_input" maxlength="20" tabindex="2"/>
                        </th>
                    </tr>
                </table>
                <div runat="server" id="error_repeat_password" style="color:red; height: 24px; margin-left:6em;margin-top:10px"></div>
                <br />
            </li>
            <li>
                <table>
                    <tr>
                        <th>
                            <abbr title="选填，这将是您用于维护账号安全的必备信息，我们推荐您在注册时完善邮箱信息">&nbsp 邮箱：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                        </th>
                        <th>
                            <input id="email" name="email" type="text" class="W_input" maxlength="60" tabindex="3"/>
                        </th>
                    </tr>
                </table>
                <div runat="server" id="error_email" style="color:red; height: 24px;"></div>
                <br />
            </li>
            <li>
                <table>
                    <tr>
                        <th>
                            <abbr title="选填，这将是你与其他用户进行交际时使用的名称">&nbsp 昵称：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                        </th>
                        <th>
                            <input id="nickname" name="nickname" type="text" class="W_input" maxlength="20" tabindex="4"/>
                        </th>
                    </tr>
                </table>
                <br />
            </li>
            <li style="margin-top: 24px">
                <table>
                    <tr>
                        <th>
                            <abbr title="选填，个人资料的一部分">&nbsp 性别：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                        </th>
                        <th>
                            <input type="radio" name="gender" value="male" tabindex="5"/> 男
                            <input type="radio" name="gender" value="female" style="margin-left: 4em" tabindex="6"/> 女
                        </th>
                    </tr>
                </table>
                <br />
            </li>
            <li  style="margin-top: 24px">
                <table>
                    <tr>
                        <th>
                            <abbr title="选填，您的生日，完善个人信息有助于其它用户更了解您">&nbsp 生日：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                        </th>
                        <th>
                            <input id="birthday" name="birthday" type="text" class="W_input" maxlength="20" tabindex="7"/>
                        </th>
                    </tr>
                </table>
                <br />
            </li>
            <li  style="margin-top: 24px">
                <table>
                    <tr>
                        <th>
                            <abbr title="选填，您的头像，这将会在您发布的每一条消息中显示">&nbsp 头像：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                        </th>
                        <th>
                            <img id="head_potrait" src="image/head_potrait.jpg" style="height: 80px; width: 80px"/>
                        </th>
                        <th class="auto-style1">
                            <button id="choose_img" name="choose_img" style="margin-left: 30px;border: none; background: #c8e1f0; border-radius: 2px; padding:3px 3px 3px 3px">选择头像</button>
                        </th>
                    </tr>
                </table>
                <br />
            </li>
            <li  style="margin-top: 24px; height: 78px;">
                <table>
                    <tr>
                        <th>
                            <a style="color: red">*</a>
                        </th>
                        <th>
                            <abbr title="必填，请在此输入验证码">&nbsp 验证码：</abbr>
                        </th>
                        <th>
                            <input id="check_num" name="check_num" type="text" class="W_input" maxlength="20" tabindex="8" style="width: 60%"/>
                        </th>
                        <th>
                            <img src="image/" alt="验证码" onclick="change_check_num()" style="width: 150px; height:30px; margin-left:30px"/></th>
                    </tr>
                </table>
                <br />
            </li>
        </ul>
        <form runat="server" class="submit_zoom">
            <asp:Button runat="server" Text="注册" class="btn-submit" style="width:80px; height:30px; margin-bottom:30px" OnClick="btnRegister_Click" tabindex="9"/>
        </form>
    </div>
    <div class="foot_box">
    <a style="margin:auto">Copyright &copy; 2014- MEEBO 清华大学软件学院<span style="margin-left: 4em">尚未提交审查</span></a>
    </div>
</body>
</html>
