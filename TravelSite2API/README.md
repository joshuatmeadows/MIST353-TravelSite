# API Documentation

## /api/Hotel/{hotelid}

### What it do
Retrieves details for a particular hotel.

### Inputs
- {hotelid}: The unique identifier for hotels in the system

### Outputs
Returns a list of hotels. Hotels have the following attributes:
- int HotelID: The unique identifier for hotels in the system...
- string Address
- string Zipcode 
- string City 
-  string State
-  string Country
- string Name The name of the hotel...

### Sample Code

Code to fetch hotel 1 details and display name in HTML element `hotelName`.

```js
const response = await fetch(`https://localhost:7095/api/Hotels/1`);
const data = await response.json();
document.getElementById('hotelName').innerHTML = data[0].name;
document.getElementById('hotelName').style.visibility = "visible";
```

## 