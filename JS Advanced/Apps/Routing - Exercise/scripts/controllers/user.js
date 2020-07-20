import { registerUser, loginUser } from '../data.js';
export async function register() {
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		registerForm: await this.load('./templates/register/registerForm.hbs'),
	};
	this.partial('./templates/register/registerPage.hbs', this.app.userData);
}
export async function login() {
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		loginForm: await this.load('./templates/login/loginForm.hbs'),
	};
	this.partial('./templates/login/loginPage.hbs', this.app.userData);
}
export async function registerPost() {
	const userData = this.params;
	registerUser(userData.username, userData.password);
	this.redirect('#/login');
}
export async function loginPost() {
	const userData = this.params;
	const userSession = await loginUser(userData.username, userData.password);
	this.app.userData.username = userSession.username;
	this.app.userData.loggedIn = true;
	this.app.userData.userId = userSession.objectId;
	localStorage.setItem('user-token', userSession['user-token']);
	this.redirect('#/home');
}
