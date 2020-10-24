const mongoose = require('mongoose');

const shoeSchema = new mongoose.Schema({
    name:{
        type:String,
        unique:true,
        required:true
    },
    price:{
        type:Number,
        required:true,
        min:0
    },
    imageUrl:{
        type:String,
        required:true
    },
    description:{
        type:String,
        maxlength:250
    },
    brand:{
        type:String
    },
    createdAt:{
        type:Date
    },
    creatorId:{
        type:mongoose.Types.ObjectId,
        ref:'user'
    },
    buyers:[{type:mongoose.Types.ObjectId,ref:'user'}]
})

module.exports = mongoose.model('shoe',shoeSchema);