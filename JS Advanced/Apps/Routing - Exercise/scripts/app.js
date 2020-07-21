import home from './controllers/home.js';
import about from './controllers/about.js';
import catalog from './controllers/catalog.js';
import details from './controllers/details.js';
import {
	register,
	registerPost,
	login,
	loginPost,
	logout,
} from './controllers/user.js';
import { create, createPost, join, leave } from './controllers/create.js';
import edit from './controllers/edit.js';
$(() => {
	//TODO: Team adding, user session etc.
	const app = Sammy('#main', function () {
		this.userData = {};
		this.use('Handlebars', 'hbs');

		this.get('#/home', home);
		this.get('#/', home);
		this.get('/', home);

		this.get('#/about', about);

		this.get('#/catalog', catalog);
		this.get('#/catalog/:id', details);
		this.get('#/edit', edit);
		this.get('#/join/:id', join);
		this.get('#/leave', leave);

		this.get('#/create', create);

		this.get('#/register', register);
		this.get('#/login', login);
		this.get('#/logout', logout);

		this.post('#/create', (ctx) => {
			createPost.call(ctx);
		});

		this.post('#/register', (ctx) => {
			registerPost.call(ctx);
		});
		this.post('#/login', (ctx) => {
			loginPost.call(ctx);
		});
	});
	app.run();
});
