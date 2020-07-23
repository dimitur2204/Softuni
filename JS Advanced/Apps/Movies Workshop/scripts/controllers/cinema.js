import {
	getMovies,
	createMovie,
	getMoviesByUserId,
	getMovieById,
	deleteMovie as deleteMovieApi,
	buyTicket,
	updateMovie,
} from '../data.js';

export async function cinema() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
		movie: await this.load('../../templates/catalog/movie.hbs'),
	};
	const movies = await getMovies();
	this.app.userData.movies = movies;
	if (this.params.search) {
		console.log(this.params.search);
		this.app.userData.movies = this.app.userData.movies.filter((m) =>
			m.genres.includes(this.params.search)
		);
	}
	this.app.userData.origin = this.app.last_location[1];
	this.partial('../../templates/catalog/cinema.hbs', this.app.userData);
}
export async function addMovie() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
	};
	this.partial('../../templates/catalog/addMovie.hbs', this.app.userData);
}
export async function addMoviePost() {
	const info = this.params;
	const movie = {
		title: info.title,
		description: info.description,
		tickets: Number(info.tickets),
		genres: info.genres,
		image: info.image,
	};
	await createMovie(movie);
	this.redirect('#/cinema');
}
export async function myMovies() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
		myMovie: await this.load('../../templates/catalog/myMovie.hbs'),
	};
	this.app.userData.movies = await getMoviesByUserId(
		localStorage.getItem('userId')
	);
	this.app.userData.origin = this.app.last_location[1];

	this.partial('../../templates/catalog/myMovies.hbs', this.app.userData);
}
export async function details() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
	};
	const movie = await getMovieById(this.params.id);
	this.app.userData.movie = movie;
	this.app.userData.origin = this.app.last_location[1];

	this.partial('../../templates/catalog/detailsMovie.hbs', this.app.userData);
}
export async function deleteMovie() {
	const id = this.params.id;
	deleteMovieApi(id);
	this.app.userData.movies = await getMovies();
	this.redirect('#/cinema');
}
export async function buy() {
	const id = this.params.id;
	await buyTicket(id);
	this.app.userData.movies = await getMovies();
	this.redirect(this.app.userData.origin);
}
export async function edit() {
	this.partials = {
		header: await this.load('../../templates/common/header.hbs'),
		footer: await this.load('../../templates/common/footer.hbs'),
	};
	const movie = await getMovieById(this.params.id);
	this.app.userData.movie = movie;
	this.partial('../../templates/catalog/editMovie.hbs', this.app.userData);
}
export async function editPost() {
	const info = this.params;
	const movie = {
		title: info.title,
		description: info.description,
		tickets: Number(info.tickets),
		genres: info.genres,
		image: info.image,
	};
	await updateMovie(this.params.id, movie);
	this.redirect('#/myMovies');
}
