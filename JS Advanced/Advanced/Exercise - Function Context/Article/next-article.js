function getArticleGenerator(articles) { 
    const contentDiv = document.getElementById('content');
    return function () {
        if (articles.length > 0) {
            const article = articles.shift();
            const articleDiv = document.createElement('article');
            articleDiv.textContent = article;
            contentDiv.appendChild(articleDiv);
        }
        return;
    }
} 