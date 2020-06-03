function deleteByEmail() {
    const table = document.querySelector('#customers');
    const headerColumns= document.querySelectorAll('th');
    let emailIndex;
    const resultDiv = document.querySelector('#result');
    for(header in headerColumns)
    {
        if (headerColumns[header].textContent == 'Email') {
            emailIndex = header;
        }
    }
    const emailToDelete = document.querySelector('[type=text]').value;
    const rows = table.querySelector('tbody').querySelectorAll('tr');
    let deleted = false;
    for (const row of rows) {
        if(row.children[emailIndex].innerHTML == emailToDelete){
            row.children[emailIndex].parentElement.remove();
            deleted = true;
        }
    }
    if (deleted) {
        resultDiv.innerHTML = 'Deleted.';
    }else{
        resultDiv.innerHTML = 'Not found.';
    }
}