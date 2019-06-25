//# sourceURL=StoreList.js

showStores();
document.querySelector('#txtFilter').addEventListener('keyup', showStores);
document.querySelector('#selectAirport').addEventListener('change', showStores);
document.querySelector('#statusFilter').addEventListener('change', showStores);
//document.querySelector("#btnRegisterStore").addEventListener('click', redirectToStoreRegister);
document.querySelector('#tblStore').classList.add('hide');
document.querySelector('#tblStore2').classList.add('hide');
document.querySelector('#tblStore3').classList.add('hide');

document.querySelector("#btnEditStore").addEventListener('click', updateStoreInfo);


showStores();
showAirports();

function showStores() {


    let user = JSON.parse(sessionStorage.getItem('user'));


    let stores;
    let callback = function (response) {
        stores = response.Data;


        let bodyTable = document.querySelector('#tblStore tbody');
        let bodyTable2 = document.querySelector('#tblStore2 tbody');
        let bodyTable3 = document.querySelector('#tblStore3 tbody');

        let sFilter = document.querySelector('#txtFilter').value.toLowerCase();
        let statusFilter = document.querySelector('#statusFilter').value;

        bodyTable.innerHTML = '';
        bodyTable2.innerHTML = '';
        bodyTable3.innerHTML = '';


        for (let i = 0; i < stores.length; i++) {
            
            if ((stores[i]['IDStore'].toLowerCase().includes(sFilter))
                || (stores[i]['Name'].toLowerCase().includes(sFilter))) {

                if (statusFilter == "true") {

                    if (stores[i]['IDAirport'] == document.querySelector('#selectAirport').value) {

                        if (stores[i]['Status'] == true) {


                            document.querySelector('#tblStore').classList.remove('hide');
                            document.querySelector('#tblStore2').classList.add('hide');
                            document.querySelector('#tblStore3').classList.add('hide');
                            let row = bodyTable.insertRow();

                            let cCodeId = row.insertCell();
                            let cName = row.insertCell();
                            let cNameAdmin = row.insertCell();
                            let cPhone = row.insertCell();
                            let cRentCost = row.insertCell();
                            let cConfiguration = row.insertCell();

                            cCodeId.appendChild(document.createTextNode(stores[i]['IDStore']));
                            cName.appendChild(document.createTextNode(stores[i]['Name']));
                            cNameAdmin.appendChild(document.createTextNode(stores[i]['ManagerName']));
                            cPhone.appendChild(document.createTextNode(stores[i]['Phone']));
                            cRentCost.appendChild(document.createTextNode(stores[i]['Rent']));


                            let editBtn = document.createElement('button');
                            editBtn.innerHTML = 'Editar';
                            editBtn.dataset.idStore = stores[i]['IDStore'];
                            editBtn.addEventListener('click', edit);

                            let disableBtn = document.createElement('button');
                            disableBtn.innerHTML = 'Deshabilitar';
                            disableBtn.dataset.idStore = stores[i]['IDStore'];
                            disableBtn.addEventListener('click', disable);


                            cConfiguration.appendChild(editBtn);
                            cConfiguration.appendChild(disableBtn);




                        }
                    }
                }

                if (statusFilter == "false") {

                    if (stores[i]['IDAirport'] == document.querySelector('#selectAirport').value) {

                        if (stores[i]['Status'] == false) {

                            document.querySelector('#tblStore').classList.add('hide');
                            document.querySelector('#tblStore2').classList.remove('hide');
                            document.querySelector('#tblStore3').classList.add('hide');
                            let row = bodyTable2.insertRow();

                            let cCodeId = row.insertCell();
                            let cName = row.insertCell();
                            let cNameAdmin = row.insertCell();
                            let cPhone = row.insertCell();
                            let cRentCost = row.insertCell();
                            let cConfiguration = row.insertCell();

                            cCodeId.appendChild(document.createTextNode(stores[i]['IDStore']));
                            cName.appendChild(document.createTextNode(stores[i]['Name']));
                            cNameAdmin.appendChild(document.createTextNode(stores[i]['ManagerName']));
                            cPhone.appendChild(document.createTextNode(stores[i]['Phone']));
                            cRentCost.appendChild(document.createTextNode(stores[i]['Rent']));


                            let enableBtn = document.createElement('button');
                            enableBtn.innerHTML = 'Habilitar';
                            enableBtn.dataset.idStore = stores[i]['IDStore'];
                            enableBtn.addEventListener('click', enable);

                            cConfiguration.appendChild(enableBtn);
                        }
                    }
                }
            }
        }



        //if (user['Rol'] == '4') {
        //    statusFilter = "true";
        //    document.querySelector('#statusFilter').classList.add('hide');

        //    if ((stores[i]['IDStore'].toLowerCase().includes(sFilter))
        //        || (stores[i]['Name'].toLowerCase().includes(sFilter))) {

        //        if (statusFilter == "true") {

        //            if (stores[i]['IDAirport'] == document.querySelector('#selectAirport').value) {

        //                if (stores[i]['Status'] == true) {

        //                    document.querySelector('#tblStore').classList.add('hide');
        //                    document.querySelector('#tblStore2').classList.add('hide');
        //                    document.querySelector('#tblStore3').classList.remove('hide');
        //                    let row = bodyTable3.insertRow();

        //                    let cCodeId = row.insertCell();
        //                    let cName = row.insertCell();
        //                    let cNameAdmin = row.insertCell();
        //                    let cPhone = row.insertCell();

        //                    cCodeId.appendChild(document.createTextNode(stores[i]['IDStore']));
        //                    cName.appendChild(document.createTextNode(stores[i]['Name']));
        //                    cNameAdmin.appendChild(document.createTextNode(stores[i]['ManagerName']));
        //                    cPhone.appendChild(document.createTextNode(stores[i]['Phone']));
        //                }
        //            }
        //        }
        //    }



        //}

        
    }
    ApiService.getFromAPI("/getStores", "", callback);
}

