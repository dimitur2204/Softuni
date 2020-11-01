module.exports = (viewName) => {
    return (req,res,next) => {
        res.locals.errorViewName = viewName;
        next();
    }
}