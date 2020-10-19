var express = require("express");
const tripController = require("..//controllers/trip");
var router = express.Router();

/* GET home page. */
router.get("/trips", tripController.tripsGet);

router.get("/trips/create", tripController.tripsCreateGet);

module.exports = router;
