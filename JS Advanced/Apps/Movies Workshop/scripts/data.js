import {
	showInfo,
	showLoading,
	closeLoading,
	showError,
} from './notification.js';
const host = (endpoint) => {
	return `https://api.backendless.com/97DEBBCC-38B7-A381-FF92-9F81213A0800/A306B679-AA12-4162-88CB-73E666897749/${endpoint}`;
};
const endpoints = {
	REGISTER: 'users/register',
	LOGIN: 'users/login',
	LOGOUT: 'users/logout',
	MOVIES: 'data/movies',
	MOVIE_BY_ID: 'data/movies/',
};
export const register = async (username, password) => {
	showLoading();
	const result = await fetch(host(endpoints.REGISTER), {
		method: 'POST',
		body: JSON.stringify({
			username,
			password,
		}),
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
		showInfo(`Successfully registered!`);
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();
	return result;
};
export const login = async (username, password) => {
	showLoading();
	const result = await fetch(host(endpoints.LOGIN), {
		method: 'POST',
		body: JSON.stringify({
			login: username,
			password,
		}),
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
		showInfo(`Successfully logged in as ${result.username}!`);
		localStorage.setItem('userToken', result['user-token']);
		localStorage.setItem('username', result.username);
		localStorage.setItem('userId', result.objectId);
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();
	return result;
};
export const logout = async () => {
	showLoading();
	const token = localStorage.getItem('userToken');
	const result = await fetch(host(endpoints.LOGOUT), {
		method: 'GET',
		headers: {
			'user-token': token,
		},
	});
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
		showInfo(`Successfully logged out!`);
		localStorage.removeItem('userToken');
		localStorage.removeItem('username');
		localStorage.removeItem('userId');
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();
};
export const getMovies = async () => {
	showLoading();
	const token = localStorage.getItem('userToken');
	const result = await fetch(host(endpoints.MOVIES), {
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();
	return result;
};
export const getMovieById = async (id) => {
	showLoading();

	const token = localStorage.getItem('userToken');
	const result = fetch(host(endpoints.MOVIE_BY_ID + id), {
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();

	return result;
};
export const getMoviesByUserId = async (userId) => {
	showLoading();

	const token = localStorage.getItem('userToken');
	const result = fetch(
		host(endpoints.MOVIES + '?where=' + escape(`ownerId='${userId}'`)),
		{
			method: 'GET',
			headers: {
				'user-token': token,
			},
		}
	).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();

	return result;
};
export const createMovie = async (movie) => {
	showLoading();

	const token = localStorage.getItem('userToken');
	const result = fetch(host(endpoints.MOVIES), {
		method: 'POST',
		body: JSON.stringify(movie),
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
		showInfo('Movie created successfully!');
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();

	return result;
};
export const updateMovie = async (id, updatedData) => {
	showLoading();

	const token = localStorage.getItem('userToken');
	const result = fetch(host(endpoints.MOVIE_BY_ID + id), {
		method: 'PUT',
		body: JSON.stringify(updatedData),
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();

	return result;
};
export const buyTicket = async (id) => {
	showLoading();
	const movie = await getMovieById(id);
	movie.tickets--;
	const token = localStorage.getItem('userToken');
	const result = await fetch(host(endpoints.MOVIE_BY_ID + id), {
		method: 'PUT',
		body: JSON.stringify(movie),
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
		showInfo('Successfully bought ticket');
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();

	return result;
};
export const deleteMovie = async (id) => {
	showLoading();

	const token = localStorage.getItem('userToken');
	const result = fetch(host(endpoints.MOVIE_BY_ID + id), {
		method: 'DELETE',
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
		showInfo('Successfully deleted movie!');
	} catch (err) {
		console.error(err.message);
		showError(err.message);
	}
	closeLoading();

	return result;
};
