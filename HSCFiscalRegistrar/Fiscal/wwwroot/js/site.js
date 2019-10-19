
$("#inactivelist").change(function () {
    if (this.checked) {
        $('#VATNumber').removeAttr("disabled");
        $('#VATSeria').removeAttr("disabled");
    } else {
        $('#VATNumber').attr('disabled', 'disabled');
        $('#VATSeria').attr('disabled', 'disabled');
    }
});