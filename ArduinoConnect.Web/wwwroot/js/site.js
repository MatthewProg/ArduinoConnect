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

$('.dataDelete').click(function () {
    var id = $(this).attr("data-id");
    var tableId = $(this).attr("data-tableId");

    $.ajax({
        type: "POST",
        url: document.location.origin + "/Panel/DeleteData?tableId=" + tableId + "&id=" + id,
        success: function () {
            $('#datarow-' + id).html("");
        }
    });  
});

$('#selectDataAll').click(function () {
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
});

//$('#deleteToast').toast('show');