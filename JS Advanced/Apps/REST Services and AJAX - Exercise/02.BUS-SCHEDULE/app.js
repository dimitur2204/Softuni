function solve() {
	const infoSpan = document.querySelector('#info').querySelector('.info');
	const departBtn = document.querySelector('#depart');
	const arriveBtn = document.querySelector('#arrive');
	let stopId = 'depot';
	function depart() {
		const url = `http://localhost:8000/schedule/${stopId}`;
		departBtn.disabled = true;
		arriveBtn.disabled = false;
		fetch(url)
			.then((res) => res.json())
			.then((stop) => {
				const result = `Next stop ${stop.name}`;
				infoSpan.textContent = result;
			});
	}

	function arrive() {
		const url = `http://localhost:8000/schedule/${stopId}`;
		departBtn.disabled = false;
		arriveBtn.disabled = true;
		fetch(url)
			.then((res) => res.json())
			.then((stop) => {
				const result = `Arriving at ${stop.name}`;
				infoSpan.textContent = result;
				stopId = stop.next;
			});
	}

	return {
		depart,
		arrive,
	};
}

let result = solve();
