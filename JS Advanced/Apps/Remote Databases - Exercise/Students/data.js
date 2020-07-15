const BASE_URL = `'https://api.backendless.com/64D49FD7-3150-FCD4-FF27-7B76EF40E400/A2772637-7B80-47ED-B650-C17BE1C4B72B/data`;
function host(endpoint) {
	return BASE_URL + endpoint;
}
export async function createStudent(student) {
	return fetch(host('students'), {
		method: 'POST',
		body: JSON.stringify(student),
	});
}
export async function deleteStudent(objectId) {
	return fetch(host(`students/${objectId}`), {
		method: 'DELETE',
	});
}
export async function getStudents() {
	return await fetch(host(`students`)).then((res) => res.json());
}
