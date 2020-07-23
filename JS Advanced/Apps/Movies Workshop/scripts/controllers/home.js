export async function home() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
	};
	this.partial('../../templates/common/home.hbs', this.app.userData);
}
