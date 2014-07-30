<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtMe.aspx.cs" Inherits="user_AtMe" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>提到我的</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
     <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
         .upper_message {width:100%;height:40px;font-size:10px;position:relative}
        .at_tips{width:40%;font-size:10px;float:left;padding:5px 5px;margin-left:5px;color:#888888}
        .news_box{width:40%;font-size:10px;float:right;text-align:right;padding:5px 5px;margin-right:5px}
        .at_box {width:100%}
        .single_at{width:80%;margin:auto;padding:10px 10px}
        .at_a {text-decoration:underline;cursor:pointer;}
        .at_info{width:100%;position:relative}
        .at_head{width:60px;float:left}
        .head_img0{width:50px;height:50px}
        .at_content{width:500px;float:left}
        .who_at{width:100%}
        .at_what{width:100%;font-size:12px}
        .at_detail{width:100%;font-size:8px;text-align:right;margin-top:30px}
    </style>
    <script type="text/javascript" src="js/getAtMe.js"></script>
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
                    <div class="left_item_word strongPage">提到我的</div></a>
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
                    最近，有这些人提到了你哦！
                </div>
                <div class="news_box">
                    <a>号外：八次男神宣布进入歌唱界！</a>
                </div>
            </div>
            <div class="at_box">
                <div class="single_at">
                    <div class="at_info">
                        <div class="at_head">
                            <img class="head_img0" src="../image/head_potrait.jpg" />
                        </div>
                        <div class="at_content">
                            <div class="who_at">
                                <a id="user1" class="at_a">黑黑的张导</a>消息<a id="content1" class="at_a">nimas...</a>中提到了你。
                            </div>
                        </div>
                    </div>
                    <div class="at_detail">
                        前天10:11
                    </div>
                </div>
                <hr class="line2" />
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
        <asp:LinkButton runat="server" ID="go_user_btn" OnClick="go_user_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="go_MeeBo_btn" OnClick="go_MeeBo_Click"></asp:LinkButton>
        </form>
</body>
</html>