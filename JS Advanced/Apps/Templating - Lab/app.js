const loadContacts = async () => {
	const appDiv = document.querySelector('#app');
	const contactCard = await fetch('./contact-card.hbs').then((res) =>
		res.text()
	);
	const contactsCard = await fetch('./contacts.hbs').then((res) => res.text());
	const contacts = await fetch('./contacts.json').then((res) => res.json());
	Handlebars.registerPartial('contact', contactCard);
	const template = Handlebars.compile(contactsCard);
	const contactsHTML = template({ contacts });
	appDiv.innerHTML += contactsHTML;
	window.addEventListener('click', (e) => {
		const target = e.target;
		const classes = target.classList;
		if (!classes.contains('detailsBtn')) {
			return;
		}
		const detailsDiv = target.parentElement.querySelector('.details');
		if (!detailsDiv.classList.contains('hidden')) {
			detailsDiv.classList.add('hidden');
		} else {
			detailsDiv.classList.remove('hidden');
		}
	});
};
loadContacts();
