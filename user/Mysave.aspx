﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MySave.aspx.cs" Inherits="user_MySave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的收藏</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
         .upper_message {width:100%;height:40px;font-size:10px;position:relative}
        .at_tips{width:40%;font-size:10px;float:left;padding:5px 5px;margin-left:5px;color:#888888}
        .news_box{width:40%;font-size:10px;float:right;text-align:right;padding:5px 5px;margin-right:5px}
        .at_box {width:100%}
        .single_at{width:80%;margin:auto;padding:10px 10px}
        .at_a {text-decoration:underline;}
        .at_info{width:100%;position:relative}
        .at_head{width:60px;float:left}
        .head_img0{width:50px;height:50px}
        .at_content{width:500px;float:left}
        .who_at{width:100%}
        .at_what{width:100%;font-size:12px}
        .at_detail{width:100%;font-size:8px;text-align:right;margin-top:30px}
    </style>
    <script type="text/javascript" src="js/MySave.js"></script>
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
                    <div class="left_item_word strongPage">我的收藏</div></a>
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
                    您一共收藏了这些消息。
                </div>
                <div class="news_box">
                    <a>号外：八次男神宣布进入歌唱界！</a>
                </div>
            </div>
            <div class="MeeBo_Box">
                <div class="single_MeeBo">
                    <div class="MeeBo_user">
                        <div class="head_potrait">
                            <img class="potrait_img" src="../image/head_potrait.jpg"/>
                        </div>
                    </div>
                    <div class="MeeBo_content">
                        <div class="user_id">
                            <a>黑黑的张导</a>
                        </div>
                        <div class="text_content">
                            嘿嘿嘿嘿
                        </div>
                        <div class="picture_content">
                            <div class="MeeBo_img">
                                <img class="MeeBo_img" src="./image/logo.jpg"/>
                            </div>
                            <div class="MeeBo_img">
                                <img class="MeeBo_img" src="./image/logo.jpg"/>
                            </div>
                            <div class="MeeBo_img">
                                <img class="MeeBo_img" src="./image/logo.jpg"/>
                            </div>
                             <div class="MeeBo_img">
                                <img class="MeeBo_img" src="./image/logo.jpg"/>
                            </div>
                             <div class="MeeBo_img">
                                <img class="MeeBo_img" src="./image/logo.jpg"/>
                            </div>
                        </div>
                        <div class="MeeBo_detail">
                            <div class="MeeBo_time">
                                今天15:11
                            </div>
                            <div class="CTA">
                                <a>赞</a>(100)|<a>转发</a>(2)|<a>评论</a>(3)|<a>收藏</a>(3)
                            </div>
                        </div>
                    </div>
                </div>
                <hr class="line3" />
            </div>
        </div>
        <div class="right_column">
        </div>
    </div>
          </form>
</body>
</html>
