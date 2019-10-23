

$(document).ready(function() {
    $('#myDataTable').dataTable( {
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Russian.json"
        }
    } );
} );

$("#inactivelist").change(function () {
    if (this.checked) {
        $('#VATNumber').removeAttr("disabled");
        $('#VATSeria').removeAttr("disabled");
    } else {
        $('#VATNumber').attr('disabled', 'disabled');
        $('#VATSeria').attr('disabled', 'disabled');
    }
});


