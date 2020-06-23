function module() {
	class Employee {
		constructor(name, age) {
			if (new.target == Employee) {
				throw new Error('Cannot instantiate abstract class');
			}
			this.name = name;
			this.age = age;
			this.tasks = [];
			this.salary = 0;
			this._counter = 0;
		}
		work() {
			if (this._counter == this.tasks.length) {
				this._counter = 0;
			}
			console.log(this.tasks[this._counter]);
			this._counter++;
		}
		collectSalary() {
			console.log(`${this.name} received ${this.salary} this month.`);
		}
	}
	class Junior extends Employee {
		constructor(name, age) {
			super(name, age);
			this.tasks = [`${this.name} is working on a simple task.`];
		}
	}
	class Senior extends Employee {
		constructor(name, age) {
			super(name, age);
			this.tasks = [
				`${this.name} is working on a complicated task.`,
				`${this.name} is taking time off work.`,
				`${this.name} is supervising junior workers.`,
			];
		}
	}
	class Manager extends Employee {
		constructor(name, age) {
			super(name, age);
			this.dividend = 0;
			this.tasks = [
				`${this.name} scheduled a meeting.`,
				`${this.name} is preparing a quarterly report.`,
			];
		}
		collectSalary() {
			console.log(
				`${this.name} received ${this.salary + this.dividend} this month.`
			);
		}
	}
	return {
		Employee,
		Junior,
		Senior,
		Manager,
	};
}
let result = module();
let guy1 = new result.Manager('Peter', 27, 250);
guy1.salary = 1200;
guy1.work();
guy1.work();
guy1.work();
guy1.work();
guy1.work();
