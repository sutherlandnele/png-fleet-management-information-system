
kendo.ui.TreeView.prototype.getCheckedItems = (function () {

    function getCheckedItems() {
        var nodes = this.dataSource.view();
        return getCheckedNodes(nodes);
    }

    function getCheckedNodes(nodes) {
        var node, childCheckedNodes;
        var checkedNodes = [];

        for (var i = 0; i < nodes.length; i++) {
            node = nodes[i];
            if (node.checked) {
                checkedNodes.push(node);
            }

            // to understand recursion, first
            // you must understand recursion
            if (node.hasChildren) {
                childCheckedNodes = getCheckedNodes(node.children.view());
                if (childCheckedNodes.length > 0) {
                    checkedNodes = checkedNodes.concat(childCheckedNodes);
                }
            }

        }

        return checkedNodes;
    }

    return getCheckedItems;
})();

(function ($, kendo) {
    //Extending the build in validator
    $.extend(true, kendo.ui.validator, {
        rules: {
            //to cater for unsupported compare validation
            equalto: function (input) {
                if (input.filter("[data-val-equalto-other]").length) {
                    var otherField = input.attr("data-val-equalto-other");
                    otherField = otherField.substr(otherField.lastIndexOf(".") + 1);
                    return input.val() === $("#" + otherField).val();
                }
                return true;
            }
        },
        messages: {
            equalto: function (input) {
                return input.attr("data-val-equalto");
            }
    
        }
    });
})(jQuery, kendo);

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
    return data;
};

//#region Global Ajax CRUD Functions

function ajaxCreateUpdate(eForm, id, controller, createAction, updateAction, redirectAction, wnd) {

    var validator = $(eForm).kendoValidator().data("kendoValidator");   
    var action = "";

    if (Number(id) > 0) {
        action = "/" + controller + "/" + updateAction;
    }
    else {
        action = "/" + controller + "/" + createAction;
    }  

    var formData = $(eForm).serializeObject();

    if (validator.validate()) {

        $.when($.ajax({
            type: "POST",
            url: action,
            data: AddAntiForgeryToken({ entityViewModel: formData }),
            dataType: "json",
            beforeSend: function () {

                //show progress bar
                if (wnd) {
                    kendo.ui.progress($("#wndProgressIndicator"), true);
                }
                else {
                    kendo.ui.progress($("#progressIndicator"), true);
                }
                
            }
        })).done(function (returndata) {
            //hide progress bar            
            if (wnd) {
                kendo.ui.progress($("#wndProgressIndicator"), false);
                wnd.close();
            }
            else {
                kendo.ui.progress($("#progressIndicator"), false);
            }


            if (returndata.isError) {
                App.notification.show({
                    message: returndata.message
                }, "error");
            }
            else {

                if (redirectAction) {                    
                    var newSrc = returndata.message;
                    window.location.href = document.referrer.replace(/(message=).*?(&)/, '$1' + newSrc + '$2');
                }
                else {
                    App.notification.show({
                        message: returndata.message
                    }, "success");
                }
            }

        });
    }

}

function ajaxCreateUpdateWithFileUpload(eForm, id, controller, createAction, updateAction, redirectAction, wnd) {

    var validator = $(eForm).kendoValidator().data("kendoValidator");
    var action = "";

    if (Number(id) > 0) {
        action = "/" + controller + "/" + updateAction;
    }
    else {
        action = "/" + controller + "/" + createAction;
    }

    var formData = new FormData($(eForm).get(0));    

    if (validator.validate()) {

        $.when($.ajax({
            type: "POST",
            url: action,
            data: AddAntiForgeryToken(formData),
            dataType: "json",
            contentType: false,
            processData: false,
            beforeSend: function () {

                //show progress bar
                if (wnd) {
                    kendo.ui.progress($("#wndProgressIndicator"), true);
                }
                else {
                    kendo.ui.progress($("#progressIndicator"), true);
                }

            }
        })).done(function (returndata) {
            //hide progress bar            
            if (wnd) {
                kendo.ui.progress($("#wndProgressIndicator"), false);
                wnd.close();
            }
            else {
                kendo.ui.progress($("#progressIndicator"), false);
            }


            if (returndata.isError) {
                App.notification.show({
                    message: returndata.message
                }, "error");
            }
            else {

                if (redirectAction) {
                    var newSrc = returndata.message;
                    window.location.href = document.referrer.replace(/(message=).*?(&)/, '$1' + newSrc + '$2');
                }
                else {
                    App.notification.show({
                        message: returndata.message
                    }, "success");
                }
            }

        });
    }

}

