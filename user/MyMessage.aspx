<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyMessage.aspx.cs" Inherits="user_MyMessage" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的私信</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .user_name {padding-top:0px}
    </style>
    <script type="text/javascript" src="js/MyMessage.js"></script>
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
                    <div class="left_item_word strongPage">我的私信</div></a>
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
                    <a style="color:#888888">有什么话想对人说吗？</a>
                </div>
                <div class="send_hot">
                    <a style="font-size:12px">今日热门：八次男神宣布将再战影视圈!!</a>
                </div>
                <div class="send_box">
                    <asp:TextBox ID="send_content" runat="server" TextMode="MultiLine" style="width:99%; height:120px"/>
                    <div class="select_whom">你想发送给：</div>
                    <asp:TextBox ID="send_target" runat="server" style="width:100px;float:left"/>
                    <asp:Button ID="send_out" Text="发起私信" runat="server" style="width:70px; float:right" OnClick="send_out_Click"/>
                </div>
            </div>
              <div class="middle_title">
                <p class="middle_title_text">收到的私信</p>
                <div class="middle_title_bottom​" style="margin-left:15px;"></div>
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
                            <a class="user_name">黑黑的张导</a>
                        </div>
                        <div class="text_content">
                            嘿嘿嘿嘿
                        </div>
                        <div class="MeeBo_detail">
                            <div class="see_Message">
                                <asp:Button ID="See_Message" Text="查看详细" runat="server" style="width:80px; float:right" OnClick="See_Message_Click"/>
                            </div>
                            <div class="Message_time">
                                今天15:11
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
                        <p style="text-align:center"><asp:Image ID="head_potrait" runat="server" ImageUrl="~/image/head_potrait.jpg" style="height: 80px; width: 80px"/></p>
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
         
         <asp:LinkButton runat="server" ID="see_detail_btn" OnClick="see_detail_btn_Click"></asp:LinkButton>
     </form>
</body>
</html>