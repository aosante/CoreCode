(function() {
   
fillForm();
//inicializar();
document.querySelector("#btnEditAirline").addEventListener('click', updateAirlineInfo);
    document.querySelector("#btnListAirline").addEventListener('click', redirectToListAirline);
    document.querySelector("#btnCancel").addEventListener('click', redirectToListAirline);
  


function fillForm() {
    let idAirline = {
        id: localStorage.getItem('idAirlineLS')
    };
    let airline;
    let callback = function (response) {

        airline = response.Data;

        document.querySelector('#txtComercialName').value = airline.Comercial_name;
        document.querySelector('#txtBusinessName').value = airline.Business_name;
        document.querySelector('#txtCreationYear').value = airline.Creation_year;
        document.querySelector('#txtDescription').value = airline.Description;
        document.querySelector('#txtEmail').value = airline.Email;
     

        
    };
    ApiService.getFromAPI("/getAirlineById", idAirline, callback);

 

}

function updateAirlineInfo() {


    let bError = validate();
    if (bError == true) {

        swal({
            title: "¡Ocurrió un error!",
            text: "Revisar campos vacíos",
            icon: "error",
            button: "OK",
        });
    }
    else {

        let nameValue = document.querySelector('#txtComercialName').value;
        let businessValue = document.querySelector('#txtBusinessName').value;
        let creationyearValue = document.querySelector('#txtCreationYear').value;
        let descriptionValue = document.querySelector('#txtDescription').value;
        let emailValue = document.querySelector('#txtEmail').value;

        let jsonItem = {
            "ID": localStorage.getItem('idAirlineLS'),
            "COMERCIAL_NAME": nameValue,
            "BUSINESS_NAME": businessValue,
            "CREATION_YEAR": creationyearValue,
            "DESCRIPTION": descriptionValue,
            "EMAIL": emailValue
        };

        let callback = function (response) {
        };
        ApiService.postToAPI("/updateAirline", jsonItem, callback);
        swal({
            title: "Aerolinea modificada",
            text: "",
            icon: "success",
            button: "OK",
        }).then(function () {
            redirectToListAirline();
        });


    }
}

function validate() {
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
    return bError;

}

function redirectToListAirline() {
    window.location.href = 'http://dev.corecode.com/ListAirline';
}


    
})();

