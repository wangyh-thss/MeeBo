﻿function getAtMe(m_json) {
    json = m_json;
    var html = "";
    for (var i = 0; i < json.length; i++) {
        if (json[i].content.length > 13) {
            var content = json[i].content.substr(1, 13);
            content = content + "...";
        }
        else
            content = json[i].content;
        html = html + '<div class="single_at"><div class="at_info"><div class="at_head"><img class="head_img0" src="' + json[i].head + '" /></div><div class="at_content"><div class="who_at"><a class="at_a_name" onclick="javascript:__doPostBack(\'go_user_btn\',\'' + json[i].userID + '\')">' + json[i].nickname + '</a>&nbsp;在Meebo&nbsp;<a class="at_a_meebo" onclick="javascript:__doPostBack(\'go_Meebo_btn\',\'' + json[i].MeeboID + '\')">' + content + '</a>&nbsp;中提到了你</div></div></div><div class="at_detail">' + json[i].time + '</div></div>'
    }

    document.getElementsByClassName("at_box")[0].innerHTML = html;
}