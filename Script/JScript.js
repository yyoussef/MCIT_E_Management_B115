

var i=+200;
var intHide;
var speed=6;
function showmenu()
{

clearInterval(intHide);
intShow=setInterval("show()",10);
}
function hidemenu()
{
clearInterval(intShow);
intHide=setInterval("hide()",10); 
}
function show()
{
if (i>12)
    {
    i=i-speed;
    document.getElementById('myMenu').style.left=i;
    }
}
function hide()
{
if (i< 200)
    {
    i=i+speed;
    document.getElementById('myMenu').style.left=i;
    }
}