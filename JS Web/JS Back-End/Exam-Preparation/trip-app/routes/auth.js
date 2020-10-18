const express = require("express");
const router = express.Router();
const authController = require("../controllers/auth");
const { requireAuth } = require("../middleware/auth-middleware");

router.get("/login", authController.getLogin);
router.post("/login", authController.postLogin);

router.get("/register", authController.getRegister);
router.post("/register", authController.postRegister);

router.get("/logout", requireAuth, authController.getLogout);

module.exports = router;
