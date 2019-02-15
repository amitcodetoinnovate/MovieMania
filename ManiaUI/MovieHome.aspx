﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieHome.aspx.cs" Inherits="ManiaUI.MovieHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Mania</title>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <link href="StyleSheet/CustomSheet/MovieHome.css" rel="stylesheet" />
    <link rel="shortcut icon" href="favicon.ico">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.7.1/css/bootstrap-datepicker.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-dropdown/2.0.3/jquery.dropdown.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css">
</head>
<body style="height: 100px; background-color: #BBBFB7">
    <h1>Movie Mania</h1>
    <p>
        <a class="btn btn-primary" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">Add New Movie
        </a>
        <button type="button" id="btnActor" class="btn btn-warning float-sm-right" data-toggle="modal" data-target="#exampleModalCenter">Add New Actor</button>
        <button type="button" id="btnProducer" class="btn btn-primary float-right" data-toggle="modal" data-target="#exampleModalCenter">Add New Producer</button>
    </p>
    <div class="collapse w-25 p-3 bg-warning" id="collapseExample">
        <form>

            <div class="form-group">
                <input type="file" class="form-control" id="file" onchange="return fileValidation()" />
            </div>
            <div id="imagePreview" class="form-group">
                <img width="200px" height="40px" src="https://s3.amazonaws.com/freecodecamp/relaxing-cat.jpg" alt="..." class="img-thumbnail">
            </div>
            <div class="form-group">
                <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="Movie Name">
            </div>
            <div class="form-group">
                <input type="text" class="form-control" id="exampleFormControlInpu1" placeholder="Year Of Release">
            </div>
            <div class="form-group">
                <label for="exampleFormControlSelect1">Producer</label>
                <select class="form-control" id="exampleFormControlSelect1">
                    <option>1900</option>
                    <option>1900</option>

                </select>
            </div>
            <div class="form-group">
                <label for="exampleFormControlSelect2">Select Actors</label>
                <div class="demo">
                    <select id="selectActors" multiple="multiple">
                        <option value="1">Mango</option>
                        <option value="2">Apple</option>
                        <option value="3">Banana</option>
                        <option value="4">Guava</option>
                        <option value="5">Orange</option>
                    </select>
                    <%--<input type="button" id="btnSelected" value="Get Selected" />--%>
                    <button type="button" id="btnSelected" class="btn btn-outline-primary">Primary</button>

                </div>
            </div>
            <div class="form-group">
                <label for="exampleFormControlTextarea1">Plot Of the Movie</label>
                <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
            </div>
        </form>

    </div>

    <table class="table table-striped table-dark">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Poster</th>
                <th scope="col">Movie Name</th>
                <th scope="col">Release Year</th>
                <th scope="col">Actors In The Movie</th>
                <th scope="col">Plot</th>
                <th scope="col">Movie Producer</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">1</th>
                <td class="w-25">
                    <img src="https://images8.alphacoders.com/560/560736.jpg" alt="..." class="img-thumbnail"></td>
                <td>Interstellar</td>
                <td>2014</td>
                <td>Mathew Macconhey</td>
                <td>Space travel movie</td>
                <td>Nolan Brothers</td>
            </tr>
            <tr>
                <th scope="row">2</th>
                <td>
                    <img src="https://s3.amazonaws.com/freecodecamp/relaxing-cat.jpg" alt="..." class="img-thumbnail"></td>
                <td>Interstellar</td>
                <td>2014</td>
                <td>Mathew Macconhey</td>
                <td>Space travel movie</td>
                <td>Nolan Brothers</td>
            </tr>
            <tr>
                <th scope="row">3</th>
                <td>
                    <img src="https://s3.amazonaws.com/freecodecamp/relaxing-cat.jpg" alt="..." class="img-thumbnail"></td>
                <td>Interstellar</td>
                <td>2014</td>
                <td>Mathew Macconhey</td>
                <td>Space travel movie</td>
                <td>Nolan Brothers</td>
            </tr>
        </tbody>
    </table>
    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Add Movie</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <input type="text" class="form-control" id="inputActorProducer" placeholder="Movie Name">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect1">Sex</label>
                        <select class="form-control" id="selectSex">
                            <option value="0">Male</option>
                            <option value="1">Female</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <input data-date-format="dd/mm/yyyy" id="datepicker">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlTextarea1">Biography</label>
                        <textarea class="form-control" id="textBio" rows="3"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button id="btnActor-Producer" type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.7.1/js/bootstrap-datepicker.min.js"></script>
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
    <script src="Scripts/CustomLibrary/MovieHome.js"></script>
</body>

</html>
