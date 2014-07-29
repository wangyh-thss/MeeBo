<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人资料</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" src="js/getMeeBo.js"></script>
     <style type="text/css">
        .head_search {float:left;position: relative;width:40%}
        .userInfo_box {width: 63%;height:612px; background:#fefefe;border: 2px solid #a0b4c1;float:left; border-radius: 10px; margin-left:2%; margin-bottom:30px;}
        .p1 {font-size: 120%;font-family: "Times New Roman"}
        .p2 {font-family: "Times New Roman";}
        .p3 {font-size: 60%;font-family: "Times New Roman";}
         .right_item {margin-top:5px;margin-left:10%}
         a:visited {color: #000000}
         .btn_submit {width:80px; height:30px; margin-left:40%;}
         #nickname {
             width: 175px;
         }
         #email {
             width: 175px;
         }
         #birthday {
             width: 175px;
         }
         .auto-style1 {
             width: 48px;
         }
    </style>
</head>
<body class="background">
    <form id="registerForm" name="regform" method="post" runat="server">
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
        <div class="userInfo_box">
            <div class="right_item">
                <p class="p1">个人信息</p>
            </div>
            <hr class="line" />
            <div style="margin-left: 80%;margin-top:1em;">
                <a class="p3">修改个人信息</a><br/><br/>
            </div>
            <div class="right_item">
                
                    <table class="p3" style="border-spacing:10px 24px; width: 500px; height: 350px; margin-bottom:30px;margin-left:15%">
                        <tr>
                            <th class="auto-style1">
                                昵称：
                            </th>
                            <th>
                                <!-- <input id="nickname" name="nickname" type="text" class="W_input" maxlength="20" tabindex="1"/> -->
                                <asp:TextBox ID="nickname" runat="server" class="W_input" maxlength="20" tabindex="1" />
                            </th>
                            <th>
                                <div runat="server" id="error_nickname" style="color:red"></div>
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style1">
                                邮箱：
                            </th>
                            <th>
                                <!-- <input id="email" name="email" type="text" class="W_input" maxlength="20" tabindex="2"/> -->
                                <asp:TextBox ID="email" runat="server" class="W_input" maxlength="20" tabindex="2" />
                            </th>
                            <th>
                                <a style="font-size: 75%; font-weight:lighter; color: red">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 注意：这将是您找回密码的重要凭据。</a>
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style1">
                                性别：
                            </th>
                            <th>
                                <!-- <input type="radio" name="gender" value="male" tabindex="3"/> 男
                                <input type="radio" name="gender" value="female" style="margin-left: 4em" tabindex="4"/> 女 -->
                                <asp:RadioButtonList ID="gender" runat="server" Height="23px" RepeatDirection="Horizontal" Width="134px">
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>

                                </asp:RadioButtonList>
                            </th>
                        </tr>
                         <tr>
                            <th class="auto-style1">
                                生日：
                            </th>
                        <!--
                            <th>
                                <input id="birthday" name="birthday" type="text" class="W_input" maxlength="20" tabindex="5"/>
                            </th>
                        -->
                             <th>
                             <table>
                             <th>
                                    <asp:DropDownList ID="year" runat="server">
                                    <asp:ListItem>1980</asp:ListItem>
                                    <asp:ListItem>1981</asp:ListItem>
                                    <asp:ListItem>1982</asp:ListItem>
                                    <asp:ListItem>1983</asp:ListItem>
                                    <asp:ListItem>1984</asp:ListItem>
                                    <asp:ListItem>1985</asp:ListItem>
                                    <asp:ListItem>1986</asp:ListItem>
                                    <asp:ListItem>1987</asp:ListItem>
                                    <asp:ListItem>1988</asp:ListItem>
                                    <asp:ListItem>1989</asp:ListItem>
                                    <asp:ListItem>1990</asp:ListItem>
                                    <asp:ListItem>1991</asp:ListItem>
                                    <asp:ListItem>1992</asp:ListItem>
                                    <asp:ListItem>1993</asp:ListItem>
                                    <asp:ListItem>1994</asp:ListItem>
                                    <asp:ListItem>1995</asp:ListItem>
                                    <asp:ListItem>1996</asp:ListItem>
                                    <asp:ListItem>1997</asp:ListItem>
                                    <asp:ListItem>1998</asp:ListItem>
                                    <asp:ListItem>1999</asp:ListItem>
                                    <asp:ListItem>2000</asp:ListItem>
                                    <asp:ListItem>2001</asp:ListItem>
                                    <asp:ListItem>2002</asp:ListItem>
                                    <asp:ListItem>2003</asp:ListItem>
                                    <asp:ListItem>2004</asp:ListItem>
                                    <asp:ListItem>2005</asp:ListItem>
                                    <asp:ListItem>2006</asp:ListItem>
                                    <asp:ListItem>2007</asp:ListItem>
                                    <asp:ListItem>2008</asp:ListItem>
                                    <asp:ListItem>2009</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                </asp:DropDownList>
                            </th>
                            <th>
                                年
                            </th>
                            <th>
                                <asp:DropDownList ID="month" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                            </th>
                            <th>
                                月
                            </th>
                            <th>
                                <asp:DropDownList ID="day" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                </asp:DropDownList>
                            </th>
                            <th>
                                日
                            </th>
                            </table>
                            </th>
                        </tr>
                        <tr>
                            <th class="auto-style1">
                                头像：
                            </th>
                            <th>
                                <!-- <img id="head_potrait" src="image/head_potrait.jpg" style="height: 80px; width: 80px"/> -->
                                <asp:Image ID="head_potrait" runat="server" ImageUrl="image/head_potrait.jpg" style="height: 80px; width: 80px"/>
                            </th>
                            <th>
                                <!-- <button id="choose_img" name="choose_img" style="margin-left: 30px;border: none; background: #c8e1f0; border-radius: 2px; padding:3px 3px 3px 3px">选择头像</button> -->
                                <asp:FileUpload ID="SelectImg" runat="server" Width="65px" style="margin-left:31px;" onchange="javascript:__doPostBack('UploadImg','')"/>
                                <asp:LinkButton ID="UploadImg" runat="server" OnClick="UploadImg_Click"></asp:LinkButton>
                            </th>
                        </tr>
                    </table>
                    <!-- <input type="submit" value="提交" style="width:80px; height:30px; margin-left:40%;" onclick="" tabindex="6"/> -->
                    <asp:Button ID="Button1" Text="保存" runat="server" style="width:60px; height:23px; margin-bottom:30px; margin-left:40%;" OnClick="submit_Click" tabindex="9"/>
                
            </div>
        </div>
    </div>
        </form>
</body>
</html>
