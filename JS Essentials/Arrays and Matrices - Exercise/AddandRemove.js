function solve(arr) {
    let number = 1;
    let myArr = [];
    while (arr.length > 0) {
        let command = arr.shift();
        if (command == "add") {
            myArr.push(number);
        }
        else{
            myArr.pop();
        }
        number ++;
    }
    if (myArr.length > 0) {
        console.log(myArr.join("\n"));
    }
    else{
        console.log("Empty");
    }
}
solve(['remove', 
'remove', 
'remove']

);