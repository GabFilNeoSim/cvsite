const searchInput = document.querySelector('#searchbar input');

searchInput.addEventListener('keyup', (event) => {
    processChange(event)
});

function debounce(func, timeout = 500) {
    let timer;
    return (...args) => {
        clearTimeout(timer);
        timer = setTimeout(() => { func.apply(this, args); }, timeout);
    };
}
function saveInput(event) {
    console.log(event.target.value)
}
const processChange = debounce(saveInput);
