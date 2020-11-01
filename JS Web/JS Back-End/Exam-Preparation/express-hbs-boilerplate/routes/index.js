
module.exports = (app) => {

	app.get('/about', (_, res) => {
		res.render('about');
	});

	app.get('*', (_, res) => {
		res.render('404');
	});
};
