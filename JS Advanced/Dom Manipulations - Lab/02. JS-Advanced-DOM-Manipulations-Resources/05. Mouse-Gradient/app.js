function attachGradientEvents() {
    const gradientBox = document.querySelector("#gradient");
    const resultDiv = document.querySelector("#result");
    gradientBox.addEventListener("mousemove", function (e) {
        const boxWidth = gradientBox.clientWidth;
        const mousePosition = e.pageX;
        const percentage = mousePosition/boxWidth * 100;
        resultDiv.textContent = Math.floor(percentage) + "%";
    });
}