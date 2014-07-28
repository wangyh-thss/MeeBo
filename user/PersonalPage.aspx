<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalPage.aspx.cs" Inherits="user_PersonalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人主页</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .send_MeeBo_Box {width:100%;padding-top: 5px;position:relative}
        .send_title {width:40%; font-family:"Times New Roman"; font-size:10px;float:left;padding-left:4em}
        .send_hot {width:40%; font-family:"Times New Roman"; font-size:10px;float:right;padding-left:1em}
        .send_box { width:90%;margin:auto;}
        .MeeBo_Box{ width:630px;margin:auto;position:relative;margin-top:10px;margin-bottom:10px}
        .single_MeeBo{ width:100%;margin:auto;position:relative}
        .MeeBo_user{ width:70px;float:left}
        .head_potrait{ width:50px;}
        .MeeBo_content{width:560px;float:left;position:relative}
        .user_id{width:100%;height:20px;font-size:15px;color:blue;margin-bottom:5px}
        .potrait_img {width: 50px;height: 50px;}
        .text_content{width:100%;height:20px;padding:2em,4em;font-size:12px;margin-bottom:5px}
        .picture_content {width:100%;position:relative;margin-bottom:5px }
        .MeeBo_img{width:75px;height:75px;float:left;margin-right:5px }
        .MeeBo_detail{width:100%;position:relative;margin-bottom:5px;font-size:10px;}
        .detail-font{color:blue;font-size:10px;}
        .MeeBo_time{float:left;width:40%;margin-bottom:10px}
        .CTA{float:right;margin-bottom:10px}
        .picture_view{position:relative;width:500px;margin:auto}
        .single_pic_view{float:left;width:50px;height:50px;margin-left:25px;margin-right:25px}
    </style>
    <script type="text/javascript" src="js/getMeeBo.js"></script>
</head>
<body class="background">
    <form id="Form2" name="search" method="post" runat="server">
    <div class="header">
        <div class="logo">
		    <p style="padding:0px 0px 0px 0px; line-height: 0px;">MeeBo</p>
        </div>
        <div class="head_list">
              <div class="head_item">
                <a style="color: #fefefe" href="PersonalPage.aspx">首页</a>
            </div>
            <div class="head_item">
                <a>|</a>
            </div>
            <div class="head_item">
                <a style="color: #fefefe" href="../hot/hot.aspx">热门</a>
            </div>
            <div class="head_item">
                <a>|</a>
            </div>
            <div class="head_item">
                <a style="color: #fefefe" href="../hot/hotTopic.aspx">话题</a>
            </div>
            <div class="head_item">
                <a>|</a>
            </div>
            <div class="head_search">
                    <table style=" margin-top:-5px;">
                        <tr><th>
                            <asp:TextBox ID="find_content" runat="server" maxlength="20" tabindex="1" style="margin-bottom:10px;" />
                        </th>
                        <th>
                            <asp:Button ID="submit_find" Text="查找" runat="server" style="width:40px; height:20px;margin-bottom:10px;" tabindex="2"/>
                        </th></tr>
                    </table>
            </div>
        </div>
    </div>
    <div class="wrapper">
        <div class="left_column">
            <div class="left_item">
                <a class="p1" href="PersonalPage.aspx" style="color: red">首页</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href="CommentMe.aspx">评论我的</a><br /><br/>
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
