const Course = require('../models/course');
const requireCreator = (shouldBeCreator)=>{
    if (shouldBeCreator) {
        return (req,res,next) => {
            const id = req.params.id;
            Course.findById(id).then(course => {
                if(res.locals.user._id.equals(course.creatorId)){
                    next();
                    return;
                }
                res.redirect('/details/'+id);
            })
        }
    }
    return (req,res,next) => {
        const id = req.params.id;
        Course.findById(id).then(course => {
            if(!(res.locals.user._id.equals(course.creatorId))){
                next();
                return;
            }
            res.redirect('/details/'+id);
            return;
        })
    }
} 

module.exports = {
    requireCreator
}