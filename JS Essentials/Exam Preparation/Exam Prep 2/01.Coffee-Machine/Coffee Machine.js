function solve(input) {
    let totalSum = 0;
    for (const info of input) {
        let tokens = info.split(", ");
        let coins = Number(tokens[0]);
        let drink = tokens[1];
        let price = 0.8;
        if (info.includes("decaf")) {
            price+=0.10;
        }
        if(info.includes("milk")){
            price+=price*0.1;
        }
        if(Number(tokens.pop()) > 0){
            price+=0.10;
        }
        if (coins >= price) {
            console.log(`You ordered ${drink}. Price: ${price.toFixed(2)}$ Change: ${(coins - price).toFixed(2)}$'`);
            totalSum+=price;
        }
        else{
            console.log(`Not enough money for ${drink}. Need ${(price - coins).toFixed(2)}$ more`);
        }
    }
    console.log(`Income Report: ${totalSum.toFixed(2)}$`);
}
solve(['8.00, coffee, decaf, 4',
'1.00, tea, 2']);