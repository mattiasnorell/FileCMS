document.getElementById("menu-open").onclick = function () {
    document.getElementsByTagName("body")[0].style.overflow = "hidden";
    document.getElementById("menu").style.height = "100%";
}

document.getElementById("menu-close").onclick = function () {
    document.getElementById("menu").style.height = "0%";

    setTimeout(function () {
        document.getElementsByTagName("body")[0].style.overflow = "auto";
    }, 300);
}