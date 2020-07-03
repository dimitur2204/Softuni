const { describe } = require('mocha');
const should = require('chai').should();
const lib = require('./functions');
describe('Sum tests', function () {
	it('Should be NaN when strings are not numbers', function () {
		const arr = ['1', 'asdf', '3'];
		lib.sum(arr).should.be.NaN;
	});
	it('Should return sum correctly when strings are numbers', function () {
		const arr = ['1', '2', '3'];
		lib.sum(arr).should.equal(6);
	});
	it('Should return sum correctly', function () {
		const arr = [1, 2, 3];
		lib.sum(arr).should.equal(6);
	});
});
describe('isSymmetric tests', function () {
	it('Should return false when input is not arr', function () {
		const arr = 'hello';
		lib.isSymmetric(arr).should.be.false;
	});
	it('Should return false when arr is not symmetric', function () {
		const arr = ['1', 'asdf', '3'];
		lib.isSymmetric(arr).should.be.false;
	});
	it('Should return true when arr is symmetric', function () {
		const arr = ['1', '2', '1'];
		lib.isSymmetric(arr).should.be.true;
	});
	it('Should return true when arr is empty', function () {
		const arr = [];
		lib.isSymmetric(arr).should.be.true;
	});
});
describe('rgbToHexTests', function () {
	it('Should return undefined when any of the colors is not an integer', function () {
		const result = lib.rgbToHexColor(-1.5, '255', 'asdf');
		should.not.exist(result);
	});
	it('Should return undefined when red is not between 0 - 255', function () {
		const result = lib.rgbToHexColor(-1, 255, 255);
		should.not.exist(result);
	});
	it('Should return undefined when green is not between 0 - 255', function () {
		const result = lib.rgbToHexColor(255, -1, 255);
		should.not.exist(result);
	});
	it('Should return undefined when blue is not between 0 - 255', function () {
		const result = lib.rgbToHexColor(255, 255, -1);
		should.not.exist(result);
	});
	it('Should return hex when colors are correctly given', function () {
		const result = lib.rgbToHexColor(252, 186, 3);
		result.should.equal('#FCBA03');
	});
});
describe('createCalculatorTest', function () {
	it('Should init calculator successfully', function () {
		const calc = lib.createCalculator();
		calc.get().should.equal(0);
		calc.should.be.a('object');
		calc.should.have.property('get');
		calc.should.have.property('add');
		calc.should.have.property('subtract');
	});
	it('Should add numbers successfully', function () {
		const calc = lib.createCalculator();
		calc.add(5);
		calc.add(-2);
		calc.add(0);
		calc.get().should.equal(3);
	});
	it('Should subtract numbers successfully', function () {
		const calc = lib.createCalculator();
		calc.subtract(5);
		calc.subtract(-2);
		calc.subtract(0);
		calc.get().should.equal(-3);
	});
});
