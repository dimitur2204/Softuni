const mongodb = require('mongodb');

const MongoClient = mongodb.MongoClient;
const connectionStr = 'mongodb://localhost:27017';

const client = new MongoClient(connectionStr);

const dbQueries = async (people) => {
	await people.insertOne({ name: 'Pesho' });

	const result = await people.find({ name: 'Pesho' }).toArray();
	console.log('async Result', result);
};

client.connect(function (err) {
	if (err) {
		console.error(err);
		throw err;
	}
	const db = client.db('softuni');
	const people = db.collection('people');

	dbQueries(people);
});
