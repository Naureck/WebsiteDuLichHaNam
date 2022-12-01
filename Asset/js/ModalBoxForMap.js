﻿// Get the modal
var modalMap = document.getElementById("modal-in-map");

// Get the image and insert it inside the modal - use its "alt" text as a caption
var imgMap = document.getElementById("img-map");
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
imgMap.onclick = function () {
    modalMap.style.display = "block";
    modalImg.src = this.src;
    captionText.innerHTML = this.alt;
}

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close-map")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modalMap.style.display = "none";
}