function edit() {
    localStorage.setItem('idStoreEditLS', this.dataset.idStore);
    let idStore = {
        id: this.dataset.idStore
    };

    let store;
    let callback = function (response) {

        store = response.Data;

        document.querySelector('#txtNameEdit').value = store.Name;
        document.querySelector('#selectAirportEdit').value = store.IDAirport;
        document.querySelector('#selectCategoryEdit').value = store.IDCategory;
        document.querySelector('#txtManagerNameEdit').value = store.ManagerName;
        document.querySelector('#txtPhoneEdit').value = store.Phone;
        document.querySelector('#nbmRentEdit').value = store.Rent;
        

    };
    showCategories();
    showAirportsEdit();
    ApiService.getFromAPI("/getStoreById", idStore, callback);

    $('#editStoreModal').modal('show');
   



}
            
function enable() {
    let idStore = {
        id: this.dataset.idStore
    };
    let store;
    let callback = function (response) {
        store = response.Data;
        store.Status = true;
        let callback2 = function (response) {

        };
        ApiService.postToAPI("/updateStore", store, callback2);
        
    };
    ApiService.getFromAPI("/getStoreById", idStore, callback);
    swal({
        title: "Tienda habilitada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showStores();
    });


}
                      
function disable() {
    let idStore = {
        id: this.dataset.idStore
    };
    let store;
    let callback = function (response) {
        store = response.Data;
        store.Status = false;
        let callback2 = function (response) {

        };
        ApiService.postToAPI("/updateStore", store, callback2);
        
    };
    ApiService.getFromAPI("/getStoreById", idStore, callback);
    swal({
        title: "Tienda deshabilitada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showStores();
    });


}



