function solve(arr) {
    let numberOfRotations = Number(arr.pop()) % arr.length;
    for (let index = 0; index < numberOfRotations; index++) {
        arr.unshift(arr.pop());              
    }
    console.log(arr.join(" "));
}
solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
);