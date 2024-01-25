



## References
[Number input and decimals (stackoverflow)](https://stackoverflow.com/questions/34057595/allow-2-decimal-places-in-input-type-number)
[Installing FontAwesome (stackoverflow)](https://stackoverflow.com/questions/57341705/how-to-install-font-awesome-in-asp-net-core-2-2-using-visual-studio-2019)
[Nominatim API (Nominatim)](https://nominatim.org/release-docs/latest/api/Overview/)
[Leaflet Quick Start Guide (Leaflet)](https://leafletjs.com/examples/quick-start/)

### ChatGPT Prompts
> with this JS how can I pass myElement to showPosition?
>
>```
>function getLocation(myElement) {
>    if (navigator.geolocation) {
>        navigator.geolocation.getCurrentPosition(showPosition);
>    } else {
>        myElement.innerHTML = "Geolocation is not supported by this browser.";
>    }
>}
>
>function showPosition(position, myElement) {
>    myElement.innerHTML = "Latitude: " + position.coords.latitude +
>        "<br>Longitude: " + position.coords.longitude;
>}
>```


> How do I add location search to a website (i.e. what you would see on a travel site)
Follow up:
> Using OpenStreetMap how would I create a textbox where users type in a city, address, etc and it is converted to geographical coordinates

> I have a form that directs to another page. From that new page, how can I use JS to get the form values that were submitted?