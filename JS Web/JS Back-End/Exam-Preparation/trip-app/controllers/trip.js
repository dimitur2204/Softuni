const Trip = require("../models/trip");

const tripsGet = async (req, res, next) => {
	try {
		const trips = await Trip.find({});
		if (trips.length) {
			res.render("sharedTripps", trips);
			return;
		}
		res.render("noSharedTripps");
	} catch (error) {
		next(error);
	}
};

const tripsCreateGet = (_, res) => {
	res.render("offerTripp");
};

const tripsCreatePost = (req, res, next) => {
	const { startEnd, dateTime, carImage, seats, description } = req.body;
	try {
		const startEndArr = startEnd.split(" - ");
		const start = startEndArr[0];
		const end = startEndArr[1];

		const trip = new Trip();
	} catch (error) {}
};

module.exports = {
	tripsGet,
	tripsCreateGet,
};
