const describe = require('mocha').describe;
const should = require('chai').should();
const funcs = require('./../functions');
describe('OddOrEvenLength tests', function () {
	it('Should return undefined when arg is not string', function () {
		should.not.exist(funcs.isOddOrEven([123, 123, 123]));
	});
	it('Should return even when string length is 0', function () {
		funcs.isOddOrEven('').should.equal('even');
	});
	it('Should return even when string length is even', function () {
		funcs.isOddOrEven('12').should.equal('even');
	});
	it('Should return odd when string length is odd', function () {
		funcs.isOddOrEven('1').should.equal('odd');
	});
});
describe('lookupChar tests', function () {
	it('Should return undefined when first arg is not string', function () {
		should.not.exist(funcs.lookupChar([123, 123, 123], 2));
	});
	it('Should return undefined when second arg is not integer', function () {
		should.not.exist(funcs.lookupChar('123', 1.25));
	});
	it('Should return Incorrect index when second arg is out of range', function () {
		funcs.lookupChar('123', 5).should.equal('Incorrect index');
	});
	it('Should return char when string and index are valid', function () {
		funcs.lookupChar('12', 0).should.equal('1');
	});
});
describe('MathEnforcer tests', function () {
	let enforcer;
	beforeEach(function () {
		enforcer = funcs.mathEnforcer;
	});
	it('Should initialize mathEnforcer correctly', function () {
		enforcer.should.be.a('object');
		enforcer.should.have.property('addFive');
		enforcer.should.have.property('subtractTen');
		enforcer.should.have.property('sum');
	});
	describe('addFive test', function () {
		it('Should return undefined when arg is not a number', function () {
			should.not.exist(enforcer.addFive('asd'));
		});
		it('Should add 5 to arg if arg is a number', function () {
			enforcer.addFive(5).should.equal(10);
		});
	});
	describe('subtractTen test', function () {
		it('Should return undefined when arg is not a number', function () {
			should.not.exist(enforcer.subtractTen('asd'));
		});
		it('Should subtract 5 from arg if arg is a number', function () {
			enforcer.subtractTen(5).should.equal(-5);
		});
	});
	describe('sum test', function () {
		it('Should return undefined when arg1 or arg2 is not a number', function () {
			should.not.exist(enforcer.sum('asd', 1));
			should.not.exist(enforcer.sum(1, 'asd'));
		});
		it('Should add two args when they are numbers', function () {
			enforcer.sum(5, 5).should.equal(10);
		});
	});
});
