function solve(arr) {
    console.log(arr.reduce((a,b) => Math.max(a,b)));
}
solve([1, 44, 123, 33]);