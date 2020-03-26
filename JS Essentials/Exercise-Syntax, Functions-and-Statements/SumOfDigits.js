function solve(number){
let sum = 0;
let boolIsSame = true;
let prevNumber = number%10;
while (number != 0) {
    if (number%10 != prevNumber) {
        boolIsSame = false;
    }
    sum+=number%10;
    prevNumber = number%10;
    number= Math.floor(number/10);    
}
console.log(boolIsSame);
console.log(sum);
}
solve(1234);