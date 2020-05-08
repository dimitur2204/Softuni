
function solve() {
    let text = document.getElementById("text").value;
    let number = Number(document.getElementById("number").value);
    let result = document.getElementById("result");
    let output = "";
    let leftover = text.length % number;
    let neededLength = text.length;
    console.log(leftover);
    if (leftover > 0) {
        while (neededLength % number != 0) {
            neededLength++;
        }
        text += text.substr(0 , neededLength - text.length);
    }
    console.log(text);
    for (let i = 0; i < text.length; i+=number) {
        let substring = text.substr(i,number);
        output += substring + " ";
    }
result.innerHTML = output.trim();
}