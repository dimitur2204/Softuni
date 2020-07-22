import { updateTeam } from '../data.js';
export async function edit() {
	if (!this.app.userData.isAuthor) {
		alert('You are not the creator of the team');
		return;
	}
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		editForm: await this.load('./templates/edit/editForm.hbs'),
	};
	this.partial('./templates/edit/editPage.hbs', this.app.userData);
}
export async function editPost() {
	const newTeamInfo = this.params;
	const team = {
		name: newTeamInfo.name,
		comment: newTeamInfo.comment,
	};
	console.log(await updateTeam(newTeamInfo.id, team));
	this.redirect('/');
}
