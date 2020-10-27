const authRoutes = require('./auth');
const shoeRoutes = require('./shoe');
const {homeGet} = require('../controllers/index');
module.exports = (app) => {
	app.use(authRoutes);
	app.use(shoeRoutes);
	app.get('/',homeGet)

	app.get('*', (_, res) => {
		res.render('404');
	});
};
