$(function () {

    const loadingBody = $("#loading-body");
    const charityPartial = $("#charityPartial");

    $(charityPartial).load("/Charity/CharityPartial", "",
        function (responseText, textStatus, XMLHttpRequest) {
            loadingDisplay(false, loadingBody);
        });

    function loadingDisplay(value, id) {
        if (value == true) {
            $(id).show();
        }
        else {
            $(id).hide();
        }
    }
});