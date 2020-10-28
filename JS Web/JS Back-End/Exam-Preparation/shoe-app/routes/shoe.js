const { createGet,editGet,detailsGet, createPost, editPost, deleteGet, buyGet } = require('../controllers/shoe');
const { requireAuth, requireCreator } = require('../middleware/auth');
const router = require('express').Router();


router.get('/create', requireAuth, createGet);
router.post('/create', requireAuth, createPost);

router.get('/edit/:id', requireAuth, requireCreator(true), editGet);
router.post('/edit/:id', requireAuth, requireCreator(true), editPost);

router.get('/details/:id', requireAuth, detailsGet);

router.get('/buy/:id', requireAuth, requireCreator(false), buyGet);

router.get('/delete/:id', requireAuth, requireCreator(true), deleteGet);

module.exports = router;