﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotTopic.aspx.cs" Inherits="hot_hotTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>热门话题</title>
    <link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../user/css/another.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
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
                <div class="left_item_a">
                <a href="../user/PersonalPage.aspx"><span class="fa fa-home icon"></span>
                    <div class="left_item_word">首页</div></a>
                    </div>
            </div>
            <hr class="line" />
            <div class="left_item">
                 <div class="left_item_a">
                <a href="hotTopic.aspx"><span class="fa fa-bullhorn icon"></span>
                    <div class="left_item_word strongPage">热门话题</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="hotUser.aspx"><span class="fa fa-child icon"></span>
                    <div class="left_item_word">热门用户</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="hot.aspx"><span class="fa fa-fire icon"></span>
                    <div class="left_item_word">热门微博</div></a>
                    </div>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
            <div class="ad_box">
                <div class="left_ad">这里您可以看到最近最热门的话题</div>
                <div class="right_ad">帮助？</div>
            </div>
            <div class="topic_container">
                <div class="hot_topic_title">
                    最近热门话题
                </div>
                <div id="Div1" class="topic_box" runat="server">
                    <div class="topic_item">
                        ·<a id="A1" runat="server">#红红火火#（近日最火话题！！！）</a>
                    </div>
                    <div class="topic_item">
                        ·<a id="A2" runat="server">#恍恍惚惚#（原本是描述精神状态的词，近日在网络上爆红）</a>
                    </div>
                    <div class="topic_item">
                        ·<a id="A3" runat="server">#哈哈哈哈#（根本停不下来）</a>
                    </div>
                    <div class="topic_item">
                        ·<a id="A4" runat="server">#火火火火#（你还记得大明湖畔的小苹果吗？）</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="right_column">
        </div>
    </div>
       </form>
</body>
</html>

