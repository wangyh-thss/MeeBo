<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentMe.aspx.cs" Inherits="user_CommentMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>评论我的</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
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
        .at_detail{width:100%;font-size:8px;text-align:right;margin-top:10px}
    </style>
    <script type="text/javascript" src="js/getCommentMe.js"></script>
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
                <a class="p1" href="PersonalPage.aspx">首页</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href="CommentMe.aspx" style="color:red">评论我的</a><br /><br/>
                <a class="p2" href="AtMe.aspx">提到我的</a><br /><br/>
                <a class="p2" href="ZanMe.aspx">赞</a><br /><br/>
                <a class="p2" href="MySave.aspx">我的收藏</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href = "MyMessage.aspx">我的私信</a><br /><br/>
                <a class="p2" href ="MyMeeBo.aspx">我的MeeBo</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href ="MyTeam.aspx">分组</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href ="UserInfo.aspx">个人信息</a><br /><br/>
                <a class="p2" href ="ChangePassword.aspx">修改密码</a><br /><br/>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
             <div class="upper_message">
                <div class="at_tips">
                    最近，共有8人评论了您的MeeBo哦！
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
                                <a id="user1" class="at_a">黑黑的张导</a>在你的消息<a id="content1" class="at_a">nimas...</a>中说道：
                            </div>
                            <div class="at_what">
                                <p>嘿嘿嘿</p>
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
        </div>
    </div>
        <asp:LinkButton runat="server" ID="go_user_btn" OnClick="go_user_Click"></asp:LinkButton>
        <asp:LinkButton runat="server" ID="go_MeeBo_btn" OnClick="go_MeeBo_Click"></asp:LinkButton>
     </form>
</body>
</html>