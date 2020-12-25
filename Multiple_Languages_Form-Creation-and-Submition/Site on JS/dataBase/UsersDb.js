const user = require('../models/user')

const getAllUsers =async ()=>
{
    const users = await user.find();
    return users;
}

const doesUserExist = async (uname, password)=>
{
    const found = await user.findOne({name: uname});
    console.log(found.name)
    if(found.name === uname )
    return true
    else return false
}

//console.log(doesUserExist("juliano",'123'))

module.exports = {
    getAllUsers,
    doesUserExist
}