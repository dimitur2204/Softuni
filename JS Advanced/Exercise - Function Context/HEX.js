class Hex{
    constructor(value){
        this.value = value;
    };
    valueOf(){
        return this.value;
    };
    toString(){
    return '0x' + this.value.toString(16).toUpperCase();
    };
    plus(number){
        if (typeof number === 'Hex') {
            return new Hex(this.value + number.valueOf());
        }
        else{
            return new Hex(this.value + number);
        }
        return this;
    };
    minus(number){
        if (typeof number === 'Hex') {
            return new Hex(this.value - number.valueOf());
        }
        else{
            return new Hex(this.value -= number)
        } 
    }
    parse(hexNumber){
        decimalNumber = parseInt(hexNumber.toLowerCase().slice(2), 16);
        return decimalNumber;
    };
}
let FF = new Hex(255); 

console.log(FF.toString()); 

FF.valueOf() + 1 == 256; 

let a = new Hex(10); 

let b = new Hex(5); 

console.log(a.plus(b).toString()); 

console.log(a.plus(b).toString()==='0xF'); 