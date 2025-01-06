﻿const avatar = document.getElementById("profile-avatar");
const form = document.getElementById("profile-change-avatar");
const input = document.getElementById("profile-change-avatar-input");

avatar.addEventListener("click", () => input.click());

input.addEventListener("change", () => {
    if (input.files.length > 0) {
        form.submit();
    }
});

$("#profile-anonymous-message-btn").on("click", function () {
    $("#message-container").show();
});


$("#message-modal-close").on("click", function () {
    $("#message-container").hide();
});