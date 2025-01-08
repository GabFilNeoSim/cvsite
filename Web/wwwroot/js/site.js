﻿function scrollToBottom() {
    const messageParent = document.querySelector('.message-parent');
    if (messageParent) {
        messageParent.scrollTop = messageParent.scrollHeight;
    }
}

let currentProfileIndex = 0;
let profileMoveLength = 210;
const profilecards = $(".card");
const cardcarousel = $("#carousel");
const visibleCardsCount = Math.floor(cardcarousel.width() / profileMoveLength) + 1;

$("#left").on('click', function (event) {
    moveProfileCarousel(-1);
});
$("#right").on('click', function (event) {
    moveProfileCarousel(1);
});

function moveProfileCarousel(direction) {
    currentProfileIndex = (currentProfileIndex + direction + profilecards.length) % profilecards.length;
    updateProfileCardStyling();
}

function updateProfileCardStyling() {
    //Resets styling
    profilecards.each(function (index, item) {
        item.classList = "card";
        item.style.transform = ""
    })
    let lastCardInView = (currentProfileIndex + visibleCardsCount - 1) % profilecards.length;
    const nextLeft = profilecards[(currentProfileIndex - 1 + profilecards.length) % profilecards.length];
    const nextRight = profilecards[(lastCardInView + 1) % profilecards.length];
    //Applies styling to next in view
    nextLeft.classList.add("left");
    nextLeft.style.transform = `translateX(${-1 * profileMoveLength}px`;

    nextRight.classList.add("right");
    nextRight.style.transform = `translateX(${visibleCardsCount * profileMoveLength}px`;

    //Styles the cards in view
    for (let i = currentProfileIndex; i < currentProfileIndex + visibleCardsCount; i++) {
        const position = ((i - currentProfileIndex + profilecards.length) % profilecards.length) * profileMoveLength
        profilecards[i % profilecards.length].style.transform = `translateX(${position}px)`;
        profilecards[i % profilecards.length].classList.add("active");
    }
}

window.onload = scrollToBottom;
window.onload = updateProfileCardStyling;

let currentConfirmationForm = "";

$("#delete-work-btn, #delete-education-btn").on("click", function (event) {
    event.preventDefault();
    const text = $(this).data("text");
    currentConfirmationForm = $(this).parent().attr("id");
    showConfirmModal(text);
});


$("#confirm-yes").on("click", function (event) {
    event.preventDefault();
    $(`#${currentConfirmationForm}`).submit();
});


function showConfirmModal(text) {
    $("#confirm-wrapper").show();
    $("#confirm-text").html(text);
}

function closeConfirmModal() {
    $("#confirm-wrapper").hide();
    currentConfirmationForm = "";
}

$("#confirm-no, #confirm-modal-close").on("click", function () {
    closeConfirmModal();
});