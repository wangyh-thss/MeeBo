<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OthersPage.aspx.cs" Inherits="user_OthersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看其他用户</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <link href="css/another.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
    </style>
    <script type="text/javascript" src="js/MyAndOtherPage.js"></script>
    <style>.trans_content{width:630px;float:left}
        .trans_userid{width:630px;font-size:15px;margin-bottom:5px}
        .trans_com{width:630px;font-size:12px;margin-bottom:5px}
        .origin_content {
float: left;
position: relative;
width: 590px;
border: 1px solid #888888;
margin: 10px 10px;
padding: 5px 15px;
background: #fafafa;
border-radius: 10px;
margin-left:0px;
}
    </style>
</head>
<body class="background">
    <form id="form1" runat="server">
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
             <a class="headout" href="../Login.aspx"> 
            </a>
        </div>
    </div>
    <div class="wrapper">
        <div class="user_info">
            <div class="user_head">
                <!-- <img src="../image/head_potrait.jpg" class="user_head_potrait" /> -->
                <asp:Image ID="userHead" ImageUrl="../image/head_potrait.jpg" runat="server" class="user_head_potrait" />
                <div class="user_community">
                    <ul class= "person_data">
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number" id="likesNum" runat="server">
                                10
                                </div>
                            <div>
                                <a class ="person_data_name">关注</a>
                            </div>
                            </a>
                        </li>
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number" id="fansNum" runat="server">
                                15
                                </div>
                            <div>
                                <a class ="person_data_name">粉丝</a>
                                </div>
                            </a>
                        </li>
                    <li class= "data_li_noright">
                        <a>
                            <div class ="person_data_number" id ="newsNum" runat="server">
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
            <div class="user_about">
                <div class="user_name">
                    <a id="user_nickname" style="font-size:25px" runat="server">黑黑的张导</a>
                </div>
                <div class="like_button">
                    <asp:Button ID="like" Text="+关注" runat="server" style="width:70px;margin-top:5px" OnClick="like_Click"/>
                </div>
                <div class="user_describe">
                    <p>这个人很懒，什么都没留下（您可以通过发送私信的方式联系他来填写个人简介）</p>
                </div>
                <div class="user_tag">
                    <div class="user_gender">
                        <p>性别：<span id="gender" runat="server">男</span></p>
                    </div>
                    <div class="user_birthday">
                        <p>生日：<span id="birthday" runat="server">XXXX年XX月XX日</span></p>
                    </div>
                </div>
            </div>
        </div>
        <div class="user_MeeBo">
            <div class="MeeBo_Box">
                <div class="single_MeeBo">
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
                <hr class="line2" />
            </div>
        </div>
        <div class="something_else">
            <div class="interest">
                <p>猜您可能喜欢：</p>
                <div class="interest_list">
                    <div class="interest_item">
                        <a>·嘿嘿嘿嘿</a>
                    </div>
                    <div class="interest_item">
                        <a>·嘿嘿嘿嘿</a>
                    </div>
                    <div class="interest_item">
                        <a>·嘿嘿嘿嘿</a>
                    </div>
                </div>
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
