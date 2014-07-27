function getMeeBo(json){
	var a = eval("("+json+")");
	var html = "";
	for(var i=0; i<a.MeeBoNum; i++){
		html = html + '<div class="single_MeeBo">' + '<div class="MeeBo_user">' + '<div class="head_potrait">' + '<img class="potrait_img" src="' + a.MeeBo[i].userHead + '"/>' + '</div>' + '</div>' + '<div class="MeeBo_content">' + '<div class="user_id">' + '<a>' + a.MeeBo[i].user + '</a>' + '</div>';
		
			html = html + '<div class="text_content">' + a.MeeBo[i].textContent + '</div>';
			html = html + '<div class="picture_content">' ;
			for(var j=0; j<a.MeeBo[i].pictureNum; j++){
			html = html + '<div class="MeeBo_img">' + '<img class="MeeBo_img" src="' + a.MeeBo[i].picture[j] + '"/>' + '</div>'
			}
			html = html + '</div>';
		
		
		html = html + '<div class="MeeBo_detail">' + '<div class="MeeBo_time">' + a.MeeBo[i].time + '</div>';
		html = html + '<div class="CTA">' + '<a>赞</a>(' + a.MeeBo[i].agreeNum + ')|<a>转发</a>(' + a.MeeBo[i].TransNum + ')|<a>评论</a>(' + a.MeeBo[i].CommentNum + ')' + ')|<a>收藏</a>(' + a.MeeBo[i].SaveNum + ')' + ' </div>';
		html = html + '</div></div></div></div>';
	}
	document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;
}

//var json='{"MeeBoNum":1,"MeeBo":[{"userHead":"../image/head_potrait.jpg","user":"张导","textContent":"嘿嘿嘿嘿","pictureNum":5,"picture":["./image/logo.jpg","./image/logo.jpg","./image/logo.jpg","./image/logo.jpg","./image/logo.jpg"],"time":"今天15:19","agreeNum":100,"CommentNum":33,"TransNum":17,"SaveNum":5}]}';  
//MeeBoNum：JSON文件中消息的数目，userHead头像，user用户，textContent：文本内容，pictureNum图片数目，picture数组每个图片的地址，time时间，agreeNum点赞数，CommentNum评论数，TransNum转发数，SaveNum收藏数                  
                               