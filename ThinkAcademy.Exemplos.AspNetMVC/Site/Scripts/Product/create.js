function searchSupplier() {
    jQuery.ajax({
        method: "POST",
        dataType: 'json',
        url: product.FindProvider,
        data: { SearchProvider: jQuery("#SearchSupplier").val() }
    }).done(onSuccess, onError);

    function onSuccess(data) {
        jQuery("#Suppliers").empty();
        var html = '<option value="">Selecione</option>';

        for (var i = 0; i < data.length; i++) {
            html += '<option value="' + data[i].Value + '">' + data[i].Text + '</option>';
        }

        jQuery("#Suppliers").append(html);
    }

    function onError() {
        //Não implementado
    }
}

$(document).ready(function () {
    jQuery("#btnSearchSupplier").on("click", searchSupplier);
});