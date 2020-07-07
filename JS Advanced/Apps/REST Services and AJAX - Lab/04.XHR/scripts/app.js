function loadRepos() {
	const url = 'https://api.github.com/users/testnakov/repos';
	// REST normal API
	// const xmlHttpRequest = new XMLHttpRequest();
	const resDiv = document.querySelector('#res');
	// xmlHttpRequest.addEventListener('readystatechange', () => {
	// 	if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {
	// 		resDiv.textContent += xmlHttpRequest.responseText;
	// 	}
	// });
	// xmlHttpRequest.open('GET', url);
	// xmlHttpRequest.send();

	//Fetch API
	fetch(url)
		.then((res) => {
			if (res.status === 200) {
				return res.json();
			} else if (res.status === 401) {
				console.log('Unath');
			} else if (res.status === 500) {
				console.log('Server Error');
			}
		})
		.then((data) => {
			if (!data) {
				return;
			}
			resDiv.textContent += JSON.stringify(data);
		});
}
