 $(document).ready(function () {
        loadData();
        HideandShow();
        AddSalePerson();
        UpdateSalePerson();
    });

    //Hide and Show Function
    function HideandShow() {
        $("#SalesForm").hide();

        $("#btnnewsaleperson").click(function () {
            $("#SalesForm").show();

        });

    }

    function loadData() {
        $.ajax({
            url: "/Invoices/SalesPersonList",
            type: "GET",
            dataType: "json",
            success: function (result1) {
                var html = '';
                $.each(result1, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.name + '</td>';
                    html += '<td>' + item.email + '</td>';
                    html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';

                    html += '</tr>';
                });
            $('tbody').html(html);
            },
        error: function (errormessage) {
            alert(errormessage.responseText);
        },
        });
    }

    //Add SalesPerson Function
    function AddSalePerson() {
        $("#btnSalepersonSave").click(function () {
            
            var obj = {
                Name: $("#txtnamesales").val(),
                Email: $("#txtemailsales").val()
            };
            $.ajax({
                url: "/Invoices/SalesPersons",
                type: "POST",
                data: obj,
                dataType: "Json",
                success: function (result) {
                   
                    if (result == "Sales Person is already exist") {
                        alert(result);
                    }
                    else {
                        loadData();
                        $("#txtnamesales").val("");
                        $("#txtemailsales").val("");
                        $("#SalePersonModel").show();
                        $("#SalesForm").hide();

                    }
                   
                }
                

            });

        });
        

     
    }

    //function getbyID(Id) {
    //    $('#txtnamesales').css('border-color', 'lightgrey');
    //    $('#txtemailsales').css('border-color', 'lightgrey');
       
    //    $.ajax({
    //        url: "/Invoices/SalesPersonsByID/" + Id,
    //        typr: "GET",
    //        contentType: "application/json;charset=UTF-8",
    //        dataType: "json",
    //        success: function (result) {
    //            $('#txtnamesales').val(result.name);
    //            $('#txtemailsales').val(result.email);
                
    //        },
    //        error: function (errormessage) {
    //            alert(errormessage.responseText);
    //        }
    //    });
    //    return false;
    //}

    //function UpdateSalePerson() {
    //    $("#btnSalepersonSave").click(function () {

    //        var obj = {
    //            Name: $("#txtnamesales").val(),
    //            Email: $("#txtemailsales").val()
    //        };

    //        $.ajax({
    //            url: "/Invoices/SalesPersonUpdate",
    //            data: obj,
    //            type: "POST",
    //            contentType: "application/json;charset=utf-8",
    //            dataType: "json",
    //            success: function (result) {
    //                loadData();
    //                $("#txtnamesales").val(""),
    //                    $("#txtemailsales").val("")
    //            },
    //            error: function (errormessage) {
    //                alert(errormessage.responseText);
    //            }


    //    });
        
    //}