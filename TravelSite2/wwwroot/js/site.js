// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition)
    }
    else {
        alert("Not supported")
    }
}

function showPosition(position) {
    document.getElementById("latTxt").value = position.coords.latitude;
    document.getElementById("longTxt").value = position.coords.longitude;
    document.getElementById("results").innerHTML = position.coords.latitude + ', ' + position.coords.longitude;
    getAddress(position.coords.latitude, position.coords.longitude)
}

async function getAddress(lat, long) {
    const response = await fetch(`https://nominatim.openstreetmap.org/reverse?lat=${lat}&lon=${long}&format=json`);
    const data = await response.json();
    if (data.address) {
        displayAddress(data.address);
    }
}

function displayAddress(address) {
    if (address["city"]) {
        document.getElementById("locInp").value = address["city"] + ', ' + address["state"];

    }
    else if (address["town"]) {
        document.getElementById("locInp").value = address["town"] + ', ' + address["state"];

    }
    else if (address["village"]) {
        document.getElementById("locInp").value = address["village"] + ', ' + address["state"];

    }
      //document.getElementById("results").innerHTML = JSON.stringify(address);

}
function addLocationFormListen() {
    document.getElementById('locationForm').addEventListener('submit', function (e) {
        e.preventDefault();

        var userInput = document.getElementById('locInp').value;
        var latitude = document.getElementById('latTxt').value;
        var longitude = document.getElementById('longTxt').value;

        if (latitude && longitude) {
            this.submit();
        }
        else {
            getCoordinates(userInput);
        }
    })
}

async function getCoordinates(address) {
    const response = await fetch(`https://nominatim.openstreetmap.org/search?format=json&q=${address}`);
    const data = await response.json();

    if (data.length > 0) {
        const coords = { lat: data[0].lat, lon: data[0].lon };
        displayCoordinates(coords);
    } else {
        displayCoordinates("no results found.");
    }
}

function displayCoordinates(coords) {
    document.getElementById('results').innerHTML = `You searched for` + JSON.stringify(coords);
    document.getElementById('latTxt').value = coords.lat;
    document.getElementById('longTxt').value = coords.lon;
}

