const describe = require('mocha').describe;
const should = require('chai').should();
const package = require('./../paymentPackage');
describe('Payment Package tests', function () {
	let pack;
	beforeEach(function () {
		pack = new package.PaymentPackage('John', 10);
	});
	describe('Constructor and setters test', function () {
		it('Should throw error when name is empty string', function () {
			const emptyName = function () {
				new package.PaymentPackage('', 5);
			};
			emptyName.should.throw(Error);
		});
		it('Should throw error when name is not a string', function () {
			const notAStringName = function () {
				new package.PaymentPackage([J, o, h, n], 5);
			};
			notAStringName.should.throw(Error);
		});
		it('Should throw error when value is not a number', function () {
			const stringValue = function () {
				new package.PaymentPackage('John', '5');
			};
			stringValue.should.throw(Error);
		});
		it('Should throw error when value is a negative number', function () {
			const negativeValue = function () {
				new package.PaymentPackage('John', -5);
			};
			negativeValue.should.throw(Error);
		});
		it('Should instantiate successfully when args are valid', function () {
			const test = new package.PaymentPackage('John', 5);
			test.name.should.equal('John');
			test.value.should.equal(5);
		});
		it('Should throw error when VAT is not a number', function () {
			const notANumberVat = function () {
				pack.VAT = -5;
			};
			notANumberVat.should.throw(Error);
		});
		it('Should throw error when VAT is negative number', function () {
			const negativeVat = function () {
				pack.VAT = -5;
			};
			negativeVat.should.throw(Error);
		});
		it('Should throw error when VAT is negative number', function () {
			const negativeVat = function () {
				pack.VAT = -5;
			};
			negativeVat.should.throw(Error);
		});
		it('Should set VAT correctly when VAT is valid', function () {
			pack.VAT = 10;
			pack.VAT.should.equal(10);
		});
		it('Should throw Error when active is not bool', function () {
			pack.active = true;
		});
		it('Should set active correctly when active is bool', function () {
			pack.VAT = 10;
			pack.VAT.should.equal(10);
		});
	});
});
