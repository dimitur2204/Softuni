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
    const user = await this.findOne({email});
    if (user) {
       const auth = await bcrypt.compare(password,user.password);
       if (auth) {
           return user;
       }
       throw Error('Incorrect password');
    }
    throw Error('Incorrect email');
}

module.exports = mongoose.model('user',userSchema);