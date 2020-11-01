const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const validator = require('validator').default;

const userSchema = new mongoose.Schema({
    username:{
        type:String,
        unique:true,
        required:[true,'You should provide a username']
    },
    password:{
        type:String,
        required:[true, 'You should provide a valid password'],
    },
    courses:[{type:mongoose.Types.ObjectId,ref:'course'}]
})


//"this" in the following functions refers to the current user model

//hashing password before saving to the database
userSchema.pre('save', function(next){
    bcrypt.genSalt().then(salt => {
        bcrypt.hash(this.password,salt).then(hashed=> {
            this.password = hashed;
            next();
        })
    })
});

userSchema.statics.login = function(username,password){
    return this.findOne({username}).then(user => {
            return bcrypt.compare(password,user.password).then(auth => {
                if (auth) {
                    return user;
                }
                throw new Error('No such user');
            });
    });
}

module.exports = mongoose.model('user',userSchema);