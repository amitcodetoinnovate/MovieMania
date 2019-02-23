var imagePath = "";
var actProFlag;
var collapseFlag = true;


$(document).ready(function () {
    GetActors();
    GetProducers();
    GetMovies();
});
$("#btnSubmit").on('click', function () {
    var isUpdate = $(this).text() == 'Update Movie' ? true : false;
    var currentYear = new Date().getFullYear();
    var upLoadedImageSrc = $('#inputPoster').attr('src');
    var upLoadedImageFile = $('#file').prop("files")[0];
    var movieName = $('#inputMovie').val();
    var movieId = $('#inputMovie').attr('movieId');
    var yearRelease = $('#inputYearRelease').val();
    var textPlot = $('#textPlot').val();
    var actors = $('#selectActors option:selected');
    var selected = [];
    var producerId = $('#selectProducer').find("option:selected").val();
    $(actors).each(function (index, actors) {
        selected.push($(this).val());
    });
    if (upLoadedImageSrc.trim(' ') == '') {
        alert('Please upload a poster.');
        return;
    } else if (movieName.trim(' ') == '') {
        alert('Please enter the movie name.');
        return;
    }
    else if ((yearRelease == '') || (yearRelease <= 1900) || (yearRelease >= currentYear)) {
        alert('Please enter the movie release date between the range 1900 to ' + currentYear + '.');
        return;
    } else if (producerId === undefined) {
        alert('Please select the producer.');
        return;
    } else if (selected.length == 0) {
        alert('Please select the actors.');
        return;
    } else if (textPlot.trim(' ') == '') {
        alert('Please enter the movie plot.');
        return;
    }
    var formData = new window.FormData();
    formData.append("file", upLoadedImageFile);
    formData.append("type", 4);
    formData.append("movieName", movieName);
    formData.append("movieId", movieId);
    formData.append("upLoadedImageSrc", upLoadedImageSrc);
    formData.append("yearRelease", yearRelease);
    formData.append("textPlot", textPlot);
    formData.append("actorList", selected);
    formData.append("producerId", producerId);
    formData.append("isUpdate", isUpdate);
    $.ajax({
        url: "/MovieHandler.ashx",
        method: "POST",
        data: formData,
        processData: false,
        contentType: false,
        async: false,
        dataType: "JSON",
        success: function (successResponseData) {
            if (successResponseData.Success == 'True') {
                GetMovies();
                alert(successResponseData.Message);
                $('[data-toggle="collapse"]').click();

            } else {
                alert(successResponseData.Message);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

            console.log(errorThrown);

        }
    });

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
                alert(res.Message);
                $('.close').click();
                GetActors();
                GetProducers();
                $('#selectActors').multiselect('rebuild');



            } else {
                alert(res.Message);
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

function GetMovies() {

    $.ajax({
        url: "/MovieHandler.ashx",
        type: "GET",
        async: false,
        dataType: "JSON",
        data: {
            type: 5
        },
        success: function (res) {
            $("#tableMovie tbody").html();
            var rows = "";
            if (res.Success == "True") {
                if (res.Movies.length > 0) {
                    for (var i = 0; i < res.Movies.length; i++) {
                        rows += '<tr><td class="w-25"> <img src = "' + res.Movies[i].Poster + '" alt = "" class="img-thumbnail" /></td >';
                        rows += '<td>' + res.Movies[i].MovieName + '<button type="button"' + ' movieData="' + res.Movies[i].MovieName + '" producerData="' + res.Movies[i].ProducerId + '" actorData="' + res.Movies[i].ActorIds + '" dataId="' + res.Movies[i].Id + '" class="btn btn-info movieEdit">Edit Movie</button>' + '</td>';
                        rows += '<td>' + res.Movies[i].YearOfRelease + '</td>';
                        rows += '<td>' + res.Movies[i].Actors + '</td>';
                        rows += '<td>' + res.Movies[i].Plot + '</td>';
                        rows += '<td>' + res.Movies[i].ProducerName + '</td></tr> ';
                    }
                    $("#tableMovie tbody").html(rows);

                }
            } else {
                alert('No Movies found.');
            }
            console.log(res);

        },
        error: function (jqXHR, textStatus, errorThrown) {
          
                console.log(errorThrown);
            
        }
    });
}


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

            console.log(errorThrown);

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

            console.log(errorThrown);

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
        $('#inputPoster').attr('src', '');
        fileInput.value = '';
        return false;
    } else {
        //Image preview
        if (fileInput.files && fileInput.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById('imagePreview').innerHTML = '<img width="200px" id="inputPoster" height="40px"  alt="..." class="img-thumbnail" src="' + e.target.result + '"/>';
            };
            reader.readAsDataURL(fileInput.files[0]);
        }
    }
}
function clearInput() {
    $('#inputActorProducer').val("");
    $('#datepicker').val("");
    $('#textBio').val(""); 

}
$(document).on('input', '#inputYearRelease', function () {
    this.value = this.value.replace(/[^\d]/g, '');
});
$(document).on('click', '.movieEdit', function () {
    flag = false;
    $('[data-toggle="collapse"]').click();
    $("#btnSubmit").html('Update Movie');
    //$('.collapse').collapse();         
    var movieId = $(this).attr('dataid');
    var movieName = $(this).attr('moviedata');
    var actorArray = $(this).attr('actorData').split(',').map(function (i) { return parseInt(i, 10); });
    var producerId = $(this).attr('producerData');
    var releaseYear = $(this).parent().next().text();
    var plot = $(this).parent().next().next().next().text();
    var imgSrc = $(this).parent().closest('tr').find('td img').attr('src');
    $('#inputPoster').attr('src', imgSrc);
    var upLoadedImageFile = $('#file').prop("files")[0];
    $('#inputMovie').val(movieName);
    $('#inputMovie').attr('movieId', movieId);
    $('#inputYearRelease').val(releaseYear);
    $('#textPlot').val(plot);
    var actors = $('#selectActors option:selected');
    $('#selectActors').multiselect('select', actorArray);
    $('#selectProducer').val(producerId);
    $(window).scrollTop(0);
});

$('[data-toggle="collapse"]').on("click", function (e) {
    if (collapseFlag) {
        $("#inputPoster, #inputMovie, #inputYearRelease, #textPlot, #selectActors, #selectProducer,#file").val("");
        $('#selectActors').multiselect('select', []);
        $('#inputPoster').attr('src', '');
        $("#btnSubmit").html('Submit New Movie');
    }
    collapseFlag = true;

});