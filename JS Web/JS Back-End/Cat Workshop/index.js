const http = require('http');
const url = require('url');
const config = require('./config.json');
const homeHandler = require('./handlers/home');
const staticHandler = require('./handlers/static-files');
const catHandler = require('./handlers/cat');
http
	.createServer((req, res) => {
		const pathname = url.parse(req.url).pathname;
		if (pathname === '/' && req.method.toUpperCase() === 'GET') {
			homeHandler(req, res);
		} else if (
			pathname.startsWith('/content') &&
			req.method.toUpperCase() === 'GET'
		) {
			staticHandler(req, res);
		} else if (
			pathname.startsWith('/cats') &&
			req.method.toUpperCase() === 'GET'
		) {
			catHandler(req, res);
		}
	})
	.listen(config.port);
