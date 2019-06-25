/// -------------------------------------------------------------------------------------------------
/// <reference path="~/Scripts/CoreCodeScripts/ApiService.js" />
// file:	Scripts\CoreCodeScripts\Dashboard.js
//
// summary:	Dashboard class
///-------------------------------------------------------------------------------------------------

/**
  * Constructor for the Dashboard Component
  * @param {} parameters parameters to set the dashboard.   
  */
"use strict";
var Dashboard = function(parameters) {
    var instance = this;
    this.isUserLoggedIn = false;
    this.ctrlActions = new ControlActions();
    this.userObject = UserSession.getCurrentUserInstance();
    this.initialize = function() {
        var instance = this;
        if (instance.userObject) {
            switch (instance.userObject.Rol) {
            case 1:
                instance.setGeneralAdminDashboard();
                break;
            case 2:
                instance.setAirportAdminDashboard();
                break;
            case 3:
                instance.setAirlineAdminDashboard();
                break;
            default:
                //redirect
                break;
            }
        }
    }
    this.setAirportAdminDashboard = function() {
        var instance = this;
        var airportStores;
        
        var scoreCardTemplate = document.getElementById("scoreCard-template");
        var gatesGainContainer = document.getElementById("gates-gain");
        var gatesCountContainer = document.getElementById("gates-ammount");
        var storeCountElement = document.getElementById("store-count");
        var storeGainElement = document.getElementById("store-gain");
        var landingGainElement = document.getElementById("landing-gain");
        var runwayGainContainer = document.getElementById("runway-gain");
        var createdElementFromTemplate;
        //Set the Information from the Airport
        var airportName = document.getElementById("airportNameHeader");
        instance.airportInstance = UserSession.getAirportInstance();
        if (airportName) {
            airportName.innerText = instance.airportInstance.Name;
        }
        //Request to retrieve the general report
        instance.ctrlActions.GetFromAPI("dashboard/getGeneralReport?airportId=" + instance.airportInstance.ID, "",
            function(response) {
                var storeGain = 0;
                var tableCounter = 0;
                var gateCodesCollection = [];
                var airlineCollection = [];
                var storesCollection = [];
                var gateCount = response.Result.Data.Gates.length;
                var storeCount = response.Result.Data.Stores.length;
                var gateTariff = UserSession.getAirportInstance().GateTariff;
                
                //Gate Count
                createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, gateCount, "Total de puertas", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                gatesCountContainer.appendChild(createdElementFromTemplate);
                

                //Gate Gain
                var gateGain = gateTariff * storeCount;
                createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, gateGain, "Ganancia de puertas", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                gatesGainContainer.appendChild(createdElementFromTemplate);
                

                //Store Count
                createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, storeCount, "Total de Tiendas", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                storeCountElement.appendChild(createdElementFromTemplate);
                
                //Landing Gain
                createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, UserSession.getAirportInstance().RunwayTariff, "Tarifa de Pista", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                landingGainElement.appendChild(createdElementFromTemplate);

                if (response.Result.Data.RunwayLandingGain) {
                    createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate,
                        response.Result.Data.RunwayLandingGain,
                        "Runway Gain",
                        "https://cdn1.iconfinder.com/data/icons/transport-outline-icons/85/Transports_01-Converted_72-512.png");
                    runwayGainContainer.appendChild(createdElementFromTemplate);
                }
                airportStores = response.Result.Data.Stores;

                //Fill Tables for Airport
                //Gates DataSource
                for (tableCounter = 0; tableCounter < 5; tableCounter ++) {
                    if (tableCounter < response.Result.Data.Gates.length) {
                        gateCodesCollection.push({ IDGate: response.Result.Data.Gates[tableCounter].IDGate });
                    } else {
                        break;
                    }
                }

                //Airlines Datasource
                for (tableCounter = 0; tableCounter < 5; tableCounter ++) {
                    if (tableCounter < response.Result.Data.Airlines.length) {
                        airlineCollection.push({ Name: response.Result.Data.Airlines[tableCounter ].Name });
                    } else {
                        break;
                    }
                }

                //Stores Datasource
                for (tableCounter = 0; tableCounter < response.Result.Data.Stores.length; tableCounter ++) {
                    if (tableCounter < 5) {
                        storesCollection.push({ Name: response.Result.Data.Stores[tableCounter ].Name });
                    }
                    storeGain += response.Result.Data.Stores[tableCounter].Rent;
                }
                createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, storeGain, "Ganancia de tiendas en el mes", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                storeGainElement.appendChild(createdElementFromTemplate);
                //Counts
                //Store Count
                //Gates Count
                //Flight Count last 7 days.
                //Ticket Count last 7 days.
                // 
                
                instance.ctrlActions.FillTableFromDataSource("airlineList", "", "", airlineCollection, true);
                instance.ctrlActions.FillTableFromDataSource("gateList", "", "", gateCodesCollection, true);
                instance.ctrlActions.FillTableFromDataSource("storeList", "", "", storesCollection, true);
                if (google && google.charts) {
                    google.charts.load('current', { 'packages': ['corechart'] });
                    google.charts.setOnLoadCallback(function() {
                        var options = {
                            title: 'Ganancias de tiendas del Aeropuerto',
                            width: 550,
                            height: 400,
                            pieHole: 0.4,
                            colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                        };

                        const map = new Map();
                        map.set("true", 1);
                        map.set("false", 0);

                        var storeCategoryCollection = new Map();
                        // Display the chart inside the <div> element with id="piechart"
                        var chart = new google.visualization.PieChart(document.getElementById('storesPieChart'));
                        var dataArray = [];
                        var currentStoreCategory;
                        var storeGain = 0;
                        for (var counter = 0; counter < airportStores.length; counter++) {
                            currentStoreCategory = airportStores[counter].Category.Description;
                            dataArray.push([airportStores[counter].Name, airportStores[counter].Rent]);
                            if (!storeCategoryCollection.get(currentStoreCategory)) {
                                storeCategoryCollection.set(currentStoreCategory, 1);
                            } else {
                                storeCategoryCollection.set(currentStoreCategory,
                                    storeCategoryCollection.get(currentStoreCategory) + 1);
                            }
                            storeGain += airportStores[counter].Rent;
                        }
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Name');
                        data.addColumn('number', 'Rent');
                        data.addRows(dataArray);
                        chart.draw(data, options);

                        //Map Chart
                        var mapData = google.visualization.arrayToDataTable([
                            ['Country', 'Popularity'],
                            ['Germany', 200]
                        ]);
                        var mapChartOptions = {};
                        var mapChart = new google.visualization.GeoChart(document.getElementById('worldMapChart'));
                        mapChart.draw(mapData, mapChartOptions);
                        
                        //Bar Chart
                        var storeCategoryData = [];
                        storeCategoryCollection.forEach(function(value, key, map) {
                            storeCategoryData.push([key, value]);
                        });
                        var categoryChartInstance =
                            new google.visualization.ColumnChart(document.getElementById('categoryChartContainer'));
                        var categoryChartDataTable = new google.visualization.DataTable();
                        var categoryChartOptions = {
                            title: 'Cantidad de tiendas por categoria en el Aeropuerto',
                            width: 550,
                            height: 400,
                            colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                        };
                        categoryChartDataTable.addColumn('string', 'Name');
                        categoryChartDataTable.addColumn('number', 'Cantidad');
                        categoryChartDataTable.addRows(storeCategoryData);
                        categoryChartInstance.draw(categoryChartDataTable, categoryChartOptions);


                        google.charts.load('current', { 'packages': ['corechart'] });
                        google.charts.setOnLoadCallback(drawVisualization);

                        function drawVisualization() {
                            // Some raw data (not necessarily accurate)
                            var data = google.visualization.arrayToDataTable([
                                ['Month', 'Bolivia', 'Ecuador', 'Madagascar', 'Papua New Guinea', 'Rwanda', 'Average'],
                                ['2004/05', 165, 938, 522, 998, 450, 614.6],
                                ['2005/06', 135, 1120, 599, 1268, 288, 682],
                                ['2006/07', 157, 1167, 587, 807, 397, 623],
                                ['2007/08', 139, 1110, 615, 968, 215, 609.4],
                                ['2008/09', 136, 691, 629, 1026, 366, 569.6]
                            ]);

                            var options = {
                                title: 'Monthly Coffee Production by Country',
                                vAxis: { title: 'Cups' },
                                hAxis: { title: 'Month' },
                                seriesType: 'bars',
                                series: { 5: { type: 'line' } },
                                width: 550,
                                height: 400
                            };

                            var chart = new google.visualization.ComboChart(document.getElementById('bigBarChart'));
                            chart.draw(data, options);
                        }
                    });
                }
        });


        //Store Gain
        //Ammount Of Stores
        //Ammount of Gates
        //List of flights.
        //
        //Show Location
    }
    this.setAirlineAdminDashboard = function() {
        var instance = this;
        instance.airlineInstance = UserSession.getAirlineSessionInstance();
        var airlineName = document.getElementById("airlineName");
        if (airlineName) {
            airlineName.innerText = instance.airlineInstance.Comercial_name;
        }
    }
    this.createScoreCard = function(templateElement, cardValue, cardLabel, cardImage) {
        var instance = this;
        var createdElementFromTemplate = document.createRange().createContextualFragment(templateElement.innerHTML);
        var currentCardValueElement = createdElementFromTemplate.querySelector(".scoreValue");
        var currentCardLabelElement = createdElementFromTemplate.querySelector(".scoreTitle");
        var currentCardImageElement = createdElementFromTemplate.querySelector(".scoreImage");
        if (currentCardValueElement) {
            currentCardValueElement.innerText = cardValue;
        }
        if (currentCardLabelElement) {
            currentCardLabelElement.innerText = cardLabel;
        }
        if (currentCardImageElement) {
            currentCardImageElement.src = cardImage;
        }
        return createdElementFromTemplate;
    };
    this.setGeneralAdminDashboard = function() {

    }

};


