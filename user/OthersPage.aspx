<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OthersPage.aspx.cs" Inherits="user_OthersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查看其他用户</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .user_info{width:1005px;height:250px;margin-left:45px;float:left;background:#f5f5f5;margin-bottom:5px;position:relative}
        .user_MeeBo {width:750px;min-height:500px;margin-left:45px;float:left;background:#fafafa}
        .something_else{width:250px;min-height:500px;margin-left:5px;float:left;background:#f0f0f0}
        .user_head{width:150px;margin-left:50px;margin-right:50px;margin-top:25px;float:left;}
        .user_head_potrait{width:150px;height:150px;}
        .user_about{width:750px;height:200px;float:left;position:relative}
        .user_name{width:200px;height:50px;padding-top:25px;float:left }
        .like_button{width:500px;height:50px;margin-left:50px;padding-top:25px;float:left }
        .user_describe{width:750px;height:100px;}
        .user_tag{width:750px;height:50px;position:relative;font-size:15px;}
        .user_gender{width:250px;height:20px;float:left}
        .user_birthday{width:250px;height:20px;float:right}
        .user_community{width:750px;height:100px}
        .single_MeeBo{width:90%;margin-top:20px}
        .interest{width:230px;padding:10px 10px}
        .interest_list{width:100%;padding-left:2em}
        .interest_item{width:100%;margin-top:15px}
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
                            <asp:Button ID="submit_find" Text="查找" runat="server" style="width:40px; height:20px;" tabindex="2"/>
                        </th>
                    </tr>
                 </table>
             </div>
        </div>
    </div>
    <div class="wrapper">
        <div class="user_info">
            <div class="user_head">
                <img src="../image/head_potrait.jpg" class="user_head_potrait" />
                <div class="user_community">
                    <ul class= "person_data">
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number">
                                10
                                </div>
                            <div>
                                <a class ="person_data_name">关注</a>
                            </div>
                            </a>
                        </li>
                    <li class= "data_li">
                        <a>
                            <div class ="person_data_number">
                                15
                                </div>
                            <div>
                                <a class ="person_data_name">粉丝</a>
                                </div>
                            </a>
                        </li>
                    <li class= "data_li_noright">
                        <a>
                            <div class ="person_data_number">
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
                    <a id="user_nickname" style="font-size:25px">黑黑的张导</a>
                </div>
                <div class="like_button">
                    <asp:Button ID="like" Text="+关注" runat="server" style="width:60px;margin-top:5px"/>
                </div>
                <div class="user_describe">
                    <p>这个人很懒，什么都没留下（您可以通过发送私信的方式联系他来填写个人简介）</p>
                </div>
                <div class="user_tag">
                    <div class="user_gender">
                        <p>性别：男</p>
                    </div>
                    <div class="user_birthday">
                        <p>生日：XXXX年XX月XX日</p>
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
    </form>
</body>
</html>
