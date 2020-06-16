function solution(arr, criteria) {
	if (criteria == 'asc') {
		arr.sort((a, b) => {
			return a - b;
		});
	} else if (criteria == 'desc') {
		arr.sort((a, b) => {
			return b - a;
		});
	}
	return arr;
}
solution([14, 7, 17, 6, 8], 'asc');