Dashboard.prototype.init = function() {
    var instance = this;
    var createdElementFromTemplate;
    var airportStores;
    var google = window.google || undefined;
    var generalScoreCardContainer = document.getElementById("generalScoreCardContainer");
    if (undefined !== google ) {
        if (google.charts) {
            google.charts.load('current', {'packages':['corechart']});
        }
        
    }

    var scoreCardTemplate = document.getElementById("scoreCard-template");
    var gatesGainContainer = document.getElementById("gates-gain");
    var gatesCountContainer = document.getElementById("gates-count");
    var runwayGainContainer = document.getElementById("runway-gain");
    
    if (generalScoreCardContainer && scoreCardTemplate) {
        //Creating an in-memory HTML for the scoreCards
        if (ApiService && typeof (ApiService) === "object") {
            ApiService.getFromAPI("dashboard/getGeneralReport?airportId=1", "",
                function(response) {
                    if (response.Result.Data.Stores.length > 0) {
                        createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, response.Result.Data.Stores.length, "Gates Count", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                        gatesCountContainer.appendChild(createdElementFromTemplate);
                    }

                    if (response.Result.Data.GatesGain) {
                        createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, response.Result.Data.GatesGain, "Gates Gain", "https://images.vexels.com/media/users/3/128926/isolated/preview/c60c97eba10a56280114b19063d04655-plane-airport-round-icon-by-vexels.png");
                        gatesGainContainer.appendChild(createdElementFromTemplate);
                    }

                    if (response.Result.Data.RunwayLandingGain) {
                        createdElementFromTemplate = instance.createScoreCard(scoreCardTemplate, response.Result.Data.RunwayLandingGain, "Runway Gain", "https://cdn1.iconfinder.com/data/icons/transport-outline-icons/85/Transports_01-Converted_72-512.png");
                        runwayGainContainer.appendChild(createdElementFromTemplate);
                    }
                    airportStores = response.Result.Data.Stores;
                    if (google && google.charts) {
                        
                        google.charts.setOnLoadCallback(function() {
                        var options = {
                                title:'Ganancias de tiendas del Aeropuerto', 
                                width:550, 
                                height:400,
                                pieHole: 0.4,
                                colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                        };

                        const map = new Map();
                        map.set("true", 1);
                        map.set("false", 0);

                        var storeCategoryCollection = new Map();
                        // Display the chart inside the <div> element with id="piechart"
                        var chart = new google.visualization.PieChart(document.getElementById('storesPieChart'));
                        var dataArray = [];
                        var currentStoreCategory;
                        var storeGain = 0;
                        for (var counter = 0; counter < airportStores.length; counter++) {
                            currentStoreCategory = airportStores[counter].Category.Description;
                            dataArray.push([airportStores[counter].Name, airportStores[counter].Rent]);
                            if (!storeCategoryCollection.get(currentStoreCategory)) {
                                storeCategoryCollection.set(currentStoreCategory, 1);
                            } else {
                                storeCategoryCollection.set(currentStoreCategory, storeCategoryCollection.get(currentStoreCategory) + 1);
                            }
                            storeGain += airportStores[counter].Rent;
                        }
                        let storeGainElement = document.getElementById("store-gain");
                        if (storeGainElement) {
                            storeGainElement.innerText = storeGain;
                        }
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Name');
                        data.addColumn('number', 'Rent');
                        data.addRows(dataArray);
                        chart.draw(data, options);


                        //Map Chart
                        var mapData = google.visualization.arrayToDataTable([
                            ['Country', 'Popularity'],
                            ['Germany', 200]
                        ]);
                        var mapChartOptions = {};
                        var mapChart = new google.visualization.GeoChart(document.getElementById('worldMapChart'));
                        mapChart.draw(mapData, mapChartOptions);


                        //Bar Chart
                        var storeCategoryData = [];
                        storeCategoryCollection.forEach(function(value, key, map) {
                            storeCategoryData.push([key, value]);
                        });
                        var categoryChartInstance = new google.visualization.ColumnChart(document.getElementById('categoryChartContainer'));
                        var categoryChartDataTable = new google.visualization.DataTable();
                        var categoryChartOptions = {
                            title:'Cantidad de tiendas por categoria en el Aeropuerto', 
                            width:550, 
                            height:400,
                            colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                        };
                        categoryChartDataTable.addColumn('string', 'Name');
                        categoryChartDataTable.addColumn('number', 'Cantidad');
                        categoryChartDataTable.addRows(storeCategoryData);
                        categoryChartInstance.draw(categoryChartDataTable, categoryChartOptions);


                        google.charts.load('current', {'packages':['corechart']});
                        google.charts.setOnLoadCallback(drawVisualization);

                        function drawVisualization() {
                            // Some raw data (not necessarily accurate)
                            var data = google.visualization.arrayToDataTable([
                                ['Month', 'Bolivia', 'Ecuador', 'Madagascar', 'Papua New Guinea', 'Rwanda', 'Average'],
                                ['2004/05',  165,      938,         522,             998,           450,      614.6],
                                ['2005/06',  135,      1120,        599,             1268,          288,      682],
                                ['2006/07',  157,      1167,        587,             807,           397,      623],
                                ['2007/08',  139,      1110,        615,             968,           215,      609.4],
                                ['2008/09',  136,      691,         629,             1026,          366,      569.6]
                            ]);

                            var options = {
                                title : 'Monthly Coffee Production by Country',
                                vAxis: {title: 'Cups'},
                                hAxis: {title: 'Month'},
                                seriesType: 'bars',
                                series: {5: {type: 'line'}},
                                width:550, 
                                height:400
                            };

                            var chart = new google.visualization.ComboChart(document.getElementById('bigBarChart'));
                            chart.draw(data, options);
                        }


                        
                        
                    });
                    }
                    
                    
                    console.log("This is the response from the dashboard file:" + response);
                });
        }
    }

    //Right Dashboard Container
    var dashboardRightContainer = $("#main-dashboard-right-container");
    //NavElements
    var generalReportBtn = $("#general-report-navbtn");
    var editAirportBtn = $("#editAirportNavBtn");
    var inactivateAirportBtn = $("#inactivateAirportNavBtn");
    var deactivateAirportBtn = $("#inactivateAirportNavBtn");
    var activateAirportBtn = $("#activateAirportNavBtn");
    var deleteAirportBtn = $("#deleteAirportNavBtn");
    var createStore = $("#createStoreNavBtn");
    var viewStores = $("#viewStores");
    var addGateBtn = $("#addGateNavBtn");
    var viewGatesBtn = $("#seeGatesNavBtn");
    var seeAirportsBtn = $("#seeAirportsNavBtn");
    var viewAirlinesBtn = $("#viewAirlinesNavBtn");
    var addCategoryBtn = $("#addCategoryNavBtn");
    var viewCategoriesBtn = $("#viewCategoryNavBtn");
    if (generalReportBtn) {
        generalReportBtn.on("click", function() {
            instance.changeCurrentShownSlideImmediatly("report-dashboard");
        });
    }

    ///*Airports*/

    ///*General Airport*/
    if (seeAirportsBtn) {
        seeAirportsBtn.on("click", function() {
            if (document.getElementById("viewAirportsContainer")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("viewAirportsContainer");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getViewAirportsHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("viewAirportsContainer");
                        }, 1000);
                    }
                });
            }
        });
    }
    if (editAirportBtn) {
        editAirportBtn.on("click", function() {
            if (document.getElementById("editAirportContainer")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("editAirportContainer");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getEditAirportHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("editAirportContainer");
                        }, 1000);
                    }
                });
            }
        });
    }

    ///*Stores*/
    if (createStore) {
        createStore.on("click", function() {
            if (document.getElementById("store-register")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("store-register");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getCreateStoreHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("store-register");
                        }, 1000);
                    }
                });
            }

            //instance.changeCurrentShownSlideWithSkeleton("store-register");
        });
    }
    if (viewStores) {
        viewStores.on("click", function() {
            if (document.getElementById("view-stores-container")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("view-stores-container");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getViewStoresHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("view-stores-container");
                        }, 1000);
                    }
                });
            }

            //instance.changeCurrentShownSlideWithSkeleton("store-register");
        });
    }
    
    ///*Categories*/
    if (addCategoryBtn) {
        addCategoryBtn.on("click", function() {
            if (document.getElementById("create-category-container")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("create-category-container");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getCreateCategoryHtml  ", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                                instance.changeCurrentShownSlideImmediatly("create-category-container");
                            }, 1000);
                    }
                });
            }
        });
    }
    if (viewCategoriesBtn) {
        viewCategoriesBtn.on("click", function() {
            if (document.getElementById("list-categories-container")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("list-categories-container");
            } else {
                //If the element doesn't exists, swap after retrieving content.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getListCategoriesHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("list-categories-container");
                        });
                        
                    }
                });
            }
        });
    }

    ///*Gates*/
    if (addGateBtn) {
        addGateBtn.on("click", function() {
            if (document.getElementById("add-gates-container")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("add-gates-container");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getAddGateHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("add-gates-container");
                        }, 1000);
                    }
                });
            }
        });
    }
    if (viewGatesBtn) {
        viewGatesBtn.on("click", function() {
            if (document.getElementById("view-gates-container")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("view-gates-container");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getViewGatesHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("view-gates-container");
                        }, 1000);
                    }
                });
            }
        });
    }

    ///*Airlines*/
    if (viewAirlinesBtn) {
        viewAirlinesBtn.on("click", function() {
            if (document.getElementById("view-airlines-container")) {
                //If the element already exists, just swap
                instance.changeCurrentShownSlideImmediatly("view-airlines-container");
            } else {
                //If the element doesn't exists, we must retrieve it.
                // Show Skeleton in the meantime
                instance.changeCurrentShownSlideImmediatly("loading-skeleton");
                DomHelper.getHtmlFromRoute("/getViewAirlinesHtml", "", function(response) {
                    if (dashboardRightContainer) {
                        dashboardRightContainer.append(response);
                        setTimeout(function() {
                            instance.changeCurrentShownSlideImmediatly("view-airlines-container");
                        }, 1000);
                    }
                });
            }
        });
    }
};

