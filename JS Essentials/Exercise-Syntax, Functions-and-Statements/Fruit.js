function solve(fruit,quantity,price){
let moneyNeeded = quantity/1000 * price;
console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${(quantity/1000).toFixed(2)} kilograms ${fruit}.`);
}
solve('apple', 1563, 2.35);