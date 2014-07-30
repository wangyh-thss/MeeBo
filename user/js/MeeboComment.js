function loadPage(m_json) {
    var json = m_json;
    var Meebo_box = "";
    Meebo_box = '<div class="single_MeeBo"> <div class="MeeBo_user"><div class="head_potrait"><img class="potrait_img" src="' + json.Meebo.head + '"/></div></div><div class="MeeBo_content"><div class="user_id"><a onclick="javascript:__doPostBack(\'save_btn\',\'' + json.Meebo.UID + '\')">' + json.Meebo.nickname + '</a></div><div class="text_content">' + json.Meebo.content + '</div>';
    if (json.Meebo.pictures) {
        Meebo_box = Meebo_box + '<div class="picture_content">'
        for (var j = 0; j < json.Meebo.pictures.length; j++) {
            Meebo_box = Meebo_box + '<div class="MeeBo_img">' + '<img class="MeeBo_img" src="' + json.Meebo.picture[j] + '"/>' + '</div>'
        }
        Meebo_box = Meebo_box + '</div>'
    }
    if (json.Meebo.isSave == true)
        var save = "取消收藏";
    else
        var save = "收藏";
    Meebo_box = Meebo_box + '<div class="MeeBo_detail"><div class="MeeBo_time">' + json.Meebo.time + '</div>'
    Meebo_box = Meebo_box + '<div class="CTA">' + '<a runat="server" id="zan" onclick="javascript:__doPostBack(\'zan_btn\',\'' + json.Meebo.MeeboID + '\')">赞</a>(' + json.Meebo.praise + ')|<a runat="server" id="repost" onclick="javascript:__doPostBack(\'repost_btn\',\'' + json.Meebo.MeeboID + '\')">转发</a>(' + json.Meebo.repost + ')|<a runat="server" id="comment" onclick="javascript:__doPostBack(\'comment_btn\',\'' + json.Meebo.MeeboID + '\')">评论</a>(' + json.Meebo.comment + ')' + ')|<a runat="server" id="save" onclick="javascript:__doPostBack(\'save_btn\',\'' + json.Meebo.MeeboID + '\')">'+ save +'</a>(' + json.Meebo.save + ')' + ' </div>';
    Meebo_box = Meebo_box + '</div></div></div>';

    document.getElementsByClassName("MeeBo_Box")[0].innerHTML = Meebo_box;

    var commentHTML = "";

    for (var i = 0; i < json.comment.length; i++) {
        commentHTML = commentHTML + '<div class="single_Comment"><div class="Comment_user"><div class="Comment_head"><img class="Comment_img" src="' + json.comment[i].head + '"/></div></div><div class="Comment_content"><div class="Comment_userID"><a onclick="javascript:__doPostBack(\'user_btn\',\'' + json.comment[i].userID + '\')">' + json.comment[i].nickname + '</a></div><div class="Comment_text">' + json.comment[i].content + '</div><div class="Comment_detail"><div class="Comment_time"><p class="detail_font">' + json.comment[i].time + '</p></div><div class="Comment_floor"><p class="detail_font">' + (i + 1) + '楼</p></div></div></div><br /></div>'
    }

    document.getElementsByClassName("Comment_Box")[0].innerHTML = commentHTML;
}