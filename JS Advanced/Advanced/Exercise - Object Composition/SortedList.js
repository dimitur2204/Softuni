function createSortedList() {
	let list = [];
	function add(element) {
		list.push(element);
		list.sort((a, b) => {
			return a - b;
		});
	}
	function remove(index) {
		if (index >= 0 && index < list.length) {
			list.splice(index, 1);
			list.sort((a, b) => {
				return a - b;
			});
		}
	}
	function get(index) {
		if (index >= 0 && index < list.length) {
			return list[index];
		}
	}
	return {
		add,
		remove,
		get,
		get size() {
			return list.length;
		},
	};
}
const sortedList = createSortedList();
