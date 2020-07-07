const reposEl = document.querySelector('#repos');
const usernameEl = document.querySelector('#username');
reposEl.innerHTML = '';
function loadRepos() {
	const username = usernameEl.value;
	const url = `https://api.github.com/users/${username}/repos`;
	fetch(url)
		.then((res) => res.json())
		.then((repos) => {
			repos.forEach((repo) => {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.href = repo.html_url;
				a.innerHTML = repo.name;
				li.appendChild(a);
				reposEl.appendChild(li);
			});
		});
}
