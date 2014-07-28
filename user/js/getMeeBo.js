function getMeeBo(json){
	var a = eval("("+json+")");
	var html = "";
	for(var i=0; i<a.length; i++){
		html = html + '<div id="singleMeebo'+ i +'" class="single_MeeBo" MeeboID="'+ a[i].MeeboID +'">' + '<div class="MeeBo_user">' + '<div class="head_potrait">' + '<img class="potrait_img" src="' + a[i].head + '"/>' + '</div>' + '</div>' + '<div class="MeeBo_content">' + '<div class="user_id">' + '<a>' + a[i].nickname + '</a>' + '</div>';
		
		html = html + '<div class="text_content">' + a[i].content + '</div>';
		html = html + '<div class="picture_content">' ;
		for(var j=0; j<a[i].pictures.number; j++){
		html = html + '<div class="MeeBo_img">' + '<img class="MeeBo_img" src="' + a[i].picture[j] + '"/>' + '</div>'
		}
		html = html + '</div>';
	    
		

		html = html + '<div class="MeeBo_detail">' + '<div class="MeeBo_time">' + a[i].time + '</div>';
		html = html + '<div class="CTA">' + '<a runat="server" id="zan' + i + '" onclick="javascript:__doPostBack(\'zan_btn\',\'' + a[i].MeeboID + '\')">赞</a>(' + a[i].praise + ')|<a runat="server" id="repost' + i + '" onclick="javascript:__doPostBack(\'repost_btn\',\'' + a[i].MeeboID + '\')">转发</a>(' + a[i].repost + ')|<a runat="server" id="comment' + i + '" onclick="javascript:__doPostBack(\'comment_btn\',\'' + a[i].MeeboID + '\')">评论</a>(' + a[i].comment + ')' + ')|<a runat="server" id="save' + i + '" onclick="javascript:__doPostBack(\'save_btn\',\'' + a[i].MeeboID + '\')">收藏</a>(' + a[i].save + ')' + ' </div>';
		html = html + '</div></div></div></div>';
	}
	document.getElementsByClassName("MeeBo_Box")[0].innerHTML = html;
}

//var json='{"MeeBoNum":1,"MeeBo":[{"userHead":"../image/head_potrait.jpg","user":"张导","textContent":"嘿嘿嘿嘿","pictureNum":5,"picture":["./image/logo.jpg","./image/logo.jpg","./image/logo.jpg","./image/logo.jpg","./image/logo.jpg"],"time":"今天15:19","agreeNum":100,"CommentNum":33,"TransNum":17,"SaveNum":5}]}';  
//MeeBoNum：JSON文件中消息的数目，userHead头像，user用户，textContent：文本内容，pictureNum图片数目，picture数组每个图片的地址，time时间，agreeNum点赞数，CommentNum评论数，TransNum转发数，SaveNum收藏数                  
 
//var json="[\r\n  {\r\n    \"head\": \"~/image/head_potrait.jpg\",\r\n    \"nickname\": \"admin\",\r\n    \"MeeboID\": \"e0216931-25ce-4729-a9da-fdfe4774b19e\",\r\n    \"content\": \"2\",\r\n    \"pictures\": null,\r\n    \"time\": \"2014-07-27T19:55:37.74\",\r\n    \"praise\": 0,\r\n    \"comment\": 0,\r\n    \"repost\": 0,\r\n    \"save\": 0\r\n  },\r\n  {\r\n    \"head\": \"~/image/head_potrait.jpg\",\r\n    \"nickname\": \"admin\",\r\n    \"MeeboID\": \"75dc3ec4-1a3d-4595-abbe-e37d419868f1\",\r\n    \"content\": \"testhahah\",\r\n    \"pictures\": null,\r\n    \"time\": \"2014-07-28T17:05:22.91\",\r\n    \"praise\": 0,\r\n    \"comment\": 0,\r\n    \"repost\": 0,\r\n    \"save\": 0\r\n  },\r\n  {\r\n    \"head\": \"~/image/head_potrait.jpg\",\r\n    \"nickname\": \"admin\",\r\n    \"MeeboID\": \"e4d154cf-6795-419e-a436-e75332de24c3\",\r\n    \"content\": \"1\",\r\n    \"pictures\": null,\r\n    \"time\": \"2014-07-28T19:55:30.46\",\r\n    \"praise\": 0,\r\n    \"comment\": 0,\r\n    \"repost\": 0,\r\n    \"save\": 0\r\n  },\r\n  {\r\n    \"head\": \"~/image/head_potrait.jpg\",\r\n    \"nickname\": \"admin\",\r\n    \"MeeboID\": \"b49e6afc-29b4-4dc0-8d91-faae63b7e45d\",\r\n    \"content\": \"2\",\r\n    \"pictures\": null,\r\n    \"time\": \"2014-07-28T19:55:42.23\",\r\n    \"praise\": 0,\r\n    \"comment\": 0,\r\n    \"repost\": 0,\r\n    \"save\": 0\r\n  }\r\n]"