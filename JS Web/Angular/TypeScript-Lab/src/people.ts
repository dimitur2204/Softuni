abstract class Employee{

    work(){
        const currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(currentTask);
    }

    collectSalary(){
        console.log(`${this.name} received ${this.salary}`);
    }

    constructor(
        public name:string,
        public age:number,
        public salary:number = 0,
        public tasks:string[] = []) {
        
    }
}

class Junior extends Employee{

    constructor(public name:string,
        public age:number) {
        super(name,age);
        this.tasks = [`${this.name} is working on a simple task.`];
    }
}

class Senior extends Employee{

    constructor(public name:string,
        public age:number) {
        super(name,age);
        this.tasks = [
            `${this.name} is working on a complicated task.`,
            `${this.name} is taking time off work.`,
            `${this.name} is supervising junior workers.`
    ];
    }
}

class Manager extends Employee{

    constructor(public name:string,
        public age:number,
        public salary:number,
        public dividend:number = 0) {
        super(name,age,salary);
        this.tasks = [
            `${this.name} scheduled a meeting.`,
            `${this.name} is preparing a quarterly report.`
    ];
    }
}