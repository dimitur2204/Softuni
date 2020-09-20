const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
//const formidable = require('formidable');
const breeds = require('../data/breeds');
const cats = require('../data/cats');
module.exports = (req, res) => {
	const pathname = url.parse(req.url).pathname;
	const handler = (err, data) => {
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
	if (pathname === '/cats/addBreed') {
		fs.readFile('views/addBreed.html', { encoding: 'utf-8' }, handler);
	} else if (pathname === '/cats/addCat') {
		fs.readFile('views/addCat.html', { encoding: 'utf-8' }, handler);
	} else if (pathname === '/cats/catShelter') {
		fs.readFile('views/catShelter.html', { encoding: 'utf-8' }, handler);
	} else if (pathname === '/cats/editCat') {
		fs.readFile('views/editCat.html', { encoding: 'utf-8' }, handler);
	}
};
