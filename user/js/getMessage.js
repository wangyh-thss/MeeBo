﻿

function getMessage(json){
    var a = json;
    var html = "";
    for(var i = 0; i < a.length; i++){
        html += '<div class="single_MeeBo">';
        if(a[i].type == "receive"){
            html = html + '<div class="MeeBo_user"><div class="head_potrait"><img class="potrait_img" src="' + a[i].head + '"/></div></div><div class="MeeBo_content"><div class="user_id"><a runat="server" onclick="javascript:__doPostBack(\'go_user_btn\',\'' + a[i].userID + '\')">' + a[i].nickname + '</a></div><div class="text_content">' + a[i].content + '</div><div class="MeeBo_detail"><div class="Message_time">' + a[i].time + '</div></div></div></div>';
        }
        else{
            html = html + '<div class="my_head"><div class="head_potrait"><img class="potrait_img" src="' + a[i].head + '"/></div></div><div class="my_content">' + a[i].content + '</div><div class="my_detail"><div class="my_time">' + a[i].time + '</div></div></div>';
        }
    }
    document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;
}

//var json = [{"head":"../image/head_potrait.jpg","nickname":"23333","userID":"2133","content":"shai","time":"2019-1-12","type":"receive"},{"head":"../image/head_potrait.jpg","nickname":"23333","userID":"2133","content":"shai","time":"2019-1-12","type":"send"},{"head":"../image/head_potrait.jpg","nickname":"23333","userID":"2133","content":"shai","time":"2019-1-12","type":"receive"},]