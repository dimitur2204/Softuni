const mongoose = require('mongoose');

const courseSchema = new mongoose.Schema({
    title:{
        type:String,
        unique:true,
        required:[true,'You should provide a title']
    },
    imageUrl:{
        type:String,
        required:[true,'You should provide an imageUrl']
    },
    description:{
        type:String,
        required:true,
        maxlength:[50,'Description cannot be more than 50 symbols']
    },
    duration:{
        type:String,
        required:true
    },
    createdAt:{
        type:String,
        required:true
    },
    creatorId:{
        type:mongoose.Types.ObjectId,
        ref:'user'
    },
    buyers:[{type:mongoose.Types.ObjectId,ref:'user'}]
})

module.exports = mongoose.model('course',courseSchema);