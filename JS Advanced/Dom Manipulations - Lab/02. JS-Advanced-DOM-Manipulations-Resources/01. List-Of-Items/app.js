function addItem() {
    const addToList = (list,newListElement) => {
        list.appendChild(newListElement);
    }
    const textToAdd = document.querySelector('#newItemText').value;
    const button = document.querySelector('[type=button]');
    const list = document.querySelector('#items');
    let newListElement = document.createElement('li');
    newListElement.innerHTML = textToAdd;
    button.addEventListener('click', addToList(list,newListElement));    
}