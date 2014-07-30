﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotUser.aspx.cs" Inherits="hot_hotUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>热门用户</title>
    <link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .hot_user_box{width:100%;padding-top:5px 10px}
        .ad_box{width:100%;position:relative;height:20px;}
        .left_ad{float:left;font-size:10px;color:#888888;padding-left:10px;}
        .right_ad{float:right;font-size:10px;padding-right:10px}
        .hot_user_item{width:700px;position:relative}
        .hot_user_title{width:100%;margin-bottom:10px;padding-left:30px;font-size:15px}
        .hot_users{width:310px;float:left;margin-left:30px;margin-bottom:30px;position:relative;height:150px;border:1px solid gray}
        .hot_user_head{width:70px;float:left;position:relative}
        .hot_user_img{width:50px;height:50px;margin-top:20px;margin-left:10px}
        .hot_user_info{width:240px;height:200px;float:left}
        .hot_user_name{width:100%;height:50px;padding-top:20px}
        .hot_user_describe{width:100%;height:50px;}
        .hot_user_detail{width:100%;height:30px;}
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
                    <div class="left_item_word">热门话题</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="hotUser.aspx"><span class="fa fa-child icon"></span>
                    <div class="left_item_word strongPage">热门用户</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="hot.aspx"><span class="fa fa-fire icon"></span>
                    <div class="left_item_word">热门微博</div></a>
                    </div>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
            <div class="hot_user_box">
                <div class="ad_box">
                    <div class="left_ad">这里您可以看到最近最热门的用户</div>
                    <div class="right_ad">帮助？</div>
                </div>
                <div class="hot_user_item">
                    <div class="hot_user_title">
                        人气最高的用户:
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="hot_user0" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail" runat="server">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img1" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="hot_user1" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img2" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="A1" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img3" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="A2" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img4" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="A3" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img5" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="A4" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img6" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="A5" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
                    </div>
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img7" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                        </div>
                        <div class="hot_user_info">
                            <div class="hot_user_name">
                                <a id="A6" runat="server">耿米多维奇</a>
                            </div>
                            <div class="hot_user_describe">
                                这个人很懒，什么都没留下
                            </div>
                            <div class="hot_user_detail">
                                关注5|粉丝100|MeeBo20
                            </div>
                        </div>
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


