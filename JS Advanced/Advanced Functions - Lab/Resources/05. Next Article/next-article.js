function getArticleGenerator(input){   
	let arr = input.slice(0);
	let divToDisplay = document.getElementById("content");
	return function showCurrentArticle() {
		let article = document.createElement("p");
		if(arr.length == 0){
			return;
		}
		article.innerHTML = arr.shift();
		divToDisplay.appendChild(article);
	}
}