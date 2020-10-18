var express = require("express");
var cookieParser = require("cookie-parser");
const handlebars = require("express-handlebars");
const dotenv = require("dotenv").config();
const path = require("path");
var indexRouter = require("./routes/auth");
var authRouter = require("./routes/index");

var app = express();

// view engine setup
const hbs = handlebars.create({
	extname: ".hbs",
	defaultLayout: "main",
	helpers: {
		user: function (_, res) {
			return res.locals.user;
		},
	},
});

app.engine(".hbs", hbs.engine);
app.set("view engine", ".hbs");

app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static("public"));

app.use(authRouter);
app.use(indexRouter);

// error handler
app.use(function (err, req, res, next) {
	// set locals, only providing error in development
	res.locals.message = err.message;
	res.locals.error = req.app.get("env") === "development" ? err : {};

	// render the error page
	res.status(err.status || 500);
	res.render("Internal server error");
});

app.listen(process.env.PORT, () => {
	console.log(`Listening on port ${process.env.PORT}`);
});
module.exports = app;
