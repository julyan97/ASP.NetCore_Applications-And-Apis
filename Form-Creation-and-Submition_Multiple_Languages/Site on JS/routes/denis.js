const express = require('express')
const router = express.Router()
const handlebars = require('express-handlebars')

router.get('/', (req,res)=>{

    res.render('denis',{
        isadmin:req.isadmin,
        userName: req.session.name,
        islogged : req.islogged
    });
})

module.exports = router