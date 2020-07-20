export default async function catalog() {
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		team: await this.load('./templates/catalog/team.hbs'),
	};
	const data = Object.assign({}, this.app.userData);
	data.teams = [
		{
			teamId: '123',
			name: 'Marek',
			comment: 'A nice team',
			members: [{ username: 'peter' }, { username: 'mari' }],
		},
	];
	this.partial('./templates/catalog/teamCatalog.hbs', data);
}
