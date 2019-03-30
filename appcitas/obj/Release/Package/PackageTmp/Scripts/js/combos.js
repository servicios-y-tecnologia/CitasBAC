var hoy = moment(new Date()).format('YYYY-MM-DD');

$(document).ready(function () {
    checkUserAccess('MTR020');
    CheckUserInfo();

    $('#FechaPrimerCargo').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
        daysOfWeekDisabled: [0, 6],
        format: 'YYYY-MM-DD',
        ignoreReadonly: true,
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down",
            left: "fa fa-arrow-left",
            right: "fa fa-arrow-right"
        }
    });

    $('#FechaSegundoCargo').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
        daysOfWeekDisabled: [0, 6],
        format: 'YYYY-MM-DD',
        ignoreReadonly: true,
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down",
            left: "fa fa-arrow-left",
            right: "fa fa-arrow-right"
        }
    });
})

function BuscarPorTarjeta(e) {
    e.stopPropagation();

    var numeroTarjeta = $('#NumeroTarjeta');
    numeroTarjeta.validate();
    if (numeroTarjeta.valid()) {
        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionCombo/BuscarPorTarjeta/',
            data: { tarjeta: numeroTarjeta.val() },
            success: function (result) {
                $('#CIF').val(result.dataList[0].Cif);
                $('#SaldoActual').val(result.dataList[0].SaldoVencido);
                $('#Limite').val(result.dataList[0].Limite);
                $('#NumeroCuenta').val(result.dataList[0].Cuenta);
                $('#Clasificacion').val(result.dataList[0].ClasificacionCuenta);
                BuscarDatosDeCatalogos(result.dataList[0].Cuenta);
            },
            error: function (data, status, xhr) {
                GenerarErrorAlerta("Se produjo un error" + status, 'error');
                goAlert();
            }
        });
    }
}

function BuscarDatosDeCatalogos(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionCombo/BuscarDatosDeCatalogos/',
        data: { cuenta: cuenta },
        success: function (dataResult) {
            $('#Familia').val(dataResult["Familia"]);
            $('#Segmento').val(dataResult["Segmento"]);
            $('#Marca').val(dataResult["Marca"]);
            $('#MarcaId').val(dataResult["MarcaId"]);
            $('#SegmentoId').val(dataResult["SegmentoId"]);
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error" + status, 'error');
            goAlert();
        }
    })
}