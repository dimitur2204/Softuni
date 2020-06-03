function solution(command) {
    function upvote() {
        post.upvotes++;
    }
    function downvote() {
        post.downvotes++;
    }
    function score() {
        let totalVotes = post.downvotes + post.upvotes;
        let totalScore = post.upvotes - post.downvotes;
        if (totalVotes > 50) {
            let upvotesToReport;
            letdownvotesToReport;
            if (post.upvotes > post.downvotes) {
                const numberToAdd = Math.round(post.upvotes * 0.25);
                upvotesToReport = post.upvotes + numberToAdd;
                downvotesToReport = post.downvotes + numberToAdd;
            }
            else{
                const numberToAdd = Math.round(post.downvotes * 0.25);
                upvotesToReport = post.upvotes + numberToAdd;
                downvotesToReport = post.downvotes + numberToAdd;
            }
            let rating;
            if ((post.upvotes/totalScore) * 100 >= 66) {
                rating = 'hot';
            }
            else if (totalScore >= 0 && (post.upvotes >= 100 || post.downvotes >= 100)) {
                rating = 'controversial';
            }
            else if (totalScore < 0) {
                rating = 'unpopular';
            }
            else if (totalVotes < 10) {
                rating = 'new';
            }
            else{
                rating = 'new';
            }
            return [upvotesToReport,downvotesToReport,totalScore,rating];
        }
        else{
            let rating;
            if ((post.upvotes/totalScore) * 100 >= 66) {
                rating = 'hot';
            }
            else if (totalScore >= 0 && (post.upvotes >= 100 || post.downvotes >= 100)) {
                rating = 'controversial';
            }
            else if (totalScore < 0) {
                rating = 'unpopular';
            }
            else if (totalVotes < 10) {
                rating = 'new';
            }
            else{
                rating = 'new';
            }
            return [upvotesToReport,downvotesToReport,totalScore,rating];
        }
    }
}
let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score');
console.log(score); // [127, 127, 0, 'controversial']
solution.call(post, 'downvote');         // (executed 50 times)
score = solution.call(post, 'score');     
