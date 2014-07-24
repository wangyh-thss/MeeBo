<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotUser.aspx.cs" Inherits="hot_hotUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>提到我的</title>
    <style type="text/css">
    .background {background: #c8e1f0;margin-top: 0px;margin-left: 0px;}
    .header {width:100%;position:fixed;background: #244050;height:60px;z-index:3;}
    .logo {font-family:"华文隶书";font-size:40px;margin-left:15%;margin-top:0px;float:left;width:20%}
    .head_list {width:45%;font-family:"Times New Roman";font-size:18px;margin-left:5%;margin-top:35px;float:left;position: relative}
    .head_item {
        float:left;
        position: relative;width:10% }
    .head_search {float:left;position: relative;width:40%}
    .wrapper {top:70px;width:80%; margin: auto;position:relative;height:700px;z-index:2;}
    .left_column {float:left;position: relative;width:15%;background: #fefefe;height:600px}
    .left_item{padding-left:2em;margin-top:5px}
    .middle_column {float:left;position: relative;width:45%;margin-left:5%;background: #fefefe;height:600px}
    .right_column {float:left;position: relative;width:18%;margin-left:5%;background: #fefefe;height:600px}
     a {text-decoration: none;color:black;}
     a:link {color: #000000}
     a:hover {color: blue}
    </style>
</head>
<body class="background">
    <div class="header">
        <div class="logo">
		    <p style="padding:0px 0px 0px 0px; line-height: 0px;">MeeBo</p>
        </div>
        <div class="head_list">
              <div class="head_item">
                <a style="color: #fefefe" href="../user/Read.aspx">首页</a>
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
                <form id="Form1" name="search" method="post" runat="server">
                    <table style=" margin-top:-5px;">
                        <tr><th>
                            <asp:TextBox ID="find_content" runat="server" maxlength="20" tabindex="1" style="margin-bottom:10px;" />
                        </th>
                        <th>
                            <asp:Button ID="submit_find" Text="查找" runat="server" style="width:40px; height:20px;margin-bottom:10px;" tabindex="2"/>
                        </th></tr>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <div class="wrapper">
        <div class="left_column">
            <div class="left_item">
                <a class="p1" href="hot.aspx" >热门信息</a><br /><br/>
            </div>
            <hr class="line" />
            <div class="left_item">
                <br />
                <a class="p2" href="hotTopic.aspx">热门话题</a><br /><br/>
                <a class="p2" href="hotUser.aspx" style="color: red">热门用户</a><br /><br/>
                <a class="p2" href="hotUser.aspx">热门微博</a><br /><br/>
            </div>
            <hr class="line" />
        </div>
        <div class="middle_column">
        </div>
        <div class="right_column">
        </div>
    </div>
</body>
</html>


