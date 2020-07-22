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
export const register = (username, password) => {
	return fetch(host(endpoints.REGISTER), {
		method: 'POST',
		body: JSON.stringify({
			username,
			password,
		}),
	}).then((res) => res.json());
};
export const login = (username, password) => {
	return fetch(host(endpoints.LOGIN), {
		method: 'POST',
		body: JSON.stringify({
			login: username,
			password,
		}),
	}).then((res) => res.json());
};
export const logout = (token) => {
	return fetch(host(endpoints.LOGOUT), {
		method: 'GET',
		headers: {
			'user-token': token,
		},
	});
};
export const getMovies = (token) => {
	return fetch(host(endpoints.MOVIES), {
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
};
export const getMovieById = (id, token) => {
	return fetch(host(endpoints.MOVIE_BY_ID + id), {
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
};
export const getMoviesByUserId = (userId, token) => {
	return fetch(
		host(endpoints.MOVIES + '?where=' + escape(`ownerId='${userId}'`)),
		{
			method: 'GET',
			body: JSON.stringify(updatedData),
			headers: {
				'user-token': token,
			},
		}
	).then((res) => res.json());
};
export const createMovie = (token, movie) => {
	return fetch(host(endpoints.MOVIES), {
		method: 'POST',
		body: JSON.stringify(movie),
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
};
export const updateMovie = (id, token, updatedData) => {
	return fetch(host(endpoints.MOVIE_BY_ID + id), {
		method: 'PUT',
		body: JSON.stringify(updatedData),
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
};
export const deleteMovie = (id, token) => {
	return fetch(host(endpoints.MOVIE_BY_ID + id), {
		method: 'DELETE',
		headers: {
			'user-token': token,
		},
	}).then((res) => res.json());
};
