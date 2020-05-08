function solve() {
    let word = document.getElementById("word").value;
    let array = JSON.parse(document.getElementById("text").value.trim());
    let wordToReplace = array[0].split(" ")[2].toLowerCase();
    let result = document.getElementById("result");
    array.forEach(element => {
        let p = document.createElement("p");
        let regEx = new RegExp(wordToReplace, "gi");
        element = element.replace(regEx, word);
        p.innerHTML = element;
        result.appendChild(p);
    });
}