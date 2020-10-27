const jwt = require('jsonwebtoken');
const User = require('../models/user');

const requireAuth = (req, res, next) => {
    const token = req.cookies.jwt;

    if (token) {
        jwt.verify(token, process.env.JWT_SECRET, (err, decodedToken) => {
            if (err) {
                console.log(err.message);
                res.redirect('/login');
                return;
            }
            next();
        });   
        return;
    }

    res.redirect('/login');
}

const checkUser = (req,res,next) => {
    const token = req.cookies.jwt;

    if (token) {
        jwt.verify(token, process.env.JWT_SECRET,(err, decodedToken) => {
            if (err) {
                console.log(err.message);
                res.locals.user = null;
                next();
                return;
            }
            User.findById(decodedToken.id).then(user => {
                res.locals.user = user;
                next();
            });
        });
        return;
    }
    res.locals.user = null;
    next();
}

module.exports = {requireAuth, checkUser};