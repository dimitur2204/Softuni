const solve = require('./Computer');
function createMixins() {
	function computerQualityMixin(classToExtend) {
		classToExtend.prototype.getQuality = function () {
			return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
		};
		classToExtend.prototype.isFast = function () {
			return this.processorSpeed > this.ram / 4;
		};
		classToExtend.prototype.isRoomy = function () {
			return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);
		};
	}
	function styleMixin(classToExtend) {
		classToExtend.prototype.isFullSet = function () {
			return (
				this.manufacturer == this.keyboard.manufacturer &&
				this.manufacturer == this.monitor.manufacturer
			);
		};
		classToExtend.prototype.isClassy = function () {
			return (
				this.battery.expectedLife >= 3 &&
				(this.color == 'Silver' || this.color == 'Black') &&
				this.weight < 3
			);
		};
	}
	return {
		computerQualityMixin,
		styleMixin,
	};
}
let result = solve();
let keyboard = new result.Keyboard('Logitech', 70);
let keyboard2 = new result.Keyboard('A-4', 70);
let monitor = new result.Monitor('Logitech', 28, 18);
let battery = new result.Battery('Energy', 3);
let laptop = new result.Laptop(
	'Hewlett Packard',
	2.4,
	4,
	0.5,
	2.99,
	'Silver',
	battery
);
let laptop2 = new result.Laptop(
	'Hewlett Packard',
	2.4,
	4,
	12,
	3.12,
	'Silver',
	battery
);
let desktop = new result.Desktop('Logitech', 3.3, 8, 1, keyboard, monitor);
let desktop2 = new result.Desktop('Logitech', 1.3, 8, 10, keyboard2, monitor);
let mixins = createMixins();
mixins.styleMixin(result.Laptop);
console.log(laptop2.isClassy());
