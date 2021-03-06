import { showInfo, showError } from '../notification.js';
import {
	register as registerUser,
	login as loginUser,
	logout as logoutUser,
} from '../data.js';
export async function login() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
	};
	this.partial('../../templates/user/login.hbs', this.app.userData);
}
const validateInfo = (info) => {
	if (info.username.length < 3) {
		showError('Username should be atleast 3 symbols');
		return false;
	}
	if (info.password.length < 6) {
		showError('Password should be atleast 6 symbols');
		return false;
	}
	if (info.repeatPassword && info.password !== info.repeatPassword) {
		showError('Passwords do not match');
		return false;
	}
	return true;
};
export async function loginPost() {
	const info = this.params;
	if (!validateInfo(info)) {
		return;
	}
	const result = await loginUser(info.username, info.password);
	this.app.userData = {
		username: localStorage.getItem('username'),
		userId: localStorage.getItem('userId'),
	};
	if (result) {
		this.redirect('#/home');
	}
}
export async function register() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
	};
	this.partial('../../templates/user/register.hbs', this.app.userData);
}
export async function registerPost() {
	const info = this.params;
	if (!validateInfo(info)) {
		return;
	}
	const result = await registerUser(info.username, info.password);
	if (result) {
		this.redirect('#/login');
	}
}
export async function logout() {
	logoutUser();
	this.app.userData = {
		username: '',
		userId: '',
	};
	this.redirect('#/home');
}
