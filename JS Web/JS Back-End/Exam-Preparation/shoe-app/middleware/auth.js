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

const requireCreator = (shouldBeCreator)=>{
    if (shouldBeCreator) {
        return (req,res,next) => {
            const id = req.params.id;
            if(res.locals.user._id === id){
                next();
                return;
            }
            res.redirect('/details/'+id);
        }
    }
    return (req,res,next) => {
        const id = req.params.id;
        if(res.locals.user._id !== id){
            next();
            return;
        }
        res.redirect('/details/'+id);
    }
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

module.exports = {requireAuth, checkUser, requireCreator};