<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeeBoComment.aspx.cs" Inherits="user_MeeBoComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>评论页面</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
     <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .Comment_Box {width:100%;margin:auto;margin-top:45px}
        .single_Comment{width:90%;margin:auto;position:relative;margin-top:15px}
        .Comment_user {width:60px;float:left;padding-top:5px}
        .Comment_img{width:40px;height:40px}
        .Comment_content {width:570px;float:left}
        .Comment_userID {width:100%;font-size:20px;}
        .Comment_text{width:100%;font-size:15px;color:#777777}
        .Comment_detail {width:100%;position:relative}
        .Comment_time{width:30%;float:left}
        .Comment_floor{width:30px;float:right}
        .detail_font{width:100%;font-size:8px}
        .trans_or_com{width:100%;position:relative;height:25px}
        .choose{width:160px;float:left;font-size:8px}
        .queren{width:65px;float:right}
    </style>
     <script type="text/javascript" src="js/MeeboComment.js"></script>
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
                            <asp:Button ID="submit_find" Text="查找" runat="server" style="width:40px; height:20px;" tabindex="2" OnClick="search_click"/>
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
            </div>
            <br />
            <hr class="line2"/>
            <div class="send_MeeBo_Box">
                    <div class="send_box">
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" style="width:100%; height:120px"/>
                        <div class="trans_or_com">
                            <div class="choose">
                                <asp:RadioButtonList ID="send_type" runat="server" Height="20px" RepeatDirection="Horizontal" Width="150px">
                                    <asp:ListItem Value="1">评论</asp:ListItem>
                                    <asp:ListItem Value="0">转发</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="queren">
                                <asp:Button ID="post" Text="发布" runat="server" style="width:60px;height:20px" OnClick="post_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            <div class="Comment_Box">
                <div class="single_Comment">
                    <div class="Comment_user">
                        <div class="Comment_head">
                            <img class="Comment_img" src="../image/head_potrait.jpg"/>
                        </div>
                    </div>
                    <div class="Comment_content">
                        <div class="Comment_userID">
                            <a>ohahaha</a>
                        </div>
                        <div class="Comment_text">
                            嗯
                        </div>
                        <div class="Comment_detail">
                            <div class="Comment_time">
                                <p class="detail_font">今天12:11</p>
                            </div>
                            <div class="Comment_floor">
                                <p class="detail_font">1楼</p>
                            </div>
                        </div>
                    </div>
                    <br />
                    <hr class="line3" />
                </div>
            </div>
        </div>
        <div class="right_column">
        </div>
    </div>
        <asp:LinkButton runat="server" ID="zan_btn" OnClick="zan_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="repost_btn" OnClick="repost_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="comment_btn" OnClick="comment_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="save_btn" OnClick="save_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="user_btn" OnClick="user_Click"></asp:LinkButton>

    </form>
</body>
</html>
