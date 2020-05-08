function solve(arr,number) {
    let arrCopy = [...arr]
    let cutSize = number;
    let firstGiant = arr.slice(0,arr.length/2);
    let secondGiant = arr.slice(arr.length/2,arr.length);
    let firstGiantSum = 0;
    let secondGiantSum = 0;
    while (firstGiant.length > 0) {
        let arr = firstGiant.slice(0,cutSize);
        firstGiant = firstGiant.slice(cutSize);
        let sum = 1;
        arr.forEach(element => {
           sum*=element;
        });
        firstGiantSum += sum;
    }
    while (secondGiant.length > 0) {
        let arr = secondGiant.slice(0,cutSize);
        secondGiant = secondGiant.slice(cutSize);
        let sum = 1;
        arr.forEach(element => {
            sum*=element;
         });
         secondGiantSum += sum;
    }
    let damagePerHit = arr.sort((a,b) => {
        return a-b;
    })[0];
    let biggestNumber = arr.sort((a,b) => {
        return a-b;
    })[arr.length - 1];
    let rounds = 1;
    while (firstGiantSum > biggestNumber && secondGiantSum > biggestNumber) {
        firstGiantSum -= damagePerHit;
        secondGiantSum -= damagePerHit;
        rounds++;
    }
    if (firstGiantSum > secondGiantSum) {
        console.log(`First Giant defeated Second Giant with result ${firstGiantSum} - ${secondGiantSum} in ${rounds} rounds`);
    }
    else if (firstGiantSum < secondGiantSum) {
        console.log(`Second Giant defeated First Giant with result ${secondGiantSum} - ${firstGiantSum} in ${rounds} rounds`);
    }
    else{
        console.log(`Its a draw ${firstGiantSum} - ${secondGiantSum}`);
    }
}
solve([4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], 2);