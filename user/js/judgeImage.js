function judgeImage() {
    var pic = document.getElementsByClassName("picPreview");
    for (var i = 0; i < pic.length; i++) {
        if (pic[i].getAttribute("src") == null) {
            pic[i].style.visibility = 'hidden';
            pic[i].style.display='none';
        } else {
            pic[i].style.visibility = 'visible'
            pic[i].style.display = 'inline-block';
        }
    }

}