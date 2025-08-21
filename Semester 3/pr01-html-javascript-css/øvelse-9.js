function PersonAlert()
{
    let age = parseInt(document.getElementById("age").value);
    let name = document.getElementById("name").value;
    if (age > 70)
    {
        window.alert("Dav " + name + " du er " + age + " gammel!");
    }
    else
    {
        window.alert("Dav " + name + " du er " + age + " ung!");
    }
}