const router = require('express').Router();
const {loginGet,registerGet,registerPost,loginPost,logoutGet, profileGet} = require('../controllers/auth');
const { requireAuth, notLoggedIn } = require('../middleware/auth');
const handleValidationErrors = require('../middleware/handleValidationErrors');
const setErrorViewName = require('../middleware/setErrorViewName');
const { repeatPasswordCheck, checkEmailExists, passwordValidator, emailValidator } = require('../middleware/validators');

router.get('/login',notLoggedIn,loginGet)
router.get('/register',notLoggedIn,registerGet)

router.post('/login',notLoggedIn,
setErrorViewName('login'),
passwordValidator,
emailValidator,
handleValidationErrors,loginPost)

router.post('/register',
notLoggedIn,
setErrorViewName('register'),
repeatPasswordCheck,
checkEmailExists,
passwordValidator,
emailValidator,
handleValidationErrors,
registerPost)

router.get('/logout',requireAuth(true),logoutGet)

router.get('/profile',requireAuth(true),profileGet)

module.exports = router;