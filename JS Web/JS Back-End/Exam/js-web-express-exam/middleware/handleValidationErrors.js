const {validationResult} = require('express-validator');

const handleValidationErrors = (req,res,next) => {
    const result = validationResult(req);
    if(!result.isEmpty()){
        next(result.errors); 
        return;
    }
    next();
}

module.exports = handleValidationErrors;