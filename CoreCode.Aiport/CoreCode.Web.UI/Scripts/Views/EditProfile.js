function EditProfile() {
    this.adminIdNumberElementId  = "inputUserId";
    this.emailInputElementId= "inputUserEmail";
    this.firstNameElementId = "inputFirstName";
    this.secondNameElementId = "inputSecondName";
    this.firstLastNameElementId = "inputFirstLastName";
    this.secondLastNameElementId = "inputSecondLastName";
    this.birthDateElementId = "inputBirthDate";
    this.phoneElementId = "inputPhone";
    this.civilStatusElementId = "selectCivilStatus";
    this.genreElementId = "selectGenre";
    this.formId = "frmEdition";
    this.ctrlActions = new ControlActions();
    this.saveButtonId = "savechanges";
    this.userObject = UserSession.getCurrentUserInstance();
    this.validFields = true;
    this.init = function() {
        var instance = this;
        var saveButton = $("#" + instance.saveButtonId); 
        $('#' + instance.formId).on("input change", function() {
            saveButton.removeClass("disabled");
        });
        saveButton.on("click", function() {
            instance.submitEdition();
        });
        $("#" + instance.emailInputElementId).on("change", function(event) {
            var targetValue = event.target.value;
            if (targetValue === "") {
                instance.validFields = false;
            } else if (!instance.validateEmail(targetValue)) {
                instance.validFields = false;
            } else if (targetValue === instance.userObject.Email) {
                $("#" + instance.emailInputElementId).removeClass("has-error").removeClass("success-form-input");
                instance.validFields = true;
            } else {
                instance.ctrlActions.PostToAPI("checkIfUserExists?userName=" + targetValue, "", function(response) {
                        if (response.Data === true) {
                            $("#" + instance.emailInputElementId).addClass("has-error")
                                .removeClass("success-form-input");
                            instance.validFields = false;
                        } else {
                            $("#" + instance.emailInputElementId).removeClass("has-error")
                                .addClass("success-form-input");
                            instance.validFields = true;
                        }
                    });
            }
        });
        if (instance.userObject) {
            switch (instance.userObject.Rol) {
            case 1:
                instance.setFormForGeneralAdmin();
                break;
            case 2:
                instance.setFormForAirportAdmin();
                break;
            case 3:
                instance.setFormForAirlineAdmin();
                break;
            default:
                //redirect
                break;
            }
        }
        //Redirect
    }
    this.setFormForGeneralAdmin = function() {
        var instance = this;
        $("#" + instance.emailInputElementId).val(instance.userObject.Email);
        $("#" + instance.firstNameElementId).val(instance.userObject.Name);
        $("#" + instance.firstLastNameElementId).val(instance.userObject.Last_Name);

    }
    this.submitEdition = function() {
        var instance = this;
        var firstName = $("#" + instance.firstNameElementId);
        var lastName = $("#" + instance.firstLastNameElementId);
        var secondLastName = $("#" + instance.secondLastNameElementId);
        var birthDate = $("#" + instance.birthDateElementId);
        var genre = $("#" + instance.genreElementId);
        var phone = $("#" + instance.phoneElementId);
        var civilStatus = $("#" + instance.civilStatusElementId);
        var email = $("#" + instance.emailInputElementId);
        var partialValidFields = true;
        //ID, mail, firstname, firstlastname, phone
        if (firstName.val() === "") {
            partialValidFields = false;
            firstName.addClass("has-error");
        }

        if (lastName.val() === "") {
            partialValidFields = false;
            firstName.addClass("has-error");
        }

        if (phone.val() === "") {
            partialValidFields = false;
            firstName.addClass("has-error");
        }

        if (civilStatus.val() === "") {
            partialValidFields  = false;
            firstName.addClass("has-error");
        }

        if (genre.val() === "") {
            partialValidFields = false;
            firstName.addClass("has-error");
        }
        
        if (partialValidFields || !instance.validFields) {
            if (!email.hasClass("has-error")) {
                instance.validFields = true;
            }
        } else {
            instance.validFields = false;
        }

        if (instance.validFields) {
            var userObject = {
                ID: instance.userObject.ID,
                FirstName: firstName.val(),
                LastName: lastName.val(),
                SecondLastName: secondLastName.val(),
                BirthDate: birthDate.val(),
                Genre: genre.val(),
                CivilStatus: civilStatus.val(),
                Email: email.val(),
                Phone: phone.val(),
                Rol: instance.userObject.Rol,
                AssignedID: instance.userObject.AssignedID,
                Password: instance.userObject.Password,
                Status: instance.userObject.Status
            };
            UserSession.setCurrentUserInstance(userObject);
            instance.ctrlActions.PostToAPI("updateUser", userObject, function() {

                swal({
                    title: "Modificado con éxito.",
                    text: "",
                    icon: "success",
                    button: "Aceptar"
                });
            });
        } else {
            swal({
                title: "Información no válida.",
                text: "Por favor corrija los errores del formulario.",
                icon: "error",
                button: "Aceptar"
            });
        }
    }

    this.validateEmail = function(email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(email).toLowerCase());
    }
    this.setFormForAirlineAdmin = function() {
        var instance = this;
        $("#" + instance.emailInputElementId).val(instance.userObject.Email);
        $("#" + instance.firstNameElementId).val(instance.userObject.Name);
        $("#" + instance.firstLastNameElementId).val(instance.userObject.Last_Name);
        $("#" + instance.secondLastNameElementId).val(instance.userObject.Second_Name);
        $("#" + instance.secondLastNameElementId).val(instance.userObject.Second_Last_Name);
        $("#" + instance.birthDateElementId).val(instance.userObject.BirthDate);
        $("#" + instance.phoneElementId).val(instance.userObject.Phone);
    }

    this.setFormForAirportAdmin = function() {
        var instance = this;
        $("#" + instance.adminIdNumberElementId).val(instance.userObject.ID);
        $("#" + instance.emailInputElementId).val(instance.userObject.Email);
        $("#" + instance.firstNameElementId).val(instance.userObject.FirstName);
        $("#" + instance.firstLastNameElementId).val(instance.userObject.LastName);
        $("#" + instance.secondLastNameElementId).val(instance.userObject.SecondName);
        $("#" + instance.secondLastNameElementId).val(instance.userObject.SecondLastName);
        $("#" + instance.birthDateElementId).val(instance.userObject.BirthDate.match("[0-9]+-[0-9]+-[0-9]+")[0]);
        $("#" + instance.genreElementId).val(instance.userObject.Genre);
        $("#" + instance.civilStatusElementId).val(instance.userObject.CivilStatus);
        $("#" + instance.phoneElementId).val(instance.userObject.Phone);
    }
};

$(document).ready(function() {
    var editProfile = new EditProfile();
    editProfile.init();
});