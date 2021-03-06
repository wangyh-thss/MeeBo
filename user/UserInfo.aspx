﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人资料</title>
    <link href="css/user.css" type="text/css" rel="stylesheet" />
    <link href="css/another.css" type="text/css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" type="text/css" rel="stylesheet" />
      <script type="text/javascript" src="js/judgeNewMsg.js"></script>
     <style type="text/css">
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
         .row_item {
             overflow:hidden;
             width: 100%;
             position: relative;
         }
         .item1 {
             padding-top:20px;
             width: 20%;
             height:50px;
             float: left;
         }
         .item2 {
             padding-top:14px;
             width: 50%;
             height:50px;
             float: left;
         }
         .item3 {
             padding-top:17px;
             width: 30%;
             height:50px;
             float: left;
         }
         .pic_item {
             overflow:hidden;
             width: 100%;
             position: relative;
         }
         .pic_item1 {
             padding-top:40px;
             width: 20%;
             height:100px;
             float: left;
         }
         .pic_item2 {
             padding-top:14px;
             width: 35%;
             height:100px;
             float: left;
         }
         .pic_item3 {
             padding-top:40px;
             width: 30%;
             height:100px;
             float: left;
         }
    </style>
</head>
<body class="background">
    <form id="registerForm" name="regform" method="post" runat="server">
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
                    <div class="left_item_word">我的私信</div></a>
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
                    <div class="left_item_word strongPage">个人信息</div></a>
                  </div>
                <div class="left_item_a">
                 <a href="ChangePassword.aspx"><span class="fa fa-unlock-alt icon"></span>
                    <div class="left_item_word">修改密码</div></a>
                  </div>
            </div>
        </div>
        <div class="userInfo_box">
            <div class="right_item">
                <p class="p1">个人信息</p>
            </div>
            <hr class="line" />
            <div class="right_item">
                
                    <div class="p3" style="border-spacing:10px 24px; width: 500px; height: 350px; margin-bottom:30px;margin-left:15%">
                        <div class="row_item">
                            <div class="item1">
                                昵称：
                            </div>
                            <div class="item2">
                                <!-- <input id="nickname" name="nickname" type="text" class="W_input" maxlength="20" tabindex="1"/> -->
                                <asp:TextBox ID="nickname" runat="server" class="W_input" maxlength="20" tabindex="1" />
                            </div>
                            <div class="item3">
                                <div runat="server" id="error_nickname" style="color:red"></div>
                            </div>
                        </div>
                        
                        <div class="row_item">
                            <div class="item1">
                                性别：
                            </div>
                            <div class="item2">
                                <!-- <input type="radio" name="gender" value="male" tabindex="3"/> 男
                                <input type="radio" name="gender" value="female" style="margin-left: 4em" tabindex="4"/> 女 -->
                                <asp:RadioButtonList ID="gender" runat="server" Height="23px" RepeatDirection="Horizontal" Width="134px">
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>

                                </asp:RadioButtonList>
                            </div>
                            <div class="item3">
                            </div>
                        </div>
                         <div>
                            <div class="item1">
                                生日：
                            </div>
                        <!--
                            <th>
                                <input id="birthday" name="birthday" type="text" class="W_input" maxlength="20" tabindex="5"/>
                            </th>
                        -->
                             <div class="item2">
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
                                年
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
                                月
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
                                日
                            </div>
                             
                            <div class="item3">
                            </div>
                        </div>
                        <div class="pic_item">
                            <div class="pic_item1">
                                头像：
                            </div>
                            <div class="pic_item2">
                                <!-- <img id="head_potrait" src="image/head_potrait.jpg" style="height: 80px; width: 80px"/> -->
                                <asp:Image ID="head_potrait" runat="server" ImageUrl="image/head_potrait.jpg" style="height: 80px; width: 80px"/>
                            </div>
                            <div class="pic_item3">
                                <!-- <button id="choose_img" name="choose_img" style="margin-left: 30px;border: none; background: #c8e1f0; border-radius: 2px; padding:3px 3px 3px 3px">选择头像</button> -->
                                <asp:FileUpload ID="SelectImg" runat="server" Width="70px" style="margin-left:31px;" onchange="javascript:__doPostBack('UploadImg','')"/>
                                <asp:LinkButton ID="UploadImg" runat="server" OnClick="UploadImg_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <!-- <input type="submit" value="提交" style="width:80px; height:30px; margin-left:40%;" onclick="" tabindex="6"/> -->
                    <asp:Button ID="Button1" Text="保存" runat="server" style="width:60px; height:23px; margin-bottom:30px; margin-left:40%;" OnClick="submit_Click" tabindex="9"/>
                
            </div>
        </div>
    </div>
        </form>
</body>
</html>
