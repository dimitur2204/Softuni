import * as api from './data.js';
const loadBtn = document.querySelector('#loadBooks');
const tBody = document.querySelector('tbody');
const submitBtn = document.querySelector('#submit');
const validateInput = (input) => {
	let valid = true;
	for (const v of Object.values(input)) {
		if (v.value === '') {
			valid = false;
			v.classList.add('inputError');
		} else {
			v.classList.remove('inputError');
		}
	}
	if (valid === false) {
		alert('You cannot have empty fields');
	}
	return valid;
};
const postBook = async (e) => {
	e.preventDefault();
	const titleInput = document.querySelector('#title');
	const authorInput = document.querySelector('#author');
	const isbnInput = document.querySelector('#isbn');
	const bookInputs = {
		Title: titleInput,
		Author: authorInput,
		ISBN: isbnInput,
	};
	if (validateInput(bookInputs)) {
		const book = {
			Title: titleInput.value,
			Author: authorInput.value,
			ISBN: isbnInput.value,
		};
		api.createBook(book);
		Object.values(bookInputs).forEach((v) => {
			v.classList.remove('inputError');
			v.value = '';
		});
	}
};
const deleteBook = (e) => {
	const bookEl = e.currentTarget.parentElement.parentElement;
	const id = bookEl.key;
	api.deleteBook(id);
	bookEl.remove();
};
const editBook = (e) => {
	const bookEl = e.currentTarget.parentElement.parentElement;
	const editEl = document.createElement('tr');
	const oldInputs = bookEl.querySelectorAll('td');
	const titleData = document.createElement('td');
	const inputTitle = document.createElement('input');
	inputTitle.value = oldInputs[0].textContent;
	titleData.appendChild(inputTitle);
	const authorData = document.createElement('td');
	const inputAuthor = document.createElement('input');
	inputAuthor.value = oldInputs[1].textContent;
	authorData.appendChild(inputAuthor);
	const ISBNData = document.createElement('td');
	const inputISBN = document.createElement('input');
	inputISBN.value = oldInputs[2].textContent;
	ISBNData.appendChild(inputISBN);
	const btnData = document.createElement('td');
	const saveBtn = document.createElement('button');
	saveBtn.textContent = 'Save';
	const updateBook = async () => {
		const bookInput = {
			Title: inputTitle,
			Author: inputAuthor,
			ISBN: inputISBN,
		};
		if (validateInput(bookInput)) {
			const updatedBook = {
				Title: inputTitle.value,
				Author: inputAuthor.value,
				ISBN: inputISBN.value,
			};
			api.updateBook(bookEl.key, updatedBook).then(() => {
				renderBooks();
			});
		}
	};
	saveBtn.addEventListener('click', updateBook);
	const cancelBtn = document.createElement('button');
	cancelBtn.textContent = 'Cancel';
	cancelBtn.addEventListener('click', () => {
		tBody.replaceChild(bookEl, editEl);
	});
	btnData.appendChild(saveBtn);
	btnData.appendChild(cancelBtn);
	editEl.appendChild(titleData);
	editEl.appendChild(authorData);
	editEl.appendChild(ISBNData);
	editEl.appendChild(btnData);
	tBody.replaceChild(editEl, bookEl);
};
const renderBooks = async () => {
	tBody.innerHTML = 'Loading...';
	try {
		const books = await api.getBooks();
		tBody.innerHTML = '';
		books.forEach((book) => {
			const bookEl = document.createElement('tr');
			const delBtn = document.createElement('button');
			delBtn.innerHTML = 'Delete';
			delBtn.addEventListener('click', deleteBook);
			const editBtn = document.createElement('button');
			editBtn.innerHTML = 'Edit';
			editBtn.addEventListener('click', editBook);
			const td = document.createElement('td');
			td.appendChild(delBtn);
			td.appendChild(editBtn);
			bookEl.innerHTML = `<td>${book.Title}</td>
        <td>${book.Author}</td>
        <td>${book.ISBN}</td>`;
			bookEl.appendChild(td);
			bookEl.key = book.objectId;
			tBody.appendChild(bookEl);
		});
	} catch (err) {
		alert(err);
		console.error(err);
	}
};
loadBtn.addEventListener('click', renderBooks);
submitBtn.addEventListener('click', postBook);
