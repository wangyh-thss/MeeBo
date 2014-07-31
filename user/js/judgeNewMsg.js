function judgeNewMsg(com, at, zan, msg) {
    if (com == "True")
        document.getElementsByClassName("fa-comments")[0].style.color = "red";
    if (at == "True")
        document.getElementsByClassName("fa-paw")[0].style.color = "red";
    if (zan == "True")
        document.getElementsByClassName("fa-thumbs-up")[0].style.color = "red";
    if (msg == "True")
        document.getElementsByClassName("fa-paper-plane")[0].style.color = "red";
}