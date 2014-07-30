<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyFans.aspx.cs" Inherits="user_MyFans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的粉丝</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .upper_message {width:100%;height:40px;font-size:10px;position:relative}
        .at_tips{width:40%;font-size:10px;float:left;padding:5px 5px;margin-left:5px;color:#888888}
        .news_box{width:40%;font-size:10px;float:right;text-align:right;padding:5px 5px;margin-right:5px}
        .hot_user_box{width:100%;padding-top:5px 10px}
        .ad_box{width:100%;position:relative;height:20px;}
        .left_ad{float:left;font-size:10px;color:#888888;padding-left:10px;}
        .right_ad{float:right;font-size:10px;padding-right:10px}
        .hot_user_item{width:700px;position:relative}
        .hot_user_title{width:100%;margin-bottom:10px;padding-left:30px;font-size:15px;margin-top:30px}
        .hot_users{width:310px;float:left;margin-left:30px;margin-bottom:30px;position:relative;height:150px;border:1px solid gray;border-radius:10px;background:#f0f0f0}
        .hot_user_head{width:70px;float:left;position:relative}
        .hot_user_img{width:50px;height:50px;margin-top:20px;margin-left:10px}
        .hot_user_info{width:240px;height:200px;float:left}
        .hot_user_name{width:100%;height:50px;padding-top:20px}
        .hot_user_describe{width:100%;height:50px;}
        .hot_user_detail{width:100%;height:30px;}
    </style>
    <script type="text/javascript" src="js/getMyLikes.js"></script>
</head>
<body class="background">
     <form id="Form2" name="search" method="post" runat="server">
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
        <div class="left_column">
            <div class="left_item">
                <div class="left_item_a">
                <a href="PersonalPage.aspx"><span class="fa fa-home icon"></span>
                    <div class="left_item_word">首页</div></a>
                    </div>
            </div>
            <hr class="line" />
            <div class="left_item">
                <div class="left_item_a">
                 <a href="CommentMe.aspx"><span class="fa fa-comments icon"></span>
                    <div class="left_item_word">评论我的</div></a>
                    </div>
                 <div class="left_item_a">
                 <a href="AtMe.aspx"><span class="fa fa-paw icon"></span>
                    <div class="left_item_word">提到我的</div></a>
                    </div>
                 <div class="left_item_a">
                 <a href="ZanMe.aspx"><span class="fa fa fa-thumbs-up icon"></span>
                    <div class="left_item_word">赞</div></a>
                  </div>
                 <div class="left_item_a">
                 <a href="MySave.aspx"><span class="fa fa-heart icon"></span>
                    <div class="left_item_word">我的收藏</div></a>
                  </div>
            </div>
            <hr class="line" />
            <div class="left_item">
                <div class="left_item_a">
                 <a href="MyMessage.aspx"><span class="fa fa-paper-plane icon"></span>
                    <div class="left_item_word">我的私信</div></a>
                  </div>
                <div class="left_item_a">
                 <a href="MyMeeBo.aspx"><span class="fa fa-folder-open icon"></span>
                    <div class="left_item_word">我的MeeBo</div></a>
                  </div>
            </div>
            <hr class="line" />
            <div class="left_item">
                <div class="left_item_a">
                 <a href="MyTeam.aspx"><span class="fa fa-star icon"></span>
                    <div class="left_item_word">分组</div></a>
                  </div>
            </div>
            <hr class="line" />
            <div class="left_item">
                <div class="left_item_a">
                 <a href="UserInfo.aspx"><span class="fa fa-info-circle icon"></span>
                    <div class="left_item_word">个人信息</div></a>
                  </div>
                <div class="left_item_a">
                 <a href="ChangePassword.aspx"><span class="fa fa-unlock-alt icon"></span>
                    <div class="left_item_word">修改密码</div></a>
                  </div>
            </div>
        </div>
        <div class="middle_column">
            <div class="upper_message">
                <div class="at_tips">
                    您有这些粉丝哦！
                </div>
                <div class="news_box">
                    <a>号外：八次男神宣布进入歌唱界！</a>
                </div>
            </div>
            <div class="hot_user_box">
                <div class="hot_user_item">
                    <div class="hot_user_title">
                        您的粉丝:
                    </div>
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
                    <div class="hot_users">
                        <div class="hot_user_head">
                            <img id="Img2" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
                            <img id="Img3" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
                            <img id="Img4" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
                            <img id="Img5" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
                            <img id="Img6" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
                            <img id="Img7" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
                            <img id="Img8" runat="server" src="../image/head_potrait.jpg" class="hot_user_img" />
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
            <div class="right_item">
                <div class ="person_info">
                    <div class ="person_img">
                        <asp:Image ID="head_potrait" runat="server" ImageUrl="~/image/head_potrait.jpg" style="height: 80px; width: 80px"/>
                    </div>
                    <div class ="person_nickname">
                         <a id="myName" href="MyMeeBo.aspx" runat="server">黑黑的张导</a>
                        </div>
                    </div>
                <ul class= "person_data">
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number" runat="server" id="LikeNum">
                                10
                                </div>
                            <div>
                                <a class ="person_data_name">关注</a>
                            </div>
                            </a>
                        </li>
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number" runat="server" id="FansNum">
                                15
                                </div>
                            <div>
                                <a class ="person_data_name">粉丝</a>
                                </div>
                            </a>
                        </li>
                    <li class= "data_li_noright">
                        <a>
                            <div class ="person_data_number" runat="server" id="MeeBoNum">
                                5
                                </div>
                            <div>
                                <a class ="person_data_name">微博</a>
                                </div>
                            </a>
                        </li>
                    </ul>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
