import { setUserTeam, getTeam, createTeam } from '../data.js';
export async function create() {
	if (!this.app.userData.loggedIn) {
		alert('Login first');
		this.redirect('/');
		return;
	}
	if (this.app.userData.hasTeam) {
		alert('You already have a team');
		this.redirect('/');
		return;
	}
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		createForm: await this.load('./templates/create/createForm.hbs'),
	};
	this.partial('./templates/create/createPage.hbs', this.app.userData);
}
export async function createPost() {
	if (!this.app.userData.loggedIn) {
		alert('Login first');
		return;
	}
	if (this.app.userData.hasTeam) {
		alert('You already have a team');
		return;
	}
	const team = this.params;
	const createdTeam = await createTeam(
		team,
		localStorage.getItem('user-token')
	);
	setUserTeam(this.app.userData.userId, createdTeam.objectId);
	this.app.userData.hasTeam = true;
	this.app.userData.isOnTeam = true;
	this.redirect('#/home');
}
export async function join() {
	const userData = this.app.userData;
	if (!userData.loggedIn) {
		alert('Login first');
		return;
	}
	if (userData.hasTeam) {
		alert('You already have a team');
		return;
	}
	const teamId = this.params.id;
	const team = await getTeam(teamId);
	setUserTeam(userData.userId, team.objectId);
	userData.hasTeam = true;
	userData.isOnTeam = true;
	userData.teamId = teamId;
	this.redirect('#/home');
}
export async function leave() {
	const userData = this.app.userData;
	if (!userData.loggedIn) {
		alert('Login first');
		return;
	}
	if (!userData.hasTeam) {
		alert('You are not in a team');
		return;
	}
	setUserTeam(userData.userId, null);
	userData.hasTeam = false;
	userData.isOnTeam = false;
	userData.teamId = null;
	this.redirect('#/home');
}
