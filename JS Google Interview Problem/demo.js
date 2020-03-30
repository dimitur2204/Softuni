// [1,21,5,784,1236,45,236]
// [56,345,36,25,24]
let [1, 8, 5];
let [4, 9, 2];
let target = 7;

function solve(firstArr, secondArr, target) {
    firstArr.sort((a, b)=> a - b);
    secondArr.sort((a, b)=> a - b);
    let x = firstArr.length - 1;
    let y = 0;

    while(x > 0 && y < secondArr.length){
        let sum = Math.abs(firstArr[x] + secondArr[y]);
        let diff = Math.abs(sum - target);
        let minDiff = 0;
        let result = [];
        if(diff < minDiff){
            result = [firstArr[x], secondArr[y]];
            minDiff = diff;
        }
        if(sum >= target){
            x--;
        }else{
            y++;
        }
    }
    console.log(result);
}

solve([1, 8, 5],[4, 9, 2],7)