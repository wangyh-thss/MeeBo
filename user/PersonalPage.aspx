<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalPage.aspx.cs" Inherits="user_PersonalPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人主页</title>
    <style type="text/css">
    .background {background: #c8e1f0;margin-top: 0px;margin-left: 0px;}
    .header {width: 100%;position:fixed;background: #244050;height:60px}
    .logo {font-family:"华文隶书";font-size:30px;margin-left:15%;margin-top:0px;float:left;width:20%}
    .head-list {width:45%;font-family:"Times New Roman";font-size:30px;margin-left:5%;margin-top:0px;float:left;position: relative}
    .head-item {
        float:left;
        background: #fefefe;
        position: relative

    }
    </style>
</head>
<body class="background">
    <div class="header">
        <div class="logo">
		    <p>MeeBo</p>
        </div>
        <div class="head_list" style="width:45%;font-family:'Times New Roman';font-size:20px;margin-left:5%;margin-top:0px;float:left;position: relative">
            <div class="head_item" style="width:30%;font-family:'Times New Roman';font-size:20px;margin-top:10px;float:left;position: relative">
                <a>首页|</a>
            </div>
            <div class="head_item" style="width:30%;font-family:'Times New Roman';font-size:20px;margin-top:10px;float:left;position: relative">
                <a>热门|</a>
            </div>
            <div class="head_item" style="width:30%;font-family:'Times New Roman';font-size:20px;margin-top:10px;float:left;position: relative">
                <a>话题</a>
            </div>
        </div>
    </div>
</body>
</html>
