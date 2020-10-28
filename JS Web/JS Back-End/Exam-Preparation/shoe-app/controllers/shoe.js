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
    const id = req.params.id;
    
    Shoe.findById(id).then(shoe=>{
        const isCreator = res.locals.user._id.toString() === shoe.creatorId.toString();
        res.render('details',{shoe,isCreator});
    })
}

const editGet = (req,res) => {
    const id = req.params.id;
    Shoe.findById(id).lean().then(shoe=>{
        res.render('edit',shoe);
    })
}

const editPost = (req,res) => {
    const id = req.params.id;
    const {name,price,description,imageUrl,brand} = req.body;
    Shoe.findByIdAndUpdate(id,{name,price,description,imageUrl,brand}).then(shoe=>{
        console.log(shoe);
        res.redirect('/details/' + id);
    })
}

module.exports = {
    createGet,
    detailsGet,
    editGet,
    createPost,
    editPost
}