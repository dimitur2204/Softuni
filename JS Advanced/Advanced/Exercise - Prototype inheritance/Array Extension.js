(function solve() {
	Array.prototype.last = function () {
		return this[this.length - 1];
	};
	Array.prototype.skip = function (n) {
		return this.slice(n, this.length - n + 1);
	};
	Array.prototype.take = function (n) {
		return this.slice(0, n);
	};
	Array.prototype.sum = function () {
		return this.reduce((acc, curr) => {
			return acc + curr;
		}, 0);
	};
	Array.prototype.average = function () {
		return this.sum() / this.length;
	};
})();
