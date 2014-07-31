function pageLoad(m_json) {
    var json = m_json;
    var html = "";
    for (var i = 0; i < json.length; i++) {
        html = html + '<div class="single_MeeBo"><div class="MeeBo_user"><div class="head_potrait"><img class="potrait_img" src="' + json[i].head + '"/></div></div><div class="MeeBo_content"><div class="user_id"><a class="user_name" onclick="javascript:__doPostBack(\'go_user_btn\',\'' + json[i].userID + '\')" style="cursor:pointer">' + json[i].nickname + '</a></div><div class="text_content">' + json[i].content + '</div><div class="MeeBo_detail"><div class="see_Message"><input type="button" value="回复" style="width:80px; float:right" onclick="javascript:__doPostBack(\'see_detail_btn\',\'' + json[i].userID + '\')" /></div><div class="Message_time">' + json[i].time + '</div></div></div></div>'
    }
    document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;
}