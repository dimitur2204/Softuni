function convertFromBinaryToDecimal(binaryNumber){
    let sum = 0;
    let position = 0;
    for (let index = binaryNumber.length; index >= 0; index--) {
    
    let currentDigit = Number(binaryNumber[index]);
        
    sum += currentDigit * (2 ** position);
    position++;
}

console.log(sum);
}
function convertDecimalToBinary(number){
    let result = '';
    while (number > 0) {
        result = (number % 2) + result;
        number = Math.trunc(number / 2);
    }
    console.log(result);
    
}
function getBitAtOne(number){
let shiftedNumber = number >> 1;
let result = shiftedNumber & 1;
console.log(result);
}
function BitDestroyer(number, position){
let shiftedNumber = 1 << position;
shiftedNumber = ~shiftedNumber;
let result = number & shiftedNumber;
console.log(result);
}
BitDestroyer(1313,5);