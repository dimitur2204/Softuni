export default async function details() {
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		team: await this.load('./templates/catalog/team.hbs'),
		teamMember: await this.load('./templates/catalog/teamMember.hbs'),
		teamControls: await this.load('./templates/catalog/teamControls.hbs'),
	};
	const team = {
		teamId: '123',
		name: 'Marek',
		comment: 'A nice team',
		members: [{ username: 'peter' }, { username: 'mari' }],
	};
	this.partial('./templates/catalog/details.hbs', team);
}
