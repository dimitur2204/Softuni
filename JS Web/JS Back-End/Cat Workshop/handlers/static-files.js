const url = require('url');
const fs = require('fs');
const path = require('path');
const utils = require('../utils');
module.exports = (req, res) => {
	const pathname = url.parse(req.url).pathname;
	if (
		pathname.toLowerCase().endsWith('png') ||
		pathname.toLowerCase().endsWith('jpeg') ||
		pathname.toLowerCase().endsWith('jpg') ||
		pathname.toLowerCase().endsWith('ico')
	) {
		fs.readFile(path.resolve('.' + decodeURI(pathname)), (err, data) => {
			if (err) {
				res.writeHead(404, {
					'Content-Type': 'text-plain',
				});
				res.end('An error occured');
				return;
			}
			res.writeHead(200, {
				'Content-Type': utils.getType(req.url),
			});
			res.end(data);
		});
	} else {
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
					'Content-Type': utils.getType(req.url),
				});
				res.end(data);
			}
		);
	}
};
