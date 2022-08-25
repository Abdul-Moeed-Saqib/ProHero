$(function () {
    $.ajax({
        type: "POST",
        url: "/Charity/GetHungerStatus",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: displayHungerChart,
        error: OnError
    });

    function displayHungerChart(data) {
        const _data = data;
        const chartLabels = _data[0];
        const countryStatus = _data[1];

        const barColor = ["red", "orange", "green", "yellow", "blue"]

        new Chart("myChart", {
            type: "line",
            data: {
                labels: chartLabels,
                datasets: [{
                    label: 'Hunger',
                    backgroundColor: barColor,
                    data: countryStatus
                }]
            }
        })
    }

    function OnError(err) {

    }
})