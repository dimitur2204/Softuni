function solve() {
let toList = document.getElementById("selectMenuTo");
let binaryOption = document.createElement("option");
let numberDiv = document.getElementById("input");
let convertButton = document.getElementsByTagName("button")[0];
let resultDiv = document.getElementById("result");
binaryOption.text = "Binary";
binaryOption.value = "binary";
let hexOption = document.createElement("option");
hexOption.text = "Hexadecimal";
hexOption.value = "hexadecimal";
toList.add(binaryOption);
toList.add(hexOption);
convertButton.addEventListener("click", function(){
        if (toList.options[toList.selectedIndex].value == "binary") {
            
            numberDiv.value = Number(numberDiv.value).toString(2);
            resultDiv.value = numberDiv.value;
        }
        else{
            numberDiv.value = Number(numberDiv.value).toString(16).toUpperCase();
            resultDiv.value = numberDiv.value;
        }
    })
}
