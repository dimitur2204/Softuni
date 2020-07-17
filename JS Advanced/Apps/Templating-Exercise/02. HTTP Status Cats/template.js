(() => {
	const catsEl = document.querySelector('#allCats');
	const renderCatTemplate = async () => {
		// TODO: Render cat template and attach events
		const cats = window.cats;
		const catHbString = await fetch(
			'./templates/cat-template.hbs'
		).then((res) => res.text());
		const allCatsHbString = await fetch('./templates/cats.hbs').then((res) =>
			res.text()
		);
		Handlebars.registerPartial('cat', catHbString);
		const catsTemplate = Handlebars.compile(allCatsHbString);
		const html = catsTemplate({ cats });
		catsEl.innerHTML = html;
	};
	renderCatTemplate();
	const showStatusCode = (e) => {
		const parent = e.target.parentElement;
		const classes = e.target.classList;
		const btn = e.target;
		if (!classes.contains('showBtn')) {
			return;
		}
		const statusDiv = parent.querySelector('.status');
		if (statusDiv.style.display == 'none') {
			btn.innerHTML = 'Hide status code';
			statusDiv.style.display = '';
		} else {
			btn.innerHTML = 'Show status code';
			statusDiv.style.display = 'none';
		}
	};
	window.addEventListener('click', showStatusCode);
})();
