
var express = require('express');
var router = express.Router();
var db = require('../dataBase/db');
var User = require('../models/user')



router.get('/', function(req, res, next) {

    res.render('create',{
      isadmin : req.isadmin,
      userName : req.session.name,
      islogged : req.islogged
  })
    
  });
  
  router.post('/', function(req, res, next) {
  
    const name = req.body.uname
    const pass = `${req.body.password}`
    const usertoadd = new User({name : name, password: pass})
    usertoadd.save();
    res.redirect('/')
  });
  
  
  module.exports = router;