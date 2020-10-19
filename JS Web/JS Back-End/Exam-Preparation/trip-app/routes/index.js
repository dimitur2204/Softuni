var express = require("express");
const homeController = require("..//controllers/home");
var router = express.Router();
var authRouter = require("./auth");
var tripRouter = require("./trip");

router.use(authRouter);
router.use(tripRouter);
/* GET home page. */
router.get("/", homeController.homeGet);

module.exports = router;
