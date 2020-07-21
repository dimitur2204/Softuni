import { createTeam, setUserTeam } from '../data.js';
export async function create() {
	if (!this.app.userData.loggedIn) {
		alert('Login first');
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
