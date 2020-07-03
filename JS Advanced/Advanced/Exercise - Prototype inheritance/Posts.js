function solve() {
	class Post {
		constructor(title, content) {
			this.title = title;
			this.content = content;
		}
		toString() {
			return `Post: ${this.title}\nContent: ${this.content}\n`;
		}
	}
	class SocialMediaPost extends Post {
		constructor(title, content, likes, dislikes) {
			super(title, content);
			this.likes = likes;
			this.dislikes = dislikes;
			this.comments = [];
		}
		addComment(comment) {
			this.comments.push(comment);
		}
		toString() {
			let result = `Post: ${this.title}\nContent: ${this.content}\nRating: ${
				this.likes - this.dislikes
			}`;
			if (this.comments.length > 0) {
				result += '\nComments:\n';
				result = this.comments.reduce((acc, curr) => {
					return acc + ' * ' + curr + '\n';
				}, result);
				return result.trim();
			}
			return result.trim();
		}
	}
	class BlogPost extends Post {
		constructor(title, content, views) {
			super(title, content);
			this.views = views;
		}
		view() {
			this.views++;
			return this;
		}
		toString() {
			let result = super.toString() + `Views: ${this.views}`;
			return result;
		}
	}
	return {
		Post,
		SocialMediaPost,
		BlogPost,
	};
}
let result = solve();
let post = new result.SocialMediaPost('Title', 'Content', 10, 5);
post.addComment('nzm');
console.log(post.toString());
