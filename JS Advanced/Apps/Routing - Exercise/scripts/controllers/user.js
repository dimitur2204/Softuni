import { registerUser, loginUser, logoutUser } from '../data.js';
export async function register() {
	if (this.app.userData.loggedIn) {
		alert('Logout first!');
		return;
	}
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		registerForm: await this.load('./templates/register/registerForm.hbs'),
	};
	this.partial('./templates/register/registerPage.hbs', this.app.userData);
}
export async function login() {
	if (this.app.userData.loggedIn) {
		alert('Logout first!');
		return;
	}
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		loginForm: await this.load('./templates/login/loginForm.hbs'),
	};
	this.partial('./templates/login/loginPage.hbs', this.app.userData);
}
export async function registerPost() {
	const userData = this.params;
	if (Object.values(userData).some((x) => !x)) {
		alert('Cannot have empty fields');
		return;
	}
	if (userData.password !== userData.repeatPassword) {
		alert("Passwords don't match");
		return;
	}
	registerUser(userData.username, userData.password);
	this.redirect('#/login');
}
export async function loginPost() {
	if (this.app.userData.loggedIn) {
		alert('Already logged in');
		return;
	}
	try {
		const userCreds = this.params;
		if (Object.values(userCreds).some((x) => !x)) {
			alert('Cannot have empty fields');
			return;
		}
		const userSession = await loginUser(userCreds.username, userCreds.password);
		this.app.userData.hasTeam = userSession.teamId ? true : false;
		this.app.userData.isOnTeam = userSession.teamId ? true : false;
		this.app.userData.teamId = userSession.teamId;
		this.app.userData.username = userSession.username;
		this.app.userData.loggedIn = true;
		this.app.userData.userId = userSession.objectId;
		localStorage.setItem('user-token', userSession['user-token']);
		this.redirect('#/home');
	} catch (err) {
		alert(err.message);
		console.error(err);
	}
}
export async function logout() {
	const userData = this.app.userData;
	if (!userData.loggedIn) {
		alert('Not logged in');
		return;
	}
	try {
		const userSession = logoutUser(localStorage.getItem('user-token'));
		userData.username = undefined;
		userData.loggedIn = false;
		userData.userId = undefined;
		localStorage.removeItem('user-token');
		this.redirect('#/home');
	} catch (err) {
		alert(err.message);
		console.error(err);
	}
}
