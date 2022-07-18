const country = document.getElementById("country");
const afg = document.getElementById("AF");


afg.addEventListener("mouseenter", countryName);

function countryName() {
    country.innerHTML = "Afghanistan";
}
