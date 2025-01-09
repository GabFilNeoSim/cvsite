

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

$(function () {
    scrollToBottom();
    updateProfileCardStyling();
})

function scrollToBottom() {
    console.log("asd");
    const messageParent = document.querySelector('.message-parent');
    if (messageParent) {
        messageParent.scrollTop = messageParent.scrollHeight;
        console.log("asd");
    }
}

let currentConfirmationForm = "";
let currentFormDataId = 0;

$("#delete-work-btn, #delete-education-btn, #delete-project-btn, #deactivate-account-btn, #delete-message-btn").on("click", function (event) {
    event.preventDefault();
    const text = $(this).data("text");
    currentConfirmationForm = $(this).parent().attr("class");
    currentFormDataId = $(this).parent().data("fid");

    showConfirmModal(text);
});

$("#confirm-yes").on("click", function (event) {
    event.preventDefault();
    //console.log($(`.${currentConfirmationForm}[data-fid="${currentFormDataId}"]`));

    $(`.${currentConfirmationForm}[data-fid="${currentFormDataId}"]`).submit();
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