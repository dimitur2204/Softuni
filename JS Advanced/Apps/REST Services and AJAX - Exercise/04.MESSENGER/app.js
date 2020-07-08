const sendBtn = document.querySelector('#submit');
const refreshBtn = document.querySelector('#refresh');
const messagesArea = document.querySelector('#messages');
function attachEvents() {
	const url = 'http://localhost:8000/messenger';
	const sendMessage = () => {
		const authorEl = document.querySelector('#author');
		const contentEl = document.querySelector('#content');
		const author = authorEl.value;
		const content = contentEl.value;
		authorEl.value = '';
		contentEl.value = '';
		const message = {
			author,
			content,
		};
		fetch(url, {
			method: 'POST', // or 'PUT'
			headers: {
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(message),
		}).then((res) => res.json());
	};
	const refreshMessages = () => {
		fetch(url)
			.then((res) => res.json())
			.then((data) => {
				const messages = Object.values(data);
				const result = messages.reduce((acc, curr) => {
					acc += `${curr.author}: ${curr.content}\n`;
					return acc;
				}, '');
				messagesArea.value = result;
			});
	};
	sendBtn.addEventListener('click', sendMessage);
	refreshBtn.addEventListener('click', refreshMessages);
}
attachEvents();
