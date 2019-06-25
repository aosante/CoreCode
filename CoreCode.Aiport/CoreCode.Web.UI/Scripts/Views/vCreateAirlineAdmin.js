function vCreateAirlineAdmin() {


    this.ctrlActions = new ControlActions();
    this.AirlineId = localStorage.getItem('idAirlineLS');
    this.userEmailHtmlElementId = "txtEmail ";
    this.userIdHtmlElementId = "txtId";
    this.Create = function () {

        var instance = this;
        if (!this.Validate()) {
            var user;
            var airlineAdminData = {};
            airlineAdminData = this.ctrlActions.GetDataForm('frmEdition');
            let callback = function (response) {
                user = response.Data;
                if (!user) {
                    airlineAdminData.Status = false;//quitar input password
                    airlineAdminData.Rol = "3";
                    airlineAdminData.AirlineID = instance.AirlineId;
                    airlineAdminData.Password = "temporal";
                    instance.ctrlActions.PostToAPI('postAirlineManager', airlineAdminData, function () {
                        swal({
                            title: "¡Administrador de aerolínea registrado!",
                            text: "Proceda a esperar correo de confirmación al siguiente correo: " + airlineAdminData.Email + " en caso de ser aceptada",
                            icon: "success",
                            button: "OK"
                        }).then(function () {
                            instance.CleanForm();
                            //  window.location.href = 'http://dev.corecode.com/vCreateAirlineAdmin';
                        });
                    });
                } else if (user.ID === document.querySelector('#txtId').value) {
                    document.querySelector('#txtId').classList.add('input-error');

                    swal({
                        title: "Error al registrar administrador",
                        text: "Cédula de identidad ya se encuentra registrada",
                        icon: "error",
                        button: "Ok"
                    });
                }
                else if (user.Email === document.querySelector('#txtEmail').value) {
                    document.querySelector('#txtEmail').classList.add('input-error');
                    swal({
                        title: "Error al registrar administrador",
                        text: "Correo electrónico ya se encuentra registrado",
                        icon: "error",
                        button: "Ok",
                    });
                }
            }
            instance.ctrlActions.GetFromAPI("checkIfUserExistsByUserNameOrId?userName=" + $("#" + instance.userEmailHtmlElementId).val() + "&id=" + $("#" + instance.userIdHtmlElementId).val() + "", "", callback);
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



    this.CleanForm = function () {
        let aInputs = document.querySelectorAll(':required');
        for (let i = 0; i < aInputs.length; i++) {

            aInputs[i].value = '';


        }
        document.querySelector('#txtSecondName').value = '';
        document.querySelector('#txtSecondLastName').value = '';
    }
}

//ON DOCUMENT READY
$(document).ready(function () {

    var vairlineadmin = new vCreateAirlineAdmin();


});
