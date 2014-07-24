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
        .infomation_list {width: 45%; margin-left: 10%;}
        .p1 {font-size: 150%; font-family: "Times New Roman";}
        .p2 {font-size: 150%; font-family: "华文隶书","Times New Roman"; color: #000000;}
        .submit_zoom {width: 100px; margin:auto;}
        .ad_box {width:335px; height: 450px; border: 2px solid #c8e1f0; position:fixed;left:55%;top:14%;border-radius: 10px; box-shadow: 10px 10px 5px #888888; }
        .btn-submit { cursor: pointer;color: #ffffff;background: #e64141; border: 1px solid #528641; font-size: 14px; font-weight: bold; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; *width: 100px;*height:30px; }
        .foot_box {width: 40%; margin-left: 35%;height: 16px;margin-top: 45px; margin-bottom: 30px}
        .auto-style1 {
            width: 136px;
        }
        .auto-style2 {
            width: 119px;
        }
        .auto-style3 {
            height: 37px;
        }
        .auto-style4 {
            height: 37px;
            width: 57px;
        }
    </style>
    <title>注册MeeBo账号</title>
    
</head>
<body class="background">
    <form runat="server">
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
                            <th class="auto-style2">
                                <!-- <input id="user" name="user" type="text" class="W_input" maxlength="20" tabindex="1"/> -->
                                <asp:TextBox ID="user" runat="server" class="W_input" maxlength="20" tabindex="1" />
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
                                <!-- <input id="password" name="password" type="password" class="W_input" maxlength="20" tabindex="2"/> -->
                                <asp:TextBox type="password" ID="password" runat="server" class="W_input" maxlength="20" tabindex="2" />
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
                                <!-- <input id="repeat_password" name="repeat_password" type="password" class="W_input" maxlength="20" tabindex="2"/> -->
                                <asp:TextBox type="password" ID="repeat_password" runat="server" class="W_input" maxlength="20" tabindex="3" />
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
                                <!-- <input id="email" name="email" type="text" class="W_input" maxlength="60" tabindex="3"/> -->
                                <asp:TextBox ID="email" runat="server" class="W_input" maxlength="60" tabindex="4" />
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
                                <!-- <input id="nickname" name="nickname" type="text" class="W_input" maxlength="20" tabindex="4"/> -->
                                <asp:TextBox ID="nickname" runat="server" class="W_input" maxlength="20" tabindex="5" />
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
                            <th class="auto-style3">
                                <abbr title="选填，您的生日，完善个人信息有助于其它用户更了解您">&nbsp 生日：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                            </th>
                            <th class="auto-style4">
                                &nbsp;<asp:DropDownList ID="year" runat="server">
                                    <asp:ListItem>1980</asp:ListItem>
                                    <asp:ListItem>1981</asp:ListItem>
                                    <asp:ListItem>1982</asp:ListItem>
                                    <asp:ListItem>1983</asp:ListItem>
                                    <asp:ListItem>1984</asp:ListItem>
                                    <asp:ListItem>1985</asp:ListItem>
                                    <asp:ListItem>1986</asp:ListItem>
                                    <asp:ListItem>1987</asp:ListItem>
                                    <asp:ListItem>1988</asp:ListItem>
                                    <asp:ListItem>1989</asp:ListItem>
                                    <asp:ListItem>1990</asp:ListItem>
                                    <asp:ListItem>1991</asp:ListItem>
                                    <asp:ListItem>1992</asp:ListItem>
                                    <asp:ListItem>1993</asp:ListItem>
                                    <asp:ListItem>1994</asp:ListItem>
                                    <asp:ListItem>1995</asp:ListItem>
                                    <asp:ListItem>1996</asp:ListItem>
                                    <asp:ListItem>1997</asp:ListItem>
                                    <asp:ListItem>1998</asp:ListItem>
                                    <asp:ListItem>1999</asp:ListItem>
                                    <asp:ListItem>2000</asp:ListItem>
                                    <asp:ListItem>2001</asp:ListItem>
                                    <asp:ListItem>2002</asp:ListItem>
                                    <asp:ListItem>2003</asp:ListItem>
                                    <asp:ListItem>2004</asp:ListItem>
                                    <asp:ListItem>2005</asp:ListItem>
                                    <asp:ListItem>2006</asp:ListItem>
                                    <asp:ListItem>2007</asp:ListItem>
                                    <asp:ListItem>2008</asp:ListItem>
                                    <asp:ListItem>2009</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                </asp:DropDownList>
                                年
                            </th>
                        </tr>
                    </table>
                    <br />
                </li>
                <li  style="margin-top: 24px">
                    <table>
                        <tr>
                            <th>
                                <abbr title="选填，您的头像，这将会在您发布的每一条消息中显示,大小限制为1MB">&nbsp 头像：&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</abbr>
                            </th>
                            <th>
                                <!-- <img id="head_potrait" src="image/head_potrait.jpg" style="height: 80px; width: 80px"/> -->
                                <asp:Image ID="head_potrait" runat="server" ImageUrl="image/head_potrait.jpg" style="height: 80px; width: 80px"/>
                            </th>
                            <th class="auto-style1">
                                <asp:FileUpload ID="SelectImg" runat="server" Width="65px" style="margin-left:35px;" onchange="javascript:__doPostBack('UploadImg','')"/>
                                <asp:LinkButton ID="UploadImg" runat="server" OnClick="UploadImg_Click"></asp:LinkButton>
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
                                <!-- <input id="check_num" name="check_num" type="text" class="W_input" maxlength="20" tabindex="8" style="width: 60%"/> -->
                                <asp:TextBox ID="check_num" runat="server" class="W_input" maxlength="20" tabindex="8" style="width: 60%"/>
                            </th>
                            <th>
                                <asp:Image ID="Captcha" runat="server" ImageUrl="~/function/Captcha.aspx" onclick="change_check_num()" style="width: 100px; height:30px; margin-left:10px"/>
                            </th>
                        </tr>
                    </table>
                    <div runat="server" id="error_check_num" style="color:red; height: 24px; margin-left:6em;margin-top:10px"></div>
                    <br />
                </li>
            </ul>
            <!-- <input type="submit" value="注册" class="btn-submit" style="width:80px; height:30px; margin-bottom:30px; margin-left:20%" onclick="btnRegister_Click" tabindex="9"/> -->
            <asp:Button Text="注册" runat="server" class="btn-submit" style="width:80px; height:30px; margin-bottom:30px; margin-left:20%" OnClick="Register_Click" tabindex="9"/>
            <div class="ad_box">
                <p>你看到了一个广告</p>
            </div>
        </div>
    <div class="foot_box">
    <a style="margin:auto">Copyright &copy; 2014- MEEBO 清华大学软件学院<span style="margin-left: 4em">尚未提交审查</span></a>
    </div>
    </form>
</body>
</html>
