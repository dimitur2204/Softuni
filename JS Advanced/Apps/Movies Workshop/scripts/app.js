import { home } from './controllers/home.js';
import { cinema } from './controllers/cinema.js';
import * as data from './data.js';
$(() => {
	const app = Sammy('#container');

	app.use('Handlebars', 'hbs');

	app.get('#/', home);
	app.get('#/home', home);
	app.get('index.html', home);
	app.get('/', home);

	app.get('#/cinema', cinema);

	app.run();
});
