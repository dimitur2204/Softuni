function solve(arr) {
    let max = arr[0];
    let incrArr = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] >= max) {
            max = arr[i];
            incrArr.push(max);
        }      
    }
    console.log(incrArr.join("\n"));
}
solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    );