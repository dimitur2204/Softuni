const urls = {
	catches: `https://fisher-game.firebaseio.com/catches.json`,
	id(id) {
		return `https://fisher-game.firebaseio.com/catches/${id}.json`;
	},
};
export async function getCatches() {
	return await fetch(urls.catches).then((res) => res.json());
}
export function createCatch(data) {
	fetch(urls.catches, {
		method: "POST",
		body: JSON.stringify(data),
	});
}
export function updateCatch(id, data) {
	fetch(urls.id(id), {
		method: "PUT",
		body: JSON.stringify(data),
	});
}
export function deleteCatch(id) {
	fetch(urls.id(id), {
		method: "DELETE",
	});
}
