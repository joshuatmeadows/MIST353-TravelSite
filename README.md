### README for MIST 353: Travel Site Example

---

#### Overview
Welcome to the MIST 353 course! In this module, we are focusing on creating a travel site that integrates basic geocoding and reverse geocoding using Nominatim, and mapping functionalities with Leaflet. Our main goal is to teach JavaScript and how to interact with APIs.

---

#### Features
- **Geolocation**: Using the browser's geolocation feature to obtain the user's current position.
- **Geocoding and Reverse Geocoding**: Implementing Nominatim API for converting addresses to coordinates and vice versa.
- **Mapping**: Utilizing Leaflet to display maps based on coordinates.

---

#### How to Use
1. **Location Retrieval**: The site retrieves the user's current location and displays coordinates.
2. **Address and Coordinate Conversion**: Users can enter an address to get coordinates or use their current coordinates to find the corresponding address.
3. **Map Display**: Based on the retrieved or entered coordinates, a map is displayed using Leaflet.

---

#### Development Notes
- `site.js`: Contains the core JavaScript functions for geolocation, geocoding, reverse geocoding, and map display.
- `Index.cshtml` & `searchResults.cshtml`: These pages handle the front-end display and user interactions.

---

#### Important Reminders for Students
- **Dynamic Learning**: The README will evolve with the latest learnings and updates in the course. Always refer to the most recent version.
- **Commit History**: For a comprehensive understanding, navigate through previous commits. Each commit provides insights into the development process and incremental changes.
- **Feedback and Questions**: Encouraged at all stages. Your input helps improve the course and this project.

---

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

> I am the instructor for a Web App Development course. In my course, we are building a travel site as an example. Write me a README given the attached pages. This implements basic geocoding and reverses geocoding via Nominatim and basic mapping using Leaflet. The main objectives are to teach JavaScript and interact with APIs. Emphasise to students the README will change based on the latest learnings so they should navigate through previous commits for full notes.

*Note: This README is a living document and will be updated regularly to reflect the latest advancements and learnings in the course.*