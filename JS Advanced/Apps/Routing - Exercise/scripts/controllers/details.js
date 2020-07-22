import { getTeam, getUsers } from '../data.js';
export default async function details() {
	if (!this.app.userData.loggedIn) {
		alert('Login first');
		return;
	}
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		team: await this.load('./templates/catalog/team.hbs'),
		teamMember: await this.load('./templates/catalog/teamMember.hbs'),
		teamControls: await this.load('./templates/catalog/teamControls.hbs'),
	};
	const id = this.params.id;
	const team = await getTeam(id);
	const users = await getUsers();
	const members = users.reduce((acc, curr) => {
		if (curr.teamId === id) {
			acc.push(curr);
		}
		return acc;
	}, []);
	if (this.app.userData.userId === team.ownerId) {
		this.app.userData.isAuthor = true;
	}
	team.members = members;
	const data = Object.assign(this.app.userData, team);
	this.partial('./templates/catalog/details.hbs', data);
}
