const { createGet,editGet,detailsGet, createPost, editPost, deleteGet, buyGet } = require('../controllers/course');
const { requireAuth } = require('../middleware/auth');
const {requireCreator} = require('../middleware/course');
const handleValidationErrors = require('../middleware/handleValidationErrors');
const setErrorViewName = require('../middleware/setErrorViewName');
const validators = require('../middleware/validators');
const router = require('express').Router();


router.get('/create',requireAuth(true), createGet);
router.post('/create',
setErrorViewName('create'),
validators.titleValidator,
validators.descriptionValidator,
validators.imageValidator,
handleValidationErrors, requireAuth(true), createPost);

router.get('/edit/:id', requireAuth(true), requireCreator(true), editGet);
router.post('/edit/:id',requireAuth(true), requireCreator(true),  
setErrorViewName('edit'),
validators.titleValidator,
validators.descriptionValidator,
validators.imageValidator,
handleValidationErrors,
editPost);

router.get('/details/:id', requireAuth(true), detailsGet);

router.get('/buy/:id', requireAuth(true), requireCreator(false), buyGet);

router.get('/delete/:id', requireAuth(true), requireCreator(true), deleteGet);

module.exports = router;