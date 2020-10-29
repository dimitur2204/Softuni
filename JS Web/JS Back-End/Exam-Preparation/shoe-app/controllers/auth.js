const User = require('../models/user');
const jwt = require('jsonwebtoken');

const MAX_AGE_MINUTES = 15;

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
    const {email,password} = req.body;
    User.login(email,password).then(user => {
        const token = createToken(user._id);
        res.cookie('jwt',token, { httpOnly:true, maxAge: MAX_AGE_MINUTES * 60 * 1000});
        res.status(200).redirect('/');
    }).catch(next);   
}

const registerGet = (_,res) => {
    res.render('register');
}

const registerPost = (req,res,next) => {
    const {email,fullName,password,rePassword} = req.body;
    if(password !== rePassword){
        throw new Error('Passwords should match');
    }
    User.create({email, fullName, password}).then(user => {
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

const profileGet = (req,res,next) => {
    const user = res.locals.user;
    User.findById(user._id).populate('shoes').exec().then(user => {
        const totalPrice = user.shoes.reduce((acc,curr) => {
            acc += curr.price;
            return acc;
        },0)
        res.render('profile',{user,totalPrice})
    }).catch(next)
}

module.exports = {
    loginGet,
    loginPost,
    registerGet,
    registerPost,
    logoutGet,
    profileGet
}