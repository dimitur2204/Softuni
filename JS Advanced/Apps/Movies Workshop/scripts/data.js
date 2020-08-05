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
const get = async (endpoint) => {
	showLoading();
	const token = localStorage.getItem('userToken');
	let result;
	try {
		result = await fetch(host(endpoint), {
			method: 'GET',
			headers: {
				'user-token': token,
			},
		}).then((res) => res.json());
	} catch (error) {
		closeLoading();
		return result;
	}
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
	} catch (err) {
		console.error(err.message);
		showError(err.message);
		return false;
	} finally {
		closeLoading();
	}
	return result;
};
const post = async (endpoint, body) => {
	showLoading();
	const token = localStorage.getItem('userToken');
	const result = await fetch(host(endpoint), {
		method: 'POST',
		headers: {
			'user-token': token,
		},
		body: JSON.stringify(body),
	}).then((res) => res.json());
	try {
		if (result.hasOwnProperty('errorData')) {
			throw new Error(result.message);
		}
	} catch (err) {
		console.error(err.message);
		showError(err.message);
		return false;
	} finally {
		closeLoading();
	}
	return result;
};
const put = async (endpoint, body) => {
	showLoading();
	const token = localStorage.getItem('userToken');
	const result = await fetch(host(endpoint), {
		method: 'PUT',
		body: JSON.stringify(body),
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
		return false;
	} finally {
		closeLoading();
	}

	return result;
};
export const register = async (username, password) => {
	const result = await post(endpoints.REGISTER, { username, password });
	if (result) {
		showInfo(`Successfully registered`);
	}
	return result;
};
export const login = async (username, password) => {
	const result = await post(endpoints.LOGIN, { login: username, password });
	if (result) {
		localStorage.setItem('userToken', result['user-token']);
		localStorage.setItem('username', result.username);
		localStorage.setItem('userId', result.objectId);
		showInfo(`Successfully logged in!`);
	}
	return result;
};
export const logout = async () => {
	localStorage.removeItem('userToken');
	localStorage.removeItem('username');
	localStorage.removeItem('userId');
	const result = get(endpoints.LOGOUT);
	if (result) {
		showInfo(`Successfully logged out!`);
	}
};
export const getMovies = async () => {
	return get(endpoints.MOVIES);
};
export const getMovieById = async (id) => {
	return get(endpoints.MOVIE_BY_ID + id);
};
export const getMoviesByUserId = async (userId) => {
	return get(endpoints.MOVIES + '?where=' + escape(`ownerId='${userId}'`));
};
export const createMovie = async (movie) => {
	const result = await post(endpoints.MOVIES, movie);
	if (result) {
		showInfo(`Successfully created movie!`);
	}
	return result;
};
export const updateMovie = async (id, updatedData) => {
	const result = await put(endpoints.MOVIE_BY_ID + id, updatedData);
	if (result) {
		showInfo('Successfully updated movie');
	}
};
export const buyTicket = async (id) => {
	const movie = await getMovieById(id);
	movie.tickets--;
	const result = await put(endpoints.MOVIE_BY_ID + id, movie);
	if (result) {
		showInfo('Successfully bought ticket');
	}
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
