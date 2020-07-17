(async () => {
	const renderMonkeys = async () => {
		const section = document.querySelector('section');
		const monkeys = await fetch('./monkeys.json').then((res) => res.json());
		const monkeyHbsString = await fetch(
			'./templates/monkey-template.hbs'
		).then((res) => res.text());
		Handlebars.registerPartial('monkey', monkeyHbsString);
		const monkeysHbsString = await fetch(
			'./templates/monkeys.hbs'
		).then((res) => res.text());
		const monkeyTemplate = Handlebars.compile(monkeysHbsString);
		const html = monkeyTemplate({ monkeys });
		section.innerHTML += html;
	};
	await renderMonkeys();
	const monkeyDiv = document.querySelector('.monkeys');
	const toggleInfo = (e) => {
		const btn = e.target;
		const monkeyEl = e.target.parentElement;
		if (btn.tagName.toLowerCase() != 'button') {
			return;
		}
		const infoDiv = monkeyEl.querySelector('p');
		if (infoDiv.style.display == 'none') {
			infoDiv.style.display = '';
		} else {
			infoDiv.style.display = 'none';
		}
	};
	monkeyDiv.addEventListener('click', toggleInfo);
})();
