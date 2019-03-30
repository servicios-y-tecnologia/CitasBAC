function LoadSucursales() {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cmb_sucursal", ' +
        '"url": "/sucursales/getSucursalesByAtencion", ' +
        '"val": "SucursalId", ' +
        '"type": "REP", ' +
        '"data": "", ' +
        '"text": "SucursalNombre"}');
    LoadComboBox(infojson);
    //$('#cmb_sucursal').append('<option value="0">Todos</option>');
}

function LoadTipoAtencion() {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cmb_tipo_atencion", ' +
        '"url": "configuracion/getParametosByIdEncabezado/", ' +
        '"val": "ConfigItemID", ' +
        '"type": "REPTA", ' +
        '"data": "TCITA", ' +
        '"text": "ConfigItemObservacion"}');
    LoadComboBox(infojson);
    //$('#cmb_tipo_atencion').append('<option value="-2">Todos</option>');
}

var hoy = moment(new Date()).format('YYYY-MM-DD');


function LoadCubiculos(IdSuc) {
    jQuery.ajaxSetup({ async: false });
    $('#cmb_cubiculo').empty();
    if (IdSuc != 0) {
        var infojson = jQuery.parseJSON('{"input": "#cmb_cubiculo", ' +
            '"url": "atencionCitas/GetCubiculosByCitas/", ' +
            '"val": "PosicionId", ' +
            '"type": "REP", ' +
            '"data": "' + IdSuc + '", ' +
            '"text": "posicionDescripcion"}');
        LoadComboBox(infojson);
    }
    else {
        $('#cmb_cubiculo').append('<option value="0">Todos</option>');
    }
}

$(document).ready(function () {
    checkUserAccess('CYRS010');
    LoadSucursales();
    LoadTipoAtencion();
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
        minDate: hoy,
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
    $('#cmb_sucursal').change(function (e) {
        var id = $(this).val();
        if (id != "-1") {
            //console.log(id + '-');
            LoadCubiculos(id);
        }
        //else
        //{
        //    LimpiarInput([""], ["#cmb_sucursal", "#cmb_cubiculo"]);
        //}
    });
});

$(document).ready(function () {
    checkUserAccess('CYRS050');
    LoadSucursales();
    LoadTipoAtencion();
});


var inputs = [];var mensaje = [];
$('#btn_crear_reporte').on('click', function () {
    try {
        var inputs = [];
        var mensaje = [];
        $('.requerido').each(function () {
            /*Llenamos los arreglos con la info para la validacion*/
            if ($(this).data('requerido') == true) {
                inputs.push('#' + $(this).attr('id'));
                mensaje.push($(this).attr('attr-message'));
            }
        });
        if (Validar(inputs, mensaje)) {
            var path = urljs + 'Reportes/DashboardConsolidado';
            var cod_estado = $("#cod_estado").val();
            var cmb_cubiculo = $("#cmb_cubiculo").val();
            var fecha1 = $("#txt_fecha1").val();
            var fecha2 = $("#txt_fecha2").val();
            
            //JSON data
            var dataType = 'application/json; charset=utf-8';
            var data = {
                sucursalid: $("#cmb_sucursal").val(),
                tipoatencion: $("#cmb_tipo_atencion").val(),
                cmb_cubiculo: $("#cmb_cubiculo").val(),
                fecha1: fecha1,
                fecha2: fecha2
            }
            var posting = $.post(path, data);
            posting.done(function (data, status, xhr) {
                var excel_cols = [0,1,2,3,4,5,6,7,8];
                LimpiarTablaExcel("#tableCitasDashboard1", [0, 1, 2, 3, 4, 5, 6, 7, 8], 'Dashboard consolidado');
                if (data.length > 0) {
                    if (data[0].Accion > 0) {
                        var counter = 1;
                        var atendidos = 0, emitidos = 0, abandonados = 0, espera = 0, atencion = 0;
                        jQuery.ajaxSetup({ async: false });
                        for (var i = data.length - 1; i >= 0; i--) {
                            espera += data[i]['citasAtendidas'] * data[i]['TiempoEspera'];
                            atencion += data[i]['citasAtendidas'] * data[i]['TiempoEnCita'];
                            atendidos += data[i]['citasAtendidas'];
                            emitidos += data[i]['TotalNoAtendidas'];
                            abandonados += data[i]['CitasAbandonadas'];

                            addRow(data[i], "#tableCitasDashboard1", counter);
                            counter++;
                        }
                        var total = 0.00;
                        total = (espera + atencion) / atendidos;
                        total = total.toFixed(2);

                        espera = espera / atendidos;
                        espera = espera.toFixed(2);
                        atencion = atencion / atendidos;
                        atencion = atencion.toFixed(2);

                        addRowDashboardTotal(counter, "Totales", espera, atencion, total, atendidos, emitidos, abandonados, "", "#tableCitasDashboard1");
                        jQuery.ajaxSetup({ async: true });
                    }
                    else {
                        GenerarErrorAlerta(data[0].Mensaje, "error");
                        goAlert();
                    }
                }

            });
            posting.fail(function (data, status, xhr) {
                //console.log(status);
            });
            //}
        }
        else {
            GenerarErrorAlerta("No estan llenos todos los filtros requeridos", "error");
            goAlert();
        }
    }
    catch (e) {
        console.log(e);
    }
});

function addRow(ArrayData, tableID, counter) {
    var total_tiempo = ArrayData["TiempoEspera"] + ArrayData["TiempoEnCita"];
    var newRow = $(tableID).dataTable().fnAddData([
        counter,
        ArrayData['SucursalNombre'],
        ArrayData['CitaTipo'],
        ArrayData['CitaUsuarioAtendio'],
        ArrayData["TiempoEspera"],
        ArrayData["TiempoEnCita"],
        total_tiempo,
        ArrayData['citasAtendidas'],
        ArrayData['TotalNoAtendidas'],
        ArrayData['CitasAbandonadas'],
        ArrayData['DiaSemana'],
    ]);

    var theNode = $(tableID).dataTable().fnSettings().aoData[newRow[0]].nTr;
}

function addRowDashboardTotal(counter, col0, col1, col2, col3, col4, col5, col6, col7, tableID) {
    //var total_tiempo = parse.float(col1) + parse.float(col2);
    //total_tiempo = total_tiempo.toFixed(2);
    var newRow = $(tableID).dataTable().fnAddData([
        counter,
        '',
        '',
        col0,
        col1,
        col2,
        col3,
        col4,
        col5,
        col6,
        col7,
    ]);

    var filaTR = $(tableID).dataTable().fnSettings().aoData[newRow[0]].nTr;
    $(filaTR)[0].setAttribute('class', 'fila-resumen');
}
