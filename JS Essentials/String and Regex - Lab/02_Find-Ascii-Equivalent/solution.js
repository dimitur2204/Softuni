function solve() {
  let text = document.getElementById("text").value;
  let resultSpan = document.getElementById("result");
  let numbers = [];
  let lettersAndSymbols = [];
  text
  .split(" ")
  .filter(x => x != "")
  .forEach(element => {
    if (isNaN(+element)) {
      lettersAndSymbols.push(element);
    }
    else{
      numbers.push(Number(element));
    }  
  });
  let asciiCodes = [];
  let fromAscii = [];
  lettersAndSymbols.forEach(word =>{
    let p = document.createElement("p");
    for (let i = 0; i < word.length; i++) {
      if (i == word.length - 1) {
        p.innerHTML += word[i].charCodeAt(0);
      }
      else{
        p.innerHTML += word[i].charCodeAt(0) + " ";
      }
    }
    resultSpan.appendChild(p);
  });
  let p = document.createElement("p");
  numbers.forEach(number =>{
    p.innerHTML+=String.fromCharCode(number);
  });
  resultSpan.appendChild(p);
} 