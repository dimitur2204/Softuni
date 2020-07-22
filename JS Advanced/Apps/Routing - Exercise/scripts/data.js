const host = (endpoint) => {
	return `https://api.backendless.com/92E24531-D488-E645-FF24-C7E20B55E800/F3A0A6BA-37FC-4F69-AC46-5CBD268D7CCA/${endpoint}`;
};
const endpoints = {
	REGISTER: 'users/register',
	LOGIN: 'users/login',
	LOGOUT: 'users/logout',
	TEAMS: 'data/teams',
	USERS: 'users',
	USERS_DATA: 'data/users',
};
export const registerUser = async (username, password) => {
	return fetch(host(endpoints.REGISTER), {
		method: 'POST',
		body: JSON.stringify({
			username,
			password,
		}),
		'Content-Type': 'application/json',
	}).then((res) => res.json());
};
export const loginUser = async (username, password) => {
	return fetch(host(endpoints.LOGIN), {
		method: 'POST',
		body: JSON.stringify({
			login: username,
			password,
		}),
		'Content-type': 'application/json',
	}).then((res) => res.json());
};
export const logoutUser = async (token) => {
	return fetch(host(endpoints.LOGOUT), {
		method: 'GET',
		headers: {
			'user-token': token,
			'Content-type': 'application/json',
		},
	});
};
export const createTeam = async (team, token) => {
	return fetch(host(endpoints.TEAMS), {
		method: 'POST',
		headers: {
			'user-token': token,
			'Content-type': 'application/json',
		},
		body: JSON.stringify(team),
	}).then((res) => res.json());
};
export const setUserTeam = async (userId, teamId) => {
	return fetch(host(endpoints.USERS + `/${userId}`), {
		method: 'PUT',
		headers: {
			'Content-type': 'application/json',
		},
		body: JSON.stringify({
			teamId,
		}),
	});
};
export const getTeams = async () => {
	return fetch(host(endpoints.TEAMS), {
		headers: {
			'Content-type': 'application/json',
		},
	}).then((res) => res.json());
};
export const getTeam = async (id) => {
	return fetch(
		host(endpoints.TEAMS + `/${id}`, {
			headers: {
				'Content-type': 'application/json',
			},
		})
	).then((res) => res.json());
};
export const getUsers = async () => {
	return fetch(host(endpoints.USERS_DATA)).then((res) => res.json());
};
export const updateTeam = async (id, team) => {
	return fetch(host(endpoints.TEAMS + '/' + id), {
		method: 'PUT',
		body: JSON.stringify(team),
	}).then((res) => res.json());
};
