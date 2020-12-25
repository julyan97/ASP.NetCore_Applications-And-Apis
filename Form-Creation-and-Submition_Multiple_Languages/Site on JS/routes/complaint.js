const express = require('express')
const router = express.Router()
const handlebars = require('express-handlebars')

router.get('/', (req,res)=>{

    res.render('complaint',{
        isadmin:    req.isadmin,
        userName: req.session.name,
        islogged : req.islogged
    });
})

router.post('/', (req,res)=>{

})

module.exports = router