const validator = require('express-validator');
const User = require('../models/user');
const bcrypt = require('bcrypt');

const repeatPasswordCheck = validator.body('rePassword').custom((value,{req}) => {
    if (value !== req.body.password) {
        throw new Error('Passwords don\'t match');
    }
    return true;
})

const checkUsernameExists = validator.body('username').custom((value, {req}) => {
    return User.findOne({username:value}).then(user => {
        if(user){
            throw new Error('Username exists!')
        }
    })
})

const checkUsernameCorrect = validator.body('username').custom((value, {req}) => {
    return User.findOne({username:value}).then(user => {
        if(!user){
            throw new Error('Incorrect username!')
        }
    })
})

const checkPasswordCorrect = validator.body('password').custom((value, {req}) => {
    return User.findOne({username:req.body.username}).then(user => {
        if (user) {
            return bcrypt.compare(value,user.password).then(auth => {
                if (!auth) {
                    throw new Error('Incorrect password!')
                }
            })
        }
    })
})
const passwordValidator = validator.body('password')
.isAlphanumeric()
.withMessage('Password should contain only words and digits')
.isLength({min:5})
.withMessage('Password should be atleast 5 symbols long');


const usernameValidator = validator.body('username')
.isAlphanumeric()
.withMessage('Username should contain only words and digits')
.isLength({min:5})
.withMessage('Username should be atleast 5 symbols long');

const titleValidator = validator.body('title')
.isLength({min:4})
.withMessage('Title should be atleast 4 characters long');

const descriptionValidator = validator.body('description')
.isLength({min:20})
.withMessage('Description should be atleast 20 characters long')

const imageValidator = validator.body('imageUrl')
.isURL()
.withMessage('ImageUrl should start with http or https')

module.exports = {
    repeatPasswordCheck,
    checkUsernameExists,
    checkUsernameCorrect,
    checkPasswordCorrect,
    passwordValidator,
    usernameValidator,
    titleValidator,
    descriptionValidator,
    imageValidator
}
