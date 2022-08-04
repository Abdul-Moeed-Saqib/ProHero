function countryName(event) {
    const country = $(event.target).attr("name");
    document.getElementById('country-name').textContent = country;
}