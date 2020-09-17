const fs = require('fs');
const path = require('path');
// const cats = require('cats');

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
		res.end(data);
	});
};
