var map;

function initialize(latitude, longitude)
{
    var latlng = new google.maps.LatLng(latitude, longitude);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map"), options);
}

function initMap(){

}