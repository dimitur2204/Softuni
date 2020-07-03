class Company{
    constructor(){
        this.departments = {};
    }
    doesKeyExist(department){
        for (const key in this.departments) {
            if (key == department) {
                return true;
            }
        }
        return false;
    };
    addEmployee(username,salary,position,department){
        if (username == '' || position == '' || department == '') {
            throw new Error('Invalid input!');
        }
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
        if(!this.doesKeyExist(department)){
            this.departments[department] = [];
        }
       const employee = {
        username:username,
        salary:salary,
        position:position,
 };
       this.departments[department].push(employee);
    return `New employee is hired. Name: ${employee.username}. Position: ${employee.position}`;
    }
    getAverageSalary(department){
        let sumOfSalaries = 0;
        for (const employee of department) {
            sumOfSalaries+= employee.salary;
        }
        return sumOfSalaries/department.length;
    }
    bestDepartment(){
        let bestSalary = Number.MIN_SAFE_INTEGER;
        let bestDepartment;
        for (const department of Object.keys(this.departments)) {
            const currentSalary = this.getAverageSalary(this.departments[department]);
            if (currentSalary > bestSalary) {
                bestDepartment = department;
                bestSalary = currentSalary;
            }
        }
        let result = '';
        result += `Best Department is: ${bestDepartment}\n`;
        result += 'Average salary: ' + this.getAverageSalary(this.departments[bestDepartment]).toFixed(2) + '\n';
        for (const employee of this.departments[bestDepartment].sort((a,b) =>{
            return b.salary - a.salary || a.username.localeCompare(b.username);
        })) {
            result += employee.username + ' ' + employee.salary + ' ' + employee.position + '\n';
        }
        return result.trim();
    }
}
let c = new Company(); 

c.addEmployee("Stanimir", 2000, "engineer", "Construction"); 

c.addEmployee("Pesho", 1500, "electrical engineer", "Construction"); 

c.addEmployee("Slavi", 500, "dyer", "Construction"); 

c.addEmployee("Stan", 2000, "architect", "Construction"); 

c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing"); 

c.addEmployee("Pesho", 1000, "graphical designer", "Marketing"); 

c.addEmployee("Gosho", 1350, "HR", "Human resources"); 
c.addEmployee("Plamen" , 3000, "HR", "Human resources");

console.log(c.bestDepartment()); 