const Shoe = require('../models/shoe');

const createGet = (req,res) => {
    res.render('create')
}

const createPost = (req,res,next) => {
   const {name,price,imageUrl,description,brand} = req.body;
   Shoe.create({
       name,
       price,
       imageUrl,
       description,
       brand,
       createdAt:new Date(Date.now()),
       creatorId:res.locals.user._id }).then(() => {
           res.redirect('/');
       }).catch(next);
}

const detailsGet = (req,res) => {
    res.render('details');
}

const editGet = (req,res) => {
    res.render('edit')
    
}

module.exports = {
    createGet,
    detailsGet,
    editGet,
}