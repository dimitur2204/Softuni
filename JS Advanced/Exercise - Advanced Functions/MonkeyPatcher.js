function solution(command) {
	function obfuscate(upvotes, downvotes) {
		let numberToObfuscate = Math.ceil(
			(Math.max(upvotes, downvotes) * 25) / 100
		);
		return [upvotes + numberToObfuscate, downvotes + numberToObfuscate];
	}
	if (command == 'upvote') {
		this.upvotes++;
	} else if (command == 'downvote') {
		this.downvotes++;
	} else {
		let rating = '';
		const totalVotes = this.upvotes + this.downvotes;
		const balance = this.upvotes - this.downvotes;
		if ((this.upvotes / totalVotes) * 100 > 66) {
			rating = 'hot';
		} else if ((balance >= 0 && this.upvotes >= 100) || this.downvotes >= 100) {
			rating = 'controversial';
		}

		if (balance < 0) {
			rating = 'unpopular';
		}

		if (totalVotes < 10 || rating == '') {
			rating = 'new';
		}
		let result;
		if (totalVotes >= 50) {
			result = obfuscate(this.upvotes, this.downvotes);
		} else {
			result = [this.upvotes, this.downvotes];
		}
		result.push(balance);
		result.push(rating);
		return result;
	}
}
var forumPost = {
	id: '1234',
	author: 'author name',
	content: 'these fields are irrelevant',
	upvotes: 50,
	downvotes: 0,
};
solution.call(forumPost, 'upvote');
const score = solution.call(forumPost, 'score');
console.log(score);
