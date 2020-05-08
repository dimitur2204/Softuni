function solve() {
let eastRegex = new RegExp(/east \d{2},\d{6}([^east (\d{2},\d{6})]*?)/,"gi");
let northRegex = new RegExp(/north (\d{2},\d{6})/, "gi");
let messageString = document.getElementById("string").value;
console.log(messageString);
let messageRegex = new RegExp(messageString + "(.*)" 
+ messageString,"g");
console.log(messageRegex);
let text = document.getElementById("text").value;
console.log(messageRegex.exec(text)[1]);
let eastMatches = eastRegex.exec;
let northMatches = text.matchAll(northRegex);
let east = eastMatches[eastMatches.length - 1];
let north = northMatches[northMatches.length - 1];
console.log(east);
console.log(north);
}