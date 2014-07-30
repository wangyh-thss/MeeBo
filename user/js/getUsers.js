

function getUsers(json){
    var a=json;
    var html="";
    html = html + '<div class="hot_user_item"><div class="hot_user_title">您的关注:</div>'
    for(var i = 0; i < a.length; a++){
        html = html + '<div class="hot_users"><div class="hot_user_head"><img runat="server" src="' + a[i].head + '" class="hot_user_img" /></div><div class="hot_user_info"><div class="hot_user_name"><a runat="server" onclick="javascript:__doPostBack(\'getUser_btn\',\'' + a[i].userID + '\')">' + a[i].nickname + '</a></div><div class="hot_user_describe">这个人很懒，什么都没留下</div><div class="hot_user_detail" runat="server"><div class="hot_user_detail_item">关注' + a[i].likesNum + '</div><div class="hot_user_detail_item">粉丝' + a[i].fansNum + '</div><div class="hot_user_detail_item_right">MeeBo' + a[i].NewsNum + '</div></div></div></div>';
    }
    html += '</div>';
    document.getElementsByClassName("hot_user_item")[0].innerHTML = html;
}

//var json=[{"head":"../image/head_potrait.jpg","nickname":"saihdi","userID":"dsbaiuhd","fansNum":9,"likesNum":19,"NewsNum":10,"birthday":2014-9-10}]