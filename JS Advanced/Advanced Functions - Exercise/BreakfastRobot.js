function solution() {
    let ingredients = 
    {
        'protein':0,
        'carbohydrate':0,
        'fat':0,
        'flavour':0
    }
    function restock(ingredient,quant) {
        ingredients[ingredient] += quant;
        return 'Success';
    }
    function prepare(recipe,quant) {
        if (recipe == 'apple') {
            let carbsNeeded = 1 * quant;
            let flavourNeeded = 2 * quant;
            if (ingredients['carbohydrate'] < carbsNeeded) {
                return `Error: not enough carbohydrate in stock`;
            }
            else if (ingredients['flavour'] < flavourNeeded) {
                return `Error: not enough flavour in stock`;
            }
            else
            {
                ingredients['carbohydrate'] -= carbsNeeded;
                ingredients['flavour'] -= flavourNeeded;
                return `Success`;
            }
        }
        else if (recipe == 'lemonade') {
            let carbsNeeded = 10 * quant;
            let flavourNeeded = 20 * quant;
            if (ingredients['carbohydrate'] < carbsNeeded) {
                return `Error: not enough carbohydrate in stock`;
            }
            else if (ingredients['flavour'] < flavourNeeded) {
                return `Error: not enough flavour in stock`;
            }
            else
            {
                ingredients['carbohydrate'] -= carbsNeeded;
                ingredients['flavour'] -= flavourNeeded;
                return `Success`;
            }
        }
        else if (recipe == 'burger') {
            let carbsNeeded = 5 * quant;
            let flavourNeeded = 3 * quant;
            let fatsNeeded = 7 * quant;
            if (ingredients['carbohydrate'] < carbsNeeded) {
                return `Error: not enough carbohydrate in stock`;
            }
            else if (ingredients['fat']< fatsNeeded) {
                return `Error: not enough fat in stock`;
            }
            else if (ingredients['flavour'] < flavourNeeded) {
                return `Error: not enough flavour in stock`;
            }
            else
            {
                ingredients['fat'] -= fatsNeeded;
                ingredients['carbohydrate'] -= carbsNeeded;
                ingredients['flavour'] -= flavourNeeded;
                return `Success`;
            }
        }
        else if (recipe == 'eggs') {
            let proteinNeeded = 5 * quant;
            let flavourNeeded = 1 * quant;
            let fatsNeeded = 1 * quant;
            if (ingredients['protein'] < proteinNeeded) {
                return `Error: not enough protein in stock`;
            }
            else if (ingredients['fat']< fatsNeeded) {
                return `Error: not enough fat in stock`;
            }
            else if (ingredients['flavour'] < flavourNeeded) {
                return `Error: not enough flavour in stock`;
            }
            else
            {
                ingredients['protein'] -= proteinNeeded;
                ingredients['fat'] -= fatsNeeded;
                ingredients['flavour'] -= flavourNeeded;
                return `Success`;
            }
        }
        else if (recipe == 'turkey') {
            let carbsNeeded = 10 * quant;
            let proteinNeeded = 10 * quant;
            let flavourNeeded = 10 * quant;
            let fatsNeeded = 10 * quant;
            if (ingredients['protein'] < proteinNeeded) {
                return `Error: not enough protein in stock`;
            }
            else if (ingredients['carbohydrate'] < carbsNeeded) {
                return `Error: not enough carbohydrate in stock`;
            }
            else if (ingredients['fat'] < fatsNeeded) {
                return `Error: not enough fat in stock`;
            }
            else if (ingredients['flavour'] < flavourNeeded) {
                return `Error: not enough flavour in stock`;
            }
            else
            {
                ingredients['protein'] -= proteinNeeded;
                ingredients['fat'] -= fatsNeeded;
                ingredients['carbohydrate'] -= carbsNeeded;
                ingredients['flavour'] -= flavourNeeded;
                return `Success`;
            }
        }
    }
    function report() {
        return `protein=${ingredients['protein']} carbohydrate=${ingredients['carbohydrate']} fat=${ingredients['fat']} flavour=${ingredients['flavour']}`
    }
    return function getCommand(commands) {
        let tokens = commands.split(' ');
        let command = tokens[0];
        if (command == 'restock') {
            return restock(tokens[1],Number(tokens[2]));
        }
        else if (command == 'prepare') {
            return prepare(tokens[1],Number(tokens[2]));
        }
        else if (command == 'report') {
            return report();
        }
    }
}
let manager = solution();
console.log(manager("restock protein 100"));
console.log(manager("restock carbohydrate 100"));
console.log(manager("restock fat 100"));
console.log(manager("restock flavour 100"));
console.log(manager("report"));
console.log(manager("prepare eggs 2"));
console.log(manager("report"));
console.log(manager("prepare eggs 1"));
console.log(manager("report"));