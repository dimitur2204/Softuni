const { createGet,editGet,detailsGet, createPost, editPost, deleteGet, buyGet } = require('../controllers/shoe');
const { requireAuth, requireCreator } = require('../middleware/auth');
const handleValidationErrors = require('../middleware/handleValidationErrors');
const setErrorViewName = require('../middleware/setErrorViewName');
const { nameValidator, imageValidator, priceValidator } = require('../middleware/validators');
const router = require('express').Router();


router.get('/create',requireAuth(true), createGet);
router.post('/create',setErrorViewName('create'),
nameValidator,
imageValidator,
priceValidator,
handleValidationErrors, requireAuth(true), createPost);

router.get('/edit/:id', requireAuth(true), requireCreator(true), editGet);
router.post('/edit/:id', setErrorViewName('edit'),
nameValidator,
imageValidator,
priceValidator,
handleValidationErrors,
requireAuth(true), 
requireCreator(true), 
editPost);

router.get('/details/:id', requireAuth(true), detailsGet);

router.get('/buy/:id', requireAuth(true), requireCreator(false), buyGet);

router.get('/delete/:id', requireAuth(true), requireCreator(true), deleteGet);

module.exports = router;