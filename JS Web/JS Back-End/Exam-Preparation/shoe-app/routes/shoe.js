const { createGet,editGet,detailsGet, createPost } = require('../controllers/shoe');
const router = require('express').Router();


router.get('/create',createGet);
router.post('/create',createPost);
router.get('/edit/:id',editGet);
router.get('/details/:id',detailsGet);

module.exports = router;