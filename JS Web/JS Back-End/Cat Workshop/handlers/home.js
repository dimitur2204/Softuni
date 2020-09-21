const fs = require('fs');
const path = require('path');
const { encode } = require('punycode');
const { stringify } = require('querystring');

module.exports = (req, res) => {
	const filePath = path.resolve('./views/home/index.html');
	fs.readFile(filePath, { encoding: 'utf-8' }, (err, data) => {
		if (err) {
			res.writeHead(404, {
				'Content-Type': 'text-plain',
			});
			res.end('An error occured');
			return;
		}
		res.writeHead(200, {
			'Content-Type': 'text-html',
		});
		const cats = require('../data/cats.json');
		const modifiedCats = cats.map(
			(cat) =>
				`<li>
			<img src="${path.join('./content/images/' + cat.image)}" alt="A Cat">
			<h3>${cat.name}</h3>
			<p><span>Breed: </span>${cat.breed}</p>
			<p><span>Description: </span>${cat.description}</p>
			<ul class="buttons">
				<li class="btn edit"><a href="/cats/editCat/${cat.id}">Change Info</a></li>
				<li class="btn delete"><a href="/cats/catShelter/${cat.id}">New Home</a></li>
			</ul>
		</li>`
		);
		const modifiedData = data.toString().replace('{{cats}}', modifiedCats);
		res.end(modifiedData);
	});
};
