function vEditAirportAdmin() {


    this.ctrlActions = new ControlActions();
    this.AirportId = localStorage.getItem('idAirportLS');


    this.Update = function () {

        let idAirport = {
            id: localStorage.getItem('idAirportLS')
        };

        var instance = this;
        if (!this.Validate()) {

            var airportAdminData = {};
            airportAdminData = this.ctrlActions.GetDataForm('frmEdition');


            var birthday = new Date(document.querySelector('#txtBirthDate').value.split('-'));
            var today = new Date();
            var age = today.getFullYear() - birthday.getFullYear();
            var m = today.getMonth() - birthday.getMonth();

            if (m < 0 || (m === 0 && today.getDate() < birthday.getDate())) {
                age--;
            }
            console.log(age, typeof (age));
            if (age < 18) {
                document.querySelector('#txtBirthDate').classList.add('input-error');
                swal({
                    title: "Error al registrar administrador",
                    text: "Usuario debe ser mayor de edad",
                    icon: "error",
                    button: "Ok",
                });
            }

            var regPass = /^(?=\S*[a-z])(?=\S*[A-Z])(?=\S*\d)(?=\S*[^\w\s])\S{8,}$/;
            if (!regPass.test(document.querySelector("#txtPassword").value)) {
                document.querySelector("#txtPassword").classList.add("input-error");
                swal({
                    title: "Error en la contraseña",
                    text: "Por favor, cumplir con el formato requerido",
                    icon: "error",
                    button: "Ok",
                });
            }
            else {

                if (document.querySelector("#txtPassword").value != document.querySelector("#txtPassword2").value) {
                    document.querySelector("#txtPassword").classList.add("input-error");
                    document.querySelector("#txtPassword2").classList.add("input-error");
                    swal({
                        title: "Error en la contraseña",
                        text: "Las contraseñas no son idénticas",
                        icon: "error",
                        button: "Ok",
                    });
                }
                else {

                    airportAdminData.Status = true;
                    airportAdminData.Rol = "2";
                    airportAdminData.AirportID = instance.AirportId;

                    instance.ctrlActions.PostToAPI('updateAirportManager', airportAdminData, function () {

                        swal({
                            title: "¡Administrador de aeropuerto modificado!",
                            text: "",
                            icon: "success",
                            button: "OK"
                        }).then(function () {
                            window.location.href = 'http://dev.corecode.com/vListAirports';
                        });
                    });



                }

            }

        }
        else {

            swal({
                title: "¡Ocurrió un error!",
                text: "Revisar campos vacíos",
                icon: "error",
                button: "OK",
            });

        }

    }


    this.Validate = function () {
        let aInputs = document.querySelectorAll(':required');
        let bError = false;

        for (let i = 0; i < aInputs.length; i++) {
            if (aInputs[i].value === '') {
                bError = true;
                aInputs[i].classList.add('input-error');
            }
            else {
                aInputs[i].classList.remove('input-error');
            }

        }


        if (document.querySelector('#txtSecondName').value == "") {
            document.querySelector('#txtSecondName').value = "N/N";
        }
        if (document.querySelector('#txtSecondLastName').value == "") {
            document.querySelector('#txtSecondLastName').value = "N/N";
        }



        return bError;

    }



    this.Cancel = function () {
        window.location.href = 'http://dev.corecode.com/vListAirports';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    let idAirport = {
        ID: localStorage.getItem('idAirportLS')
    };
    var vAirportAdminEdit = new vEditAirportAdmin();
    document.querySelector("#txtId").disabled = true;
    document.querySelector("#txtEmail").disabled = true;
    var airportAdmin;
    let callback = function (response) {

        airportAdmin = response.Data;

        document.querySelector("#txtId").value = airportAdmin.ID;
        document.querySelector("#txtEmail").value = airportAdmin.Email;
        document.querySelector("#txtFirstName").value = airportAdmin.FirstName;
        document.querySelector("#txtLastName").value = airportAdmin.LastName;
        document.querySelector("#txtSecondName").value = airportAdmin.SecondName;
        document.querySelector("#txtSecondLastName").value = airportAdmin.SecondLastName;
        document.querySelector("#txtBirthDate").value = airportAdmin.BirthDate;
        document.querySelector("#txtPhone").value = airportAdmin.Phone;
        document.querySelector("#txtPassword").value = airportAdmin.Password;
        document.querySelector("#txtPassword2").value = airportAdmin.Password;
        document.querySelector("#selectCivilStatus").value = airportAdmin.CivilStatus;
        document.querySelector("#selectGenre").value = airportAdmin.Genre;

    }
    vAirportAdminEdit.ctrlActions.GetFromAPI("/getAdminAirportByAirportId", idAirport, callback);

});

