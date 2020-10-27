const Shoe = require('../models/shoe');

const homeGet = (req,res) => {
    if(res.locals.user){
        Shoe.find({}).then(shoes => {
        res.render('shoes',{shoes});
        return;
        })
        return;
    }
    res.render('home');
}


module.exports = {
    homeGet
}