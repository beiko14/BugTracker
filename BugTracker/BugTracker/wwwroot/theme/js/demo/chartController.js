// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

function GetJSON_Simple() {
    var resp = [];
    $.ajax({
        type: "GET",
        url: '/Jobs/Index',
        async: false,
        contentType: "application/json",
        success: function (data) {
            resp.push(data);
        },
        error: function (req, status, error) {
            // do something with error
            alert("error");
        }
    });
    return resp;
}
var simpleData = GetJSON_Simple();
var ctx = document.getElementById("canvas")
var lineChartData = {
    labels: simpleData[0].myDate,
    datasets: [{
        label: 'Sucess',
        borderColor: "MediumSeaGreen",
        backgroundColor: "MediumSeaGreen",
        fill: false,
        data: simpleData[0].mySuccess,
        yAxisID: 'y-axis-1',
    }, {
        label: 'Exceptioned',
        borderColor: "Tomato",
        backgroundColor: "Tomato",
        fill: false,
        data: simpleData[0].myException,
        yAxisID: 'y-axis-2'
    }]
};

window.myLine = Chart.Line(ctx, {
    data: lineChartData,
    options: {
        responsive: true,
        hoverMode: 'index',
        stacked: false,
        title: {
            display: true,
            text: 'Processes'
        },
        scales: {
            yAxes: [{
                type: 'linear',
                display: true,
                position: 'left',
                id: 'y-axis-1',
            }, {
                type: 'linear',
                display: true,
                position: 'right',
                id: 'y-axis-2',

                // grid line settings
                gridLines: {
                    drawOnChartArea: false, // only want the grid lines for one axis to show up
                },
            }],
        }
    }
});

