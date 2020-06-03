let test = (function adder() {
    let sum = 0
    return function add(number) {
        sum+=number;
        add.call = function () {
            return sum;
        }
        return add;
    }
})();
console.log(test(1)(5)(6).call());