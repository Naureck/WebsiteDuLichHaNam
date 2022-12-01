var btnShow = document.getElementById("show-payment");
var close = document.getElementById("close-btn");
var show = document.getElementById("show-box");
var show2 = document.getElementById("show-box-2")

btnShow.onclick = function () {
    show.style.display = "block";
    show2.style.display = "none";
}

close.onclick = function () {
    show.style.display = "none";
    show2.style.display = "block";
}
