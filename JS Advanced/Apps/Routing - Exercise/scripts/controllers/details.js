import { getTeam } from '../data.js';
export default async function details() {
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		team: await this.load('./templates/catalog/team.hbs'),
		teamMember: await this.load('./templates/catalog/teamMember.hbs'),
		teamControls: await this.load('./templates/catalog/teamControls.hbs'),
	};
	const id = this.params.id;
	const team = await getTeam(id);
	const data = Object.assign(team, this.app.userData);
	this.partial('./templates/catalog/details.hbs', data);
}
