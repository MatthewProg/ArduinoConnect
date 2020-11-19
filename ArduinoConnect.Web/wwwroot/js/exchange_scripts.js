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
$('#processFormReceiverDevice').on('input', function () { $('#exchangeConfirmProcess').collapse('hide'); });

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
                if (data == true)
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

