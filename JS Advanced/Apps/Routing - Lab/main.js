(async function () {
	const BASE_URL =
		"https://api.backendless.com/FDBF10C1-75D2-BE41-FF57-5ED27AC6E500/4902CC97-6754-42CF-9639-C8FCF5C4ED1B/data/furniture";
	const homeEl = document.querySelector("#home");
	const createEl = document.querySelector("#create");
	await (async function registerPartials() {
		const furnitureTemplateString = await fetch(
			"./templates/partials/furniture-partial.hbs"
		).then((res) => res.text());
		const myFurnitureTemplateString = await fetch(
			"./templates/partials/my-furniture-partial.hbs"
		).then((res) => res.text());
		Handlebars.registerPartial("furniture", furnitureTemplateString);
	})();
	const app = Sammy("#container", function () {
		this.get("/#/home", async () => {
			const furnitureData = await fetch(BASE_URL).then((res) => res.json());
			const furnitureTemplateString = await fetch(
				"./templates/all-furniture.hbs"
			).then((res) => res.text());
			const furnitureTemplate = Handlebars.compile(furnitureTemplateString);
			const furnitureHTML = furnitureTemplate(furnitureData);
			this.swap(furnitureHTML);
		});
	});
	app.run();
})();