///-------------------------------------------------------------------------------------------------
/// <summary>   This will swap the content shown with the specified one </summary>
///
/// <remarks>   Celopez </remarks>
///
/// <param name="toChangeElementId"> Identifier for to change element. </param>
///
/// <returns>   . </returns>
///-------------------------------------------------------------------------------------------------
Dashboard.prototype.changeCurrentShownSlideImmediatly = function(toChangeElementId) {
    /**Show Skeleton */
    var toSwapElement = $("#" + toChangeElementId);
    if (toSwapElement) {
        //If the shown element is not already shown.
        if (!toSwapElement.hasClass("currentShownSlide")) {
            $(".currentShownSlide").hide();
            $(".currentShownSlide").removeClass("currentShownSlide");
            toSwapElement.fadeIn();
            toSwapElement.addClass("currentShownSlide");
        }
    }
}

Dashboard.prototype.changeCurrentShownSlideWithSkeleton = function(toChangeElementId) {
    /**Show Skeleton */
    var skeletonElement = $("#loading-skeleton");
    var toSwapElement = $("#" + toChangeElementId);
    if (toSwapElement) {
        //If the shown element is not already shown.
        if (!toSwapElement.hasClass("currentShownSlide")) {
            $(".currentShownSlide").hide();
            $(".currentShownSlide").removeClass("currentShownSlide");
            skeletonElement.fadeIn();
            setTimeout(function() {
                    skeletonElement.fadeOut();
                    toSwapElement.fadeIn();
                    toSwapElement.addClass("currentShownSlide");
                },
                2000);            
        }
    }
};

