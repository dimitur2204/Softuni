const validator = require('express-validator');
const User = require('../models/user');


const repeatPasswordCheck = validator.body('rePassword').custom((value,{req}) => {
    if (value !== req.body.password) {
        throw new Error('Passwords don\'t match');
    }
    return true;
})

const checkEmailExists = validator.body('email').custom((value, {req}) => {
    return User.findOne({email:value}).then(user => {
        console.log(user);
        if(user){
            throw new Error('Email exists!')
        }
    })
})
const passwordValidator = validator.body('password')
.isAlphanumeric()
.withMessage('Password should contain only words and digits')
.isLength({min:3})
.withMessage('Password should be atleast 3 symbols long');


const emailValidator = validator.body('email')
.isEmail()
.withMessage('You should provide a valid email');

const nameValidator = validator.body('name')
.notEmpty()
.withMessage('You should provide a valid name');

const priceValidator = validator.body('price')
.notEmpty()
.withMessage('You should provide a price')
.isNumeric()
.withMessage('You should provide a valid price')

const imageValidator = validator.body('imageUrl')
.notEmpty()
.withMessage('You should provide an imageUrl')
.isURL()
.withMessage('You should provide a valid URL')

module.exports = {
    passwordValidator,
    emailValidator,
    nameValidator,
    priceValidator,
    imageValidator,
    checkEmailExists,
    repeatPasswordCheck
}
