﻿function getHotTopic(m_json) {
    var json = m_json;
    var html = "";
    for (var i = 0; i < json.length; i++) {
        html = html + '<div class="topic_item"><a style="font-size:20px;cursor:pointer;" onclick="javascript:__doPostBack(\'searchTopic_btn\',\'' + json[i].topic + '\')">#' + json[i].topic + '#&nbsp;<span style="font-size:10px">（相关MeeBo数:' + json[i].newsNum + '&nbsp;&nbsp;&nbsp;转发总数:' + json[i].transNum + '&nbsp;&nbsp;&nbsp;评论总数:' + json[i].comNum + '）</span></a></div>'
    }
    document.getElementsByClassName("topic_box")[0].innerHTML = html;
}