function ajaxDelete(entityId,controller,action) {

    var urlAction = "/" + controller + "/" + action;

    $.ajax({
        type: "POST",
        url: urlAction,
        data: AddAntiForgeryToken({ id: entityId }),
        dataType: "json",
        async: true,
        beforeSend: function (xhr) {
            //show progress bar
            kendo.ui.progress($("#progressIndicator"), true);
        },
        success: function (result, status, xhr) {
            if (result.isError) {
                App.notification.show({
                    message: result.message
                }, "error");
            }
            else {
                App.notification.show({
                    message: result.message
                }, "success");
            }
        },
        error: function (xhr, status, error) {           
            App.notification.show({
                message: "An error occured: " + xhr.status + " " + xhr.statusText
            }, "error");

        },
        complete: function (xhr, status) {
            kendo.ui.progress($("#progressIndicator"), false);
        }
    });
}

function ajaxReturnDelete(entityId, controller, action) {

    var urlAction = "/" + controller + "/" + action;

    return $.ajax({
        type: "POST",
        url: urlAction,
        data: AddAntiForgeryToken({ id: entityId }),
        dataType: "json",
        async: true,
        beforeSend: function (xhr) {
            //show progress bar
            kendo.ui.progress($("#progressIndicator"), true);
        },
        success: function (result, status, xhr) {
            if (result.isError) {
                App.notification.show({
                    message: result.message
                }, "error");
            }
            else {
                App.notification.show({
                    message: result.message
                }, "success");
            }
        },
        error: function (xhr, status, error) {
            App.notification.show({
                message: "An error occured: " + xhr.status + " " + xhr.statusText
            }, "error");

        },
        complete: function (xhr, status) {
            kendo.ui.progress($("#progressIndicator"), false);
        }
    });
}

//#endregion


//#region populate display info functions


function populateVehicleServiceInfoBox(id) {

    var urlAction = "/VehicleServiceManagement/GetVehicleServiceInformation";
    $.ajax({
        type: "POST",
        url: urlAction,
        data: { vehicleServiceId: id },
        dataType: "json",
        async: true,
        beforeSend: function (xhr) {
            //show progress bar
            kendo.ui.progress($("#progressIndicator"), true);
        },
        success: function (result, status, xhr) {
            if (!result.isError) {

                $("#vsServiceJobNumber").text(result.vehicleService.ServiceJobNumber);
                $("#vsStartDate").text(result.vehicleService.StartDate);
                $("#vsEndDate").text(result.vehicleService.EndDate);
                $("#vsIsAmountPaid").text(result.vehicleService.IsAmountPaid);
                $("#vsCost").text(result.vehicleService.Cost);
                $("#vsProvider").text(result.vehicleService.Provider);
                $("#vsServiceMechanic").text(result.vehicleService.ServiceMechanic);
                $("#vsIsIncidentService").text(result.vehicleService.IsIncidentService);
                $("#vsIsIncident").text(result.vehicleService.IsIncident);
            }
            else {

                $("#vsServiceJobNumber").text("");
                $("#vsStartDate").text("");
                $("#vsEndDate").text("");
                $("#vsIsAmountPaid").text("");
                $("#vsCost").text("");
                $("#vsProvider").text("");
                $("#vsServiceMechanic").text("");
                $("#vsIsIncidentService").text("");
                $("#vsIsIncident").text("");

            }
        },
        error: function (xhr, status, error) {
            alert("An error occured: " + xhr.status + " " + xhr.statusText);
        },
        complete: function (xhr, status) {
            kendo.ui.progress($("#progressIndicator"), false);
        }
    });
}



function populateContactInfoBox(id) {

    var urlAction = "/OrganisationManagement/GetContactInformation";
    $.ajax({
        type: "POST",
        url: urlAction,
        data: { contactDetailId : id },
        dataType: "json",
        async: true,
        beforeSend: function (xhr) {
            //show progress bar
            kendo.ui.progress($("#progressIndicator"), true);
        },
        success: function (result, status, xhr) {
            if (!result.isError) {

                $("#oContactName").text(result.contact.ContactName);
                $("#oCenter").text(result.contact.Center);
                $("#oContactPerson").text(result.contact.ContactPerson);
                $("#oStreetAddress").text(result.contact.StreetAddress);
                $("#oWebsite").text(result.contact.Website);
                $("#oFacsimile").text(result.contact.Facsimile);
                $("#oTelephone").text(result.contact.Telephone);
                $("#oMobile").text(result.contact.Mobile);
                $("#oEmail").text(result.contact.Email);
                $("#oComments").text(result.contact.Comments);
            }
            else {

                $("#oContactName").text("");
                $("#oCenter").text("");
                $("#oContactPerson").text("");
                $("#oStreetAddress").text("");
                $("#oWebsite").text("");
                $("#oFacsimile").text("");
                $("#oTelephone").text("");
                $("#oMobile").text("");
                $("#oEmail").text("");
                $("#oComments").text("");

            }
        },
        error: function (xhr, status, error) {
            alert("An error occured: " + xhr.status + " " + xhr.statusText);
        },
        complete: function (xhr, status) {
            kendo.ui.progress($("#progressIndicator"), false);
        }
    });
}


