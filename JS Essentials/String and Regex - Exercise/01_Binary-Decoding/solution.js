function solve() {
	let input = document.getElementById("input").value;
	let sumOfOnes = 0;
	let myString = "";
	let regex = /[\w ]/;
	let result = document.getElementById("resultOutput");
	for (const symbol of input) {
		if (symbol == 1) {
			sumOfOnes++;
		}
	}
	let numberToTrim = 0;
	for (const symbol of sumOfOnes.toString()) {
		numberToTrim+=Number(symbol);
	}
	console.log(numberToTrim);
	input = input.slice(numberToTrim,input.length - numberToTrim);
	for (let i = 0; i < input.length; i+=numberToTrim * 2) {
		let number = input.substr(i,numberToTrim * 2);
		let decimalNumber = parseInt(number, 2);
		if (!(regex.test(String.fromCharCode(decimalNumber)))) {
			continue;
		}
		console.log(decimalNumber);
		let symbol = String.fromCharCode(decimalNumber);
		myString += symbol;
	}
	result.innerHTML += myString;
}