function solve() {
	const inputDiv = document.getElementById('container');
	const inputFields = inputDiv.getElementsByTagName('input');
	const form = document.getElementById('add');
	form.onsubmit = () => false;
	const getName = function () {
		return inputFields[0].value;
	};
	const setName = function (value) {
		inputFields[0].value = value;
	};
	const getAge = function () {
		return inputFields[1].value;
	};
	const setAge = function (value) {
		inputFields[1].value = value;
	};
	const getKind = function () {
		return inputFields[2].value;
	};
	const setKind = function (value) {
		inputFields[2].value = value;
	};
	const getOwner = function () {
		return inputFields[3].value;
	};
	const setOwner = function (value) {
		inputFields[3].value = value;
	};
	const validator = {
		validateValue: function (value) {
			return value ? true : false;
		},
		validateAge: function (value) {
			return isNaN(value) ? false : true;
		},
	};
	const checkInputs = function (inputs) {
		for (const key in inputs) {
			if (!validator.validateValue(inputs[key])) {
				return false;
			}
			if (key === 'age' && !validator.validateAge(inputs[key])) {
				return false;
			}
		}
		return true;
	};
	const addBtn = inputDiv.getElementsByTagName('button')[0];
	const adoptionSec = document.getElementById('adoption');
	const adoptionUl = adoptionSec.getElementsByTagName('ul')[0];
	const adoptedUl = document
		.getElementById('adopted')
		.getElementsByTagName('ul')[0];
	const removeFromAdopted = (e) => {
		e.currentTarget.parentElement.remove();
	};
	const moveToAdopted = (e) => {
		const list = e.currentTarget.parentElement.parentElement;
		const nameField = list
			.getElementsByTagName('div')[0]
			.getElementsByTagName('input')[0];
		if (nameField.value) {
			const ownerSpan = list.getElementsByTagName('span')[0];
			ownerSpan.textContent = `New Owner: ${nameField.value}`;
			const checkedBtn = document.createElement('button');
			checkedBtn.textContent = 'Checked';
			checkedBtn.addEventListener('click', removeFromAdopted);
			list.appendChild(checkedBtn);
			list.removeChild(list.getElementsByTagName('div')[0]);
			e.currentTarget.remove();
			list.remove();
			adoptedUl.appendChild(list);
		}
	};
	const contactClick = (e) => {
		const contactDiv = document.createElement('div');
		const nameField = document.createElement('input');
		const list = e.currentTarget.parentElement;
		nameField.placeholder = 'Enter your names';
		const takeItBtn = document.createElement('button');
		takeItBtn.addEventListener('click', moveToAdopted);
		takeItBtn.textContent = 'Yes! I take it!';
		contactDiv.appendChild(nameField);
		contactDiv.appendChild(takeItBtn);
		list.appendChild(contactDiv);
		e.currentTarget.remove();
	};
	const addPet = () => {
		const input = {
			name: getName(),
			age: getAge(),
			kind: getKind(),
			currentOwner: getOwner(),
		};
		if (checkInputs(input)) {
			const list = document.createElement('li');
			const para = document.createElement('p');
			const ownerSpan = document.createElement('span');
			const contactButton = document.createElement('button');
			contactButton.addEventListener('click', contactClick);
			para.innerHTML = `<strong>${input.name}</strong> is a <strong>${input.age}</strong> year old <strong>${input.kind}</strong>`;
			ownerSpan.textContent = `Owner: ${input.currentOwner}`;
			contactButton.textContent = 'Contact with owner';
			list.appendChild(para);
			list.appendChild(ownerSpan);
			list.appendChild(contactButton);
			console.log(list);
			adoptionUl.appendChild(list);
			setName('');
			setAge('');
			setKind('');
			setOwner('');
		}
	};
	addBtn.addEventListener('click', addPet);
}
