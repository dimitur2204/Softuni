function donka(a,b){
    function getDivisors(number){
        let divisors = [];
for (let index = 1; index <= number; index++) {
    const element = index;
    if (number%element == 0) {
        divisors.push(element);
    }
}
return divisors;
    }
let divisorsOfA = getDivisors(a);
let divisorsOfB = getDivisors(b);
let sth = divisorsOfA
.concat(divisorsOfB)
.sort();
let dupes = [];
for (let index = 0; index < sth.length; index++) {
    const element = sth[index];
    if (element == sth[index + 1]) {
        dupes.push(element);
    }
}

console.log(dupes.sort().reverse()[0]);

}
donka(15,5)