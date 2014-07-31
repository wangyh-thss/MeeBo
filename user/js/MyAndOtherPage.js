function getMeebo(m_json) {
    var json = m_json;
    var html = "";
    for (var i = 0; i < json.length; i++) {
        if (json[i].isSave == true)
            var save = "取消收藏";
        else
            var save = "收藏";
        if (json[i].type == "Meebo") {
            html = html + '<div class="single_MeeBo"><div class="text_content">' + json[i].content + '</div><div class="picture_content">';
            if (json[i].pictures) {
                for (var j = 0; j < json[i].pictures.length; j++) {
                    html = html + '<div class="MeeBo_img"><img class="MeeBo_img" src="'+ json[i].pictures[j] +'"/></div>'
                }
            }
            html = html + '</div><div class="MeeBo_detail"><div class="MeeBo_time">' + json[i].time + '</div><div class="CTA">' + '<div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'zan_btn\',\'' + json[i].MeeboID + '\')">赞(' + json[i].praiseNum + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'repost_btn\',\'' + json[i].MeeboID + '\')">转发(' + json[i].transNum + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'comment_btn\',\'' + json[i].MeeboID + '\')">评论(' + json[i].comNum + ')</a></div><div class = "MeeBo_detail_item item_no_border"><a onclick="javascript:__doPostBack(\'save_btn\',\'' + json[i].MeeboID + '\')">' + save + '(' + json[i].saveNum + ')</a></div></div></div></div>';
        } else {
            html = html + '<div class="trans_MeeBo"><div class="trans_content"><div class="trans_com">' + json[i].content + '</div><div class="origin_content"><div class="user_id"><a onclick="javascript:__doPostBack(\'go_user_btn\',\'' + json[i].originUserID + '\')" style="cursor:pointer">' + json[i].originUser + '</a></div><div class="text_content">' + json[i].originContent + '</div><div class="picture_content">';
            if (json[i].originpictures) {
                for (var j = 0; j < json[i].originpictures.length; j++) {
                    html = html + '<div class="MeeBo_img"><img class="MeeBo_img" src="' + json[i].originpictures[j] + '"/></div>'
                }
            }
            html = html + '</div><div class="MeeBo_detail"><div class="MeeBo_time">' + json[i].originTime + '</a></div><div class = "MeeBo_detail_item"></div></div></div><div class="MeeBo_detail"></div><div class="MeeBo_time">' + json[i].time + '</div><div class="CTA">' + '<div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'zan_btn\',\'' + json[i].MeeboID + '\')">赞(' + json[i].praiseNum + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'repost_btn\',\'' + json[i].MeeboID + '\')">转发(' + json[i].transNum + ')</a></div><div class = "MeeBo_detail_item"><a onclick="javascript:__doPostBack(\'comment_btn\',\'' + json[i].MeeboID + '\')">评论(' + json[i].comNum + ')</a></div><div class = "MeeBo_detail_item item_no_border"><a onclick="javascript:__doPostBack(\'save_btn\',\'' + json[i].MeeboID + '\')">' + save + '(' + json[i].saveNum + ')</a></div></div></div></div>';
        }
    }
    document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;

}

function changeBtnText(isFollow) {
    if (isFollow)
        document.getElementById("like").setAttribute("value", "取消关注");
    else
        document.getElementById("like").setAttribute("value", "关注");
}