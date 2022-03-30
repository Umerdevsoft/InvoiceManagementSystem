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
        url: '/Items/ItemOverviewList',
        dataType: 'json',
        success: function (allItems) {
            console.log(allItems);
            var myRow1;

            $.each(allItems, function (index, item) {
                myRow1 = '<tr><td class="col-1" style="text-align:center"> <input type="checkbox" value="' + item.id + '" name="checks" class="checkboxAll" id=""></td><td> <a>' + item.name + '</a></td> <td><a>' + item.description + '</a></td> <td><a>' + item.sellingPrice + '</a></td><td><a>' + item.unit + '</a></td></tr>';
                $('#t_Body').append(myRow1);
            });

            var table = $('#tblItems').DataTable();

            // Event listener to the two range filtering inputs to redraw on input
            $('#min, #max').keyup(function () {
                table.draw();
            });
        }
    });

    $("#delete_Multiple").click(function () {
        var ID;
        var object1 = {};
        var Arr2 = [];
        $.each($("input:checkbox[name='checks']:checked"), function () {
            ID = $(this).val();
            object1 = { id: ID };
            Arr2.push(object1);
        });

        console.log(Arr2);
        $.each(Arr2, function (index, item) {
            $.ajax({
                url: '/Items/ItemDeleteList',
                type: 'POST',
                datatype: 'json ',
                data: item,
                success: function (msg1) {
                    if (msg1 == "Something went Wrong, Plz Try Again") {
                        $("#divi1").append(msg1);
                    }
                    else {
                        $("#divi1").append(msg1);
                    }
                    $.ajax({
                        type: 'GET',
                        url: '/Customers/CustomersOverviewList',
                        dataType: 'json',
                        success: function (allitems) {
                            console.log(allitems);
                            $('#t_Body').empty();
                            myRow1 = '';
                            $.each(allitems, function (index, value) {
                                myRow1 = '<tr><td class="col-1" style="text-align:center"> <input type="checkbox" value="' + value.custID + '" name="check" class="checkboxAll" id=""></td><td> <a>' + value.customerDisplayName + '</a></td> <td><a>' + value.companyName + '</a></td> <td><a>' + value.email + '</a></td><td><a>' + value.workPhone + '</a></td><td><a></a></td><td><a></a></td></tr>';
                                $('#t_Body').append(myRow1);
                            });

                        }
                    });
                }
            });
        });

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