﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZanMe.aspx.cs" Inherits="user_ZanMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>给我点赞的</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
</head>
<body class="background">
    <div class="header">
        <div class="logo">
		    <p style="padding:0px 0px 0px 0px; line-height: 0px;">MeeBo</p>
        </div>
        <div class="head_list">
              <div class="head_item">
                <a style="color: #fefefe" href="PersonalPage.aspx">首页</a>
            </div>
            <div class="head_item">
                <a>|</a>
            </div>
            <div class="head_item">
                <a style="color: #fefefe" href="../hot/hot.aspx">热门</a>
            </div>
            <div class="head_item">
                <a>|</a>
            </div>
            <div class="head_item">
                <a style="color: #fefefe" href="../hot/hotTopic.aspx">话题</a>
            </div>
            <div class="head_item">
                <a>|</a>
            </div>
            <div class="head_search">
                <form id="Form1" name="search" method="post" runat="server">
                    <table style=" margin-top:-5px;">
                        <tr><th>
                            <asp:TextBox ID="find_content" runat="server" maxlength="20" tabindex="1" style="margin-bottom:10px;" />
                        </th>
                        <th>
                            <asp:Button ID="submit_find" Text="查找" runat="server" style="width:40px; height:20px;margin-bottom:10px;" tabindex="2"/>
                        </th></tr>
                    </table>
                </form>
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
                <a class="p2" href="ZanMe.aspx" style="color: red">赞</a><br /><br/>
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
                <a class="p2" href ="UserInfo.aspx">个人信息</a><br /><br/>
                <a class="p2" href ="ChangePassword.aspx">修改密码</a><br /><br/>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
        </div>
        <div class="right_column">
            <div class="right_item">
                <div class ="person_info">
                    <div class ="person_img">
                        <img class="person_potrait_img" src="../image/head_potrait.jpg"/>
                        </div>
                    <div class ="person_nickname">
                         <a>黑黑的张导</a>
                        </div>
                    </div>
                <ul class= "person_data">
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number">
                                10
                                </div>
                            <div class ="person_data_name">
                                关注
                                </div>
                            </a>
                        </li>
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number">
                                15
                                </div>
                            <div class ="person_data_name">
                                粉丝
                                </div>
                            </a>
                        </li>
                    <li class= "data_li_noright">
                        <a>
                            <div class ="person_data_number">
                                5
                                </div>
                            <div class ="person_data_name">
                                微博
                                </div>
                            </a>
                        </li>
                    </ul>
            </div>
        </div>
    </div>
</body>
</html>