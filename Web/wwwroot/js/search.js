﻿
$("#searchbar input").on('keyup', function (event) {
    processChange(event);
});

function debounce(func, timeout = 500) {
    let timer;
    return (...args) => {
        clearTimeout(timer);
        timer = setTimeout(() => { func.apply(this, args); }, timeout);
    };
}
function saveInput(event) {
    const search = event.target.value;
    if (!search) {
        $('#search-result').hide();
        return;
    }

    $.ajax({
        url: `/home/users?query=${encodeURIComponent(search)}`,
        method: 'GET',
        success: function (data) {
            listUsers(data);
        },
        error: function (error) {
            console.error('Error fetching user data:', error);
        }
    });
}
const processChange = debounce(saveInput);

function listUsers(users) {
    $("#search-result").html("");

    if (users.length == 0) {
        let html = `<p>No user found</p>`;
        $("#search-result").html(html);
    }

    users.forEach(function (user) {
        let html = `
            <a href="/profile/${user.id}" class="search-result-child">
                <img src="/avatars/${user.avatar}" />
                <p>${user.name}</p>
                </a>
        `;
        $("#search-result").append(html);
    });
    $('#search-result').show();
}

$(document).on('click', function (event) {
    if (!$(event.target).closest('#searchbar').length) {
        $('#search-result').hide();
    }
});