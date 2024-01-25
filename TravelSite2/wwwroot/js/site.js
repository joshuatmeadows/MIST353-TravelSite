// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets

// Main JavaScript code starts here.

// Function to get the current geographical location of the user.
function getLocation(mylat, mylong) {
    // Check if geolocation is supported in the browser.
    if (navigator.geolocation) {
        // Get the current position and pass it to the showPosition function.
        navigator.geolocation.getCurrentPosition(function (position) {
            showPosition(position, mylat, mylong);
        });
    } else {
        // Alert the user if geolocation is not supported.
        alert("Geolocation is not supported by this browser.");
    }
}

// Function to process the position obtained from geolocation.
function showPosition(position, mylat, mylong) {
    // Set the latitude and longitude values in the respective input fields.
    mylat.value = position.coords.latitude;
    mylong.value = position.coords.longitude;
    // Get the address corresponding to the latitude and longitude.
    getAddress(position.coords.latitude, position.coords.longitude);
}

// Async function to get coordinates for a given address using the Nominatim API.
async function getCoordinates(address) {
    // Fetching data from the Nominatim API.
    const response = await fetch(`https://nominatim.openstreetmap.org/search?format=json&q=${address}`);
    const data = await response.json();
    // Check if any data was returned.
    if (data.length > 0) {
        // Extract coordinates from the first result and display them.
        const coords = { lat: data[0].lat, lon: data[0].lon };
        displayCoordinates(coords);
    } else {
        // Display a message if no results were found.
        displayCoordinates("No results found.");
    }
}

// Async function to get an address for given latitude and longitude using the Nominatim reverse API.
async function getAddress(lat, lon) {
    // Fetching data from the Nominatim reverse geocoding API.
    const response = await fetch(`https://nominatim.openstreetmap.org/reverse?format=json&lat=${lat}&lon=${lon}`);
    const data = await response.json();
    // Check if an address was returned.
    if (data.address) {
        // Display the found address.
        const address = data.address;
        displayAddress(address);
    } else {
        // Display a message if no address was found.
        displayAddress("No results found.");
    }
}

// Function to display the address on the web page.
function displayAddress(address) {
    // Check for different address components and display the most specific one.
    if (address['city']) {
        document.getElementById('locInp').value = address['city'] + ', ' + address['state'];
    }
    else if (address['town']) {
        document.getElementById('locInp').value = address['town'] + ', ' + address['state'];
    }
    else if (address['village']) {
        document.getElementById('locInp').value = address['village'] + ', ' + address['state'];
    }
}

// Function to display the coordinates on the web page.
function displayCoordinates(coords) {
    // Display the coordinates and update the respective input fields.
    document.getElementById('results').innerHTML = `You searched for` + JSON.stringify(coords);
    document.getElementById('latTxt').value = coords.lat;
    document.getElementById('longTxt').value = coords.lon;
}

// Function to process and display results based on URL parameters.
function showResults() {
    // Extract parameters from the URL.
    const urlParams = new URLSearchParams(window.location.search);
    const location = urlParams.get('location');
    const latitude = urlParams.get('latitude');
    const longitude = urlParams.get('longitude');
    const results = document.getElementById('results');

    // Display a map or fetch coordinates depending on the available parameters.
    if (latitude && longitude) {
        results.innerHTML = `You searched for ${latitude}, ${longitude}.`;
        // Initialize a map centered at the provided coordinates.
        var map = L.map('map').setView([latitude, longitude], 13);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 18
        }).addTo(map);
    } else if (location) {
        // If only location is provided, get its coordinates.
        getCoordinates(location);
    } else {
        // Display a message if no parameters are provided.
        results.innerHTML = 'You did not search for anything.';
    }
}

// Function to add an event listener to the location form.
function addLocationFormListener() {
    // Add a submit event listener to the form.
    document.getElementById('locationForm').addEventListener('submit', function (e) {
        // Prevent the default form submission.
        e.preventDefault();
        // Get user input values.
        var userInput = document.getElementById('locInp').value;
        var latitude = document.getElementById('latTxt').value;
        var longitude = document.getElementById('longTxt').value;

        // Check if latitude and longitude are provided, then submit the form.
        if (latitude && longitude) {
            this.submit();
        }
        else { // If not, get coordinates based on the user's address input.
            getCoordinates(userInput);
        }
    });
}
