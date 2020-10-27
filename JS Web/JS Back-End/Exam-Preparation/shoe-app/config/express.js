const express = require('express');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const { checkUser } = require('../middleware/auth');

module.exports = (app) => {
	const hbs = handlebars.create({ 
		extname: '.hbs',
		defaultLayout:'main',
		helpers:{
			user:function (_, res) {
				return res.locals.user;
			  }
		} 
	});
	app.engine('.hbs', hbs.engine);
	app.set('view engine', '.hbs');

	app.use(express.urlencoded({ extended: false }));
	app.use(express.json());
	app.use(cookieParser());
	app.use(express.static('static'));
	app.use(checkUser);

	app.use((err,req,res,next) => {
		res.send('In global handler');
	})
};
