function FormControl(parameters) {
    var instance = this;
    instance.formId = parameters.formId;
    instance.errorMessageElementId = parameters.errorMessageElementId;
    instance.confirmMessageElementId = parameters.confirmMessageElementId;
    instance.validateEmptyRequiredFields = function() {
        var isAnyRequiredEmpty = false;
        var requiredFields = $("#" + this.formId).find("input[required]");
        requiredFields.each(function(element) {
            if (this.value === "") {
                isAnyRequiredEmpty = true;
                return;
            }
        });
        if (isAnyRequiredEmpty) {
            instance.showErrorMessage("Campos requeridos", "Por favor llenar todos los campos");
            return !isAnyRequiredEmpty;
        }
        return isAnyRequiredEmpty;
    };

    this.showErrorMessage = function(title, message) {
        if (swal) {
            swal({
                title: title,
                text: message,
                icon: "error",
                button: "OK",
            });
        }
    };

    this.showConfirmMessage = function(title, message) {
        if (swal) {
            swal({
                title: title,
                text: message,
                icon: "error",
                button: "OK",
            });
        }
        
    };
};