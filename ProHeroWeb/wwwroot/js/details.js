function charitydetail(element) {
    var charityId = $(element).data("id");

    $.ajax({
        type: "POST",
        url: "/Charity/Details",
        data: { "charityId": charityId },
        success: function (response) {
            $("#charityDescription").find(".modal-body").html(response);
            $("#charityDescription").modal('show');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}