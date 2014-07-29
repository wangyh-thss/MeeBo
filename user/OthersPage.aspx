<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OthersPage.aspx.cs" Inherits="user_OthersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看其他用户</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .user_MeeBo {width:650px;height:800px;margin-left:45px;float:left;background:#fafafa}
        .user_info{width:350px;height:800px;margin-left:5px;float:left;background:#f0f0f0}
    </style>
</head>
<body class="background">
    <form id="form1" runat="server">
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
        <div class="user_MeeBo">
        </div>
        <div class="user_info">
        </div>
    </div>
    </form>
</body>
</html>
