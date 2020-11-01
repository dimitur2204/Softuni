const router = require('express').Router();
const {loginGet,registerGet,registerPost,loginPost,logoutGet} = require('../controllers/auth');
const { requireAuth, notLoggedIn } = require('../middleware/auth');
const handleValidationErrors = require('../middleware/handleValidationErrors');
const setErrorViewName = require('../middleware/setErrorViewName');
const validators = require('../middleware/validators');

router.get('/login',notLoggedIn,loginGet)
router.get('/register',notLoggedIn,registerGet)

router.post('/login',notLoggedIn,
setErrorViewName('login'),
validators.usernameValidator,
validators.passwordValidator,
validators.checkUsernameCorrect,
validators.checkPasswordCorrect,
handleValidationErrors,loginPost)

router.post('/register',
notLoggedIn,
setErrorViewName('register'),
validators.usernameValidator,
validators.passwordValidator,
validators.checkUsernameExists,
validators.repeatPasswordCheck,
handleValidationErrors,
registerPost)

router.get('/logout',requireAuth(true),logoutGet)


module.exports = router;