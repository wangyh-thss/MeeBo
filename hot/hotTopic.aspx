﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotTopic.aspx.cs" Inherits="hot_hotTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>热门话题</title>
    <link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
    </style>
</head>
<body class="background">
   <form id="Form1" name="form" method="post" runat="server">
    <div class="header">
        <div class="headbody">
            <div class="logo">
		        <p class="logoText">MeeBo</p>
            </div>
            <div class="head_list">
                <div class="head_item">
                    <a style="color: #fefefe" href="../user/PersonalPage.aspx">首页</a>
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
                <br />
                <a class="p2" href="hotTopic.aspx" style="color: red">热门话题</a><br /><br/>
                <a class="p2" href="hotUser.aspx">热门用户</a><br /><br/>
                <a class="p2" href="hot.aspx">热门微博</a><br /><br/>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
        </div>
        <div class="right_column">
        </div>
    </div>
       </form>
</body>
</html>

