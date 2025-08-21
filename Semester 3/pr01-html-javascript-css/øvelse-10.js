function ChangeMessage()
{
    date = new Date().toLocaleDateString();
    document.getElementById("ChangeText").innerHTML = "Daniel er så sej! " + date;
}

function ChangeBackgroundColor()
{
    document.body.style.backgroundColor = "red";
}

function ChangeDivColor()
{
    document.getElementById("Div1").style.backgroundColor = "blue";
}