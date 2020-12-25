var express = require('express');
var router = express.Router();
var db = require('../dataBase/db');
var User = require('../models/user')

/* GET home page. */
router.get('/login', function(req, res, next) {
  
  res.render('login',{
    isadmin : req.isadmin,
    userName : req.session.name,
    islogged : req.islogged
})
});

router.post('/login', function(req, res, next) {
  
  User.findOne({name: req.body.uname, password: req.body.password},(err,an)=>
  {
    try{
    if(an.name == req.body.uname){
      req.session.name =req.body.uname;
      req.session.password = req.body.password
    res.redirect('/');
    }
  }
    catch{
     console.log(err)
      res.redirect('/login')
    }
  })
  
  // if(db.ContainsUser(req.body.uname,req.body.password))
  // {
  //   req.session.name =req.body.uname;
  //   req.session.password = req.body.password
  //   res.redirect('/');
  //   return
  // }
  // //db.addUser(req.body.uname,req.body.password)
  // res.redirect('/login')

  
});



module.exports = router;