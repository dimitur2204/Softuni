function getStringModifier() {
    let string = '';
    function append(newString) {
        string += newString;
    }
    function removeStart(n) {
        string = string.substr(n);
    }
    function removeEnd(n) {
        string = string.substr(0,string.length - n);
    }
    function print() {
        console.log(string);
    }
    return {
        append: append,
        removeStart: removeStart,
        removeEnd: removeEnd,
        print: print
    }
}
let secondZeroTest = getStringModifier();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();