Dashboard.prototype.createScoreCard = function(templateElement, cardValue, cardLabel, cardImage) {
    var instance = this;
    var createdElementFromTemplate = document.createRange().createContextualFragment(templateElement.innerHTML);
    var currentCardValueElement = createdElementFromTemplate.querySelector(".scoreValue");
    var currentCardLabelElement = createdElementFromTemplate.querySelector(".scoreTitle");
    var currentCardImageElement = createdElementFromTemplate.querySelector(".scoreImage");
    if (currentCardValueElement) {
        currentCardValueElement.innerText = cardValue;
    }
    if (currentCardLabelElement) {
        currentCardLabelElement.innerText = cardLabel;
    }
    if (currentCardImageElement) {
        currentCardImageElement.src = cardImage;
    }
    return createdElementFromTemplate;
};

Dashboard.prototype.defineCurrentUserNavigation = function() {
    var sessionElement = sessionStorage.getItem("userSessionItem");
    
}


Dashboard.prototype.createStorePieChart = function(storeArray) {
    var options = {'title':'Ganancies de tiendas del Aeropuerto', 'width':550, 'height':400};

    // Display the chart inside the <div> element with id="piechart"
    var chart = new google.visualization.PieChart(document.getElementById('storesPieChart'));
    var dataArray = [];

    for (var counter = 0; counter < storeArray.length; counter++) {
        dataArray.push([storeArray[counter].Name, 50]);
    }

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Name');
    data.addColumn('number', 'Rent');
    data.addRows(dataArrasy);
    chart.draw(data, options);
};


$(document).ready(function() {
    var dashboardInstance = new Dashboard();
    dashboardInstance.initialize();
});




