<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchMeebo.aspx.cs" Inherits="SearchPage_SearchMeebp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>搜索MeeBo</title>
    <link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../user/js/getMeeBo.js"></script>
    <style type="text/css">
        .search_box{width:700px;overflow:hidden;position:relative}
        .search_text_box{width:400px;float:left;margin-left:100px}
        .search_button_box{width:150px;float:left;margin-left:50px}
        .search_type{width:700px;height:30px;position:relative;padding-left:100px;margin-bottom:15px}
        .type_item{width:50px;margin-right:50px;float:left}
        .now_choose{font-family:"微软雅黑";color:red;font-size:20px}
        .no_choose{font-family:"微软雅黑";font-size:20px}
        .trans_MeeBo{position:relative;width:630px;overflow:hidden;border-bottom-width: 2px;
    border-bottom-style: solid;
    border-color: #e6e6e6;}
        .trans_user_head{width:70px;float:left}
        .trans_content{width:560px;float:left}
        .trans_userid{width:560px;font-size:15px;margin-bottom:5px}
        .trans_com{width:560px;font-size:12px;margin-bottom:5px}
        .origin_content{float:left;position:relative;width:500px;border:1px solid #888888;margin:10px 10px;padding:5px 15px;background: #fafafa;border-radius: 10px;}
    </style>
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
                        <a><div class="now_choose">微博</div></a>
                    </div>
                    <div class="type_item">
                        <a href="SearchUser.aspx"><div class="no_choose">找人</div></a>
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
                    <asp:Button ID="go_search" Text="查找" runat="server" style="width:50px; height:26px;"/>
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
                <div class="trans_MeeBo">
                    <div class="trans_user_head">
                        <img class="head_potrait" src="../image/head_potrait.jpg" />
                    </div>
                    <div class="trans_content">
                        <div class="trans_userid">
                            <a>白白的张导</a>
                        </div>
                        <div class="trans_com">
                            黑黑黑
                        </div>
                        <div class="origin_content">
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
        </div>
        <div class="right_column">
        </div>
    </div>
   </form>
</body>
</html>
