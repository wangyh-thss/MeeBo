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
            html = html + '</div><div class="MeeBo_detail"><div class="MeeBo_time">' + json[i].time + '</div><div class="CTA">' + '<a onclick="javascript:__doPostBack(\'zan_btn\',\'' + json[i].MeeboID + '\')">赞</a>(' + json[i].praiseNum + ')|<a onclick="javascript:__doPostBack(\'repost_btn\',\'' + json[i].MeeboID + '\')">转发</a>(' + json[i].transNum + ')|<a onclick="javascript:__doPostBack(\'comment_btn\',\'' + json[i].MeeboID + '\')">评论</a>(' + json[i].comNum + ')' + ')|<a onclick="javascript:__doPostBack(\'save_btn\',\'' + json[i].MeeboID + '\')">' + save + '</a>(' + json[i].saveNum + ')</div></div></div>';
        } else {
            html = html + '<div class="trans_MeeBo"><div class="trans_content"><div class="trans_com">' + json[i].content + '</div><div class="origin_content"><div class="user_id"><a onclick="javascript:__doPostBack(\'go_user_btn\',\'' + json[i].originUserID + '\')">' + json[i].originUser + '</a></div><div class="text_content">' + json[i].originContent + '</div><div class="picture_content">';
            if (json.originpictures) {
                for (var j = 0; j < json[i].pictures.length; j++) {
                    html = html + '<div class="MeeBo_img"><img class="MeeBo_img" src="' + json[i].originpictures[j] + '"/></div>'
                }
            }
            html = html + '</div><div class="MeeBo_detail"><div class="MeeBo_time">' + json[i].originTime + '</div></div></div><div class="MeeBo_detail"></div><div class="MeeBo_time">' + json[i].time + '</div><div class="CTA">' + '<a onclick="javascript:__doPostBack(\'zan_btn\',\'' + json[i].MeeboID + '\')">赞</a>(' + json[i].praiseNum + ')|<a onclick="javascript:__doPostBack(\'repost_btn\',\'' + json[i].MeeboID + '\')">转发</a>(' + json[i].transNum + ')|<a onclick="javascript:__doPostBack(\'comment_btn\',\'' + json[i].MeeboID + '\')">评论</a>(' + json[i].comNum + ')' + ')|<a onclick="javascript:__doPostBack(\'save_btn\',\'' + json[i].MeeboID + '\')">' + save + '</a>(' + json[i].saveNum + ')</div></div></div>';
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