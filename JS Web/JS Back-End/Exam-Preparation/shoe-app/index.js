const env = process.env.NODE_ENV || 'development';
require('dotenv').config();
const config = require('./config/config')[env];
const app = require('express')();
const mongoose = require('mongoose');
require('./config/express')(app);
require('./routes')(app);

const connectionString = process.env.DB_CONNECTION_STRING;

mongoose.connect(connectionString, {
	useNewUrlParser: true,
	useUnifiedTopology: true,
	useFindAndModify:false
}).then(() => {
	console.log('Connected to database');
}).catch(err => {
	console.error(err);
});

app.use((err,req,res,next) => {
	console.log(err);
	if (res.locals.errorViewName) {
		res.render(res.locals.errorViewName,{errors:err,body:req.body})
		return;
	}
	res.status(500);
	res.send(err);
})

app.listen(
	config.port,
	console.log(`Listening on port ${config.port}! Now its up to you...`)
);
