function scrollToBottom() {
    const messageParent = document.querySelector('.message-parent');
    if (messageParent) {
        messageParent.scrollTop = messageParent.scrollHeight;
    }
}

let currentProfileIndex = 1;
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


$("#delete-qualification-btn").on("click", function (event) {
    console.log("asd");
});

function showConfirmModal(text, formToSubmit) {
    $("#confirm-wrapper").show();
    $("#confirm-text").html(text)

    $('#confirm-btn').click(() => {
        callback(); // Call the provided callback
        closePopup(); // Close the popup
    });

    // Handle cancel
    $('#confirm-modal-close').click(closePopup);

    // Function to close the popup
    function closePopup() {
        $('#confirm-overlayl').fadeOut(() => {
            $('#confirm-modal').empty(); // Remove popup from DOM
        });
    }
}