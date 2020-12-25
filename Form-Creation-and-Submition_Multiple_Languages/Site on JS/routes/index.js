var express = require('express');
const cookie = require('cookie-session')
var router = express.Router();

/* GET home page. */
router.get('/', (req, res, next) =>{

 

  res.render('index',{
    isadmin:req.isadmin,
    list:req.list,
    userName: req.session.name,
    islogged : req.islogged
});
 
});

router.post('/',(req,res,next)=>{

  
});

module.exports = router;
