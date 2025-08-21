let Number1;
let Number2;
let Result;

function Add()
{
    Number1 = parseFloat(document.getElementById("Input1"));
    Number2 = parseFloat(document.getElementById("Input2"));

    Result = Number1 + Number2;
    ShowResult();
}

function Subtract()
{

}

function Multiply()
{

}

function Divide()
{

}

function ShowResult()
{
    document.getElementById("ShowResult").innerHTML = "Resultatet er " + Result;
}