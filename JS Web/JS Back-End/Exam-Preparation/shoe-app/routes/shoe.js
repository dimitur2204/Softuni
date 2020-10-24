const { createGet,editGet,detailsGet } = require('../controllers/shoe');
const router = require('express').Router();


router.get('/create',createGet);
router.get('/edit/:id',editGet);
router.get('/details/:id',detailsGet);

module.exports = router;