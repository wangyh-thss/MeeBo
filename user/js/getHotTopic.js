function getHotTopic(m_json) {
    var json = m_json;
    var html = "";
    if (json.length < 10)
        var len = json.length;
    else
        var len = 10;
    for (var i = 0; i < len; i++)
    {
        html = html + '<div class="topic_item"><a style="font-size:20px;cursor:pointer;" onclick="javascript:__doPostBack(\'searchTopic_btn\',\'' + json[i].topic + '\')">#' + json[i].topic + '#&nbsp;<br><span style="font-size:10px">（相关MeeBo数:' + json[i].newsNum + '&nbsp;&nbsp;&nbsp;转发总数:' + json[i].transNum + '&nbsp;&nbsp;&nbsp;评论总数:' + json[i].comNum + '）</span></a></div>'
    }
    document.getElementsByClassName("topic_box")[0].innerHTML = html;
}