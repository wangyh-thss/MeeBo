function judgeImage() {
    var pic = document.getElementsByClassName("picPreview");
    for (var i = 0; i < pic.length; i++) {
        if (pic[i].getAttribute("src") == null) {
            pic[i].style.visibility = 'hidden'
        } else {
            pic[i].style.visibility = 'visible'
        }
    }

}