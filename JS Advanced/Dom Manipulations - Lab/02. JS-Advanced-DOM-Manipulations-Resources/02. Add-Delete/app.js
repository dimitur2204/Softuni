function addItem() {
    const button = document.querySelector('[type=button]');
    button.addEventListener('click', () => {
        let textToAdd = document.querySelector('#newText').value;
       
        const list = document.querySelector('#items');
        let newListElement = document.createElement('li');
        newListElement.innerHTML = `${textToAdd}`;
        const deleteAnker = document.createElement('a');
        deleteAnker.href = '#';
        deleteAnker.innerHTML = '[Delete]';
        newListElement.appendChild(deleteAnker);
        list.appendChild(newListElement);
        const link = newListElement.lastChild;  
        textToAdd = '';
        link.addEventListener('click', (ev) => {
            ev.target.parentNode.remove();
        }); 
    });
}