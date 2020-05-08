function solve() {
    let data = JSON.parse(document.getElementById("arr").value);
    let result = document.getElementById("result");
    let nameRegex = /^[A-Z][a-z]* [A-Z][a-z]*/;
    let phoneRegex = /\+359([ \-])\d\1\d{3}\1\d{3}/;
    let emailRegex = /(?<=\s)[a-z]+\@[a-z]+\.[a-z]{2,3}/;
    for (const person of data) {
        let name = person.match(nameRegex);
        let phone = person.match(phoneRegex);
        let email = person.match(emailRegex);
        if (name && phone && email) {
            let namePara = document.createElement("p");
            namePara.innerHTML = `Name: ${name[0]}`;
            let phonePara = document.createElement("p");
            phonePara.innerHTML = `Phone Number: ${phone[0]}`;
            let emailPara = document.createElement("p");
            emailPara.innerHTML = `Email: ${email[0]}`;
            result.appendChild(namePara);
            result.appendChild(phonePara);
            result.appendChild(emailPara);
            let endOfLine =document.createElement("p");
            endOfLine.innerHTML = "- - -";
            result.appendChild(endOfLine);
        }
        else{
            let invalidData = document.createElement("p");
            invalidData.innerHTML = "Invalid data";
            result.appendChild(invalidData);
            let endOfLine =document.createElement("p");
            endOfLine.innerHTML = "- - -";
            result.appendChild(endOfLine);
        }
    }
}