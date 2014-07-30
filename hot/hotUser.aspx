<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotUser.aspx.cs" Inherits="hot_hotUser" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>热门用户</title>
    <link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../user/css/another.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
    </style>
    
    <script type="text/javascript" src="../user/js/getUsers.js"></script>
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
                                <div class="hot_user_detail_item">关注5</div>
                                <div class="hot_user_detail_item">粉丝100</div>
                                <div class="hot_user_detail_item_right">MeeBo20</div>
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
        <asp:LinkButton runat="server" ID="getUser_btn" OnClick="go_user_Click"></asp:LinkButton>
        </form>
</body>
</html>


