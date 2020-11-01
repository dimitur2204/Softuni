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
});

app.listen(
	config.port,
	console.log(`Listening on port ${config.port}! Now its up to you...`)
);
