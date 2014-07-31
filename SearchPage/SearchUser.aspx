<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="SearchPage_SearchUser" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>搜索用户</title>
<link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../user/css/another.css" type="text/css" rel="stylesheet" />
    <link href="css/Search.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
    </style>
    <script type="text/javascript" src="../user/js/getUsers.js"></script>
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
                            <asp:ImageButton ID="submit_find" ImageUrl="~/image/search.png" runat="server" OnClick="search_click" style="width:25px; height:25px;" tabindex="2"/>
                        </th>
                    </tr>
                 </table>
             </div>
             <a class="headout" href="../Login.aspx"> 
            </a>
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
                        <a><div class="now_choose">找人</div></a>
                    </div>
                    <div class="type_item">
                        <a href="SearchTopic.aspx"><div class="no_choose">话题</div></a>
                    </div>
                    <div class="type_item">
                        <a href="../hot/hot.aspx"><div class="no_choose">热门</div></a>
                    </div>
                </div>
                <div class="search_text_box">
                    <asp:TextBox ID="search_content" runat="server" Width="400px" Height="20px"/>
                </div>
                <div class="search_button_box">
                    <asp:Button ID="go_search" Text="查找" runat="server" style="width:50px; height:26px;" OnClick="go_search_Click"/>
                </div>
            </div>
            <div class="hot_user_box">
                <div class="hot_user_item">
                    <div class="hot_user_title">
                        以下是搜索结果：
                    </div>
                    <div class="hot_user_container">
                        <div class="hot_users">
                            <div class="hot_user_head">
                                <img id="Img1" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
                            </div>
                            <div class="hot_user_info">
                                <div class="hot_user_name">
                                    <a id="hot_user0" runat="server">耿米多维奇</a>
                                </div>
                                <div class="hot_user_describe">
                                    这个人很懒，什么都没留下
                                </div>
                                <div id="Div1" class="hot_user_detail" runat="server">
                                    关注5|粉丝100|MeeBo20
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
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
        <asp:LinkButton runat="server" ID="getUser_btn" OnClick="go_user_Click"></asp:LinkButton>
   </form>
</body>
</html>