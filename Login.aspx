 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <form>
			用户：<input type="text" name="form_email"><br />
			密码：<input type="password" name="form_password">
		</form>
		<input type="submit" value="登录" name="user_login" class="btn-submit" tabindex="5"/>
    </div>
    </form>
</body>
</html>
