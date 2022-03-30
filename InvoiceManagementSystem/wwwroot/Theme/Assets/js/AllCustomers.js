$.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        var min = parseInt($('#min').val(), 10);
        var max = parseInt($('#max').val(), 10);
        var age = parseFloat(data[3]) || 0; // use data for the age column

        if ((isNaN(min) && isNaN(max)) ||
            (isNaN(min) && age <= max) ||
            (min <= age && isNaN(max)) ||
            (min <= age && age <= max)) {
            return true;
        }
        return false;
    }
);

$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/Customers/CustomersOverviewList',
        dataType: 'json',
        success: function (allCustomers) {
            console.log(allCustomers);
            var myRow;

            $.each(allCustomers, function (index, item) {
                myRow = '<tr><td class="col-1" style="text-align:center"> <input type="checkbox" value="' + item.custID + '" name="check" class="checkboxAll" id=""></td><td> <a>' + item.customerDisplayName + '</a></td> <td><a>' + item.companyName + '</a></td> <td><a>' + item.email + '</a></td><td><a>' + item.workPhone + '</a></td><td><a></a></td><td><a></a></td></tr>';
                $('#t_Body').append(myRow);
            });

            var table = $('#tblItems').DataTable();

            //Event listener to the two range filtering inputs to redraw on input
            $('#min, #max').keyup(function () {
                table.draw();
            });
        }
    });

    $("#Delete_Multiple").click(function () {
        var C_ID;
        var object2 = {};
        var Arr3 = [];

        $.each($("input:checkbox[name='check']:checked"), function () {
            C_ID = $(this).val();
            object2 = { custID: C_ID };
            console.log(object2);
            Arr3.push(object2);
        });

        console.log(Arr3);
        var myMsg;

        $.each(Arr3, function (index, value) {
            $.ajax({
                url: '/Customers/CustomersDeleteList',
                type: 'POST',
                datatype: 'json ',
                data: value,
                success: function (msg) {
                    if (msg == "Something went Wrong, Plz Try Again") {
                        $("#divi").append(msg);
                    }
                    else {
                        $("#divi").append(msg);
                    }
                    $.ajax({
                        type: 'GET',
                        url: '/Customers/CustomersOverviewList',
                        dataType: 'json',
                        success: function (allCustomers) {
                            console.log(allCustomers);
                            myRow = '';
                            $('#t_Body').empty();
                            $.each(allCustomers, function (index, item) {
                                myRow = '<tr><td class="col-1" style="text-align:center"> <input type="checkbox" value="' + item.custID + '" name="check" class="checkboxAll" id=""></td><td> <a>' + item.customerDisplayName + '</a></td> <td><a>' + item.companyName + '</a></td> <td><a>' + item.email + '</a></td><td><a>' + item.workPhone + '</a></td><td><a></a></td><td><a></a></td></tr>';
                                $('#t_Body').append(myRow);
                            });

                            //var table = $('#tblItems').DataTable();

                            // //Event listener  to the two range filtering inputs to redraw on input
                            //$('#min, #max').keyup(function () {
                            //    table.draw();
                            //});
                        }
                    });

                }
            });

        });


        //location.reload();
    });


    $("#selectAll").click(function () {
        if (this.checked) {
            $('.checkboxAll').each(function () {
                $(".checkboxAll").prop('checked', true);
            })
        } else {
            $('.checkboxAll').each(function () {
                $(".checkboxAll").prop('checked', false);
            })
        }
    });

});