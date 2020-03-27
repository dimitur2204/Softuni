function createArticle() {	
	let titleHeading = document.createElement("h3");
	let paragraph = document.createElement("p");
	let title = document.getElementById("createTitle");
	let articles = document.getElementById("articles");
	let content = document.getElementById("createContent");
	let article = document.createElement("article");
	if (title.value && content.value) {
		titleHeading.innerHTML = title.value;
		article.appendChild(titleHeading);	 
		paragraph.innerHTML = content.value;
		article.appendChild(paragraph);
		articles.appendChild(article);
}
title.value = "";
content.value = "";
}