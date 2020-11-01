const Course = require('../models/course');
const User = require('../models/user');

const createGet = (req,res) => {
    res.render('create')
}

const createPost = (req,res,next) => {
   const {title,duration,imageUrl,description} = req.body;
   Course.create({
       title,
       imageUrl,
       description,
       duration,
       createdAt:new Date(Date.now()).toDateString(),
       creatorId:res.locals.user._id }).then(() => {
           res.redirect('/');
       }).catch(next);
}

const detailsGet = (req,res,next) => {
    const id = req.params.id;
    Course.findById(id).then(course=>{
        const user = res.locals.user;
        const isCreator = user._id.equals(course.creatorId);
        const isEnrolled = course.buyers.filter(b => b._id.equals(user._id)).length;
        res.render('details',{course, isCreator, isEnrolled});
    }).catch(next)
}

const editGet = (req,res,next) => {
    const id = req.params.id;
    Course.findById(id).lean().then(course=>{
        res.render('edit',course);
    }).catch(next)
}

const editPost = (req,res,next) => {
    const id = req.params.id;
    const {title,description,imageUrl,duration} = req.body;
    Course.findByIdAndUpdate(id,{title,description,imageUrl,duration}).then(course=>{
        res.redirect('/details/' + id);
    }).catch(next)
}

const deleteGet = (req,res,next) => {
    const id = req.params.id;
    Course.findByIdAndDelete(id).then(course => {
        res.redirect('/');
    }).catch(next)
}

const buyGet = (req,res,next) => {
    const id = req.params.id;
    const user = res.locals.user;
    Course.findByIdAndUpdate(id,{
        $addToSet: {buyers: user}
    }).then(course => {
        User.findByIdAndUpdate(user._id,{
            $addToSet: {courses: course}
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