var express = require('express');
var router = express.Router();
var db = require('../dataBase/db')


router.get('/login/out', function(req, res, next) {
    req.session.name =undefined;
    req.session.password = undefined;
  
    res.redirect(307, '/');
  });


  module.exports = router