function populateOperatorInfoBox(id) {

    var urlAction = "/VehicleAllocation/GetOperatorInformation";
    $.ajax({
        type: "POST",
        url: urlAction,
        data: { operatorId: id },
        dataType: "json",
        async: true,
        beforeSend: function (xhr) {
            //show progress bar
            kendo.ui.progress($("#progressIndicator"), true);
        },
        success: function (result, status, xhr) {
            if (!result.isError) {

                $("#oDriverName").text(result.op.DriverName);
                $("#oDateOfBirth").text(result.op.DriverDateOfBirth);
                $("#oStaffNumber").text(result.op.staffNumber);
                $("#oLicenseNumber").text(result.op.DriverLicenceNumber);
                $("#oEmail").text(result.op.DriverEmail);
                $("#oMobile").text(result.op.DriverMobile);
            }
            else {

                $("#oDriverName").text("");
                $("#oDateOfBirth").text("");
                $("#oStaffNumber").text("");
                $("#oLicenseNumber").text("");
                $("#oEmail").text("");
                $("#oMobile").text("");
                //alert("An error occured: " + result.message);
            }
        },
        error: function (xhr, status, error) {
            //alert("An error occured: " + xhr.status + " " + xhr.statusText);
            $("#oDriverName").text("");
            $("#oDateOfBirth").text("");
            $("#oStaffNumber").text("");
            $("#oLicenseNumber").text("");
            $("#oEmail").text("");
            $("#oMobile").text("");
        },
        complete: function (xhr, status) {
            kendo.ui.progress($("#progressIndicator"), false);
        }
    });
}


function populateVehicleInfoBox(id) {

    var urlAction = "/VehicleManagement/GetVehicleInformation";
    $.ajax({
        type: "POST",
        url: urlAction,
        data: { vehicleId: id },
        dataType: "json",
        async: true,
        beforeSend: function (xhr) {
            //show progress bar
            kendo.ui.progress($("#progressIndicator"), true);
        },
        success: function (result, status, xhr) {
            if (!result.isError) {

                $("#vRegistrationNumber").text(result.vehicle.VehicleRegistrationNumber);
                $("#vModel").text(result.vehicle.VehicleModel);
                $("#vMake").text(result.vehicle.VehicleMake);
                $("#vType").text(result.vehicle.VehicleType);
                $("#vColor").text(result.vehicle.VehicleColor);
                $("#vCurrentMileage").text(result.vehicle.CurrentMileage);
                $("#vCondition").text(result.vehicle.VehicleCondition);
                $("#vStatus").text(result.vehicle.VehicleStatus);
                $("#vBusinessGroup").text(result.vehicle.BusinessGroup);
                $("#vCenter").text(result.vehicle.Center);

            }
            else {

                $("#vRegistrationNumber").text("");
                $("#vModel").text("");
                $("#vMake").text("");
                $("#vType").text("");
                $("#vColor").text("");
                $("#vCurrentMileage").text("");
                $("#vCondition").text("");
                $("#vStatus").text("");
                $("#vBusinessGroup").text("");
                $("#vCenter").text("");
                
            }
        },
        error: function (xhr, status, error) {
            //alert("An error occured: " + xhr.status + " " + xhr.statusText);

            $("#vRegistrationNumber").text("");
            $("#vModel").text("");
            $("#vMake").text("");
            $("#vType").text("");
            $("#vColor").text("");
            $("#vCurrentMileage").text("");
            $("#vCondition").text("");
            $("#vStatus").text("");
            $("#vBusinessGroup").text("");
            $("#vCenter").text("");


        },
        complete: function (xhr, status) {
            kendo.ui.progress($("#progressIndicator"), false);
        }
    });
}


function setGridFormSubmitNotification() {
    //check for Navigation Timing API support
    if (window.performance) {
        if (performance.navigation.type === performance.navigation.TYPE_RELOAD || performance.navigation.type === performance.navigation.TYPE_BACK_FORWARD) {
            App.notificationMessage = "NA"; //prevent message from appearing if browser is refreshed or back/forward button is pressed
        }
    }

    if (App.notificationMessage !== "NA") {
        if (App.notificationIsError === "True") {
            App.notification.show({
                message: App.notificationMessage
            }, "error");
        }
        else {
            App.notification.show({
                message: App.notificationMessage
            }, "success");
        }
    }
}


//#endregion






