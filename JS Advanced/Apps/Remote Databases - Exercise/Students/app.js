import * as api from './data';
async function loadStudents() {
	const tbody = document.querySelector('tbody');
	const students = await api.getStudents();
	console.log(students);
	students
		.sort((a, b) => {
			return a.ID - b.ID;
		})
		.forEach(async (s) => {
			const tr = document.createElement('tr');
			const idData = document.createElement('td');
			idData.textContent = s.ID;
			const firstNameData = document.createElement('td');
			firstNameData.textContent = s.firstName;
			const lastNameData = document.createElement('td');
			lastNameData.textContent = s.lastName;
			const facNumData = document.createElement('td');
			facNumData.textContent = s.facultyNumber;
			const gradeData = document.createElement('td');
			gradeData.textContent = s.grade;
			tr.appendChild(idData);
			tr.appendChild(firstNameData);
			tr.appendChild(lastNameData);
			tr.appendChild(facNumData);
			tr.appendChild(gradeData);
			tbody.appendChild(tr);
		});
}
