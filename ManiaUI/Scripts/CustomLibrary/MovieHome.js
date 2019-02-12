﻿var imagePath = "";


function GetActors() {
    var broadCastId = $(this).attr("broadCastId");
    if ($(this).text() == 'No Call') {
        //alert('Oops! it seems,like there no call');
        return;
    }
    $.ajax({
        url: "/MovieHandler.ashx",
        type: "GET",
        async: false,
        dataType: "JSON",
        data: {
            type: 1
        },
        success: function (res) {
            $("#tblFeedBack").html();
            var feedBackData = "";
            feedBackData += "<thead><th>Question</th><th>FeedBack</th></thead><tbody>";
            if (res.Success == "True") {
                if (res.BroadCastTable.length > 0) {
                    for (var i = 0; i < res.BroadCastTable.length; i++) {
                        feedBackData += "<option actorId =";
                        feedBackData +=  res.Actors[i].Id + "</td>";
                        feedBackData += "<td>" + res.BroadCastTable[i].DigitsPressed + "</td>";
                        feedBackData += "</tr>"; 
                    }
                }
            } else {
                feedBackData += "<tr><td colspan='4'>No Reports</td></tr>";
            }
            feedBackData += "</tbody>";
            $("#tblFeedBack").html(feedBackData);
            $("#modalFeedBack").modal("show");

        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status == 401) {
                window.location.href = "/Login.aspx?message=Session expired";
            } else if (jqXHR.status == 406) {
                $("#modalPreviousSession").modal("show");
            } else {
                console.log(errorThrown);
            }
        }
    });
}


$(function () {
    $('#selectActors').multiselect({
        includeSelectAllOption: true
    });
});
function fileValidation() {
    var fileInput = document.getElementById('file');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert('Please upload file having extensions .jpeg/.jpg/.png/.gif only.');
        fileInput.value = '';
        return false;
    } else {
        //Image preview
        if (fileInput.files && fileInput.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById('imagePreview').innerHTML = '<img width="200px" height="40px"  alt="..." class="img-thumbnail" src="' + e.target.result + '"/>';
            };
            reader.readAsDataURL(fileInput.files[0]);
        }
    }
}