(function () {
	function ensureStart(str) {
		if (!this.startsWith(str)) {
			return str + this;
		}
		return this.toString();
	}
	function ensureEnd(str) {
		if (!this.endsWith(str)) {
			return this + str;
		}
		return this.toString();
	}
	function isEmpty() {
		if (this.length === 0) {
			return true;
		}
		return false;
	}
	function truncate(n) {
		if (n <= 3) {
			return '.'.repeat(n);
		}
		if (n >= this.length) {
			return this.toString();
		}
		let spaceIndex = this.substring(0, n - 1).lastIndexOf(' ');
		if (spaceIndex > 0) {
			return this.substring(0, n - 3) + '...';
		}
	}
	function format(string, ...params) {
		params.forEach((e, i) => {
			string = string.replace(`{${i}}`, e);
		});
		return string;
	}
	String.prototype.ensureStart = ensureStart;
	String.prototype.ensureEnd = ensureEnd;
	String.prototype.isEmpty = isEmpty;
	String.prototype.truncate = truncate;
	String.format = format;
})();
let myString = 'hello';
myString = myString.ensureStart('hi');
myString = myString.ensureStart('hello');
console.log(myString);
