const Shoe = require('../models/shoe');

const homeGet = (req,res) => {
    if(res.locals.user){
        Shoe.find({}).then(shoes => {
            shoes.sort((a,b) => {
               return b.buyers.length - a.buyers.length;
            })
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