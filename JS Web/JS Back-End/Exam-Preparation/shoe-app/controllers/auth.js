const User = require('../models/user');
const jwt = require('jsonwebtoken');

const createToken = (id) => {
    return jwt.sign({ id }, process.env.JWT_SECRET, {
        // 15 minutes
        expiresIn: 15 * 60
    });
}

const loginGet = (_,res) => {
    res.render('login');
}

const loginPost = (req,res,next) => {
    User.login(email,password).then(user => {
        const token = createToken(user._id);
        res.cookie('jwt',token, { httpOnly:true, maxAge: MAX_AGE_SECONDS * 1000});
        res.status(200).redirect('/');
    }).catch(next);   
}

const registerGet = (_,res) => {
    res.render('register');
}

const registerPost = (req,res,next) => {
    const {email,fullName,password,rePassword} = req.body;
    User.create({email, fullName, password}).then(user => {
        const token = createToken(user._id);
        res.cookie('jwt',token, { httpOnly:true, maxAge: MAX_AGE_SECONDS * 1000});
        res.status(201).redirect('/');
    }).catch(next);
}

module.exports = {
    loginGet,
    loginPost,
    registerGet,
    registerPost
}