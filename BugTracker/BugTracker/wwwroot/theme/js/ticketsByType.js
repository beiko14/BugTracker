$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: 'Home/GetTicketTypeCount',
        data: JSON.stringify({}),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        success: function (json) {
            debugger
            var values = json.ticketTypeCount;
            var incident = parseInt(values[0]);
            var enhancement = parseInt(values[1]);
            var change = parseInt(values[2]);





            // Set new default font family and font color to mimic Bootstrap's default styling
            Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
            Chart.defaults.global.defaultFontColor = '#858796';

            // Pie Chart Example
            var ctx = document.getElementById("ticketByType");
            var ticketByType = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ["Bug", "Verbesserung", "Aenderungsanforderung"],
                    datasets: [{
                        data: [incident, enhancement, change,],
                        backgroundColor: ['#4e73df', '#ff2626', '#29bd00'],
                        hoverBorderColor: "rgba(150, 150, 150, 1)",
                        hoverOffset: 20,
                        hoverBorderWidth: 3,
                    }],
                },
                options: {
                    maintainAspectRatio: false,
                    tooltips: {
                        backgroundColor: "rgb(255,255,255)",
                        bodyFontColor: "#858796",
                        borderColor: '#dddfeb',
                        borderWidth: 1,
                        xPadding: 15,
                        yPadding: 15,
                        displayColors: false,
                        caretPadding: 10,
                    },
                    legend: {
                        display: false
                    },
                    cutoutPercentage: 50,
                },
            });






        }
    })
});












