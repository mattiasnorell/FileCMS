function hasClass(ele, cls) {
    return ele.className.match(new RegExp('(\\s|^)' + cls + '(\\s|$)'));
}

function addClass(ele, cls) {
    if (!hasClass(ele, cls)) ele.className += " " + cls;
}

function removeClass(ele, cls) {
    if (hasClass(ele, cls)) {
        var reg = new RegExp('(\\s|^)' + cls + '(\\s|$)');
        ele.className = ele.className.replace(reg, ' ');
    }
}

document.getElementById("menu-open").onclick = function () {
    document.getElementsByTagName("body")[0].style.overflow = "hidden";
    document.getElementById("menu").style.height = "100%";
}

document.getElementById("menu-close").onmouseover = function(evt) {
    addClass(evt.currentTarget, "fa-spin");
}

document.getElementById("menu-close").onmouseout = function (evt) {
    removeClass(evt.currentTarget, "fa-spin");
}

document.getElementById("menu-close").onclick = function () {
    document.getElementById("menu").style.height = "0%";

    setTimeout(function () {
        document.getElementsByTagName("body")[0].style.overflow = "auto";
    }, 300);
}

