function vEditAirlineAdmin() {


    this.ctrlActions = new ControlActions();
    this.AirlineId = localStorage.getItem('idAirlineLS');


    this.Update = function () {

        let idAirline = {
            id: localStorage.getItem('idAirlineLS')
        };

        var instance = this;
        if (!this.Validate()) {

            var airlineAdminData = {};
            airlineAdminData = this.ctrlActions.GetDataForm('frmEdition');


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

                    airlineAdminData.Status = true;
                    airlineAdminData.Rol = "3";
                    airlineAdminData.AirlineID = instance.AirlineId;

                    instance.ctrlActions.PostToAPI('updateAirlineManager', airlineAdminData, function () {

                        swal({
                            title: "¡Administrador de aerolinea modificado!",
                            text: "",
                            icon: "success",
                            button: "OK"
                        }).then(function () {

                            window.location.href = 'http://dev.corecode.com/vListAirlinesRequest';
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
        window.location.href = 'http://dev.corecode.com/vListAirlinesRequest';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    let idAirline = {
        ID: localStorage.getItem('idAirlineLS')
    };
    var vAirlineAdminEdit = new vEditAirlineAdmin();
    document.querySelector("#txtId").disabled = true;
    document.querySelector("#txtEmail").disabled = true;
    var airlineAdmin;
    let callback = function (response) {

        airlineAdmin = response.Data;

        document.querySelector("#txtId").value = airlineAdmin.ID;
        document.querySelector("#txtEmail").value = airlineAdmin.Email;
        document.querySelector("#txtFirstName").value = airlineAdmin.FirstName;
        document.querySelector("#txtLastName").value = airlineAdmin.LastName;
        document.querySelector("#txtSecondName").value = airlineAdmin.SecondName;
        document.querySelector("#txtSecondLastName").value = airlineAdmin.SecondLastName;
        document.querySelector("#txtBirthDate").value = airlineAdmin.FormattedYear;
        document.querySelector("#txtPhone").value = airlineAdmin.Phone;
        document.querySelector("#txtPassword").value = airlineAdmin.Password;
        document.querySelector("#txtPassword2").value = airlineAdmin.Password;
        document.querySelector("#selectCivilStatus").value = airlineAdmin.CivilStatus;
        document.querySelector("#selectGenre").value = airlineAdmin.Genre;

    }
    vAirlineAdminEdit.ctrlActions.GetFromAPI("/getAirlineAdminByAirlineId", idAirline, callback);
    
});

