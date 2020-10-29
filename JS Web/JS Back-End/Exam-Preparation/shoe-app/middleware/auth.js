const jwt = require('jsonwebtoken');
const User = require('../models/user');
const Shoe = require('../models/shoe');

const requireAuth = (shouldRequireAuth) => {
    if(shouldRequireAuth){
        return (req, res, next) => {
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
            return;
        }
    }
}

const notLoggedIn = (req,res,next) => {
    if(res.locals.user){
        res.redirect('/');
        return;
    }
    next()
}

const requireCreator = (shouldBeCreator)=>{
    if (shouldBeCreator) {
        return (req,res,next) => {
            const id = req.params.id;
            Shoe.findById(id).then(shoe => {
                if(res.locals.user._id.equals(shoe.creatorId)){
                    next();
                    return;
                }
                res.redirect('/details/'+id);
            })
        }
    }
    return (req,res,next) => {
        const id = req.params.id;
        Shoe.findById(id).then(shoe => {
            if(!(res.locals.user._id.equals(shoe.creatorId))){
                next();
                return;
            }
            res.redirect('/details/'+id);
            return;
        })
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

module.exports = {requireAuth, checkUser, requireCreator, notLoggedIn};