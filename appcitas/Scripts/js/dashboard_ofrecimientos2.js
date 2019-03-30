var hoy = moment(new Date()).format('YYYY-MM-DD');

$(document).ready(function () {
    checkUserAccess('CYRS140');
    jQuery.ajaxSetup({ global: false });

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

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}

function AgregarFilasATabla(ArrayData, table) {
    var newRow = $(table).dataTable().fnAddData([
        "",
        ArrayData['Canal'],
        ToJavaScriptDate(ArrayData['Fecha']),
        ArrayData['Trmaite'],
        ArrayData['Item'],
        ArrayData['Variable'],
        ArrayData['clientesOk'],
        ArrayData['porcentajeOk'],
        ArrayData['clientesNOTOk'],
        ArrayData['porcentajeNOTOk']
    ]);
    var theNode = $(table).dataTable().fnSettings().aoData[newRow[0]].nTr;
    format(ArrayData);
    $(table).DataTable().order([1, 'asc']).draw();
}

function GenerarReporte(e) {
    e.stopPropagation();

    $.ajax({
        type: 'POST',
        url: urljs + 'Reportes/GenerarReporteDashboardOfrecimientos2/',
        data: {
            FechaInicio: $('#txt_fecha1').val(),
            FechaFinal: $('#txt_fecha2').val(),
            canal: $('#Canales option:selected').text(),
            tipoOffer: $('#TipoOfrecimiento option:selected').text()
        },
        success: function (mydata) {
            if (mydata.length > 0) {
                $('#tableMotorDashboard').dataTable().fnClearTable();
                $('#tableMotorDashboard').dataTable().fnDestroy();

                var myFinalData = [];
                var clntok = 0;
                var prcntgok = 0;
                var clntnotok = 0;
                var prcntgnotok = 0;
                var item = '';
                var fecha = '';
                var canal = '';
                var variable = '';
                var tramite = '';

                for (var i = 0; i < mydata.length; i++) {
                    clntok = 0;
                    prntgok = 0;
                    clntnotok = 0;
                    prcntgnotok = 0;
                    for (var j = 0; j < mydata[i].length; j++) {                      
                        canal = mydata[i][j].Canal;
                        fecha = ToJavaScriptDate(mydata[i][j].Fecha);
                        item = mydata[i][j].Item;
                        variable = mydata[i][j].Variable;
                        tramite = mydata[i][j].Tramite;
                        if (mydata[i][j].clientesOk > 0) {
                            clntok = clntok + 1;
                        }
                        else if (mydata[i][j].clientesNOTOk > 0) {
                            clntnotok = clntnotok + 1;
                        }
                    }

                    prcntgnotok = (clntnotok / (clntnotok + clntok)) * 100;
                    prcntgok = (clntok / (clntnotok + clntok)) * 100;

                    myFinalData.push({
                        Canal: canal,
                        Fecha: fecha,
                        Tramite: tramite,
                        Item: item,
                        Variable: variable,
                        clientesNOTOk: clntnotok,
                        porcentajeNOTOk: prcntgnotok,
                        clientesOk: clntok,
                        porcentajeOk: prcntgok
                    });                    
                }

                var table = $('#tableMotorDashboard').DataTable({
                    "paging": false,
                    "lengthChange": true,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "language": languageConf,
                    dom: 'Bfrtip',
                    data: myFinalData,
                    "columns": [
                        { "data": "Canal" },
                        { "data": "Fecha" },
                        { "data": "Tramite" },
                        { "data": "Item" },
                        { "data": "Variable" },
                        { "data": "clientesOk" },
                        { "data": "porcentajeOk" },
                        { "data": "clientesNOTOk" },
                        { "data": "porcentajeNOTOk" }
                    ],
                    buttons: [
                        {
                            extend: 'collection',
                            text: 'Exportar',
                            className: 'btn btn-default',
                            buttons: [
                                'copy',
                                'excel',
                                'csv',
                                'pdf',
                                'print'
                            ]
                        }
                    ]
                });
            }
            else {
                GenerarErrorAlerta(mydata[0].Mensaje, "error");
                goAlert();
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Error cargando datos", "error");
            goAlert();
        }
    });
}