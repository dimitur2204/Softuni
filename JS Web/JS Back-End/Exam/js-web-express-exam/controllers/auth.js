const User = require('../models/user');
const jwt = require('jsonwebtoken');

const MAX_AGE_MINUTES = 15;

const createToken = (id) => {
    return jwt.sign({ id }, '123456', {
        // 15 minutes
        expiresIn: 15 * 60
    });
}

const loginGet = (_,res) => {
    res.render('login');
}

const loginPost = (req,res,next) => {
    const {username,password} = req.body;
    User.login(username,password).then(user => {
        const token = createToken(user._id);
        res.cookie('jwt',token, { httpOnly:true, maxAge: MAX_AGE_MINUTES * 60 * 1000});
        res.status(200).redirect('/');
    }).catch(next);   
}

const registerGet = (_,res) => {
    res.render('register');
}

const registerPost = (req,res,next) => {
    const {username,password,rePassword} = req.body;
    User.create({username, password}).then(user => {
        const token = createToken(user._id);
        res.cookie('jwt',token, { httpOnly:true, maxAge: MAX_AGE_MINUTES * 60 * 1000});
        res.status(201).redirect('/');
    }).catch(next);
}

const logoutGet = (req,res) => {
    res.cookie('jwt','',{maxAge:1});
    res.locals.user = null;
    res.redirect('/login');
}

module.exports = {
    loginGet,
    loginPost,
    registerGet,
    registerPost,
    logoutGet
}