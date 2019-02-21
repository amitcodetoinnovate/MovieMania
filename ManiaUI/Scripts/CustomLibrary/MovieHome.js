var imagePath = "";
var actProFlag;


$(document).ready(function () {
    GetActors();
    GetProducers();
});

$('#btnActor-Producer').on('click', function () {
    var name = $('#inputActorProducer').val();
    var sex = $('#selectSex').val();
    var dateOfBirth = $('#datepicker').val();
    var bioGraphy = $('#textBio').val();
    if (name.trim() == "") {
        alert("Name cannot be empty.");
        return;
    } else if (dateOfBirth.trim() == "") {
        alert("Date of birth cannot be empty.");
        return;
    } else if (bioGraphy.trim() == "") {
        alert("Biography cannot be empty.");
        return;
    }

    $.ajax({
        url: "/MovieHandler.ashx",
        type: "POST",
        async: false,
        dataType: "JSON",
        data: {
            type: 3, name: name, sex: sex, dateOfBirth: dateOfBirth, bioGraphy: bioGraphy, actProFlag: actProFlag
        },
        success: function (res) {
            if (res.Success == "True") {
                alert(res.Success);
                $('.close').click();

            } else {
                alert(res.Success);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
});
$('#btnActor').on('click', function () {
    actProFlag = 0;
    $("#modalTitle").text('Add Actor');
    clearInput();
});
$('#btnProducer').on('click', function () {
    actProFlag = 1;
    $("#modalTitle").text('Add Producer');
    clearInput();
});

function GetActors() {

    $.ajax({
        url: "/MovieHandler.ashx",
        type: "GET",
        async: false,
        dataType: "JSON",
        data: {
            type: 1
        },
        success: function (res) {
            $("#selectActors").html();
            var optionElements = "";
            if (res.Success == "True") {
                if (res.Actors.length > 0) {
                    for (var i = 0; i < res.Actors.length; i++) {
                        optionElements += "<option value =" + res.Actors[i].Id + " >" + res.Actors[i].Name + "</option>";
                        
                    }
                }
                $("#selectActors").html(optionElements);
            } else {
                alert('No actor found.');
            }

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
function GetProducers() {

    $.ajax({
        url: "/MovieHandler.ashx",
        type: "GET",
        async: false,
        dataType: "JSON",
        data: {
            type: 2
        },
        success: function (res) {
            $("#selectProducer").html();
            var optionElements = "";
            if (res.Success == "True") {
                if (res.Producers.length > 0) {
                    for (var i = 0; i < res.Producers.length; i++) {
                        optionElements += "<option value =" + res.Producers[i].Id + " >" + res.Producers[i].Name + "</option>";

                    }
                }
                $("#selectProducer").html(optionElements);
            } else {
                alert('No Producer found.');
            }

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
$('#datepicker').datepicker({
    weekStart: 1,
    daysOfWeekHighlighted: "6,0",
    autoclose: true,
    format: 'mm/dd/yyyy',
    startDate: new Date(1900, 1, 1),
    endDate: new Date(),
    todayHighlight: true,
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
function clearInput() {
    $('#inputActorProducer').val("");
    //$('#selectSex').val("");
    $('#datepicker').val("");
    $('#textBio').val("");
}