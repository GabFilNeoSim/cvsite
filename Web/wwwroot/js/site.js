function scrollToBottom() {
    const messageParent = document.querySelector('.message-parent');
    if (messageParent) {
        messageParent.scrollTop = messageParent.scrollHeight;
    }
}

window.onload = scrollToBottom;