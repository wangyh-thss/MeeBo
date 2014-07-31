 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/frame.css" type="text/css" rel="stylesheet" />
    <link href="css/register.css" type="text/css" rel="stylesheet" />
    <link href="css/login.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        label { display: inline-block; float:left; margin-right: 15px; text-align: right; width: 60px; font-size: 14px; line-height: 30px; vertical-align: baseline }
        .btn-submit { cursor: pointer;color: #ffffff;background: #e64141; border: 1px solid #528641; font-size: 14px; font-weight: bold; margin-left: 75px; border-radius: 3px; -moz-border-radius: 3px; -webkit-border-radius: 3px; *width: 100px;*height:30px; }
        .footer_nologin_new {background: #c8e1f0;}
        .slogan_read
        {
            padding: 17px 0 17px 0px;
            line-height: 20px;
            font-size:18px;
            font-family: "Microsoft Yahei";
            font-style: italic;
        }
    </style>
    <title>MeeBo-分享身边的新鲜事儿</title>
</head>
<body class="B_login ">
    <div class="W_nologin">
    	<div class="W_reg_header">
        	<div class="W_nologin_logo">
				<img src="image/logo.jpg" alt="logo(MeeBo)" />
			</div>
        </div>
        <div class="W_nologin_main">
			<div class="topboard">
				<a></a>
				<br />
				<style type="text/css">
					.W_nologin_main .topboard {background-image:url("image/nolog_head.jpg");}
				</style>
			</div>
            <div class="W_login_info clearfix">
				<div class="leftbox">
					<div class="slogan">
						还没有MeeBo帐号？现在加入						<a class="btn_reg_red" href="Register.aspx"><span>立即注册</span></a>
					</div>
					<div class="show_img"><img src="image/nolog_left.jpg" /></div>
                </div>
                <form id="lzform" name="lzform" method="post" action="login.aspx" runat="server">
				<div class="loginbox">
                    <div class="slogan_read">
						热门抢先看->				<a class="btn_reg_red"  href="hot/hot.aspx"><span style="width: 100px;height: 20px;line-height: 18px;">热门</span></a>
					</div>
                    <div class="login_switch" id="pl_login_form">
                        <div class="item">
                            <h4>用户登录：</h4>
                        </div>
                        <br />
                        <div class="item" style="margin-top: 20px">
                            <label>帐号</label>
                            <input id="user" name="user" type="text" class="W_input" maxlength="60"  tabindex="1"/>
                        </div>
                        <br />
                        <div class="item">
                            <label>密码</label>
                            <input id="password" name="password" type="password" class="W_input" maxlength="20" tabindex="2"/>
                        </div>
                        <br />
                        <div runat="server" id="error_label" style="color:red; height: 24px; margin-left:30%"></div>
                        <br />
                        <div class="item">
                            <input type="submit" value="登录" name="user_login" class="btn-submit" style="width:100px; height:30px; margin-left:20%" tabindex="3"/>
                        </div>
                    </div>
                </div>
                </form>
            </div>
        </div>
        <div class="footer_nologin_new">
                 <div class="help_link">
                 	<a target="_blank" href="about:blank">关于我们</a><i class="S_txt2">|</i>
                 	<a target="_blank" href="about:blank">使用帮助</a><i class="S_txt2">|</i>
                    <a target="_blank" href="about:blank">意见反馈</a>
                </div>
                <br />
                <a class="S_txt2">Copyright &copy; 2014-???? MEEBO 清华大学软件学院<span class="Icp">尚未提交审查</span></a>
            </div>
    </div>
</body>
</html>
