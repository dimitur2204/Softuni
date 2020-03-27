function solve() {
  let textElement = document.getElementById("input");
  let sentences = textElement
  .innerHTML
  .split('.')
  .filter(Boolean)
  .map(x => x + ".");
  let outputElement = document.getElementById("output");
  while (sentences.length > 0) {
    let newParagraph = document.createElement("p");
      if(sentences.length > 2) {
        newParagraph.innerHTML = sentences.shift();
        newParagraph.innerHTML += sentences.shift();
        newParagraph.innerHTML += sentences.shift();
        outputElement.appendChild(newParagraph);
      }
      else if(sentences.length > 1){
        newParagraph.innerHTML = sentences.shift();
        newParagraph.innerHTML += sentences.shift();
        outputElement.appendChild(newParagraph);
      }
      else if(sentences.length > 0){
        newParagraph.innerHTML = sentences.shift();
        outputElement.appendChild(newParagraph);
      }
  }
}