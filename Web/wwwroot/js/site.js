function scrollToBottom() {
    const messageParent = document.querySelector('.message-parent');
    if (messageParent) {
        messageParent.scrollTop = messageParent.scrollHeight;
    }
}

//let currentProfileIndex = 1;
//let profileMoveLength = 210;
//const profilecards = $(".card");

//$("#left").on('click', function (event) {
//    moveProfileCarousel(-1);
//});
//$("#right").on('click', function (event) {
//    moveProfileCarousel(1);
//});

//function moveProfileCarousel(direction) {
//    currentProfileIndex = (currentProfileIndex + direction) % profilecards.length;
//    updateProfileCardStyling();
//}

//function updateProfileCardStyling() {
//    profilecards.each(function (index, item) {
//        const relativeIndex = Math.abs((item.id - currentProfileIndex) % profilecards.length);
//        item.style.transform = `translateX(${relativeIndex * profileMoveLength}px)`;
//    })
//}

window.onload = scrollToBottom;
window.onload = updateProfileCardStyling;