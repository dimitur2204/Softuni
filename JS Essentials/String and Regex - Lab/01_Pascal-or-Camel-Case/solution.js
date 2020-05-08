function solve() {
  let text = document.getElementById("text").value;
  let convention = document.getElementById("naming-convention").value;
  let resultSpan = document.getElementById("result");
  let transformedText = "";
  if (convention == "Pascal Case") {
    let words = text
    .split(" ");
    words.forEach(element => {
      let newElement = element[0].toUpperCase()
       + element.slice(1).toLowerCase();
       transformedText += newElement;
    });
    resultSpan.innerHTML = transformedText;
  }
  else if(convention == "Camel Case"){
    let words = text
    .split(" ");
    words.forEach(element => {
      let newElement = element[0].toUpperCase()
       + element.slice(1).toLowerCase();
      if (words[0] == element) {
        newElement = newElement[0].toLowerCase() + newElement.slice(1).toLowerCase();
      }
       transformedText += newElement;
    });
    resultSpan.innerHTML = transformedText;
  }
  else{
    resultSpan.innerHTML = "Error!";
  }
}