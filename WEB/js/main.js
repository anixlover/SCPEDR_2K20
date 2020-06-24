(function () {
    "use strict";
    document.addEventListener('DOMContentLoaded', function(){

        var map = L.map('mapa').setView([-12.157711, -76.96212], 17);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

L.marker([-12.157711, -76.96212]).addTo(map)
    .bindPopup('DECORMOLDURAS & ROSETONES S.A.C. <br>Venta de modluras')
    .openPopup();





    console.log("listo")


    }); //DOM CONTENT LOAD
})();