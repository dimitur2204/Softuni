const authRoutes = require('./auth');
const shoeRoutes = require('./shoe');
module.exports = (app) => {
	app.use(authRoutes);
	app.use(shoeRoutes);
	app.get('/',(_,res) => {
		res.render('home');
	})

	app.get('*', (_, res) => {
		res.render('404');
	});
};
