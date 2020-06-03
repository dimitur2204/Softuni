    function stopwatch() {
        const startBtn = document.querySelector('#startBtn');
        const stopBtn = document.querySelector('#stopBtn');
        const timeField = document.querySelector('#time');
        let timerInterval;
        const count = (time) =>{
            let minutes = time.split(':')[0];
            let seconds = time.split(':')[1];
            let updatedSeconds = +seconds + 1;
            if (updatedSeconds == 60) {
                minutes = Number(minutes) + 1;
                updatedSeconds = 0;
            }
            return minutes.toString().padStart(2,'0') + ':' + updatedSeconds.toString().padStart(2,'0');
        };
        const startCounting = () =>{
            timerInterval = setInterval(() => {
                timeField.textContent = count(timeField.textContent);
                timeField
            },1000);
        };
        const stopCounting = () =>{
            clearInterval(timerInterval);
        }
        const startTimer = () => {
            timeField.textContent = '00:00';
            startCounting();
            startBtn.disabled = true;
            stopBtn.disabled = false;
        };
        const stopTimer = () => {
            stopCounting();
            startBtn.disabled = false;
            stopBtn.disabled = true;
        };
        startBtn.addEventListener('click',startTimer);
        stopBtn.addEventListener('click',stopTimer);
    }