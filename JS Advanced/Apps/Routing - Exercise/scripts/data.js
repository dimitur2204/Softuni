const host = (endpoint) => {
	return `https://api.backendless.com/92E24531-D488-E645-FF24-C7E20B55E800/F3A0A6BA-37FC-4F69-AC46-5CBD268D7CCA/${endpoint}`;
};
const endpoints = {
	REGISTER: 'users/register',
	LOGIN: 'users/login',
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
