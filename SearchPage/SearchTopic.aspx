﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTopic.aspx.cs" Inherits="SearchPage_SearchTopic" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>搜索热门话题</title>
<link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../user/css/another.css" type="text/css" rel="stylesheet" />
    <link href="css/Search.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../user/js/getMeeBo.js"></script>
    <style type="text/css">
    </style>
    <script type="text/javascript" src="../user/js/getMeeBo.js"></script>
</head>
<body class="background">
    <form id="Form2" name="form" method="post" runat="server">
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
                <a href="../hot/hotTopic.aspx"><span class="fa fa-bullhorn icon"></span>
                    <div class="left_item_word">热门话题</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="../hot/hotUser.aspx"><span class="fa fa-child icon"></span>
                    <div class="left_item_word">热门用户</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="../hot/hot.aspx"><span class="fa fa-fire icon"></span>
                    <div class="left_item_word">热门微博</div></a>
                    </div>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
            <div class="search_box">
                <div class="search_type">
                    <div class="type_item">
                        <a href="SearchMeeBo.aspx"><div class="no_choose">微博</div></a>
                    </div>
                    <div class="type_item">
                        <a href="SearchUser.aspx"><div class="no_choose">找人</div></a>
                    </div>
                    <div class="type_item">
                        <a><div class="now_choose">话题</div></a>
                    </div>
                    <div class="type_item">
                        <a href="../hot/hot.aspx"><div class="no_choose">热门</div></a>
                    </div>
                </div>
                <div class="search_text_box">
                    <asp:TextBox ID="search_content" runat="server" Width="400px" Height="20px"/>
                </div>
                <div class="search_button_box">
                    <asp:Button ID="go_search" Text="查找" runat="server" style="width:50px; height:26px;"/>
                </div>
            </div>
            <div class="MeeBo_Box">
            </div>
            <!--
            <div class="topic_container">
                <div class="hot_topic_title">
                    最近热门话题
                </div>
                <div class="topic_box" runat="server">
                    <div class="topic_item">
                        ·<a runat="server">#红红火火#（近日最火话题！！！）</a>
                    </div>
                    <div class="topic_item">
                        ·<a runat="server">#恍恍惚惚#（原本是描述精神状态的词，近日在网络上爆红）</a>
                    </div>
                    <div class="topic_item">
                        ·<a runat="server">#哈哈哈哈#（根本停不下来）</a>
                    </div>
                    <div class="topic_item">
                        ·<a runat="server">#火火火火#（你还记得大明湖畔的小苹果吗？）</a>
                    </div>
                </div>
            </div>
            -->
        </div>
        <div class="right_column">
            <div class="right_item">
                <div class ="person_info">
                    <div class ="person_img">
                        <p style="text-align:center"><asp:Image ID="head_potrait" runat="server" ImageUrl="~/image/head_potrait.jpg" style="height: 80px; width: 80px"/></p>
                    </div>
                    <div class ="person_nickname">
                         <a id="myName" href="MyMeeBo.aspx" runat="server">黑黑的张导</a>
                        </div>
                    </div>
                <ul class= "person_data">
                    <li class= "data_li">
                        <a class="right_item_a" href="../user/MyLikes.aspx">
                            <div class ="person_data_number" runat="server" id="LikeNum">
                                10
                                </div>
                            <div class ="person_data_name">关注</div>
                            </a>
                        </li>
                    <li class= "data_li">
                        <a  class="right_item_a" href="../user/MyFans.aspx">
                            <div class ="person_data_number" runat="server" id="FansNum">
                                15
                                </div>
                            <div class ="person_data_name">粉丝</div>
                            </a>
                        </li>
                    <li class= "data_li_noright">
                        <a class="right_item_a" href="../user/MyMeeBo.aspx">
                            <div class ="person_data_number" runat="server" id="MeeBoNum">
                                5
                                </div>
                            <div class ="person_data_name">微博</div>
                            </a>
                        </li>
                    </ul>
            </div>
        </div>
    </div>
        <asp:LinkButton runat="server" ID="zan_btn" OnClick="zan_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="repost_btn" OnClick="repost_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="comment_btn" OnClick="comment_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="save_btn" OnClick="save_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="go_user_btn" OnClick="go_user_Click"></asp:LinkButton>
   </form>
</body>
</html>