const Course = require('../models/course');

const homeGet = (req,res,next) => {
    const query = req.query;
	const search = query.search;

	Course.find({
		title: {
			$regex: new RegExp(search, 'i') || '.*',
		},
	}).then((courses) => {
        courses.sort((a,b) => {
            return b.buyers.length - a.buyers.length;
        });
        if(res.locals.user){
            res.render('courses',{courses});
            return;
        }
        res.render('home',{courses});
        return;
	}).catch(next);
   
}


module.exports = {
    homeGet
}