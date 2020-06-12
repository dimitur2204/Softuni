function notify(message) {
    const notificationDiv = document.querySelector('#notification');
    notificationDiv.innerText = message;
    notificationDiv.style.display = 'block';
        setTimeout(function () {
        notificationDiv.style.display = 'none';
    },2000);
}