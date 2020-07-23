import { home } from './controllers/home.js';
import {
	login,
	loginPost,
	register,
	registerPost,
	logout,
} from './controllers/user.js';
import {
	cinema,
	myMovies,
	addMovie,
	addMoviePost,
	details,
	deleteMovie,
	buy,
	edit,
	editPost,
} from './controllers/cinema.js';
$(() => {
	const app = Sammy('#container');

	app.use('Handlebars', 'hbs');

	app.userData = {
		username: localStorage.getItem('username') || '',
		userId: localStorage.getItem('userId') || '',
		movies: [],
	};

	app.get('#/', home);
	app.get('#/home', home);
	app.get('index.html', home);
	app.get('/', home);

	app.get('#/register', register);
	app.get('#/login', login);
	app.get('#/logout', logout);

	app.get('#/cinema', cinema);
	app.get('#/addMovie', addMovie);
	app.get('#/myMovies', myMovies);

	app.get('#/edit/:id', edit);
	app.get('#/details/:id', details);
	app.get('#/buy/:id', buy);
	app.get('#/delete/:id', deleteMovie);

	app.post('#/register', (ctx) => {
		registerPost.call(ctx);
	});
	app.post('#/login', (ctx) => {
		loginPost.call(ctx);
	});
	app.post('#/addMovie', (ctx) => {
		addMoviePost.call(ctx);
	});
	app.post('#/edit/:id', (ctx) => {
		editPost.call(ctx);
	});

	app.run();
});
