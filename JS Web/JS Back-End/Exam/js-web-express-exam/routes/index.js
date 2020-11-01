const authRoutes = require('./auth');
const courseRoutes = require('./course');
const {homeGet} = require('../controllers/index');
module.exports = (app) => {
	app.use(authRoutes);
	app.use(courseRoutes);
	app.get('/',homeGet)

	app.get('*', (_, res) => {
		res.render('404');
	});
};
