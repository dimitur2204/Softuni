const loadBtn = document.querySelector('#btnLoadPosts');
const postsEl = document.querySelector('#posts');
const viewBtn = document.querySelector('#btnViewPost');
const titleEl = document.querySelector('#post-title');
const bodyEl = document.querySelector('#post-body');
const commentsUl = document.querySelector('#post-comments');
const loadPosts = () => {
	const url = `https://blog-apps-c12bf.firebaseio.com/posts.json`;
	fetch(url)
		.then((res) => res.json())
		.then((posts) => {
			console.log(posts);
			for (const [key, value] of Object.entries(posts)) {
				const option = document.createElement('option');
				option.value = key;
				option.text = value.title;
				postsEl.appendChild(option);
			}
		});
};
const viewPosts = () => {
	titleEl.textContent = '';
	bodyEl.textContent = '';
	commentsUl.textContent = '';
	const url = `https://blog-apps-c12bf.firebaseio.com/posts/${
		postsEl.options[postsEl.selectedIndex].value
	}.json`;
	fetch(url)
		.then((res) => res.json())
		.then((postData) => {
			titleEl.textContent = postData.title;
			bodyEl.textContent = postData.body;
			Object.values(postData.comments || {}).forEach((comment) => {
				const li = document.createElement('li');
				li.textContent = comment.text;
				commentsUl.appendChild(li);
			});
		});
};
function attachEvents() {
	loadBtn.addEventListener('click', loadPosts);
	viewBtn.addEventListener('click', viewPosts);
}

attachEvents();