function updateStoreInfo() {


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

        let airportValue = document.querySelector('#selectAirportEdit').value;
        let nameValue = document.querySelector('#txtNameEdit').value;
        let categoryValue = document.querySelector('#selectCategoryEdit').value;
        let managerValue = document.querySelector('#txtManagerNameEdit').value;
        let phoneValue = document.querySelector('#txtPhoneEdit').value;
        let rentValue = document.querySelector('#nbmRentEdit').value;




        let jsonItem = {
            "IDStore": localStorage.getItem('idStoreEditLS'),
            "Name": nameValue,
            "ManagerName": managerValue,
            "Phone": phoneValue,
            "IDCategory": categoryValue,
            "IDAirport": airportValue,
            "Rent": rentValue,
            "Status": true
        };

        let callback = function (response) {
        };
        ApiService.postToAPI("/updateStore", jsonItem, callback);

        swal({
            title: "Tienda modificada",
            text: "",
            icon: "success",
            button: "OK",
        }).then(function () {

            $('#editStoreModal').modal('hide');

            showStores();
        });
        //if (Admin Aeropuerto hace el update) {
        //    redirecciona al home del admin a
        //}
        //if (Admin G hace el update) {
        //    redirecciona al home del admin g
        //}

    }
}

function removeStore() {

    let idStore = {
        id: this.dataset.idStore
    };
    let store;
    let callback = function (response) {
        store = response.Data;
    };
    ApiService.getFromAPI("/deleteStore", idStore, callback);
    swal({
        title: "Tienda eliminada",
        text: "",
        icon: "success",
        button: "OK",
    }).then(function () {
        showStores();
    });



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

function showAirports() {


    let user = JSON.parse(sessionStorage.getItem('user'));


    let airports;
    let callback = function (response) {
        airports = response.Data;
       
         //if (user['Rol'] == '2') {
        //    document.querySelector('#selectAirport').classList.add('hide');

            //for (let i = 0; i < airports.length; i++) {

            //    if (airports[i]['ID'] == ID AIRPORT DEL ADMIN AEROPUERTO) {

            //        let newOption = new Option(airports[i]['Name']);

            //        newOption.value = airports[i]['ID'];

            //        document.querySelector('#selectAirport').options.add(newOption);
            //    }
            //}


        //}

        //if (user['Rol'] == '4') {
        //   QUITAR---> document.querySelector('#selectAirport').disabled = true;
        //    document.querySelector('#statusFilter').classList.add('hide');

        //    for (let i = 0; i < airports.length; i++) {
        //      

        //            let newOption = new Option(airports[i]['Name']);

        //            newOption.value = airports[i]['ID'];

        //            document.querySelector('#selectAirport').options.add(newOption);
        //        
        //    }
           
        
        //}
       
    //    else {
        //-----------> lo que va abajo
    //}
        
            let selectAirport = document.querySelector('#selectAirport');

            let defaultOption = new Option("Seleccione aeropuerto");
            defaultOption.value = "";
            selectAirport.options.add(defaultOption);
            for (let i = 0; i < airports.length; i++) {
                if (airports[i]['Status'] == true) {



                    let newOption = new Option(airports[i]['Name']);

                    newOption.value = airports[i]['ID'];

                    selectAirport.options.add(newOption);
                }
            }
        
    }
    ApiService.getFromAPI("/getAirports", "", callback);
}



function redirectToStoreRegister() {
    window.location.href = 'http://dev.corecode.com/CreateStore';
}


function showAirportsEdit() {

    document.querySelector('#selectAirportEdit').disabled = true;

    let selectAirport = document.querySelector('#selectAirportEdit');


    let airports;
    let callback = function (response) {
        airports = response.Data;

        for (let i = 0; i < airports.length; i++) {
            if (airports[i]['Status'] == true) {

                let newOption = new Option(airports[i]['Name']);

                newOption.value = airports[i]['ID'];

                selectAirport.options.add(newOption);

            }
        }
    }
    ApiService.getFromAPI("/getAirports", "", callback);

}


function showCategories() {


    let selectCategories = document.querySelector('#selectCategoryEdit');

    //let defaultOption = new Option("Seleccione categoría");
    //defaultOption.value = "";
    //selectCategories.options.add(defaultOption);

    let categories;
    let callback = function (response) {
        categories = response.Data;
        let valido = false;

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
