const mongoose = require('mongoose')

const FormSchema = new mongoose.Schema({

 
    user:{
        type: 'ObjectId',
        ref: 'User'
    }

})

module.exports = mongoose.model('Form',FormSchema);