const phoneBookEl = document.querySelector('#phonebook');
const loadBtn = document.querySelector('#btnLoad');
const createBtn = document.querySelector('#btnCreate');
function attachEvents() {
	const url = `http://localhost:8000/phonebook`;
	const loadData = () => {
		phoneBookEl.innerHTML = '';
		const deleteBtnNode = document.createElement('button');
		deleteBtnNode.textContent = 'Delete';
		const deleteEntry = (e) => {
			let li = e.currentTarget.parentNode;
			let key = li.id;
			li.remove();
			const deleteUrl = url + '/' + key;
			fetch(deleteUrl, {
				method: 'DELETE',
			})
				.then((res) => res.json())
				.then((data) => data);
		};

		deleteBtnNode.addEventListener('click', deleteEntry);

		fetch(url)
			.then((res) => res.json())
			.then((data) => {
				for (const key in data) {
					const li = document.createElement('li');
					li.id = key;
					li.textContent = `${data[key].person}: ${data[key].phone}`;
					const deleteBtn = deleteBtnNode.cloneNode(true);
					deleteBtn.addEventListener('click', deleteEntry);
					li.appendChild(deleteBtn);
					phoneBookEl.appendChild(li);
				}
			});
	};

	const createPerson = () => {
		const personField = document.querySelector('#person');
		const phoneField = document.querySelector('#phone');
		const personToSend = {
			person: personField.value,
			phone: phoneField.value,
		};
		fetch(url, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(personToSend),
		});
	};
	createBtn.addEventListener('click', createPerson);
	createBtn.addEventListener('click', loadData);
	loadBtn.addEventListener('click', loadData);
}

attachEvents();
