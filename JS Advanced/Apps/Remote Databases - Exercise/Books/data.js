const BASE_URL = `https://api.backendless.com/64D49FD7-3150-FCD4-FF27-7B76EF40E400/A2772637-7B80-47ED-B650-C17BE1C4B72B/data/`;
function host(endpoint) {
	return BASE_URL + endpoint;
}
export async function getBooks() {
	const data = await fetch(host('books')).then((res) => res.json());
	return data;
}
export function createBook(book) {
	fetch(host('books'), {
		method: 'POST',
		body: JSON.stringify(book),
		headers: {
			'Content-Type': 'application/json',
		},
	});
}
export async function updateBook(id, book) {
	return fetch(host(`books/${id}`), {
		method: 'PUT',
		body: JSON.stringify(book),
		headers: {
			'Content-Type': 'application/json',
		},
	});
}
export function deleteBook(id) {
	fetch(host(`books/${id}`), {
		method: 'DELETE',
	});
}
