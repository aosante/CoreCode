$(document).ready(function () {
    let users;

    $.get("http://dev.corecodeapi.com/api/getUsers",
        function(data) {
            users = data.Data;
            console.log(users);
        });
    $('#loginButton').click(function () {
        let username = $('#loginEmail').val();
        let password = $('#loginPassword').val();
        let loggedUser;
        let userFound = false;
        for (let i = 0; i < users.length; i++) {
            if (users[i].Email === username && users[i].Password === password) {
                userFound = true;
                loggedUser = users[i];
            }
        }
            if (userFound) {
                loggedUser.Password = '#####';
                sessionStorage.setItem('user', JSON.stringify(loggedUser));
                switch (loggedUser.Rol) {
                    case '1':
                        window.location.href = "http://dev.corecode.com/dashboard/general";
                        break;
                    case '2':
                        window.location.href = "http://dev.corecode.com/dashboard/airport/" + loggedUser.AssignedID;
                        //add hiding clases to corresponding items in the nav bar
                        break;
                    case '3':
                        window.location.href = "http://dev.corecode.com/dashboard/airline/" + loggedUser.AssignedID;
                        break;
                }
            } else {
                swal({
                    title: "Usuario o contraseña incorrectas. Por favor inténtelo de nuevo.",
                    text: "",
                    icon: "error",
                    button: "Ok",
                });
            }
        }
    )




    $('#btnRecover').click(function () {

        function generar() {
            var caracteres = "!@abcdefghijkmnpqrtuvwxyzABCDEFGHIJKLMNPQRTUVWXYZ2346789!@";
            var contrasenna = "";
            var longitud = 8;
            for (i = 0; i < longitud; i++) contrasenna += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
            return contraseña;
        }

        let username = $('#loginEmail').val();

        if (users === null) {


            for (let i = 0; i < users.length; i++) {
                if (users[i].Email === username) {
                    userRecovered = users[i];
                    opcion = users[i].Rol;
                    pwdGeneric = generar();

                    var user = {
                        ID: users.ID,
                        name: users.name,
                        lastName: users.lastName

                    }



                    switch (opcion) {
                        case '2':
                            ApiService.postToAPI('postFAQ', user, function (response) { });
                            break;

                        case '3':
                            ApiService.postToAPI('postFAQ', user, function (response) { });
                            break;


                    }

                } else {
                    swal({
                        title: "Usuario  incorrecto. Por favor inténtelo de nuevo.",
                        text: "",
                        icon: "error",
                        button: "Ok",
                    });

                }

            }
        } else {
            swal({
                title: "Usuario  incorrecto. Por favor inténtelo de nuevo.",
                text: "",
                icon: "error",
                button: "Ok",
            });
            console.log("error")
        }


    })
})
