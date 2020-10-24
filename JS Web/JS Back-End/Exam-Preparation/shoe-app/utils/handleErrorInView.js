exports.default = (req,res,viewName,err) => {
    res.render(viewName,{body:req.body,err})
}