// ----------------------------
//   _UserTablesPartial
// ----------------------------
$('#modalDelete').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('id') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    var found = modal.find('#modalDeleteId')
    found.val(recipient);
});



// ----------------------------
//   _DataTableTablePartial
// ----------------------------
$('#deleteDataButton').click(function () {
    $('#modalDataDelete').modal('hide');
    $('#modalDeleteProgess').modal('show');

    var selected = [];
    $('#dataTable input:checked').each(function () {
        selected.push($(this).attr('name').substr(6));
    });

    $('#deletedAll').text(selected.length);

    for (let i = 0; i < selected.length; i++) {
        var tableId = $('#tabId').text().substr(1);
        $.ajax({
            type: "POST",
            url: document.location.origin + "/Panel/DeleteData?tableId=" + tableId + "&id=" + selected[i],
            success: function (data) {
                if (data == true) {
                    var no = parseInt($('#deletedSuccess').text());
                    $('#deletedSuccess').text(no + 1);
                } else {
                    var no = parseInt($('#deletedError').text());
                    $('#deletedError').text(no + 1);
                }

                $('#datarow-' + selected[i]).html("");
            },
            error: function (xhr, status, error) {
                var no = parseInt($('#deletedError').text());
                $('#deletedError').text(no + 1);
            }
        });
        var percent = ((i + 1) * 100.00) / selected.length;
       $('#deleteProgress').width(percent + '%');
    }

    $('#modalDeleteProgess').modal('hide');
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
        if(check)
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



// ----------------------------
//   Exchange
// ----------------------------
$('.processBtn').click(function () {
    var action = $(this).val();

    if (action == "del-all" || action == "get-all") {
        var params = { receiverId: null, receiverDevice: null };

        params.receiverId = ($('#processFormReceiverId').val() == '-1') ? null : $('#processFormReceiverId').val();
        params.receiverDevice = $('#processFormReceiverDevice').val();

        var paramsEncoded = jQuery.param(params);
        $.ajax({
            type: "POST",
            url: document.location.origin + "/Panel/WaitingExchanges?" + paramsEncoded,
            success: function (data) {
                $('#exchangeAffectedNo').text(data);
            },
            error: function (e) {
                console.log("Unable to update affected exchanges number");
            }
        });
    } else {
        $('#exchangeAffectedNo').text("1");
    }

    $('#exchangeConfirmProcessAction').attr('data-data-action', action);
    $('#exchangeConfirmProcess').collapse('show');
});

$('#processFormReceiverId').change(function () { $('#exchangeConfirmProcess').collapse('hide'); });
$('#processFormReceiverDevice').on('input',function () { $('#exchangeConfirmProcess').collapse('hide'); });

$('#processCancel').click(function () {
    $('#exchangeConfirmProcess').collapse('hide');
});

$('#processOk').click(function () {
    var params = { "action": null, "receiverId": null, "receiverDevice": null };

    params.action = $('#exchangeConfirmProcessAction').attr('data-data-action');
    params.receiverId = ($('#processFormReceiverId').val() == '-1') ? null : $('#processFormReceiverId').val();
    params.receiverDevice = $('#processFormReceiverDevice').val();

    var paramsEncoded = jQuery.param(params);
    $.ajax({
        type: 'POST',
        url: document.location.origin + "/Panel/ExchangeProcess?" + paramsEncoded,
        success: function (data) {
            if (params.action == "del-all") {
                if(data == true)
                    $('#deleteToast').toast('show');
            }
            else {
                $('#exchangeTable').html(data);
            }
            refreshInfo();
        },
        error: function (e) {
            console.log("Action didn't work");
        }
    });

    $('#exchangeConfirmProcess').collapse('hide');
});

function refreshInfo() {
    $.ajax({
        type: 'GET',
        url: document.location.origin + "/Panel/ExchangeInfo",
        success: function (data) {
            $('#exchangeInfo').html(data);
        },
        error: function (e) {
            console.log("Unable to refresh info");
        }
    })
}

