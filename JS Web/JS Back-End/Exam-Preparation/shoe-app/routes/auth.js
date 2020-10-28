const router = require('express').Router();
const {loginGet,registerGet,registerPost,loginPost,logoutGet} = require('../controllers/auth');
const { requireAuth } = require('../middleware/auth');

router.get('/login',loginGet)
router.get('/register',registerGet)

router.post('/login',loginPost)
router.post('/register',registerPost)

router.get('/logout',requireAuth,logoutGet)

module.exports = router;