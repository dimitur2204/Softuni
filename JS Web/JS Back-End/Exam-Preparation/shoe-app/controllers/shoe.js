const Shoe = require('../models/shoe');
const User = require('../models/user');

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

const detailsGet = (req,res,next) => {
    const id = req.params.id;
    Shoe.findById(id).then(shoe=>{
        const user = res.locals.user;
        const isNotCreator = !(user._id.equals(shoe.creatorId));
        const isNotBuyer = !(shoe.buyers.filter(b => b._id.equals(user._id)).length);
        const showBuy = isNotBuyer && isNotCreator;
        res.render('details',{shoe,showBuy, isNotCreator});
    }).catch(next)
}

const editGet = (req,res,next) => {
    const id = req.params.id;
    Shoe.findById(id).lean().then(shoe=>{
        res.render('edit',shoe);
    }).catch(next)
}

const editPost = (req,res,next) => {
    const id = req.params.id;
    const {name,price,description,imageUrl,brand} = req.body;
    Shoe.findByIdAndUpdate(id,{name,price,description,imageUrl,brand}).then(shoe=>{
        res.redirect('/details/' + id);
    }).catch(next)
}

const deleteGet = (req,res,next) => {
    const id = req.params.id;
    Shoe.findByIdAndDelete(id).then(shoe => {
        res.redirect('/');
    }).catch(next)
}

const buyGet = (req,res,next) => {
    const id = req.params.id;
    const user = res.locals.user;
    Shoe.findByIdAndUpdate(id,{
        $addToSet: {buyers: user}
    }).then(shoe => {
        User.findByIdAndUpdate(user._id,{
            $addToSet: {shoes: shoe}
        }).then(() => {
        res.redirect('/details/'+id);
        })
    }).catch(next)
}

module.exports = {
    createGet,
    detailsGet,
    editGet,
    createPost,
    editPost,
    deleteGet,
    buyGet
}