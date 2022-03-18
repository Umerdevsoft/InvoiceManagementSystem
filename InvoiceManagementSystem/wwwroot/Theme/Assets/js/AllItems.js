 $(document).ready(function () {
        $('#ItemTable').DataTable({
            "ajax": {
                "url": "/Items/AllItems",
                "type": "GET",
                "datatype": "json",
            },
            columns: [
                { "Data": "Type" },
                { "Data": "Name" },
                { "Data": "Unit" },
                { "Data": "SellingPrice" },
                { "Data": "Description" },
                { "Data": "Tax" }
            ]
        });
       
    });