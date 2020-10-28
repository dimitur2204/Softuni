const router = require('express').Router();
const {loginGet,registerGet,registerPost,loginPost,logoutGet} = require('../controllers/auth')

router.get('/login',loginGet)
router.get('/register',registerGet)

router.post('/login',loginPost)
router.post('/register',registerPost)

router.get('/logout',logoutGet)

module.exports = router;