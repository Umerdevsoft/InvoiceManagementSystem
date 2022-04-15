$(document).ready(function () {
    Validation();
    $("#btnSaveItems").click(function (e) {
        var Type = $("#optradio").val();
        var Name = $("#txtitemsName").val();
        var Unit = $("#selectUnit").val();
        var SellingPrice = $("#txtsellingPrice").val();
        var Description = $("#txtDescription").val();
        var Tax = $("#selectTax").val();

        var obj = [
            Type = Type,
            Name = Name,
            Unit = Unit,
            SellingPrice = SellingPrice,
            Description = Description,
            Tax = Tax
        ];

        alert(obj);
        $.ajax({
            url: "/Items/AddItems",
            type: "POST",
            data: $("#ADDITEMFORM").serialize(obj),
            success: function (msg) {
                $("#msg").show()
                $("#msg").html(msg)
                $("#optradio").attr('Checked', false);
                $("#txtitemsName").val("");
                $("#selectUnit").val("-1");
                $("#txtsellingPrice").val("");
                $("#txtDescription").val("");
                $("#selectTax").val("-1");

            },
            error: function (err) {
                console.log(err);
            },

        });

    });
});
function Validation() {
    $("#btnSaveItems").click(function () {
        var msgtype = "Please Select the type";
        var msgitemName = "Please Enter the Item Name";
        var msgunit = "Please Select the Unit";
        var msgsellingprice = "Please Enter the Selling Price";
        var msgdescription = "Please Enter the Description";
        var msgtax = "Please select selectTax";
        if ($('input[name="type"]:checked').length == 0) {
            alert(msgtype);
        }
        if ($.trim($("#txtitemsName").val()) == "") {
            alert(msgitemName);
        }
        if ($.trim($("#selectUnit").val()) == "") {

            alert(msgunit);
        }
        if ($.trim($("#txtsellingPrice").val()) == "") {
            alert(msgsellingprice);
        }
        if ($.trim($("#txtDescription").val()) == "") {
            alert(msgdescription);
        }
        if ($.trim($("#selectTax").val()) == "") {
            alert(msgtax);
        }
    });
}
