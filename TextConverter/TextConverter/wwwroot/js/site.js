// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $("#converter .convert-xml").click(function () {
        convertText("xml");
    });

    $("#converter .convert-csv").click(function () {
        convertText("csv");
    });

    $("#xml-downloader .xml-download").click(function () {
        downloadFile("xml");
    });

    $("#csv-downloader .csv-download").click(function () {
        downloadFile("csv");
    });

    // This function converts text into xml or csv using Web API
    // in /api/textconvert.
    function convertText(resultType) {
        var textToConvert = $("#TextToConvert").val();

        var textObject = {
            'TextToConvert': textToConvert,
            'ResultType': resultType
        };

        // Send ajax request with text object and get converted result.
        var requestGet = $.ajax(
        {
            url: "/api/textconvert",
            method: "GET",
            data: textObject,
            contentType: "application/json",
            dataType: "text"
        });

        // Callback handler that will be called on success
        requestGet.done(function (response, textStatus, jqXHR) {
            if (resultType === "xml") {
                $("#xml-result").val(response);
            } else {
                $("#csv-result").val(response);
            }
        });

        // Callback handler that will be called on failure
        requestGet.fail(function (jqXHR, textStatus, errorThrown) {
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
        var text = '';
        if (resultType === "xml") {
            text = $("#xml-result").val();
        }
        else {
            text = $("#csv-result").val();
        }

        if (!text) {
            return;
        }

        var link = document.createElement("a");
        link.href = 'data:text/' + resultType + ';charset=utf-8,' + encodeURIComponent(text);
        link.download = "convertedText." + resultType;

        link.style.display = 'none';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
});