const url = require('url');
const fs = require('fs');
const path = require('path');
const getType = (url) => {
	if (url.endsWith('css')) {
		return 'text/css';
	} else if (url.endsWith('html')) {
		return 'text/html';
	} else if (url.endsWith('js')) {
		return 'application/javascript';
	} else if (url.endsWith('png')) {
		return 'image/png';
	}
};

module.exports = (req, res) => {
	const pathname = url.parse(req.url).pathname;
	fs.readFile(
		path.resolve('.' + pathname),
		{ encoding: 'utf-8' },
		(err, data) => {
			if (err) {
				res.writeHead(404, {
					'Content-Type': 'text-plain',
				});
				res.end('An error occured');
				return;
			}
			res.writeHead(200, {
				'Content-Type': getType(req.url),
			});
			res.end(data);
		}
	);
};
