const describe = require('mocha').describe;
const should = require('chai').should();
const lib = require('./../warehouse');
describe('Warehouse tests', function () {
	describe('Constructor tests', function () {
		it('Should throw error when capcity is negative or 0', function () {
			const negativeCap = () => {
				new lib.Warehouse(0);
			};
			negativeCap.should.throw('Invalid given warehouse space');
		});
		it('Should init warehouse properly', function () {
			const warehouse = new lib.Warehouse(10);
			warehouse.capacity.should.equal(10);
		});
	});
});
