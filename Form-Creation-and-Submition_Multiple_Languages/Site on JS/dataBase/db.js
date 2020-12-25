const fs = require('fs');

function readUsers()
{
    let users;
    users = fs.readFileSync('dataBase/users.txt','utf8')
    return users.split('\r\n')
}
function addUser(name, password)
{
    fs.appendFileSync('dataBase/users.txt','\r\n'+name+' '+'user'+ ' '+password)
}

function ContainsUser(name , password)
{
    users = fs.readFileSync('dataBase/users.txt','utf8').split('\r\n')

    for (let i = 0; i < users.length; i++) {
        const element = users[i];
        if(name === 'admin')
        {
            if(element === name+' '+'admin'+ ' '+password)
            return true;
        }

        if(element === name+' '+'user'+ ' '+password)
        return true;
        
    }
    return false;
}
module.exports={
    ContainsUser,
    readUsers,
    addUser
}
