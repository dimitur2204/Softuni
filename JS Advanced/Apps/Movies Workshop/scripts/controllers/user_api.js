import {
	showLoading,
	closeLoading,
	showError,
	showInfo,
} from '../notification.js';
class User {
	constructor(appKey, apiKey) {
		this.apiKey = apiKey;
		this.appKey = appKey;
		this.endpoints = {
			REGISTER: 'users/register',
			LOGIN: 'users/login',
			LOGOUT: 'users/logout',
		};
	}
	url = `${(this.apiKey, this.appKey)}`;
	host(endpoint) {}
	get = async (endpoint) => {
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
	post = async (endpoint, body) => {
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
	put = async (endpoint, body) => {
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
	register = async (username, password) => {
		const result = await post(endpoints.REGISTER, { username, password });
		if (result) {
			showInfo(`Successfully registered`);
		}
		return result;
	};
	login = async (username, password) => {
		const result = await post(endpoints.LOGIN, { login: username, password });
		if (result) {
			localStorage.setItem('userToken', result['user-token']);
			localStorage.setItem('username', result.username);
			localStorage.setItem('userId', result.objectId);
			showInfo(`Successfully logged in!`);
		}
		return result;
	};
	logout = async () => {
		localStorage.removeItem('userToken');
		localStorage.removeItem('username');
		localStorage.removeItem('userId');
		const result = get(endpoints.LOGOUT);
		if (result) {
			showInfo(`Successfully logged out!`);
		}
	};
}
