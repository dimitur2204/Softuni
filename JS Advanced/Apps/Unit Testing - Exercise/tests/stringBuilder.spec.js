const describe = require('mocha').describe;
const should = require('chai').should();
const StringBuilder = require('./../stringBuilder');
describe('String Builder tests', function () {
	let sb;
	beforeEach(function () {
		sb = new StringBuilder.StringBuilder();
	});
	describe('Constructor tests', function () {
		it('Should init StringBuilder properly without args', function () {
			sb._stringArray.should.be.a('array');
		});
		it('Should init StringBuilder properly with args', function () {
			sb = new StringBuilder.StringBuilder('Hellooo');
			sb._stringArray.should.be.a('array');
		});
		it('Should throw TyperError when arg is not a string', function () {
			const badFn = function () {
				new StringBuilder.StringBuilder([1, 2, 3]);
			};
			badFn.should.throw(TypeError);
		});
	});
	describe('Append tests', function () {
		it('Should append string to arr when empty', function () {
			sb.append('test');
			sb.toString().should.equal('test');
		});
		it('Should append string to end of arr when full', function () {
			sb.append('sth');
			sb.append('test');
			sb.toString().should.equal('sthtest');
		});
		it('Should throw TyperError when arg is not a string', function () {
			const badFn = function () {
				sb.append([1, 2, 3]);
			};
			badFn.should.throw(TypeError);
		});
	});
	describe('Prepend tests', function () {
		it('Should append string to arr', function () {
			sb.prepend('test');
			sb.toString().should.equal('test');
		});
		it('Should append string to start of arr', function () {
			sb.prepend('test');
			sb.prepend('asd');
			sb.toString().should.equal('asdtest');
		});
		it('Should throw TyperError when arg is not a string', function () {
			const badFn = function () {
				sb.append([1, 2, 3]);
			};
			badFn.should.throw(TypeError);
		});
	});
	describe('insertAt tests', function () {
		it('Should insert string to arr when empty', function () {
			sb.insertAt('test', 0);
			sb.toString().should.equal('test');
		});
		it('Should insert string to index of arr', function () {
			sb.insertAt('test', 0);
			sb.insertAt('asd', 1);
			sb.toString().should.equal('tasdest');
		});
		it('Should throw TyperError when arg is not a string', function () {
			const badFn = function () {
				sb.prepend([1, 2, 3]);
			};
			badFn.should.throw(TypeError);
		});
	});
	describe('Remove tests', function () {
		it('Should remove nothing when length 0 string', function () {
			sb.insertAt('test', 0);
			sb.remove(0, 0);
			sb.toString().should.equal('test');
		});
		it('Should remove string when length is > 0', function () {
			sb.insertAt('test', 0);
			sb.remove(0, 2);
			sb.toString().should.equal('st');
		});
		it('Should throw TyperError when arg is not a string', function () {
			const badFn = function () {
				sb.prepend([1, 2, 3]);
			};
			badFn.should.throw(TypeError);
		});
	});
	describe('toString tests', function () {
		it('Should join arr correctly', function () {
			sb.insertAt('test', 0);
			sb.toString().should.be.a('string');
			sb.toString().should.equal('test');
		});
	});
});
