function solve() {
let keys = document.getElementsByClassName("keys")[0];
let numKeys = keys.getElementsByTagName("button");
let clearButton = document.getElementsByClassName("clear")[0];
let expressionField = document.getElementById("expressionOutput");
let outputField = document.getElementById("resultOutput");
    for (const key of numKeys) {
        if (key.value != "=" && key.value != "+" &&key.value != "-" &&key.value != "*" &&key.value != "/") {
            key.addEventListener("click", e =>{
                expressionField.innerHTML += key.value ;
            });
        }
        else if (key.value != "=") {           
            key.addEventListener("click", e =>{
            expressionField.innerHTML += " " + key.value + " ";
        });
        }
        else{
            key.addEventListener("click", e =>{
                let expression = expressionField.innerHTML;
                let character = expression
                .split(/[^\+\-\*\/]/)
                .filter(x => x != "")[0];
                let leftAndRight = expression
                .split(/[\+\-\*\/]/)
                .filter(x => x != "" && x != " ");
                console.log(leftAndRight);
                if (!(leftAndRight.length < 2 || leftAndRight > 2)) {
                    if (character == "*") {
                        outputField.innerHTML = Number(leftAndRight[0])*Number(leftAndRight[1])
                    }
                    else if(character == "+"){
                        outputField.innerHTML = Number(leftAndRight[0])+Number(leftAndRight[1])
                    }
                    else if(character == "/"){
                        outputField.innerHTML = Number(leftAndRight[0])/Number(leftAndRight[1])
                    }
                    else if(character == "-"){
                        outputField.innerHTML = Number(leftAndRight[0])-Number(leftAndRight[1])
                    }
                }
                else{
                    outputField.innerHTML = Number.NaN;
                }
            });
        }
    }
    clearButton.addEventListener("click", e=>{
        console.log("object");
        outputField.innerHTML = "";
        expressionField.innerHTML = "";
    });
}