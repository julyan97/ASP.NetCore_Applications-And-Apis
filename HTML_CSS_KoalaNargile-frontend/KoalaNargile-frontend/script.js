var totalPrice=0;

function change(price,idname,pout,url)
{
   
    document.getElementById(idname).style.backgroundImage=url;
    document.getElementById(pout).innerText=
    document.getElementById(price).innerText+" lv";
}
    function narg1(){
    change("pstyle1","narga","pout1","url('narg1.jpg')");}
    function narg2(){
    change("pstyle2","narga","pout1","url('narg2.jpeg')");}
    function narg3(){
    change("pstyle3","narga","pout1","url('narg3.jpg')");}
    function narg4(){
    change("pstyle4","narga","pout1","url('narg4.jpg')");}
    
    function hose1(){
    change("inerhose1","taste","pout2","url('hose1.jpg')");}
    function hose2(){
    change("inerhose2","taste","pout2","url('hose2.jpg')");}
    function hose3(){
    change("inerhose3","taste","pout2","url('hose3.jpg')");}
    function hose4(){
    change("inerhose4","taste","pout2","url('hose4.jpg')");}
    

    function taste1(){
    change("inertaste2","hose","pout3","url('logo.png')")}
    function taste2(){
    change("inertaste2","hose","pout3","url('al.png')")}
    function taste3(){
    change("inertaste3","hose","pout3","url('maz.png')")}
    function taste4(){
    change("inertaste4","hose","pout3","url('hasze.png')")}
function totalPrice1()
{
    var num;
    num= parseInt(document.getElementById("pout1").innerText.split(" ")[0])+
    parseInt(document.getElementById("pout2").innerText.split(" ")[0])+
    parseInt(document.getElementById("pout3").innerText.split(" ")[0]);

    if(num.toString()=="NaN") document.getElementById("total").innerText="Not fully ordered";
else     document.getElementById("total").innerText="Order complete you've paid: "+num.toString()+" lv";
    
}