function countryName(event) {
    const country = $(event.target).attr("name");

    if (country.length != 0) {
        document.getElementById('country-name').textContent = country;
    }
    else {
        document.getElementById('country-name').textContent = "World Map";
    }
}

function countryNameRemove() {
    document.getElementById('country-name').textContent = "World Map";
} 

function countryStatus() {
    const countries = document.getElementsByTagName("path");

    for (var i = 0; i < countryInfo.length; i++) {
        const level = countryInfo[i].Level;
        const country = countryInfo[i].CountryName;
        let color = "";

        switch (level) {
            case "Red":
                color = "red";
                countryLevels(countries, country, color);
                break;
            case "Orange":
                color = "orange";
                countryLevels(countries, country, color);
                break;
            case "Yellow":
                color = "yellow"
                countryLevels(countries, country, color);
                break;
        }
    }
}

function countryLevels(countries, country, color) {
    $(countries[country]).css({ "fill": color, "stroke": "black" });
    $(countries[country]).hover(function () {
        $(this).css("fill", "black");
    }, function () {
        $(this).css({ "fill": color, "transition": "0.6s", "cursor": "pointer" });
    });
}