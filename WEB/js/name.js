

function name(e) {
    var nametxt = document.getElementById("lblselected");
    var namevalue = e.options[e.selectedIndex].value;
    if (namevalue > 0) {
    var selectedtex = e.options[e.selectedIndex].Text;
    lblselected.innerHTML = "Seleccionaste : " + selectedtex;
}
}
                                       