function solve(input){
    let obj={};
for (let index = 0; index < input.length; index+=2) {
    const element = input[index];
    obj[element] = Number(input[index + 1]);
}
console.log(obj);
}
solve(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);