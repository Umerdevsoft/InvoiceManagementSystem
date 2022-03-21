$(document).ready(function () {
    cache: false
    $('.Single').click(function () {
        $('.target').hide();
        $('#div' + $(this).attr('target')).show();
    });

    var array = [];
    var objCon = {};
    var custId;

    $("#add-row").click(function () {
        var salutation = $("#modaltxtSalulation").val();
        var firstName = $("#modaltxtFirstName").val();
        var lastName = $("#modaltxtLastName").val();
        var Email = $("#modaltxtEmail").val();
        var workPlace = $("#modaltxtWorkplace").val();
        var mobile = $("#modaltxtMobile").val();

        $(".table tbody tr").last().after(
            '<tr>' +
            '<td>' + salutation + '</td>' +
            '<td>' + firstName + '</td>' +
            '<td>' + lastName + '</td>' +
            '<td>' + Email + '</td>' +
            '<td>' + workPlace + '</td>' +
            '<td>' + mobile + '</td>' +
            '</tr>'


        );

        objCon = { C_P_Id: 0, C_P_Salulation: salutation, C_P_FirstName: firstName, C_P_LastName: lastName, C_P_Email: Email, C_P_WorkPlace: workPlace, C_P_Mobile: mobile, C_P_CustID: 0 };
        console.log(objCon);
        array.push(objCon);
        console.log(array);
        $("#modaltxtSalulation").val("");
        $("#modaltxtFirstName").val("");
        $("#modaltxtLastName").val("");
        $("#modaltxtEmail").val("");
        $("#modaltxtWorkplace").val("");
        $("#modaltxtMobile").val("");

    });

    $("#btnsubmit").click(function myfunction() {
        var c_Id = 0;
        var c_Salutaion = $("#txtSalulation").val();
        var c_FirstName = $("#txtFirstName").val();
        var c_LastName = $("#txtLastName").val();
        var c_CompanyName = $("#txtCompanyName").val();
        var c_CustomerDisplayName = $("#txtCustomerDisplayName").val();
        var c_CustomerEmail = $("#CustomerEmail").val();
        var c_WorkingPhone = $("#txtWorkingPhone").val();
        var c_Mobile = $("#txtmobile").val();
        var c_Currency = $("#txtCurrency").val();

        //var b_Id = 0;
        //var b_Attention = $("#billAttention").val();
        //var b_Country_Region = $("#billCounrtyRegion").val();
        //var b_Address_Street1 = $("#billAddressStreet1").val();
        //var b_Address_Street2 = $("#billAddressStreet2").val();
        //var b_City = $("#billCity").val();
        //var b_State = $("#billState").val();
        //var b_ZipCode = $("#billZipCode").val();
        //var b_Phone = $("#billPhone").val();
        //var b_Fax = $("#billFax").val();

        var obj = { CustID: c_Id, Salutation: c_Salutaion, FirstName: c_FirstName, LastName: c_LastName, CompanyName: c_CompanyName, CustomerDisplayName: c_CustomerDisplayName, Email: c_CustomerEmail, WorkPhone: c_WorkingPhone, Mobile: c_Mobile, Currency: c_Currency };
        //var obj1 = { Billing_Id: b_Id, B_Attention: b_Attention, B_Country_Region: b_Country_Region, B_Address_Street1: b_Address_Street1, B_Address_Street2: b_Address_Street2, B_City: b_City, B_State: b_State, B_ZipCode: b_ZipCode, B_Phone: b_Phone, b_Fax: b_Fax };

        $.ajax({
            url: '/Customers/AddCustomer',
            type: 'POST',
            datatype: 'json ',
            data: obj,
            success: function (userId) {
                //$("#msg").html(msg);
                console.log(userId);

                custId = userId;

                var b_Id = 0;
                var b_CustID = userId;
                var b_Attention = $("#billAttention").val();
                var b_Country_Region = $("#billCounrtyRegion").val();
                var b_Address_Street1 = $("#billAddressStreet1").val();
                var b_Address_Street2 = $("#billAddressStreet2").val();
                var b_City = $("#billCity").val();
                var b_State = $("#billState").val();
                var b_ZipCode = $("#billZipCode").val();
                var b_Phone = $("#billPhone").val();
                var b_Fax = $("#billFax").val();


                var obj1 = { Billing_Id: b_Id, B_Attention: b_Attention, B_Country_Region: b_Country_Region, B_Address_Street1: b_Address_Street1, B_Address_Street2: b_Address_Street2, B_City: b_City, B_State: b_State, B_ZipCode: b_ZipCode, B_Phone: b_Phone, B_Fax: b_Fax, B_CustID: b_CustID };

                $.ajax({
                    url: '/Customers/AddBilling',
                    type: 'POST',
                    datatype: 'json ',
                    data: obj1,
                    success: function (msg) {
                        $("#msg1").html(msg);

                        var s_Id = 0;
                        var s_CustID = custId;
                        var s_Attention = $("#shipAttention").val();
                        var s_Country_Region = $("#shipCounrtyRegion").val();
                        var s_Address_Street1 = $("#shipAddressStreet1").val();
                        var s_Address_Street2 = $("#shipAddressStreet2").val();
                        var s_City = $("#shipCity").val();
                        var s_State = $("#shipState").val();
                        var s_ZipCode = $("#shipZipCode").val();
                        var s_Phone = $("#shipPhone").val();
                        var s_Fax = $("#shipFax").val();

                        var obj2 = { Shipping_Id: s_Id, S_Attention: s_Attention, S_Country_Region: s_Country_Region, S_Address_Street1: s_Address_Street1, s_Address_Street2: s_Address_Street2, s_City: s_City, S_State: s_State, S_ZipCode: s_ZipCode, S_Phone: s_Phone, S_Fax: s_Fax, S_CustID: s_CustID };

                        $.ajax({
                            url: '/Customers/AddShipping',
                            type: 'POST',
                            datatype: 'json ',
                            data: obj2,
                            success: function (msg) {
                                $("#msg2").html(msg);
                                console.log();
                                var MyArr = array;
                                //console.log(MyArr);
                                //contactPersonViewModels = JSON.stringify(MyArr);
                                //contactPersonViewModels = JSON.stringify({ 'contactPersonViewModels': MyArr });
                                //console.log(contactPersonViewModels);
                                //var objCon1=objCon
                                //console.log(objCon1);
                                $.each(MyArr, function (index, item) {
                                    console.log(item);
                                    var id = custId;
                                    item.C_P_CustID = id;
                                    $.ajax({

                                        url: '/Customers/AddContactPerson',
                                        type: 'POST',
                                        datatype: 'json ',
                                        data: item,
                                        success: function (msg) {
                                            $("#msg3").html(msg);
                                        }
                                    });
                                });
                            }
                        });
                    }

                });
            }
        });

        //$.ajax({
        //    url: '/Customers/AddBilling',
        //    type: 'POST',
        //    datatype: 'json ',
        //    data: obj1,
        //    success: function (msg) {
        //        $("#msg1").html(msg);


        //    },

        //});

    });

    //$("#btnsubmit").click(function myfunction() {
    //    var b_Id = 0;
    //    var b_Attention = $("#billAttention").val();
    //    var b_Country_Region = $("#billCounrtyRegion").val();
    //    var b_Address_Street1 = $("#billAddressStreet1").val();
    //    var b_Address_Street2 = $("#billAddressStreet2").val();
    //    var b_City = $("#billCity").val();
    //    var b_State = $("#billState").val();
    //    var b_ZipCode = $("#billZipCode").val();
    //    var b_Phone = $("#billPhone").val();
    //    var b_Fax = $("#billFax").val();

    //    var obj1 = { Billing_Id: b_Id, B_Attention: b_Attention, B_Country_Region: b_Country_Region, B_Address_Street1: b_Address_Street1, B_Address_Street2: b_Address_Street2, B_City: b_City, B_State: b_State, B_ZipCode: b_ZipCode, B_Phone: b_Phone, b_Fax: b_Fax };


    //    $.ajax({
    //        url: '/Customers/AddBilling',
    //        type: 'POST',
    //        datatype: 'json ',
    //        data: obj1,
    //        success: function (msg) {
    //           /* $("#msg").html(msg);*/
    //        }
    //    });
    //});

});