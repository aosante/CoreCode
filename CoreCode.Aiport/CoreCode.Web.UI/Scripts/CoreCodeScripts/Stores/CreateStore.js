//# sourceURL=CreateStore.js

function CreateStore(parameters) {
    var instance = this;
    instance.formId = parameters ? parameters.formId : "";
    instance.storeRegisterControl = new FormControl({
        formId: instance.formId
    });
    instance.submitForm = function() {
        if (instance.storeRegisterControl.validateEmptyRequiredFields()) {
            //Custom Validations
            
        };
    }
    
    instance.fillCategoryDropdown = function() {
        let selectCategories = document.querySelector('#selectCategory');
       let defaultOption = new Option("Seleccione categoría");
       defaultOption.value = "";
        document.querySelector('#selectCategory').options.add(defaultOption);
        let categories;
        let callback = function (response) {
            categories = response.Data;
            console.log(categories);
            let valid = false;
            for (let i = 0; i < categories.length; i++) {
                if (categories[i]['Status'] == true) {
                    let newOption = new Option(categories[i]['Description']);
                    newOption.value = categories[i]['IDCategory'];
                    selectCategories.options.add(newOption);
                }
            }
        }
        ApiService.getFromAPI("/getCategories", "", callback);
    }

    instance.init = function() {
        instance.fillCategoryDropdown();
    }

}



//let btnRegister = document.querySelector('#btnRegisterStore');
//btnRegister.addEventListener('click', registerAirport);
////document.querySelector("#btnListStores").addEventListener('click', redirectToStoreList);
//document.querySelector("#btnCancel").addEventListener('click', cleanForm);

//showCategories();
//showAirports();

//function registerAirport() {

//    let bError = validate();
//    if (bError == true) {

//        swal({
//            title: "¡Ocurrió un error!",
//            text: "Revisar campos vacíos",
//            icon: "error",
//            button: "OK",
//        });
//    }
//    else {
//        let airportValue = document.querySelector('#selectAirport').value;
//        let nameValue = document.querySelector('#txtName').value;
//        let categoryValue = document.querySelector('#selectCategory').value;
//        let managerValue = document.querySelector('#txtManagerName').value;             
//        let phoneValue = document.querySelector('#txtPhone').value; 
//        let rentValue = document.querySelector('#nbmRent').value;
                               
//        let stores;
//        let cont = 0;
//        let repeatedStore = false;
//        let callback = function (response) {
//            stores = response.Data;


//            for (let i = 0; i < stores.length; i++) {
//                if (stores[i]['Name'] == document.querySelector('#txtName').value
//                    && stores[i]['IDAirport'] == document.querySelector('#selectAirport').value) {
//                    repeatedStore = true;
//                }
//            }

//            if (repeatedStore) {
//                document.querySelector('#txtName').classList.add('input-error');

//                swal({
//                    title: "Tienda ya se encuentra registrada",
//                    text: "Revisar nombre",
//                    icon: "error",
//                    button: "Ok",
//                });

//            }
//            else {
//                for (let i = 0; i < stores.length; i++) {
//                    if (stores[i]['IDAirport'] == airportValue) {
//                        cont++;
//                    }
//                }
//                cont = cont + 1;

//                let jsonItem = {
//                    "IDStore": "STR-" + airportValue + "-" + cont.toString(),
//                    "Name": nameValue,
//                    "ManagerName": managerValue,
//                    "Phone": phoneValue,
//                    "IDCategory": categoryValue,
//                    "IDAirport": airportValue,
//                    "Rent": rentValue,
//                    "Status": true
//                };

//                ApiService.postToAPI("/postStore", jsonItem);



//            }

          
//        }
//        ApiService.getFromAPI("/getStores", "", callback);
//        swal({
//            title: "Tienda registrada",
//            text: "",
//            icon: "success",
//            button: "Ok",
//        }).then(function () {
//            cleanForm();

//        });
//    }
    
//}

//function validate() {
//    let aInputs = document.querySelectorAll(':required');
//    let bError = false;

//    for (let i = 0; i < aInputs.length; i++) {
//        if (aInputs[i].value === '') {
//            bError = true;
//            aInputs[i].classList.add('input-error');
//        }
//        else {
//            aInputs[i].classList.remove('input-error');
//        }

//    }
//    return bError;

//}
//function cleanForm() {
//    document.querySelector('#selectAirport').value = '';
//    //document.querySelector('#txtId').value = '';
//    document.querySelector('#txtName').value = '';
//    document.querySelector('#selectCategory').value = '';
//    document.querySelector('#txtManagerName').value = '';
//    document.querySelector('#txtPhone').value = '';
//    document.querySelector('#nbmRent').value = '';


//    let aInputs = document.querySelectorAll(':required');
//    for (let i = 0; i < aInputs.length; i++) {
//        aInputs[i].classList.remove('input-error');
//    }

//}

//function showAirports() {
    
//    let airports;
//    let callback = function (response) {
//        airports = response.Data;
//        let selectAirport = document.querySelector('#selectAirport');

//        let defaultOption = new Option("Seleccione aeropuerto");
//        defaultOption.value = "";
//        selectAirport.options.add(defaultOption);

//        for (let i = 0; i < airports.length; i++) {
//            if (airports[i]['Status'] == true) {

//                let newOption = new Option(airports[i]['Name']);

//                newOption.value = airports[i]['ID'];

//                selectAirport.options.add(newOption);
//            }
//        }


//    }
//    ApiService.getFromAPI("/getAirports", "", callback);

//}


//function showCategories() {
//    let selectCategories = document.querySelector('#selectCategory');

//    let defaultOption = new Option("Seleccione categoría");
//    defaultOption.value = "";
//    selectCategories.options.add(defaultOption);

//    let categories;
//    let callback = function (response) {
//        categories = response.Data;
//        let valido = false;

//        for (let i = 0; i < categories.length; i++) {
//            if (categories[i]['Status'] == true) {

//                let newOption = new Option(categories[i]['Description']);

//                newOption.value = categories[i]['IDCategory'];

//                selectCategories.options.add(newOption);
//            }
//        }


//    }
//    ApiService.getFromAPI("/getCategories", "", callback);

//}


//function redirectToStoreList() {
//    window.location.href = 'http://dev.corecode.com/ListStore';
//}