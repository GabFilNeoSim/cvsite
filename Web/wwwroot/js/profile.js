const avatar = document.getElementById("profile-avatar");
const form = document.getElementById("profile-change-avatar");
const input = document.getElementById("profile-change-avatar-input");

avatar.addEventListener("click", () => input.click());

console.log("Hello world");


$("#profile-anonymous-message-btn").on("click", function () {
    $("#message-container").show();
});


$("#message-modal-close").on("click", function () {
    $("#message-container").hide();
});