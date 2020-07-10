const locationEl = document.querySelector('#location');
const submitBtn = document.querySelector('#submit');
const forecastEl = document.querySelector('#forecast');
const currentEl = document.querySelector('#current');
const upcomingEl = document.querySelector('#upcoming');
const symbols = {
	Sunny: '&#x2600;',
	'Partly sunny': '&#x26C5;',
	Overcast: '&#x26C5;',
	Rain: '&#x2614;',
	Degress: '&#176;',
};
const getLocationCode = async (location) => {
	const url = `https://judgetests.firebaseio.com/locations.json`;
	const data = await fetch(url).then((_data) => _data.json());
	return data.find((x) => x.name === location).code;
};
const getCurrentForecast = async (code) => {
	const url = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;
	const data = await fetch(url).then((_data) => _data.json());
	return data;
};
const getUpcomingForecasts = async (code) => {
	const url = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
	const data = await fetch(url).then((_data) => _data.json());
	return data;
};
const createCurrentDiv = (location, forecast) => {
	const div = document.createElement('div');
	div.classList.add('forecasts');

	const symbolSpan = document.createElement('span');
	symbolSpan.classList.add('conditions');
	symbolSpan.classList.add('symbol');
	symbolSpan.innerHTML = symbols[forecast.condition];

	const conditionSpan = document.createElement('span');
	conditionSpan.classList.add('condition');

	const locSpan = document.createElement('span');
	locSpan.classList.add('forecast-data');
	locSpan.innerHTML = location;

	const degreesSpan = locSpan.cloneNode(true);
	degreesSpan.innerHTML = `${forecast.high}${symbols.Degress}/${forecast.low}${symbols.Degress}`;
	degreesSpan.classList.add('forecast-data');

	const weatherSpan = locSpan.cloneNode(true);
	weatherSpan.innerHTML = forecast.condition;
	weatherSpan.classList.add('forecast-data');

	conditionSpan.appendChild(locSpan);
	conditionSpan.appendChild(degreesSpan);
	conditionSpan.appendChild(weatherSpan);

	div.appendChild(symbolSpan);
	div.appendChild(conditionSpan);

	return div;
};
const createUpcomingDiv = (forecasts) => {
	const div = document.createElement('div');
	div.classList.add('forecast-info');
	const createUpcomingSpan = (forecast) => {
		const mainSpan = document.createElement('span');
		mainSpan.classList.add('upcoming');

		const symbolSpan = document.createElement('span');
		symbolSpan.classList.add('symbol');
		symbolSpan.innerHTML = symbols[forecast.condition];

		const locSpan = document.createElement('span');
		locSpan.classList.add('forecast-data');

		const degreesSpan = locSpan.cloneNode(true);
		degreesSpan.innerHTML = `${forecast.high}${symbols.Degress}/${forecast.low}${symbols.Degress}`;
		degreesSpan.classList.add('forecast-data');

		const conditionSpan = document.createElement('span');
		conditionSpan.innerHTML = forecast.condition;
		conditionSpan.classList.add('forecast-data');

		mainSpan.appendChild(symbolSpan);
		mainSpan.appendChild(degreesSpan);
		mainSpan.appendChild(conditionSpan);

		return mainSpan;
	};
	console.log(forecasts);
	forecasts.forEach((forecast) => {
		div.appendChild(createUpcomingSpan(forecast));
	});
	return div;
};
const renderForecast = async () => {
	const location = locationEl.value;
	const code = await getLocationCode(location);
	const currentForecast = await getCurrentForecast(code);
	const upcomingForecasts = await getUpcomingForecasts(code);
	const currentDiv = createCurrentDiv(
		currentForecast.name,
		currentForecast.forecast
	);
	const upcomingDiv = createUpcomingDiv(upcomingForecasts.forecast);
	currentEl.appendChild(currentDiv);
	upcomingEl.appendChild(upcomingDiv);
	forecastEl.style.display = '';
};
function attachEvents() {
	submitBtn.addEventListener('click', renderForecast);
}

attachEvents();
