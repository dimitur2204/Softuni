function solve() {

    let rows = document.getElementsByTagName("li");
    let addBtn = document.getElementsByTagName("button")[0];
    let inputField = document.getElementsByTagName("input")[0];
    addBtn.addEventListener("click", e=>{
        let name = inputField.value;
        let firstLetter = name[0];
        let newName = name[0].toUpperCase() + name.slice(1).toLowerCase();
        let numberInAlphabet = firstLetter.toUpperCase().charCodeAt(0) - 64;
        if (rows[numberInAlphabet - 1].textContent == "") {
            rows[numberInAlphabet - 1].textContent += newName;
        }
        else{
            rows[numberInAlphabet - 1].textContent += ", " + newName;
        }
    });
}