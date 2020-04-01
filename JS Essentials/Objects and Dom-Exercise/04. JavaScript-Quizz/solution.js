
function solve() {
  let rightAnswersCount = 0;
  let firstSection = document.getElementsByTagName("section")[0];
  let secondSection = document.getElementsByTagName("section")[1];
  let thirdSection = document.getElementsByTagName("section")[2];
  let leftAnswer = document.getElementsByClassName("quiz-answer low-value")[0];
  let rightAnswer = document.getElementsByClassName("quiz-answer high-value")[0];
  let results = document.getElementById("results");
  let resultDiv = document.getElementsByClassName("results-inner")[0].getElementsByTagName("h1")[0];
    rightAnswer.addEventListener("click", e => {
      firstSection.style.display = "none";
      secondSection.style.display = "block";
      secondSection.className == "";
    })
    leftAnswer.addEventListener("click", e =>{
      rightAnswersCount++;
      firstSection.style.display = "none";
      secondSection.style.display = "block";
    })
    leftAnswer = document.getElementsByClassName("quiz-answer low-value")[1];
    rightAnswer = document.getElementsByClassName("quiz-answer high-value")[1];
    rightAnswer.addEventListener("click", e => {
      rightAnswersCount++;
      secondSection.style.display = "none";
      thirdSection.style.display = "block";
    })
    leftAnswer.addEventListener("click", e =>{
      secondSection.style.display = "none";
      thirdSection.style.display = "block";
    })
    leftAnswer = document.getElementsByClassName("quiz-answer low-value")[2];
    rightAnswer = document.getElementsByClassName("quiz-answer high-value")[2];
    rightAnswer.addEventListener("click", e => {
      thirdSection.style.display = "none";
      resultDiv.innerHTML = `You have ${rightAnswersCount} right answers`;
      results.style.display = "block";
    })
    leftAnswer.addEventListener("click", e =>{
      if (rightAnswersCount == 2) {
        resultDiv.innerHTML = "You are recognized as top JavaScript fan!";
      }
      else{
        resultDiv.innerHTML = `You have ${++rightAnswersCount} right answers`;
      }
      thirdSection.style.display = "none";
      results.style.display = "block";
    })
}
