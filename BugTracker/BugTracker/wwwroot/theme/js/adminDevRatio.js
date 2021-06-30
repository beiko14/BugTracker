$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: 'Home/GetAdminDevCount',
        data: JSON.stringify({}),
        contentType: "application/json:charset=utf-8",
        dataType: "json",
        success: function (json) {
            debugger
            var values = json.devCount;
            var admin = parseInt(values[0]);
            var developer = parseInt(values[1]);





            // Set new default font family and font color to mimic Bootstrap's default styling
            Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
            Chart.defaults.global.defaultFontColor = '#858796';

            // Pie Chart Example
            var ctx = document.getElementById("adminDevRatio");
            var ticketByType = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ["Admin", "Developer"],
                    datasets: [{
                        data: [admin, developer],
                        backgroundColor: ['#616161', '#FF4500'],
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












