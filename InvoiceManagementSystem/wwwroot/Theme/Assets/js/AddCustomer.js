$(document).ready(function () {
    validation();
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

        $('#txtSalulation').val("");
        $('#txtFirstName').val("");
        $('#txtLastName').val("");
        $('#txtCompanyName').val("");
        $('#txtCustomerDisplayName').val("");
        $('#CustomerEmail').val("");
        $('#txtWorkingPhone').val("");
        $('#txtmobile').val("");
        $('#billAttention').val("");
        $('#shipAttention').val("");
        $('#billAddressStreet1').val("");
        $('#shipAddressStreet1').val("");
        $('#billAddressStreet2').val("");
        $('#shipAddressStreet2').val("");
        $('#billCity').val("");
        $('#shipCity').val("");
        $('#billZipCode').val("");
        $('#shipZipCode').val("");
        $('#billPhone').val("");
        $('#shipPhone').val("");
        $('#billFax').val("");
        $('#shipFax').val("");

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

function GetCurrency() {
    $.ajax({
        type: "GET",
        url: "/Customers/CurrencyData",
        data: "{}",
        success: function (data) {
            var s = '<option value ="-1">Please Select a Currency </option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].id + '" >' + data[i].currencyName + '</option>';
            }
            $("#inputChangeCurrence").html(s);
        }
    });
}

function validation() {
    $("#btnsubmit").click(function () {
        var msgsalulation = "Please Enter The Salulation";
        var msgfirstname = "Please Enter The FirstName";
        var msglastname = "Please Enter The LastName";
        var msgcompanyname = "Please Enter the CompanyName";
        var msgcustomername = "Please Enter The Customer Name";
        var msgcustomeremail = "Please Enter The Customer Email";
        var msgcustomerworkphone = "Please Enter The Working Phone";
        var msgcustomerMobile = "Please Enter The Mobile Number";
        var msgcurreny = "Please select the Curreny";
        var msgaddressattention = "Please Enter The  Attention";
        var msgcountryaddress = "Please select  Country/Region";
        var msgaddressaddress = "Please Enter  the Address";
        var msgcityaddress = "Please Enter  the City";
        var msgstateaddress = "Please Select  the State";
        var msgzipcodeaddress = "Please Enter  the Zipcode";
        var msgphoneaddress = "Please Enter the Phone";
        var msgfaxaddress = "Please Enter the fax";
        var msgshippingattention = "Please Enter The  Attention";
        var msgcountryshipping = "Please select  Country/Region";
        var msgaddressshipping = "Please Enter  the Address";
        var msgcityshipping = "Please Enter  the City";
        var msgstateshipping = "Please Select  the State";
        var msgzipcodeshipping = "Please Enter  the Zipcode";
        var msgphoneshipping = "Please Enter the Phone";
        var msgfaxshipping = "Please Enter the fax";
        var msgEmail = "Please Enter the Email";
        var msgworkplace = "Please Enter the Work Place";
        if ($.trim($("#txtSalulation").val()) == "") {
            alert(msgsalulation);
        }
        if ($.trim($("#txtFirstName").val()) == "") {
            alert(msgfirstname);
        }
        if ($.trim($("#txtLastName").val()) == "") {
            alert(msglastname);
        }
        if ($.trim($("#txtCompanyName").val()) == "") {
            alert(msgcompanyname);
        }
        if ($.trim($("#txtCustomerDisplayName").val()) == "") {
            alert(msgcustomername);
        }
        if ($.trim($("#txtCustomerDisplayName").val()) == "") {
            alert(msgcustomername);
        }
        if ($.trim($("#CustomerEmail").val()) == "") {
            alert(msgcustomeremail);
        }
        if ($.trim($("#txtWorkingPhone").val()) == "") {
            alert(msgcustomerworkphone);
        }
        if ($.trim($("#txtmobile").val()) == "") {
            alert(msgcustomerMobile);
        }
        if ($.trim($("#inputChangeCurrence").val()) == "") {
            alert(msgcurreny);
        }
        if ($.trim($("#billAttention").val()) == "") {
            alert(msgaddressattention);
        }
        if ($.trim($("#shipAttention").val()) == "") {
            alert(msgshippingattention);
        }
        if ($.trim($("#billCounrtyRegion").val()) == "") {
            alert(msgcountryaddress);
        }
        if ($.trim($("#shipCounrtyRegion").val()) == "") {
            alert(msgcountryshipping);
        }
        if ($.trim($("#billAddressStreet1").val()) == "") {
            alert(msgaddressaddress);
        }
        if ($.trim($("#billAddressStreet2").val()) == "") {
            alert(msgaddressaddress);
        }
        if ($.trim($("#shipAddressStreet1").val()) == "") {
            alert(msgaddressshipping);
        }
        if ($.trim($("#shipAddressStreet2").val()) == "") {
            alert(msgaddressshipping);
        }
        if ($.trim($("#billCity").val()) == "") {
            alert(msgcityaddress);
        }
        if ($.trim($("#shipCity").val()) == "") {
            alert(msgcityshipping);
        }
        if ($.trim($("#billState").val()) == "") {
            alert(msgstateaddress);
        }
        if ($.trim($("#shipState").val()) == "") {
            alert(msgstateshipping);
        }
        if ($.trim($("#billZipCode").val()) == "") {
            alert(msgzipcodeaddress);
        }
        if ($.trim($("#shipZipCode").val()) == "") {
            alert(msgzipcodeshipping);
        }
        if ($.trim($("#billPhone").val()) == "") {
            alert(msgphoneaddress);
        }
        if ($.trim($("#shipPhone").val()) == "") {
            alert(msgphoneshipping);
        }
        if ($.trim($("#billFax").val()) == "") {
            alert(msgfaxaddress);
        }
        if ($.trim($("#shipFax").val()) == "") {
            alert(msgfaxshipping);
        }
        if ($.trim($("#modaltxtSalulation").val()) == "") {
            alert(msgsalulation);
        }
        if ($.trim($("#modaltxtFirstName").val()) == "") {
            alert(msgfirstname);
        }
        if ($.trim($("#modaltxtLastName").val()) == "") {
            alert(msglastname);
        }
        if ($.trim($("#modaltxtEmail").val()) == "") {
            alert(msgEmail);
        }
        if ($.trim($("#modaltxtWorkplace").val()) == "") {
            alert(msgEmail);
        }
        if ($.trim($("#modaltxtMobile").val()) == "") {
            alert(msgcustomerMobile);
        }


    });
}