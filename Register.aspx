 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/frame.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .background {background: #c8e1f0}
        .header {width: 86%; margin: auto;}
        .register_box {width: 86%; margin: auto; background:#fefefe;}
        .infomation_list {width: 80%; margin: auto;}
    </style>
    <title>注册MeeBo-分享身边的新鲜事儿</title>
</head>
<body class="background">
    <div class="header">
		<img src="image/logo.jpg" alt="logo(MeeBo)" />
    </div>
    <div class="register_box">
        <p>填写以下信息来加入我们：</p>
        <ul class="infomation_list">
            <li>
                <label>*用户名：</label>
                <input id="password" name="password" type="password" class="W_input" maxlength="20" tabindex="2"/>
            </li>
        </ul>
    </div>
</body>
</html>
