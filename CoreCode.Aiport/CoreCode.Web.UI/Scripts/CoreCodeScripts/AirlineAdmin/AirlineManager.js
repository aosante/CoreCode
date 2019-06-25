$(document).ready(function () {
    function limpiar() {
        $ID = $('#inputID');
        $firstName = $('#inputFirstName');
        $secondName = $('#inputSecondName');
        $firstLastName = $('#inputFirstLastName');
        $secondLastName = $('#inputSecondLastName');
        $birthDate = $('#inputBirthdate');
        $genre = $('#inputGenre');
        $email = $('#inputEmail');
        $password = $('#inputPassword');
        $phone = $('#inputPhone');
        $civilStatus = $('#inputCivilStatus');
        $airport = $('#inputAirport');
        //fill form
        $ID.val("");
        $firstName.val("");
        $secondName.val("");
        $firstLastName.val("");
        $secondLastName.val("");
        $birthDate.val("");
        $genre.val("");
        $email.val("");
        $password.val("");
        $phone.val("");
        $civilStatus.val("");
        $airport.val("");
    }
    $('#btnLimpiar').click(function () {
        limpiar();
    })
    let existingAirlines;

    const select = document.querySelector('#inputAirline');
    let defaultOption = new Option("Seleccione aerolinea");
    defaultOption.value = "";
    select.options.add(defaultOption);

    $.get("http://dev.corecodeapi.com/api/getAirlines/", function (data) {
        existingAirlines = data.Data;
        console.log(existingAirlines);
        for (let i = 0; i < existingAirlines.length; i++) {
            let newOption = new Option(existingAirlines[i].Comercial_name, existingAirlines[i].Id);
            select.options.add(newOption);
        }
    });


    //listar de airline manager------------------------------------------------------------------
    //este listar se tiene que modificar para que si el usuario loggeado es admin de aeropuerto, muestre solo los admins 
    //hacer un if en usando el rol en el que si es 1, se listan todos los admins de aerolineas y si es 2, entonces solo los respectivos
    var loggedAirportID = '1';
    $('#airlineManager').DataTable({
        responsive: true,
        processing: true,
        "ajax": {
            "url": 'http://dev.corecodeapi.com/api/getAirlineManagers',
            "type": "get",
            "datatype": "json",
            dataSrc: "Data"
        },
        "columns": [
            { "data": "FirstName" },
            { "data": "LastName" },
            { "data": "SecondLastName" },
            { "data": "Email" },
            { "data": "Phone" },
            { "data": "AirlineName" },
            {
                "data": "ID", "render": function (data) {
                    return '<i id="btnEdit" data-toggle="modal" style="color:green;font-size: 1.2em;cursor:pointer" data-target="#editModal" class="fas fa-edit"></i>';
                }
            },
            {
                "data": "ID", "render": function (data) {
                    return '<i id="btnDelete" style="color:red;font-size:1.2em;cursor:pointer" class="fas fa-trash"></i>';
                }
            }
        ]
    })
    //--------------------------------------------------------------------------------------------
    //registrar de airline manager------------------------------------------------------------------
    $('#btnAddAirlineManager').click(function () {
        let error = false;

        $ID = $('#inputID');
        $firstName = $('#inputFirstName');
        $secondName = $('#inputSecondName');
        $firstLastName = $('#inputFirstLastName');
        $secondLastName = $('#inputSecondLastName');
        $birthDate = $('#inputBirthdate');
        $genre = $('#inputGenre');
        $email = $('#inputEmail');
        $password = $('#inputPassword');
        $phone = $('#inputPhone');
        $civilStatus = $('#inputCivilStatus');
        $airline = $('#inputAirline');

        var data = {
            ID: $ID.val(),
            FirstName: $firstName.val(),
            SecondName: $secondName.val() || "-",
            LastName: $firstLastName.val(),
            SecondLastName: $secondLastName.val(),
            BirthDate: $birthDate.val(),
            Genre: $genre.val(),
            Email: $email.val(),
            Password: $password.val(),
            Phone: $phone.val(),
            CivilStatus: $civilStatus.val(),
            Status: true,
            Rol: "3",
            AirlineID: $airline.val()
        };
        var birthday = new Date($birthDate.val().split('-'));
        var today = new Date();
        var age = today.getFullYear() - birthday.getFullYear();
        var m = today.getMonth() - birthday.getMonth();

        if (m < 0 || (m === 0 && today.getDate() < birthday.getDate())) {
            age--;
        }
        console.log(age, typeof (age));
        if (age < 18) {
            swal({
                title: "El usuario debe de ser mayor de edad para poder crear una cuenta",
                text: "",
                icon: "error",
                button: "Ok",
            });
            $('#inputBirthdate')[0].classList.add('error');
            return;
        }
        var regEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!regEmail.test($email.val())) {
            swal({
                title: "Por favor ingrese un formato correcto para el correo electrónico",
                text: "",
                icon: "error",
                button: "Ok",
            });
            $('#inputEmail')[0].classList.add('error');
            return;
        }
        var regPass = /^(?=\S*[a-z])(?=\S*[A-Z])(?=\S*\d)(?=\S*[^\w\s])\S{8,}$/;
        if (!regPass.test($password.val())) {
            swal({
                title: "La contraseña debe ser de un minimo de 8 caracteres y debe contener por lo menos una letra minúscula, una mayúscula, y un número.",
                text: "",
                icon: "error",
                button: "Ok",
            });
            $('#inputPassword')[0].classList.add('error');
            return;
        }
        $("input.register:required").each(function (i, v) {
            if (v.value == "") {
                console.log(v);
                v.classList.add('error');
                error = true;
            }
        });
        if (error) {
            //swall
            swal({
                title: "Campos requeridos vacios",
                text: "",
                icon: "error",
                button: "Ok",
            });
        } else {
            $.post("http://dev.corecodeapi.com/api/postAirlineManager/", data, function (res) {
                console.log(res);
                swal({
                    title: "Administrador registrado",
                    text: "",
                    icon: "success",
                    button: "Ok",
                });
                $('#airlineManager').DataTable().ajax.reload();
            }).fail(function (err) {
                console.log(err);
            });

            $("input.register:required").each(function (i, v) {
                v.classList.remove('error');
            });
            $('input.register').each(function (i, v) {
                v.value = "";
            })
        }
    })
    //------------------------------------------------------------------------------------------------
    //eliminar airport manager-------------------------------------------------------------------
    $('#airlineManager').on('click', '#btnDelete', function () {
        var manager = table.row($(this).parents('tr')).data();
        $.delete = function (url, data, callback) {
            if ($.isFunction(data)) {
                type = type || callback,
                    callback = data,
                    data = {}
            }
            return $.post(url, data, callback); 
        }

        swal({
            title: "¿Desea proceder?",
            text: "El administrador será eliminado de manera permanente",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        }).then((willDelete) => {
            if (willDelete) {
                $.delete("http://dev.corecodeapi.com/api/deleteAirlineManager/", manager, function (res) {
                    swal({
                        title: "Administrador eliminado",
                        text: "",
                        icon: "success",
                        button: "Ok"
                    });
                    $('#airlineManager').DataTable().ajax.reload();
                })
            }
        })
    });
    //----------------------------------------------------------------------------------------------
    //esto es para el edit
    var table = $('#airlineManager').DataTable();
    //editar airport manager-------------------------------------------------------------------
    $('#airlineManager').on('click', '#btnEdit', function () {
        var data = table.row($(this).parents('tr')).data();
        let error = false;
        console.log(data.CivilStatus);
        $ID = $('#inputIDEdit');
        $firstName = $('#inputFirstNameEdit');
        $secondName = $('#inputSecondNameEdit');
        $firstLastName = $('#inputFirstLastNameEdit');
        $secondLastName = $('#inputSecondLastNameEdit');
        $birthDate = $('#inputBirthdateEdit');
        $genre = $('#inputGenreEdit');
        $email = $('#inputEmailEdit');
        $password = $('#inputPasswordEdit');
        $phone = $('#inputPhoneEdit');
        $civilStatus = $('#inputCivilStatusEdit');
        $airline = $('#inputAirlineEdit');
        //fill form
        $ID.val(data.ID);
        $firstName.val(data.FirstName);
        $secondName.val(data.SecondName);
        $firstLastName.val(data.LastName);
        $secondLastName.val(data.SecondLastName);
        $birthDate.val(data.BirthDate.split('T')[0]);
        $genre.val(data.Genre);
        $email.val(data.Email);
        $password.val(data.Password);
        $phone.val(data.Phone);
        $civilStatus.val(data.CivilStatus);
        $airline.val(data.AirlineID);

        var manager = {
            "ID": $ID.val(),
            "FirstName": $firstName.val(),
            "SecondName": $secondName.val(),
            "LastName": $firstLastName.val(),
            "SecondLastName": $secondLastName.val(),
            "BirthDate": $birthDate.val(),
            "Genre": $genre.val(),
            "Email": $email.val(),
            "Password": $password.val(),
            "Phone": $phone.val(),
            "CivilStatus": $civilStatus.val(),
            "Status": true,
            "Rol": "2",
            "AirlineID": data.AirlineID
        };

        console.log(manager);

        $('#btnEditAirlineManager').click(function () {
            //validate
            var regEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!regEmail.test($email.val())) {
                swal({
                    title: "Por favor ingrese un formato correcto para el correo electrónico",
                    text: "",
                    icon: "error",
                    button: "Ok",
                });
                $('#inputEmailEdit')[0].classList.add('error');
                return;
            }

            $("input.edit:required").each(function (i, v) {
                if (v.value == "") {
                    v.classList.add('error');
                    error = true;
                    return;
                } else {
                    error = false;
                }
            });
            if (error) {
                swal({
                    title: "Campos requeridos vacios",
                    text: "",
                    icon: "error",
                    button: "Ok",
                });
            } else {
                $.post("http://dev.corecodeapi.com/api/updateAirlineManager/", manager, function () {
                    swal({
                        title: "Administrador modificado",
                        text: "",
                        icon: "success",
                        button: "Ok",
                    });
                    $('#airlineManager').DataTable().ajax.reload();
                });
            }
        })
    })
    //---------------------------------------------------------------------------------------------
})

