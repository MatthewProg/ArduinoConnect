// ----------------------------
//   UserTables (table)
// ----------------------------
$('#modalDelete').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var recipient = button.data('id');
    $('#modalDeleteId').val(recipient);
});


// ----------------------------
//   UserTablesEditAdd
// ----------------------------
function jsonToTable(data) {
    var header = '<tr><th>No.</th><th>Name</th><th>Type</th><th></th></tr>';
    var add = '<tr><td class="text-center" colspan="4"><button type="button" class="btn btn-primary" onclick="tableNewRow();">New</button></td></tr>';

    if (data == null || data == "") {
        $('#tableSchemaTable').html(header + add);
        return;
    }
    var jsonResult;
    try {
        jsonResult = JSON.parse(data);

        $('#tableSchemaTable').html(header + add);

        var i = 2;
        Object.keys(jsonResult).forEach(function (key) {
            tableNewRow();
            setRowValues(i, key, jsonResult[key]);
            i++;
        });
    }
    catch (e) {
        console.log("error: " + e);
        var middle = '<tr><td colspan="4" class="text-center"><button onclick="clearScheme();" type="button" class="btn btn-danger">CLEAR SCHEME</button><span class="mx-3 text-danger font-weight-bold">ERROR!</span><button type="button" onclick="showRawScheme();" class="btn btn-danger">SHOW RAW</button></td></tr>';
        add = '';
        $('#tableSchemaTable').html(header + middle + add);
    };
}

function clearScheme() {
    $('#TableSchema').val("");
    jsonToTable(null);
}

function showRawScheme() {
    $('#TableSchema').removeAttr("hidden");
    $('#tableSchemaTable').attr("hidden","hidden");
}

function tableNewRow() {
    var insert = '<tr><td>#NUM#</td><td><input type="text" class="form-control" name="col-name-#NUM#"/></td><td><select class="form-control" name="col-type-#NUM#"><optgroup label="numeric"><option value="int">INT</option><option value="long">LONG</option><option value="float">FLOAT</option><option value="double">DOUBLE</option></optgroup><optgroup label="text"><option value="string">STRING</option><option value="char">CHAR</option></optgroup><optgroup label="date & time"><option value="datetime">DATETIME</option><option value="timestamp">TIMESTAMP</option></optgroup><optgroup label="other"><option value="bool">BOOL</option><option value="binary">BINARY</option><option value="array">ARRAY</option><option value="json">JSON</option></optgroup></select></td><td><button type="button" class="btn btn-danger" onclick="removeFromTable(#NUM#);"><i class="fa fa-times" aria-hidden="true"></i></button></td></tr>';
    var noRows = $('#tableSchemaTable tr').length-1;
    insert = insert.replaceAll("#NUM#", noRows);
    var index = $('#tableSchemaTable tr:last').index();
    $('#tableSchemaTable tr:nth-child(' + index + ')').after(insert);
}

function setRowValues(index, name, select) {
    $('#tableSchemaTable > tr:nth-child(' + index + ') > td:nth-child(2) > input').val(name);
    $('#tableSchemaTable > tr:nth-child(' + index + ') > td:nth-child(3) > select').val(select);
}

function removeFromTable(index) {
    index++;
    $('#tableSchemaTable > tr:nth-child(' + index + ')').remove();
    for (let i = index; i < $('#tableSchemaTable tr').length; i++) {
        $('#tableSchemaTable > tr:nth-child(' + i + ') > td:first-child').text(i - 1);
        $('#tableSchemaTable input[name="col-name-' + i + '"]').attr("name", "col-name-" + (i - 1));
        $('#tableSchemaTable select[name="col-type-' + i + '"]').attr("name", "col-type-" + (i - 1));
        $('#tableSchemaTable tr:nth-child(' + i + ') button').attr("onclick", "removeFromTable(" + (i-1) + ");");
    }
}

$('#addEditForm').submit(function(event) {
    var good = true;
    var indexed_array = {};

    $('#TableName').val($.trim($('#TableName').val()));
    $('#TableDescription').val($.trim($('#TableDescription').val()));
    if ($('#TableName').val() == '') {
        $('#TableName').addClass("is-invalid");
        good = false;
    }
    else
        $('#TableName').removeClass("is-invalid");

    for (let i = 1; i < $('#tableSchemaTable tr').length - 1; i++) {
        var v = $('#tableSchemaTable input[name="col-name-' + i + '"]').val();
        $('#tableSchemaTable input[name="col-name-' + i + '"]').val($.trim(v));
        if ($.trim(v) == '' || v in indexed_array) {
            $('#tableSchemaTable input[name="col-name-' + i + '"]').addClass("is-invalid");
            good = false;
        } else {
            $('#tableSchemaTable input[name="col-name-' + i + '"]').removeClass("is-invalid");
            indexed_array[v] = $('#tableSchemaTable select[name="col-type-' + i + '"]').val();
        }
    }
    if (good == false) {
        event.preventDefault();
    } else {
        $('#TableSchema').val(JSON.stringify(indexed_array));
    }
    return good;
});