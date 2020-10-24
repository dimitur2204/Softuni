const router = require('express').Router();
const {loginGet,registerGet,registerPost,loginPost} = require('../controllers/auth')

router.get('/login',loginGet)
router.get('/register',registerGet)

router.post('/login',loginPost)
router.post('/register',registerPost)

module.exports = router;