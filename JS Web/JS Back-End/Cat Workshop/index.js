const http = require('http');
const url = require('url');
const config = require('./config.json');
const homeHandler = require('./handlers/home');
const staticHandler = require('./handlers/static-files');
const catHandler = require('./handlers/cat');
const homeSearchHandler = require('./handlers/home-search');
http
	.createServer((req, res) => {
		const urls = req.url;
		const pathname = url.parse(req.url).pathname;
		if (pathname === '/' && req.method.toUpperCase() === 'GET') {
			homeHandler(req, res);
		} else if (pathname === '/' && req.method.toUpperCase() === 'POST') {
			homeSearchHandler(req, res);
		} else if (
			pathname.includes('/content') &&
			req.method.toUpperCase() === 'GET'
		) {
			staticHandler(req, res);
		} else if (pathname.startsWith('/cats')) {
			catHandler(req, res);
		}
	})
	.listen(config.port);
