const http = require('http');
const url = require('url');
const config = require('./config.json');
const homeHandler = require('./handlers/home');
http
	.createServer((req, res) => {
		const pathname = url.parse(req.url).pathname;
		if (pathname === '/' && req.method.toUpperCase() === 'GET') {
			homeHandler(req, res);
		}
	})
	.listen(config.port);
