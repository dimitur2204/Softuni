export async function create() {
	this.partials = {
		header: await this.load('./templates/common/header.hbs'),
		footer: await this.load('./templates/common/footer.hbs'),
		createForm: await this.load('./templates/create/createForm.hbs'),
	};
	this.partial('./templates/create/createPage.hbs', this.app.userData);
}
export function createPost() {
	const team = this.params;
	this.redirect('#/home');
}
