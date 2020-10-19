const mongoose = require("mongoose");

const tripSchema = new mongoose.Schema({
	startPoint: {
		type: String,
		required: [true, "You should provide an email"],
	},
	endPoint: {
		type: String,
		required: [true, "You should provide an end point"],
	},
	date: {
		type: String,
		required: [true, "You should provide a data"],
	},
	time: {
		type: String,
		required: [true, "You should provide a time"],
	},
	seats: {
		type: Number,
		required: [true, "You should provide a number of seats"],
	},
	description: {
		type: String,
		required: [true, "You should provide a description"],
	},
	carImage: {
		type: String,
		required: [true, "You should provide a car image"],
	},
	buddies: [{ type: mongoose.Schema.Types.ObjectId, ref: "User" }],
	creator: {
		type: mongoose.Schema.Types.ObjectId,
		ref: "User",
		required: [true, "You should provide a creator"],
	},
});

module.exports = mongoose.model("Trip", tripSchema);
