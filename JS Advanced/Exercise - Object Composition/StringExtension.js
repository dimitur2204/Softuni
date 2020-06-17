(function () {
	function ensureStart(str) {
		let result = '';
		if (!this.includes(str)) {
			result += str;
		}
		result += this;
		return result;
	}
	function ensureEnd(str) {
		result = this;
		if (!this.includes(str)) {
			result += str;
		}
		return result;
	}
	function isEmpty() {
		if (this == '') {
			return true;
		}
		return false;
	}
	function truncate(n) {
		if (this.length <= n) {
			return this;
		} else {
			const tokens = this.split('');
			let result = tokens.reduce((acc, curr) => {
				if ((acc + curr).length < n) {
					acc += curr + ' ';
				}
				return acc;
			}, '');
		}
	}
	function format(string, ...params) {
		for (let i = 0; i < string.length; i++) {
			const symbol = string[i];
			if (symbol == '{') {
				string[i] = '';
				string[i + 1] = params[Number(string[i + 1])];
				string[i + 2] = '';
			}
		}
		return string;
	}
	String.prototype.ensureStart = ensureStart;
	String.prototype.ensureEnd = ensureEnd;
	String.prototype.isEmpty = isEmpty;
})();
let myString = 'hello';
myString = myString.ensureStart('hi');
myString = myString.ensureStart('hello');
console.log(myString);
