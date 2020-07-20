(async function () {
	const BASE_URL =
		'https://api.backendless.com/FDBF10C1-75D2-BE41-FF57-5ED27AC6E500/4902CC97-6754-42CF-9639-C8FCF5C4ED1B/data/furniture';
	const homeEl = document.querySelector('#home');
	const createEl = document.querySelector('#create');
	await (async function registerPartials() {
		const furnitureTemplateString = await fetch(
			'./templates/partials/furniture-partial.hbs'
		).then((res) => res.text());
		const myFurnitureTemplateString = await fetch(
			'./templates/partials/my-furniture-partial.hbs'
		).then((res) => res.text());
		Handlebars.registerPartial({
			furniture: furnitureTemplateString,
			myFurniture: myFurnitureTemplateString,
		});
	})();
	const app = Sammy('#container');
	app.get('#/', function () {
		this.redirect('#/furniture/all');
	});
	app.get('#/furniture/all', async function () {
		const furnitureData = await fetch(BASE_URL).then((res) => res.json());
		const furnitureTemplateString = await fetch(
			'./templates/all-furniture.hbs'
		).then((res) => res.text());
		const furnitureTemplate = Handlebars.compile(furnitureTemplateString);
		const furnitureHTML = furnitureTemplate({ furnitureData });
		app.swap(furnitureHTML);
	});
	app.get('#/furniture/details/:id', async function (context) {
		const id = context.params.id;
		const item = await fetch(BASE_URL + `/${id}`).then((res) => res.json());
		const detailHbsString = await fetch(
			'./templates/furniture-detail.hbs'
		).then((res) => res.text());
		const detailTemplate = Handlebars.compile(detailHbsString);
		this.swap(detailTemplate({ item }));
	});
	app.get('#/furniture/create', async function () {
		const createHTML = await fetch(
			'./templates/create-furniture.hbs'
		).then((res) => res.text());
		app.swap(createHTML);
		const inputs = {
			make: document.querySelector('#new-make'),
			model: document.querySelector('#new-model'),
			year: document.querySelector('#new-year'),
			description: document.querySelector('#new-description'),
			price: document.querySelector('#new-price'),
			imageUrl: document.querySelector('#new-image'),
			material: document.querySelector('#new-material'),
		};
		const validateInputs = (inputs) => {
			const inputEls = Object.values(inputs);
			const keys = Object.keys(inputs);
			let valid = true;
			const minimumLengthValidation = (input, length) => {
				if (input.length < length) {
					return false;
				}
				return true;
			};
			const yearValidation = (year) => {
				if (year < 1950 || year > 2050) {
					return false;
				}
				return true;
			};
			const addValidClass = (element) => {
				element.classList.add('is-valid');
				element.classList.remove('is-invalid');
			};
			const addInvalidClass = (element) => {
				element.classList.add('is-invalid');
				element.classList.remove('is-valid');
			};
			keys.forEach((key, index) => {
				const currentEl = inputEls[index];
				if (key === 'make' || key === 'model') {
					if (minimumLengthValidation(currentEl.value, 4)) {
						addValidClass(currentEl);
					} else {
						valid = false;
						addInvalidClass(currentEl);
					}
				} else if (key === 'description') {
					if (minimumLengthValidation(currentEl.value, 10)) {
						addValidClass(currentEl);
					} else {
						valid = false;

						addInvalidClass(currentEl);
					}
				} else if (key === 'imageUrl') {
					if (currentEl.value !== '') {
						addValidClass(currentEl);
					} else {
						valid = false;

						addInvalidClass(currentEl);
					}
				} else if (key === 'year') {
					if (yearValidation(currentEl.value)) {
						addValidClass(currentEl);
					} else {
						valid = false;

						addInvalidClass(currentEl);
					}
				} else if (key === 'price') {
					if (currentEl.value !== '' && Number(currentEl.value) >= 0) {
						addValidClass(currentEl);
					} else {
						valid = false;

						addInvalidClass(currentEl);
					}
				}
			});
			return valid;
		};
		const submitBtn = document.querySelector('div.col-md-4>input.btn');
		const submitClick = async (e) => {
			e.preventDefault();
			if (validateInputs(inputs)) {
				const item = Object.entries(inputs).reduce((acc, curr) => {
					if (curr[0] === 'year' || curr[0] === 'price') {
						acc[curr[0]] = +curr[1].value;
						return acc;
					}
					acc[curr[0]] = curr[1].value;
					return acc;
				}, {});
				fetch(BASE_URL, {
					method: 'POST',
					body: JSON.stringify(item),
				});
				this.redirect('#/');
			}
		};
		submitBtn.addEventListener('click', submitClick);
	});
	app.run('#/');
})();
