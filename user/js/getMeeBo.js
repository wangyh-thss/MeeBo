function getMeeBo(json) {
    var a = json;
    var html = "";
    for (var i = 0; i < a.length; i++) {
        if (a[i].isSave == true)
            var save = "取消收藏";
        else
            var save = "收藏";

        if (a[i].type == "Meebo") {
            html = html + '<div id="singleMeebo' + i + '" class="single_MeeBo" MeeboID="' + a[i].MeeboID + '">' + '<div class="MeeBo_user">' + '<div class="head_potrait">' + '<img class="potrait_img" src="' + a[i].head + '"/>' + '</div>' + '</div>' + '<div class="MeeBo_content">' + '<div class="user_id">' + '<a onclick="javascript:__doPostBack(\'go_user_btn\',\'' + a[i].userID + '\')">' + a[i].nickname + '</a>' + '</div>';
            html = html + '<div class="text_content">' + a[i].content + '</div>';
            html = html + '<div class="picture_content">';
            if (a[i].pictures) {
                for (var j = 0; j < a[i].pictures.length; j++) {
                    html = html + '<div class="MeeBo_img">' + '<img class="MeeBo_img" src="' + a[i].picture[j] + '"/>' + '</div>'
                }
            }
            html = html + '</div>';
            html = html + '<div class="MeeBo_detail">' + '<div class="MeeBo_time">' + a[i].time + '</div>';
            html = html + '<div class="CTA">' + '<div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'zan_btn\',\'' + a[i].MeeboID + '\')">赞(' + a[i].praise + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'repost_btn\',\'' + a[i].MeeboID + '\')">转发(' + a[i].repost + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'comment_btn\',\'' + a[i].MeeboID + '\')">评论(' + a[i].comment + ')</a></div><div class = "MeeBo_detail_item item_no_border"><a onclick="javascript:__doPostBack(\'save_btn\',\'' + a[i].MeeboID + '\')">' + save + '(' + a[i].save + ')</a></div>' + ' </div>';
            html = html + '</div></div></div></div>';
        } else {
            html = html + '<div class="trans_MeeBo"><div class="trans_user_head"><img class="head_potrait" src="' + a[i].head + '" /></div><div class="trans_content"><div class="trans_userid"><a onclick="javascript:__doPostBack(\'go_user_btn\',\'' + json[i].userID + '\')">' + a[i].nickname + '</a></div><div class="trans_com">' + a[i].content + '</div><div class="origin_content"><div class="user_id"><a onclick="javascript:__doPostBack(\'go_user_btn\',\'' + a[i].originUserID + '\')">' + a[i].originUser + '</a></div><div class="text_content">' + a[i].originContent + '</div>';
            html = html + '<div class="picture_content">';
            if (a[i].originPictures) {
                for (var j = 0; j < a[i].pictures.length; j++) {
                    html = html + '<div class="MeeBo_img">' + '<img class="MeeBo_img" src="' + a[i].originPictures[j] + '"/>' + '</div>'
                }
            }
            html = html + '</div>';
            html = html + '<div class="MeeBo_detail"><div class="MeeBo_time">' + a[i].originTime + '</div></div></div><div class="MeeBo_detail"><div class="MeeBo_time">' + a[i].time + '</div><div class="CTA">' + '<div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'zan_btn\',\'' + a[i].MeeboID + '\')">赞(' + a[i].praise + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'repost_btn\',\'' + a[i].MeeboID + '\')">转发(' + a[i].repost + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'comment_btn\',\'' + a[i].MeeboID + '\')">评论(' + a[i].comment + ')' + ')</a></div><div class = "MeeBo_detail_item item_no_border"><a onclick="javascript:__doPostBack(\'save_btn\',\'' + a[i].MeeboID + '\')">' + save + '(' + a[i].save + ')</a></div>' + ' </div></div></div></div>';
        }
    }
    document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;
}

