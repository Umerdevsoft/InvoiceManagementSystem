$(document).ready(function () {
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
