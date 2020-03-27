function solve(input) {
let re = /[^\w]/;
let words = input
.shift()
.split(re)
.map(x => x.trim())
.filter(x => x!="");
let result = {};
for (const word in words) {
    if (!result.hasOwnProperty(words[word])) {
        result[words[word]] = 0;
    }
    result[words[word]]++;    
}
console.log(JSON.stringify(result));
}

solve(["Far too slow, you're far too slow."])