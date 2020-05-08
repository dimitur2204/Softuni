function solve(arr) {
var step = arr.pop();
for (let index = 0; index < arr.length; index+=Number(step)) {
    const element = arr[index];
    console.log(element);
}
}
solve(['1', 
'2',
'3', 
'4', 
'5', 
'6']

);