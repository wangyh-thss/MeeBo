<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hot.aspx.cs" Inherits="hot_hot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>热门MeeBo</title>
     <link href="../user/css/user.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../user/js/getMeeBo.js"></script>
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
                    <div class="left_item_word">热门用户</div></a>
                    </div>
                 <div class="left_item_a">
                <a href="hot.aspx"><span class="fa fa-fire icon"></span>
                    <div class="left_item_word strongPage">热门微博</div></a>
                    </div>
            </div>
            <hr class="line" />
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
        </div>
        <div class="right_column">
        </div>
    </div>
        <asp:LinkButton runat="server" ID="zan_btn" OnClick="zan_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="repost_btn" OnClick="repost_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="comment_btn" OnClick="comment_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="save_btn" OnClick="save_Click"></asp:LinkButton>
   </form>
</body>
</html>

