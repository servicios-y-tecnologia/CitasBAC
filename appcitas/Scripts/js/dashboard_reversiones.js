var hoy = moment(new Date()).format('YYYY-MM-DD');

$(document).ready(function () {
    checkUserAccess('CYRS140');
    jQuery.ajaxSetup({ global: false });
    LimpiarTablaExcel("#tableDashboardMotor", [0, 1, 2, 3, 4, 5, 6, 7, 8], 'Reporte Incidencia de Motor de Retenciones');
    jQuery.ajaxSetup({ global: false });
});

$(function () {
    $('#fecha1').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
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
    $('#fecha2').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
        format: 'YYYY-MM-DD',
        ignoreReadonly: true,
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down",
            left: "fa fa-arrow-left",
            right: "fa fa-arrow-right"
        },
        useCurrent: false
    });

    $("#fecha1").on("dp.change", function (e) {
        $('#fecha2').data("DateTimePicker").minDate(e.date);
    });
    $("#fecha2").on("dp.change", function (e) {
        $('#fecha1').data("DateTimePicker").maxDate(e.date);
    });
});

function GenerarReporte(e) {
    e.stopPropagation();

    $.ajax({
        type: "POST",
        url: urljs + "Reportes/GenerarReporteReversiones/",
        data: {
            FechaInicio: $('#txt_fecha1').val(),
            FechaFinal: $('#txt_fecha2').val(),
            canal: $('#Canales option:selected').text(),
            motor: $('#MotorUtilizado option:selected').text(),
        },
        success: function (data) {
            var excel_cols = [0, 1, 2, 3, 4, 5, 6, 7, 8];
            LimpiarTablaExcel("#tableDashboardMotor", excel_cols, 'Reporte de Reversiones');
            if (data.length > 0) {
                if (data[0].Accion > 0) {
                    for (var i = 0; i < data.length; i++) {
                        AgregarFilasATabla(data[i], '#tableDashboardMotor');
                    }
                }
                else {
                    GenerarErrorAlerta(data[0].Mensaje, "error");
                    goAlert();
                }
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Error cargando datos", "error");
            goAlert();
        }
    });
}

function AgregarFilasATabla(ArrayData, table) {
    var newRow = $(table).dataTable().fnAddData([
        ArrayData['NumeroCuenta'],
        ToJavaScriptDate(ArrayData['Fecha']),
        ArrayData['Marca'],
        ArrayData['Familia'],
        ArrayData['Segmento'],
        ArrayData['TipoReversion'],
        ArrayData['MontoReversion'],
        ArrayData['Canal'],
        ArrayData['Herramienta']
    ]);
    var theNode = $(table).dataTable().fnSettings().aoData[newRow[0]].nTr;
    $(table).DataTable().order([0, 'asc']).draw();
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}