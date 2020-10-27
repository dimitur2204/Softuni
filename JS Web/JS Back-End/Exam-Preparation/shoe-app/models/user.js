const mongoose = require('mongoose');
const bcrypt = require('bcrypt');

const userSchema = new mongoose.Schema({
    email:{
        type:String,
        unique:true,
        required:true
    },
    fullName:{
        type:String,
    },
    password:{
        type:String,
        required:true
    },
    shoes:[{type:mongoose.Types.ObjectId,ref:'shoe'}]
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

userSchema.statics.login = function(email,password){
    return this.findOne({email}).then(user => {
        if (user) {
            bcrypt.compare(password,user.password).then(auth => {
                if (auth) {
                    return user;
                }
                throw Error('Incorrect password');
            });
            return user;
         }
         throw Error('Incorrect email');
    });
}

module.exports = mongoose.model('user',userSchema);