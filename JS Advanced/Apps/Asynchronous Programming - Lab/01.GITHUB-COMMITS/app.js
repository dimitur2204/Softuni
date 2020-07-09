const usernameEl = document.querySelector('#username');
const repoEl = document.querySelector('#repo');
const commitsUl = document.querySelector('#commits');
function loadCommits() {
	const username = usernameEl.value;
	const repo = repoEl.value;
	const url = `https://api.github.com/repos/${username}/${repo}/commits`;
	fetch(url)
		.then((res) => res.json())
		.then((items) => {
			commitsUl.innerHTML = '';
			items.forEach((item) => {
				const li = document.createElement('li');
				li.textContent = `${item.commit.author.name}: ${item.commit.message}`;
				commitsUl.appendChild(li);
			});
		});
}
