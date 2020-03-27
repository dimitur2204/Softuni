function growingWord() {
let myPara = document.getElementsByTagName("p")[2];
let regex = /\d+/;
console.log(myPara.style.fontSize.length);
if (Number(regex.exec(myPara.style.fontSize)) > 0) {
  if (myPara.style.color == "blue") {
    myPara.style.color = "green";
  }
  else if (myPara.style.color == "green") {
    myPara.style.color = "red";
  }
  else if (myPara.style.color == "red") {
    myPara.style.color = "blue";
  }
  myPara.style.fontSize = Number(regex.exec(myPara.style.fontSize))*2 + "px";
}
else{
myPara.style.color = "blue";
myPara.style.fontSize = "2px";
}
}