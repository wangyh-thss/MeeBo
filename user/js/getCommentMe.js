function getCommentMe(json) {
    var a = json;
    var html = "";
    for (var i = 0; i < a.length; i++) {
        if (a[i].MeeboContent.length > 13) {
            var content = a[i].MeeboContent.substr(1, 13);
            content = content + "...";
        }
        else
            content = a[i].MeeboContent;

        html = html + '<div id="singleAt' + i + '" class="single_at" MeeboID="' + a[i].userID + '">' + '<div class="at_info">' + '<div class="at_head">' + '<img class="head_img0" src="' + a[i].head + '"/>' + '</div>' + '<div class="at_content">' + '<div class="who_at">' + '<a runat="server" id="user' + i + '" class="at_a_name" onclick="javascript:__doPostBack(\'go_user_btn\',\'' + a[i].userID + '\')">' + a[i].nickname + '</a>&nbsp;在你的MeeBo&nbsp;<a runat="server" id="content' + i + '" class="at_a_meebo" onclick="javascript:__doPostBack(\'go_MeeBo_btn\',\'' + a[i].MeeboID + '\')">' + content + '</a>' + '&nbsp;中说道：</div>' + '<div class="at_what"><p>' + a[i].commentContent + '</p>' + '</div></div></div>' + '<div class="at_detail">' + a[i].time + '</div></div>' + '</div>';
	}
    document.getElementsByClassName("at_box")[0].innerHTML = html;
}

//var json=[{"head":"../image/head_potrait.jpg","nickname":"miao","userID":"2123","MeeBoID":"1231","MeeBoContent":"heihei","commentContent":"heng","time":"8:00"},{"head":"../image/head_potrait.jpg","nickname":"miao","userID":"2123","MeeBoID":"1231","MeeBoContent":"heihei","commentContent":"heng","time":"8:00"},{"head":"../image/head_potrait.jpg","nickname":"miao","userID":"2123","MeeBoID":"1231","MeeBoContent":"heihei","commentContent":"heng","time":"8:00"}]