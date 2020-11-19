// ----------------------------
//   DataTable
// ----------------------------
$('#deleteDataButton').click(function () {
    $('#modalDataDelete').modal('hide');
    $('#modalDeleteProgess').modal('show');

    var selected = [];
    $('#dataTable input:checked').each(function () {
        selected.push($(this).attr('name').substr(6));
    });

    $('#deletedAll').text(selected.length);
    $('#deleteProgress').width('0%');

    for (let i = 0; i < selected.length; i++) {
        var tableId = $('#tabId').text().substr(1);
        $.ajax({
            type: "POST",
            url: document.location.origin + "/Panel/DeleteData?tableId=" + tableId + "&id=" + selected[i],
            success: function (data) {
                var noOk = parseInt($('#deletedSuccess').text());
                var noErr = parseInt($('#deletedError').text());
                if (data == true) {
                    $('#deletedSuccess').text(noOk + 1);

                    var percent = ((noOk + noErr + 1) * 100.00) / parseFloat($('#deletedAll').text());
                    $('#deleteProgress').width(percent + '%');
                } else {
                    $('#deletedError').text(noErr + 1);

                    var percent = ((noOk + noErr + 1) * 100.00) / parseFloat($('#deletedAll').text());
                    $('#deleteProgress').width(percent + '%');
                }

                $('#datarow-' + selected[i]).remove();
                noOk = parseInt($('#deletedSuccess').text());
                noErr = parseInt($('#deletedError').text());
                if (noOk + noErr >= parseInt($('#deletedAll').text()))
                    $('#modalDeleteProgess').modal('hide');
            },
            error: function (xhr, status, error) {
                var noOk = parseInt($('#deletedSuccess').text());
                var noErr = parseInt($('#deletedError').text());
                $('#deletedError').text(noErr + 1);

                var percent = ((noOk + noErr + 1) * 100.00) / parseFloat($('#deletedAll').text());
                $('#deleteProgress').width(percent + '%');

                noOk = parseInt($('#deletedSuccess').text());
                noErr = parseInt($('#deletedError').text());
                if (noOk + noErr >= parseInt($('#deletedAll').text()))
                    $('#modalDeleteProgess').modal('hide');
            }
        });
    }
});

function dataDelete(id, tableId) {
    $.ajax({
        type: "POST",
        url: document.location.origin + "/Panel/DeleteData?tableId=" + tableId + "&id=" + id,
        success: function () {
            $('#datarow-' + id).html("");
        },
        error: function (e) {
            console.log("Unable to delete data");
        }
    });
}

function selectAll() {
    var check = false;
    if ($('#allSelected').is(':checked')) {
        check = false;
        $('#allSelected').prop('checked', false);
    }
    else {
        check = true;
        $('#allSelected').prop('checked', true);
    }
    $('#dataTable input[type=checkbox]').each(function () {
        if (check)
            $(this).prop('checked', true);
        else
            $(this).prop('checked', false);
    });
}

function setDataTable(id, page = 0, displayData = 25, raw = false, order = "DESC", orderCol = "ID", parse = true) {
    $('#dataTableTable').html("Loading...");
    var params = { "id": id, "page": page, "displayData": displayData, "raw": raw, "order": order, "orderCol": orderCol, "parse": parse };
    var paramsEncoded = jQuery.param(params);
    $.ajax({
        type: 'GET',
        url: document.location.origin + "/Panel/DataTableTable?" + paramsEncoded,
        success: function (data) {
            $('#dataTableTable').html(data);
        },
        error: function (e) {
            $('#dataTableTable').html("Error occured!");
            console.log("Unable to load data");
        }
    });
}

function applySettings(tableId) {
    var orderCol = $('#dataTableSettings [name="orderCol"]').val();
    var order = $('#dataTableSettings [name="order"]').val();
    var displayData = $('#dataTableSettings [name="displayData"]:checked').val();
    var parse = $('#dataTableSettings [name="parse"]').prop("checked");
    setDataTable(tableId, 0, parseInt(displayData), false, order, orderCol, parse);
}
