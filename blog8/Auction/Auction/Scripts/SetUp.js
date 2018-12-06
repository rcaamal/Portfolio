/* Javascript */

// In the javascript
console.log("In js");

// get the ID of the item
var id = window.location.href.split("/").slice(-1)[0];

$(document).ready(function () {
    // set the source
    var source = "/Items/ShowBids/" + id;

    // ajax call fx
    var ajax_call = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: source,
            success: displayData,
            error: errorOnAjax
        });
    };

    // Ajax will load every 5 seconds
    var interval = 5000;
    window.setInterval(ajax_call, interval);

    /* show the data */
    function displayData(data) {
        console.log("in displaydata");
        console.log("data: " + data);
        var update = "<table class = \"table\"><tbody>";

        $.each(data, function (num, item) {
            console.log("i: " + num);
            console.log("item: " + item);
            update += "<tr>" + "<td>" + item.Name +
                "</td>" + "<td> $" + item.Price + "</td>" + "</tr>";

        });

        // update the page
        $("#tableResp").html(update);
    }
});

/* Throw error if ajax is unsuccessful */
function errorOnAjax() {
    console.log("Ajax error");
}