var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var exphbs  = require('express-handlebars');
var cookie = require('cookie-session')
var indexRouter = require('./routes/index');
var usersRouter = require('./routes/users');
var uverenieRouter = require('./routes/uverenie')
var complaintRouter = require('./routes/complaint')
var loginRouter = require('./routes/login')
var viktorRouter = require('./routes/viktor')
var denisRouter = require('./routes/denis')
var logoutRouter = require('./routes/logout')
var createRouter = require('./routes/create')
const mongoose = require('mongoose')
const password = 'User123'

mongoose.connect(`mongodb+srv://user:${password}@unisofia.43jia.mongodb.net/UniSofiaDb?retryWrites=true&w=majority`,{
    useNewUrlParser: true,
    useUnifiedTopology: true
},(err)=>{
    if(err)throw err;
    console.log('connected');
})


var app = express();


app.use(cookie({
  name: 'session',
  keys: ['key1', 'key2']
}))

function noAcces(req,res,next)
{
  if(!req.islogged)next()
  else res.redirect('/')
}

function auth(req,res,next)
{
  req.list = ['approved', 'declined','nz']
  
  if(req.session.name == undefined && req.session.password == undefined){
    console.log(req.session.name,req.session.password)
  req.islogged = false
  
  }
  else
  {
  req.islogged = true
  req.isadmin = req.session.name === 'admin' ? true : false;
  console.log(req.isadmin,req.session.name,req.session.password)
  }
  
  next()
}

// view engine setup
 
app.engine('.hbs', exphbs({
    extname:'.hbs',
    helpers:{
      auth:'hi there'
    }
  }
));
app.set('view engine', '.hbs');


app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));



app.use('/',auth,indexRouter);
app.use('/users',auth, usersRouter);
app.use('/uverenie',auth, uverenieRouter);
app.use('/complaint',auth, complaintRouter);
app.use('/viktor',auth, viktorRouter);
app.use('/denis',auth, denisRouter);
app.use('/create',auth,createRouter);
app.use('/',auth, logoutRouter);
app.use('/',auth,noAcces,loginRouter);





// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

module.exports = app;
