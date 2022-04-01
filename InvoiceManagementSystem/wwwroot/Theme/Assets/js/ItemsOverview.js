   $(document).ready(function () {
        function loop(allItems) {
            var myRow;
            var myCard;
            $.each(allItems, function (index, item) {

                myRow = '<tr class="upd" target="' + item.id + '"><td id="updDiv"><div target="' + item.id + '"  class="icheck-primary"> <input type="checkbox" value="" class="master' + item.id + '" id="check"> </div></td><td class="mailbox-name"><a>' + item.name + '</a></td></tr>';
                $('#MailBoxTable').append(myRow);
                myCard = '<div class="card" id="card' + item.id + '" style="display:none"><div class="card-header" data-card-widget="collapse"><h1>' + item.name + '</h1> <h3 class="card-title">Overview</h3><div class="card-tools"><div class="row"><input type="text" id="divInput' + item.id + '" value="' + item.id + '" style="display:none"><div id="' + item.id + '" class="divUpdate  col" target="' + item.id + '"><a type="button" id="btnUpdate' + item.id + '" target="' + item.id + '" class="btn btn-tool" data-toggle="modal" data-target=".bd-example-modal-lg"><i class="fas fa-edit"></i></a></div><div id="" class="divDelete col" target="' + item.id + '"><a type="button" id="btnDelete' + item.id + '" target="' + item.id + '" class="btn btn-tool"><i class="fas fa-trash"></i></a></div></div></div></div><div class="card-body"><div class="row"><div class="col-4">Item type</div><div class="col-8"><b>' + item.type + '</b></div></div><div class="row"><div class="col-4">Created Source</div><div class="col-8"><b></b></div></div><br /><div class="row"><div class="col-4"><b>Sales Information</b></div></div><div class="row"><div class="col-4">Selling Price</div><div class="col-8"><b>PKR ' + item.sellingPrice + '</b></div></div><div class="row"><div class="col-4">Description</div><div class="col-8">' + item.description + '</div></div></div></div>'
                $('#myDisplay').append(myCard);

            });
        }

        $.ajax({
            type: 'GET',
            url: '/Items/ItemOverviewList',
            dataType: 'json',
            success: function (allItems) {
                console.log(allItems);
                loop(allItems);

                $('.icheck-primary').click(function () {
                    if ($('.master' + $(this).attr('target')).is(":checked")) {
                        $('#card' + $(this).attr('target')).show();
                    }
                    else {
                        $('#card' + $(this).attr('target')).hide();
                    }
                });

                /*delete button--------------------------------------------------------------------------------------*/
                $('.divDelete').click(function () {
                    $('#btnDelete' + $(this).attr('target')).show(function () {

                        var proceed = confirm("do you want to Delete An item ?");
                        if (proceed) {
                            var Div_id = $('#divInput' + $(this).attr('target')).val();
                            console.log(Div_id);
                            var objDelete = { id: Div_id };
                            console.log(objDelete);
                            $.ajax({
                                type: 'POST',
                                url: '/Items/ItemDelete',
                                data: objDelete,
                                success: function (msg) {
                                    objDelete = {};
                                    location.reload();
                                }
                            });
                        }
                        else {
                            location.reload();
                        }
                    });
                });
                //--------------------------------------------------------------------------------------------------------------

                $('.divUpdate').click(function () {
                    $('#btnUpdate' + $(this).attr('target')).show(function () {
                        DivUpdate_Id = $('#divInput' + $(this).attr('target')).val();
                        var objUpdate = { id: DivUpdate_Id };
                        $.ajax({
                            type: 'GET',
                            url: '/Items/EditItems',
                            data: objUpdate,
                            success: function (item) {
                                //if (item.type == "Goods") {
                                //    $("#radioDiv1").prop("checked", true);
                                //    $("#radioDiv2").prop("checked", false);
                                //    //var item_Type = $(".radioDiv1").val();
                                //}
                                //else {
                                //    $("#radioDiv1").prop("checked", false);
                                //    $("#radioDiv2").prop("checked", true);
                                //    //var item_Type = $(".radioDiv2").val();
                                //}
                                $('#txtitemsName').val(item.name);
                                $('#txtItemsUnit').val(item.unit);
                                $('#txtsellingPrice').val(item.sellingPrice);
                                $('#txtDescription').val(item.description);
                                $('#txtItemTax').val(item.tax);
                            }
                        });


                    });
                });

                $('#btn_Update').click(function () {

                    var item_Type = $('input[name="optradio"]:checked').val();
                    var item_Name = $('#txtitemsName').val();
                    var item_Unit = $('#txtItemsUnit').val();
                    var item_SellingPrice = $('#txtsellingPrice').val();
                    var item_Description = $('#txtDescription').val();
                    var item_Tax = $('#txtItemTax').val();

                    var objUpdatePost = { id: DivUpdate_Id, type: item_Type, name: item_Name, unit: item_Unit, sellingPrice: item_SellingPrice, description: item_Description, tax: item_Tax };
                    $.ajax({
                        type: 'POST',
                        url: '/Items/EditItems_Post',
                        data: objUpdatePost,
                        success: function (msg) {
                            location.reload();
                            $("#radioDiv1").prop("checked", false);
                            $("#radioDiv2").prop("checked", false);
                            $('#txtitemsName').val("");
                            $('#txtItemsUnit').val("");
                            $('#txtsellingPrice').val("");
                            $('#txtDescription').val("");
                            $('#txtItemTax').val("");
                        }
                    });
                });
            },
            error: function () {
                /* $('#termoneError').text('An error occurred');*/
            }
        });
    });
