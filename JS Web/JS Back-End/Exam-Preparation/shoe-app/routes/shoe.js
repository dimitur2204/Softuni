const { createGet,editGet,detailsGet, createPost,editPost } = require('../controllers/shoe');
const router = require('express').Router();


router.get('/create',createGet);
router.post('/create',createPost);

router.get('/edit/:id',editGet);
router.post('/edit/:id',editPost);

router.get('/details/:id',detailsGet);

module.exports = router;