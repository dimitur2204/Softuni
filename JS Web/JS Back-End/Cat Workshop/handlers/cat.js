const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const formidable = require('formidable');
const breeds = require('../data/breeds');
const cats = require('../data/cats');

module.exports = (req, res) => {
	const pathname = url.parse(req.url).pathname;
	const getHandler = (err, data) => {
		if (err) {
			res.writeHead(404, {
				'Content-Type': 'text/plain',
			});
			res.end('An error occured');
			return;
		}
		res.writeHead(200, {
			'Content-Type': 'text/html',
		});
		res.end(data);
	};
	const addCatHandler = (err, data) => {
		if (err) {
			res.writeHead(404, {
				'Content-Type': 'text/plain',
			});
			res.end('An error occured');
			return;
		}
		let catBreedPlaceholder = breeds.map(
			(breed) => `<option value="${breed}">${breed}</option>`
		);
		let modifiedData = data
			.toString()
			.replace('{{catBreeds}}', catBreedPlaceholder);
		res.writeHead(200, {
			'Content-Type': 'text/html',
		});
		res.end(modifiedData);
	};
	const editCatHandler = (err, data) => {
		if (err) {
			res.writeHead(404, {
				'Content-Type': 'text/plain',
			});
			res.end('An error occured');
			return;
		}
		const id = Number(pathname.split('/').pop());
		const currentCat = cats[id - 1];
		let catBreedPlaceholder = breeds.map(
			(breed) => `<option value="${breed}">${breed}</option>`
		);
		let modifiedData = data.replace('{{catBreeds}}', catBreedPlaceholder);
		modifiedData = modifiedData.replace('{{id}}', currentCat.id);
		modifiedData = modifiedData.replace('{{name}}', currentCat.name);
		modifiedData = modifiedData.replace(
			'{{description}}',
			currentCat.description
		);
		modifiedData = modifiedData.replace('{{breed}}', currentCat.breed);
		res.writeHead(200, {
			'Content-Type': 'text/html',
		});
		res.end(modifiedData);
	};
	const catShelterHandler = (err, data) => {
		if (err) {
			res.writeHead(404, {
				'Content-Type': 'text/plain',
			});
			res.end('An error occured');
			return;
		}
		const id = Number(pathname.split('/').pop());
		const currentCat = cats[id - 1];
		let modifiedData = data.toString();
		modifiedData = modifiedData.replace('{{id}}', currentCat.id);
		modifiedData = modifiedData.replace('{{name}}', currentCat.name);
		modifiedData = modifiedData.replace(
			'{{description}}',
			currentCat.description
		);
		modifiedData = modifiedData.replace('{{breed}}', currentCat.breed);
		res.writeHead(200, {
			'Content-Type': 'text/html',
		});
		res.end(modifiedData);
	};
	if (pathname === '/cats/addBreed' && req.method.toUpperCase() === 'GET') {
		fs.readFile('views/addBreed.html', { encoding: 'utf-8' }, getHandler);
	} else if (
		pathname.startsWith('/cats/addBreed') &&
		req.method.toUpperCase() === 'POST'
	) {
		let raw = '';
		req.on('data', (chunk) => {
			raw += chunk;
		});
		req.on('end', () => {
			const formData = qs.decode(raw);
			fs.readFile('data/breeds.json', { encoding: 'utf-8' }, (err, data) => {
				if (err) {
					res.end('An error occurred1');
				} else {
					const breeds = JSON.parse(data);
					breeds.push(formData.breed);
					fs.writeFile(
						'data/breeds.json',
						JSON.stringify(breeds),
						{ encoding: 'utf-8' },
						(err) => {
							res.writeHead(301, { Location: '/' });
							res.end();
						}
					);
				}
			});
		});
	} else if (
		pathname === '/cats/addCat' &&
		req.method.toUpperCase() === 'GET'
	) {
		fs.readFile('views/addCat.html', { encoding: 'utf-8' }, addCatHandler);
	} else if (
		pathname.startsWith('/cats/addCat') &&
		req.method.toUpperCase() === 'POST'
	) {
		let form = new formidable.IncomingForm();
		form.parse(req, (err, fields, files) => {
			fs.readFile('data/cats.json', { encoding: 'utf-8' }, (err, data) => {
				if (err) {
					res.end(err.message);
					return;
				}
				const cats = JSON.parse(data);
				const file = files.upload;
				const cat = {
					id: cats.length + 1,
					name: fields.name,
					description: fields.description,
					breed: fields.breed,
					image: file.name,
				};
				fs.rename(
					file.path,
					path.resolve(`content/images/${file.name}`),
					(err) => {
						if (err) {
							res.end(err.message);
						}
					}
				);
				cats.push(cat);
				fs.writeFile(
					'data/cats.json',
					JSON.stringify(cats),
					{ encoding: 'utf-8' },
					(err) => {
						res.writeHead(301, { Location: '/' });
						res.end();
					}
				);
			});
		});
	} else if (
		pathname.startsWith('/cats/catShelter') &&
		req.method.toUpperCase() === 'GET'
	) {
		fs.readFile(
			'views/catShelter.html',
			{ encoding: 'utf-8' },
			catShelterHandler
		);
	} else if (
		pathname.startsWith('/cats/catShelter') &&
		req.method.toUpperCase() === 'POST'
	) {
		const id = Number(pathname.split('/').pop());
		let catss = cats;
		catss.splice(id - 1, 1);
		catss = cats.map((cat) => {
			cat.id = cats.indexOf(cat) + 1;
			return cat;
		});
		fs.writeFile(
			'data/cats.json',
			JSON.stringify(catss),
			{ encoding: 'utf-8' },
			(err) => {
				res.writeHead(301, { Location: '/' });
				res.end();
			}
		);
	} else if (
		pathname.startsWith('/cats/editCat') &&
		req.method.toUpperCase() === 'GET'
	) {
		fs.readFile('views/editCat.html', { encoding: 'utf-8' }, editCatHandler);
	} else if (
		pathname.startsWith('/cats/editCat') &&
		req.method.toUpperCase() === 'POST'
	) {
		const id = Number(pathname.split('/').pop());
		let form = new formidable.IncomingForm();
		form.parse(req, (err, fields, files) => {
			fs.readFile('data/cats.json', { encoding: 'utf-8' }, (err, data) => {
				if (err) {
					res.end(err.message);
					return;
				}
				const cats = JSON.parse(data);
				const file = files.image;
				const currentCat = cats[id - 1];
				const cat = {
					id: currentCat.id,
					name: fields.name,
					description: fields.description,
					breed: fields.breed,
					image: (file && file.name) || currentCat.image,
				};
				if (file) {
					fs.rename(
						file.path,
						path.resolve(`content/images/${file.name}`),
						(err) => {}
					);
				}
				cats[id - 1] = cat;
				fs.writeFile(
					'data/cats.json',
					JSON.stringify(cats),
					{ encoding: 'utf-8' },
					(err) => {
						res.writeHead(301, { Location: '/' });
						res.end();
					}
				);
			});
		});
	}
};
