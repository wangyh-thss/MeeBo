<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PersonalPage.aspx.cs" Inherits="user_PersonalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人主页</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/getMeeBo.js"></script>
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
                            <asp:ImageButton ID="submit_find" ImageUrl="~/image/search.png" runat="server" OnClick="search_click" style="width:25px; height:25px;" tabindex="2"/>
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
                    <div class="left_item_word strongPage">首页</div></a>
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
            <div class="send_MeeBo_Box">
                <div class="send_title">
                    <a style="color:#888888">有什么新鲜事想分享吗？</a>
                </div>
                <div class="send_hot">
                    <a style="font-size:12px">今日热门：八次男神宣布将再战影视圈!!</a>
                </div>
                <div class="send_box">
                    <asp:TextBox ID="send_content" runat="server" TextMode="MultiLine" style="width:100%; height:120px"/>
                    <asp:FileUpload ID="SelectImg" Text="发布图片" runat="server" Width="70px" style="float:left;margin-left:3%" onchange="javascript:__doPostBack('UploadImg','')"/>
                    <asp:Button ID="send_out" Text="发布" runat="server" style="width:60px; margin-left:70%" OnClick="SendOut_Click"/>
                </div>
                <div class="picture_view">
                    <!--在此动态添加图片-->
                    <!--示例>
                        <div class="single_pic_view">
                            <asp:Image ID="pic_view1" runat="server" ImageUrl="~/image/head_potrait.jpg" style="height: 50px; width: 50px"/>
                        </div>
                    <-->
                </div>
            </div>
             <hr class="line2"/>
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
                        <a class="right_item_a" href="MyLikes.aspx">
                            <div class ="person_data_number" runat="server" id="LikeNum">
                                10
                                </div>
                            <div class ="person_data_name">关注</div>
                            </a>
                        </li>
                    <li class= "data_li">
                        <a  class="right_item_a" href="MyFans.aspx">
                            <div class ="person_data_number" runat="server" id="FansNum">
                                15
                                </div>
                            <div class ="person_data_name">粉丝</div>
                            </a>
                        </li>
                    <li class= "data_li_noright">
                        <a class="right_item_a" href="MyMeeBo.aspx">
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

    </form>
    
</body>
</html>
