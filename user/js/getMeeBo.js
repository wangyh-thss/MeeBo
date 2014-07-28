function getMeeBo(json) {
    var a = json;
    var html = "";
    for (var i = 0; i < a.length; i++) {
        html = html + '<div id="singleMeebo' + i + '" class="single_MeeBo" MeeboID="' + a[i].MeeboID + '">' + '<div class="MeeBo_user">' + '<div class="head_potrait">' + '<img class="potrait_img" src="' + a[i].head + '"/>' + '</div>' + '</div>' + '<div class="MeeBo_content">' + '<div class="user_id">' + '<a>' + a[i].nickname + '</a>' + '</div>';

        html = html + '<div class="text_content">' + a[i].content + '</div>';
        html = html + '<div class="picture_content">';
        if (a[i].pictures) {
            for (var j = 0; j < a[i].pictures.length; j++) {
                html = html + '<div class="MeeBo_img">' + '<img class="MeeBo_img" src="' + a[i].picture[j] + '"/>' + '</div>'
            }
        }
        html = html + '</div>';



        html = html + '<div class="MeeBo_detail">' + '<div class="MeeBo_time">' + a[i].time + '</div>';
        html = html + '<div class="CTA">' + '<a runat="server" id="zan' + i + '" onclick="javascript:__doPostBack(\'zan_btn\',\'' + a[i].MeeboID + '\')">赞</a>(' + a[i].praise + ')|<a runat="server" id="repost' + i + '" onclick="javascript:__doPostBack(\'repost_btn\',\'' + a[i].MeeboID + '\')">转发</a>(' + a[i].repost + ')|<a runat="server" id="comment' + i + '" onclick="javascript:__doPostBack(\'comment_btn\',\'' + a[i].MeeboID + '\')">评论</a>(' + a[i].comment + ')' + ')|<a runat="server" id="save' + i + '" onclick="javascript:__doPostBack(\'save_btn\',\'' + a[i].MeeboID + '\')">收藏</a>(' + a[i].save + ')' + ' </div>';
        html = html + '</div></div></div></div>';
    }
    document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;
}

