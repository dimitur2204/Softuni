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
        const user = res.locals.user;
        const isNotCreator = user._id.toString() !== shoe.creatorId.toString();
        const isNotBuyer = shoe.buyers.includes(b => b._id !== user._id);
        const showBuy = isNotBuyer && isNotCreator;
        res.render('details',{shoe,showBuy});
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

const deleteGet = (req,res) => {
    const id = req.params.id;
    Shoe.findByIdAndDelete(id).then(shoe => {
        res.redirect('/');
    })
}

const buyGet = (req,res) => {
    const id = req.params.id;
    const user = res.locals.user;
    Shoe.findByIdAndUpdate(id,{
        $addToSet: {buyers: user}
    }).then(shoe => {
        res.redirect('/details/'+id);
    })
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