const stopIdEl = document.querySelector('#stopId');
const submitBtn = document.querySelector('#submit');
const stopNameEl = document.querySelector('#stopName');
const busesEl = document.querySelector('#buses');
function getInfo() {
	const url = `http://localhost:8000/businfo/${stopIdEl.value}`;
	busesEl.textContent = '';
	fetch(url)
		.then((res) => res.json())
		.then((stop) => {
			stopNameEl.textContent = stop.name;
			for (const busId in stop.buses) {
				const li = document.createElement('li');
				const result = `Bus ${busId} arrives in ${stop.buses[busId]}`;
				li.textContent = result;
				busesEl.appendChild(li);
			}
		})
		.catch((er) => {
			stopNameEl.textContent = 'Error';
		});
}
