function scrollToBottom() {
    const messageParent = document.querySelector('.message-parent');
    if (messageParent) {
        messageParent.scrollTop = messageParent.scrollHeight;
    }
}

let currentProfileIndex = 0;
let profileMoveLength = 210;
const profilecards = $(".card");

$("#left").on('click', function (event) {
    moveProfileCarousel(-1);
});
$("#right").on('click', function (event) {
    moveProfileCarousel(1);
});

function moveProfileCarousel(direction) {
    currentProfileIndex = (currentProfileIndex + direction) % profilecards.length;
    updateProfileCardStyling();
}

function updateProfileCardStyling() {
    console.log(currentProfileIndex)
    profilecards.each(function (index, item) {
        const relativeIndex = Math.abs((item.id - currentProfileIndex) % profilecards.length);
        item.style.transform = `translateX(${relativeIndex * profileMoveLength}px)`;
    })
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