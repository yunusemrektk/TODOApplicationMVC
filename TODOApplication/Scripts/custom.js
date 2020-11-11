
$(function () {
    $("#tblContents").DataTable({
        "columnDefs": [{ type: 'date-uk', targets: 1 }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
    $("#tblContents").on("click", ".btnContentSil", function () {
        var btn = $(this);
        bootbox.confirm("İçeriği silmek istediğinize emin misiniz ?", function (result) {

            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Home/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }

        });

    }); 

});

$(function () {
    
    var dataTable = $("#tblContentsToday").DataTable({

        "columnDefs": [{ type: 'date-uk', targets: 1 }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },

    });


    $("#tblContentsToday").on("click", ".btnContentSilToday", function () {
        var btn = $(this);
        bootbox.confirm("İçeriği bugünden silmek istediğinize emin misiniz ?", function (result) {

            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Today/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }

        });



    });
});

$(function () {

    var dataTable = $("#tblContentsMonth").DataTable({

        "columnDefs": [{ type: 'date-uk', targets: 1 }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },

    });


    $("#tblContentsMonth").on("click", ".btnContentSilMonth", function () {
        var btn = $(this);
        bootbox.confirm("İçeriği bu aydan silmek istediğinize emin misiniz ?", function (result) {

            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Month/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }

        });



    });
});



$(function () {

    var dataTable = $("#tblContentsWeek").DataTable({

        "columnDefs": [{ type: 'date-uk', targets: 1 }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },

    });


    $("#tblContentsWeek").on("click", ".btnContentSilWeek", function () {
        var btn = $(this);
        bootbox.confirm("İçeriği haftadan silmek istediğinize emin misiniz ?", function (result) {

            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Week/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }

        });



    });
});

$(function () {

    var dataTable = $("#tblContentsDone").DataTable({

        "columnDefs": [{ type: 'date-uk', targets: 1 }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },

    });


    $("#tblContentsDone").on("click", ".btnContentSilDone", function () {
        var btn = $(this);
        bootbox.confirm("İçeriği geçmişten silmek istediğinize emin misiniz ?", function (result) {

            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Done/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }

        });



    });
});
