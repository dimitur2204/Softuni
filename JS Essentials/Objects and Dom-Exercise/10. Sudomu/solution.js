function solve() {
let checkBtn = document.getElementsByTagName("button")[0];
let clearBtn = document.getElementsByTagName("button")[1];
let numbers = document.getElementsByTagName("input");
let table = document.getElementsByTagName("table")[0];
let paragraph = document.getElementsByTagName("p")[0];
checkBtn.addEventListener("click", e =>{
    let one = numbers[0].value;
    let two= numbers[1].value;
    let three= numbers[2].value;
    let four= numbers[3].value;
    let five= numbers[4].value;
    let six= numbers[5].value;
    let seven= numbers[6].value;
    let eight= numbers[7].value;
    let nine= numbers[8].value;
    console.log(nine);
    if (one != two && one != three &&
        one != four && one != seven &&
        two != three && four != seven &&
        four != five && four != six &&
        five != six && two != five && 
        two != eight && five != eight &&
        seven != eight && seven != nine &&
        eight != nine && three != six &&
        three != nine && six != nine) {
            paragraph.style.color = "green";
            table.style.border = "2px solid green";
            paragraph.innerHTML = "You solve it! Congratulations!";
    }
    else{
        paragraph.style.color = "red";
        table.style.border = "2px solid red";
        paragraph.innerHTML = "NOP! You are not done yet…";
    }
});
clearBtn.addEventListener("click", e =>{
    paragraph.innerHTML = "";
    paragraph.textContent.fontcolor("");
    table.style.border = "";
    for (const number of numbers) {
        number.value = "";
    }
});
}