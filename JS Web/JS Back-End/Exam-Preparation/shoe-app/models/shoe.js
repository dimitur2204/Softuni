const mongoose = require('mongoose');

const shoeSchema = new mongoose.Schema({
    name:{
        type:String,
        unique:true,
        required:[true,'You should provide a name']
    },
    price:{
        type:Number,
        required:[true,'You should provide a price'],
        min:0
    },
    imageUrl:{
        type:String,
        required:[true,'You should provide an imageUrl']
    },
    description:{
        type:String,
        maxlength:[250,'Description cannot be more than 250 symbols']
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