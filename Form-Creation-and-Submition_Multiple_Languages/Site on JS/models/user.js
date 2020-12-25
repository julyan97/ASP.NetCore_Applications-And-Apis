const mongoose = require('mongoose')

const UserSchema = new mongoose.Schema({
    name:{
        type: String
    },
    password:{
        type: String
    },
    forms:[{
        type: 'ObjectId',
        ref:'Form'
    }]

})

module.exports = mongoose.model('User',UserSchema);