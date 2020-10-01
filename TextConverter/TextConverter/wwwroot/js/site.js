// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    // This function converts text into xml or csv using Web API
    // in /api/textconvert.
    function convertText(resultType) {
        var textToConvert = $("#TextToConvert").val();

        var text = {
            'Id': 1,
            'TextToConvert': textToConvert,
            'Sentences': null,
            'ResultType': resultType
        };

        // Send ajax request with text object and get converted result.
        var requestPost = $.ajax(
        {
            url: "/api/textconvert",
            method: "POST",
            data: JSON.stringify(text),
            contentType: "application/json",
            dataType: "text"
        });

        // Callback handler that will be called on success
        requestPost.done(function (response, textStatus, jqXHR) {

            if (resultType === "xml") {
                $("#xml-result").val(response);
            } else {
                $("#csv-result").val(response);
            }


        });

        // Callback handler that will be called on failure
        requestPost.fail(function (jqXHR, textStatus, errorThrown) {

            // Log the error to the console
            console.error(
                "The following error occurred: " +
                textStatus,
                errorThrown
            );

        });
    }

    // Downloads result file with extension specified in resultType.
    function downloadFile(resultType) {
        if (resultType !== "xml") {
            resultType = "csv";
        }

        var downloadPath = "/wwwroot/result." + resultType;

        var link = document.createElement("a");
        link.download = "result." + resultType;
        link.href = downloadPath;
        link.click();
    }

    var convertedToXml = false;
    var convertedToCsv = false;

    $("#xml-downloader .xml-download").click(function () {
        if (convertedToXml) {
            downloadFile("xml");
        }
    });

    $("#csv-downloader .csv-download").click(function () {
        if (convertedToCsv) {
            downloadFile("csv");
        }
    });

    $("#converter .convert-xml").click(function () {
        convertText("xml");
        convertedToXml = true;
    });
    $("#converter .convert-csv").click(function () {
        convertText("csv");
        convertedToCsv = true;
    });
});