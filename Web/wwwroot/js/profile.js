$("#profile-anonymous-message-btn").on("click", function () {
    $("#message-container").show();
});

$("#message-modal-close").on("click", function () {
    $("#message-container").hide();
});

$("#profile-avatar").on("click", function () {
    $("#profile-change-avatar-input").click();
});

$("#profile-change-avatar-input").on("change", function () {
    $("#profile-change-avatar").submit();
});