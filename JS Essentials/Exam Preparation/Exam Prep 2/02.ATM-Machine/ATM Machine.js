function solve(input) {
    let totalCash = 0;
    let banknotes = [];
    for (const array of input) {
        if (array.length > 2) {
            let insertedCash = 0;
            for (const banknote of array) {
                totalCash+=banknote;
                insertedCash+=banknote;
                banknotes.push(banknote);
            }
            console.log(`Service Report: ${insertedCash}$ inserted. Current balance: ${totalCash}$.`);
        }
        else if (array.length == 2) {
            let balance = array[0];
            let money = array[1];
            let initialWithdraw = money;
            if (balance < money) {
                console.log(`Not enough money in your account. Account balance: ${balance}$.`);
                continue;
            }
            if (totalCash < money) {
                console.log(`ATM machine is out of order!`);
                continue;
            }
            banknotes = banknotes.sort((a,b) =>{
                return b-a;
            });
            for (let i = 0; i < banknotes.length; i++) {
                if (money - banknotes[i] > 0) {
                    money-=banknotes[i];
                    banknotes.splice(i, 1);
                    balance -= banknotes[i];
                }
                else if(money - banknotes[i] == 0){
                    balance -= banknotes[i];
                    banknotes.splice(i, 1);
                    console.log(`You get ${initialWithdraw}$. Account balance: ${balance}$. Thank you!`);
                    break;
                }
            }
            totalCash = banknotes.reduce((a, b) => a + b, 0);
        }
        else if (array.length == 1) {
            let banknoteToSearch = array[0];
            let count = 0;
            for (const banknote of banknotes) {
                if (banknote == banknoteToSearch) {
                    count++;
                }
            }
            console.log(`Service Report: Banknotes from ${banknoteToSearch}$: ${count}.`);
        }
    }
}
solve([[20, 5, 100, 20, 1],
    [457, 25],
    [1],
    [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
    [20, 85],
    [5000, 4500],
   ]
   );