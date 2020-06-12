function attachEventsListeners() {
    const daysField = document.querySelector('#days');
    const hoursField = document.querySelector('#hours');
    const minutesField = document.querySelector('#minutes');
    const secondsField = document.querySelector('#seconds');
    const daysBtn = document.querySelector('#daysBtn');
    const hoursBtn = document.querySelector('#hoursBtn');
    const minutesBtn = document.querySelector('#minutesBtn');
    const secondsBtn = document.querySelector('#secondsBtn');
    daysBtn.addEventListener('click',convertDays);
    hoursBtn.addEventListener('click',convertHours);
    minutesBtn.addEventListener('click',convertMinutes);
    secondsBtn.addEventListener('click',convertSeconds);
    function convertDays(e) {
        const days = +daysField.value;
        hoursField.value = days * 24;
        minutesField.value = days * 24 * 60;
        secondsField.value = days * 24 * 60 * 60;
    }
    function convertHours(e) {
        const hours = +hoursField.value;
        daysField.value = hours / 24;
        minutesField.value = hours * 60;
        secondsField.value = hours * 60 * 60;
    }
    function convertMinutes(e) {
        const minutes = +minutesField.value;
        daysField.value = minutes / 24 / 60;
        hoursField.value = minutes / 60;
        secondsField.value = minutes * 60;
    }
    function convertSeconds(e) {
        const seconds = +secondsField.value;
        daysField.value = seconds / 60 / 60 / 24;
        hoursField.value = seconds / 60 / 60;
        minutesField.value = seconds / 60;
    }
}