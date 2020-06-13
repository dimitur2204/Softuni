function getFibonator() {
    let fibonator = [];
    return function () {
        if (fibonator.length == 0 || fibonator.length == 1) {
            fibonator.push(1)
            return 1;
        }
        else{
            fibonator.push(fibonator[fibonator.length - 1] + fibonator[fibonator.length - 2]);
            return fibonator[fibonator.length-1];
        }
    }
}
let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());