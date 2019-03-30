﻿var anioSeleccionado = -1;
var hoy = moment(new Date()).format('YYYY-MM-DD');
var horaActualCliente = moment(new Date()).format('HH:mm:ss');
var hoy_max_date = moment(new Date(hoy)).add(14, 'days');
var tiempoTramite = { 'minutes': 30 };
var TramiteSinTiempoMuerto = { 'minutes': 30 };
var TramiteDuracionMins = 45;

var citasProgramadas = {}; citasProgramadas.evento = [];
var feriadosProgramados = {}; feriadosProgramados.evento = [];
var espaciosProgramados = {}; espaciosProgramados.evento = [];
var dataCitas = [];
var dataRazones = [];
var dataRazonesTemp = [];

var SucursalId = '';
var Sucursal = {}; Sucursal.horario = [];
var horarioArray = [];

var listadoExtraGlobal = 0;
var EtiquetaListadoExtraGlobal = '';
var TipoOrigenListadoExtraGlobal = '';
var TipoCodigoListadoExtraGlobal = '';
var listadoExtraIdGlobal = '';

var cubiculoIdGlobal = '';
var cubiculoGlobal = '';
var fechaGlobal = '';
var CitaIdGlobal = '-1';
var CitaIdentificacionGlobal = '';
var CitaNombreGlobal = '';
var CitaCorreoElectronicoGlobal = '';
var CitaCuentaGlobal = '';
var CitaTarjetaGlobal = '';
var CitaTelefonoCelularGlobal = '';
var CitaTelefonoCasaGlobal = '';
var CitaTelefonoOficinaGlobal = '';
var TramiteIdGlobal = '';
var TramiteGlobal = '';
var SucursalIdGlobal = '';
var SucursalGlobal = '';
var CitaSegmentoIdGlobal = '';
var CitaSegmentoGlobal = '';

var inputs = ['#txt_identificacion_n', '#txt_nombre_n', '#txt_email_n', '#txt_cuenta_n', '#txt_tarjeta', '#txt_cel_n', '#cod_tramite', '#cod_sucursal', '#cod_segmento'];
var mensaje = ['Campo requerido', 'Campo requerido', 'Campo requerido', 'Campo requerido', 'Campo requerido', 'Campo requerido', 'Campo requerido', 'Campo requerido', 'Campo requerido'];

var numeroGestionGlobal = '';
var asuntoGlobal = '';
var cuerpoCorreo = '';
var citaFueModificada = true;

var minTimeScheduleGlobal = '07:00:00';
var maxTimeScheduleGlobal = '19:00:00';
var slotDurationGlobal = '00:05:00';

var nuevoRegistro = true;
var tableRazones_hasTempItems = false;
var minRazones = 0;
var maxRazones = 1;
var totalRazones = 0;

$(document).ready(function () {
    $("#cod_razon").empty().append(new Option('No se ha cargado información', '-1'));
    ini_events($('#div_cubiculos div.cubiculos'));
    $('.numero').mask('####');
    $('.cuentaFormato').mask('################');
    $('.telefono').mask('########');
    $('.id').mask('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', { translation: { 'A': { pattern: /[A-Za-z0-9]/, optional: true } } });
    $('.varchar50').mask('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', { translation: { 'A': { pattern: /[A-Za-z-,.: 0-9 ÁÉÍÓÚáéúíóúÑñÄËÏÖÜäëïöüÀÈÌÒÙàèìòùÃÕãõçÇÂâÊêÎîÔôÛû]/, optional: true } } });
    $('.nombre').mask('AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', { translation: { 'A': { pattern: /[A-Za-z/0-9. ÁÉÍÓÚáéúíóúÑñÄËÏÖÜäëïöüÀÈÌÒÙàèìòùÃÕãõçÇÂâÊêÎîÔôÛû]/, optional: true } } });

    $(".timepicker").timepicker({
        format: 'HH:mm',
    });
    $('#div_fecha').datetimepicker({
        locale: 'es',
        minDate: hoy,
        maxDate: hoy_max_date,
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

    $('#FechaDeCargoAnualidad').datetimepicker({
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

    $('#FechaCargo1').datetimepicker({
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

    $('#FechaCargo2').datetimepicker({
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

    $('#FechaCargo3').datetimepicker({
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

    $('#FechaCargo4').datetimepicker({
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

    $('#FechaCargo5').datetimepicker({
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

    $('#FechaCargo6').datetimepicker({
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

    $('#FechaDelCambioTasa').datetimepicker({
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

    LimpiarTabla('#resultadosDeVariablesTasas');
    LimpiarTabla('#resultadosDeVariablesReversion');
    LimpiarTabla('#tableVariablesAnualidad');

    checkUserAccess('PDCC010');
    jQuery.ajaxSetup({ global: false });
    LoadSucursales_modal_session();
    getUserAgencyName();
    CheckUserInfo();
    citas_constructor_tramites();
    Get_ReporteCentroAtencion();
    checkUserAgency();
    jQuery.ajaxSetup({ global: true });
});/* Fin Document.Ready */

//$('#id_sucursal').change(function (e) {
//    var id = $(this).val();
//    if(id != "-1")
//    {
//        $('input[type="submit"]').attr('disabled', true);
//        $("#btn_ok").removeAttr('disabled');
//    }
//    else {
//        $("#btn_ok").prop("disabled", true);
//        $(".validation-error").removeClass('hide');
//    }
//});

$("#btn_centros_atencion, #btn_actualizar_tabla").on('click', function (e) {
    jQuery.ajaxSetup({ global: true });
    Get_ReporteCentroAtencion();
})

$("#btn_ok").on('click', function (e) {
    jQuery.ajaxSetup({ global: true });
    var url = urljs + "Home/Dashboard/";
    window.location.href = url;
})
$("#btn_reasing").on('click', function (e) {
    jQuery.ajaxSetup({ global: true });
    checkUserAgency2();
})
function Get_ReporteCentroAtencion() {
    try {
        jQuery.ajaxSetup({ async: false });
        var path = urljs + "/citas/GetTiempoEspera_CentrosAtencion";
        var posting = $.post(path);
        posting.done(function (data, status, xhr) {
            dataCitas = [];
            dataCitas = data;
            LimpiarTabla('#table_centros_fidelizacion');
            if (data.length > 0) {
                if (data[0].Accion > 0) {
                    var contador = 1;
                    var len = data.length;
                    for (var i = 0; i != len; i++) {
                        var promedioEspera = data[i].NumeroClientes <= 0 ? -1 : data[i].DiferenciaMinutos / data[i].NumeroClientes;
                        var newRow = $('#table_centros_fidelizacion').dataTable().fnAddData([
                            contador,
                            data[i].sucursal,
                            data[i].NumeroClientes,
                            data[i].PromedioTiempoEspera + " minuto(s)"/*,
                                data[i].MaximoTiempoEspera + " minuto(s)",
                                data[i].MinimoTiempoEspera + " minuto(s)"*/
                        ]);

                        var theNode = $('#table_centros_fidelizacion').dataTable().fnSettings().aoData[newRow[0]].nTr;
                        contador++;
                    }
                    if (contador == 1) {
                        //$('#div_citas_proceso').append('<li class="list-group-item">No hay registros</li>');
                        //$('#tbody_citas_proceso').append('<tr"><td colspan="5" align="center">No hay registros</td></tr>');
                    }
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

function citas_get_minMax_Razones() {
    minRazones = 0;
    maxRazones = 1;
    try {
        var path = urljs + "/configuracion/getParametosByIdEncabezado";
        var posting = $.post(path, { ConfigId: 'CFGRC' });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].ConfigItemID == 'MINRAZONES') { minRazones = data[i].ConfigItemAbreviatura; }
                        if (data[i].ConfigItemID == 'MAXRAZONES') { maxRazones = data[i].ConfigItemAbreviatura; }
                    }
                    if (minRazones > maxRazones) {
                        minRazones = 0;
                        maxRazones = 1;
                    }
                }
            }
        });
    }
    catch (e) {
        minRazones = 0;
        maxRazones = 1;
    }
}

function citas_get_minMaxTime_schedule() {
    minTimeScheduleGlobal = '07:00:00';
    maxTimeScheduleGlobal = '19:00:00';
    try {
        minTimeScheduleGlobal = moment(Sucursal.horario[0].start, 'hh:mm:ss A').format('HH:mm:ss');
        maxTimeScheduleGlobal = moment(Sucursal.horario[0].end, 'hh:mm:ss A').format('HH:mm:ss');
        for (var bt = 0; bt < Sucursal.horario.length; bt++) {
            var horaInicioJornada = moment(Sucursal.horario[bt].start, 'hh:mm:ss A').format('HH:mm:ss');
            var horaFinalJornada = moment(Sucursal.horario[bt].end, 'hh:mm:ss A').format('HH:mm:ss');
            if (horaInicioJornada <= minTimeScheduleGlobal) {
                minTimeScheduleGlobal = horaInicioJornada;
            }
            if (horaFinalJornada >= maxTimeScheduleGlobal) {
                maxTimeScheduleGlobal = horaFinalJornada;
            }
        }
    }
    catch (e) {
        minTimeScheduleGlobal = '07:00:00';
        maxTimeScheduleGlobal = '19:00:00';
    }
}

function citas_get_minTime_schedule() {
    minTimeScheduleGlobal = '07:00:00';
    try {
        var path = urljs + "/configuracion/getParametosByIdEncabezado";
        var posting = $.post(path, { ConfigId: 'SCHDL', ConfigItemId: 'MINTIME' });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    minTimeScheduleGlobal = data[0].ConfigItemAbreviatura;
                }
            }
        });
    }
    catch (e) {
        minTimeScheduleGlobal = '07:00:00';
    }
}

function citas_get_slotDuration_schedule() {
    slotDurationGlobal = '00:05:00';
    try {
        var path = urljs + "/configuracion/getParametosByIdEncabezado";
        var posting = $.post(path, { ConfigId: 'SCHDL', ConfigItemId: 'SLOTDURAT' });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    slotDurationGlobal = data[0].ConfigItemAbreviatura;
                }
            }
        });
    }
    catch (e) {
        slotDurationGlobal = '00:05:00';
    }
}

function citas_get_maxDate_schedule() {
    hoy_max_date = moment(new Date(hoy)).add(14, 'days');
    try {
        var path = urljs + "/configuracion/getParametosByIdEncabezado";
        var posting = $.post(path, { ConfigId: 'SCHDL', ConfigItemId: 'MAXDATE' });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    hoy_max_date = moment(new Date(hoy)).add(data[0].ConfigItemAbreviatura.toString(), 'days');
                }
            }
        });
    }
    catch (e) {
        hoy_max_date = moment(new Date(hoy)).add(14, 'days');
    }
}

$("#btnNotificarCita").on('click', function (e) {
    var hora = moment(fechaGlobal).format('hh:mm a');
    var horaFinal = moment(fechaGlobal).add(tiempoTramite, 'minutes').format('hh:mm a');
    var fecha = moment(fechaGlobal).format('DD/MM/YYYY');
    var accionCita = 1;
    if (citaFueModificada == true) {
        accionCita = 2;
    }
    enviarEmail(CitaCorreoElectronicoGlobal, CitaNombreGlobal, numeroGestionGlobal, SucursalGlobal, TramiteGlobal, fecha, hora, horaFinal, accionCita);
});

function enviarEmail(emailCliente, nombreCliente, numeroGestion, sucursal, tramite, fecha, hora, horaFinal, accionCita) {
    try {
        var path = urljs + "/citas/EnviarEmail";
        var posting = $.post(path, {
            emailCliente: emailCliente,
            nombreCliente: nombreCliente,
            numeroGestion: numeroGestion,
            sucursal: sucursal,
            tramite: tramite,
            fecha: fecha,
            hora: hora,
            horaFinal: horaFinal,
            accionCita: accionCita
        });
        posting.done(function (data, status, xhr) {
            GenerarSuccessAlerta(data.Mensaje, "success");
            goAlert();
            LimpiarInput(inputs, ['']);
            $("#busqueda").val('');
            $("#cod_sucursal").val('');
            $("#cod_segmento").empty().append(new Option('No se ha cargado información', '-1'));
            //$("#cod_tramite").empty().append( new Option('No se ha cargado información','-1') );
            activarTabInicio('tiempo_centros_atencion');
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

/* ------------------------ VALIDACIONES INPUTS, SELECTS ------------------------ */
// #region Validaciones
$("input.requerido[data-requerido='true']").keyup(function (e) {
    if ($(this).val().trim() != "") {
        $(this).removeClass('input-has-error');
    }
    else {
        $(this).addClass('input-has-error');
    }
});

$("select.requerido[data-requerido='true']").on('change', function (e) {
    var objeto = $(this);
    if (objeto.val() == null || objeto.val() == '-1' || objeto.val() == '') {
    } else {
    }
});

$(".requerido[data-requerido='true']").on('change', function (e) {
    validarObligatorios(".requerido[data-requerido='true']");
});

$("input.email").on('blur', function (e) {
    if ($(this).val().trim() != "") {
        if (emailValido($(this).val()) == true) {
            $(this).removeClass('input-has-error');
            $(this).parent().find('.validation-error-mail').addClass('hide');
        }
        else {
            $(this).addClass('input-has-error');
            $(this).parent().find('.validation-error-mail').removeClass('hide');
        }
    }
    else {
        $(this).addClass('input-has-error');
        $(this).parent().find('.validation-error-mail').addClass('hide');
    }
});
// #endregion Validaciones

/* ----------------------------- CONSTRUCTORES ----------------------------- */
// #region Construtores
function citas_constructor_tramites() {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_tramite", ' +
        '"url": "tramites/GetAllTramitesComboBox/", ' +
        '"val": "TramiteId", ' +
        '"type": "GET", ' +
        '"data": "", ' +
        '"text": "TramiteDescripcion"}');
    LoadComboBox(infojson);
}

function citas_constructor_sucursales_por_atencion() {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_sucursal", ' +
        '"url": "sucursales/getSucursalesByAtencion/", ' +
        '"val": "SucursalId", ' +
        '"type": "GET", ' +
        '"data": "", ' +
        '"text": "SucursalNombre"}');
    LoadComboBox(infojson);
}

function citas_constructor_sucursales_por_segmento(segmentoId) {
    $("#cod_sucursal").empty().append(new Option('No se ha cargado información', '-1'));
    try {
        var path = urljs + "/sucursales/getSucursalesBySegmento";
        var posting = $.post(path, { segmentoId: segmentoId });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    var contador = 0;
                    $("#cod_sucursal").empty().append(new Option('Ninguno', '-1'));
                    for (var i = data.length - 1; i >= 0; i--) {
                        $("#cod_sucursal").append(new Option(data[contador].SucursalNombre, data[contador].SucursalId));
                        contador++;
                    }
                }
                else {
                    GenerarErrorAlerta(data[0].Mensaje, "error");
                    goAlert();
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
    $("#cod_sucursal").val('-1').trigger('change');
}

function citas_constructor_segmentos() {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_segmento", ' +
        '"url": "configuracion/getParametosByIdEncabezado/", ' +
        '"val": "ConfigItemID", ' +
        '"type": "GET", ' +
        '"data": "SEGM", ' +
        '"text": "ConfigItemAbreviatura"}');
    LoadComboBox(infojson);
}

function citas_constructor_segmentos_por_sucursal(sucursalId) {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_segmento", ' +
        '"url": "sucursales/GetSegmentosBySucursalId/", ' +
        '"val": "SucSegmentoId", ' +
        '"type": "GET", ' +
        '"data": "' + sucursalId + '", ' +
        '"text": "ConfigItemAbreviatura"}');
    LoadComboBox(infojson);
}

function citas_constructor_tipos_razon() {
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_tipo_razon", ' +
        '"url": "TipoRazones/GetAllTipoRazones/", ' +
        '"val": "TipoId", ' +
        '"type": "GET", ' +
        '"data": "", ' +
        '"text": "TipoDescripcion"}');
    LoadComboBox(infojson);
}

function citas_constructor_listado_extra_config(id) {
    $("#label_cod_listado_extra").text(EtiquetaListadoExtraGlobal);
    $("#listadoExtraContainer").removeClass('hide');
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_listado_extra", ' +
        '"url": "configuracion/getParametosByIdEncabezado/", ' +
        '"val": "ConfigItemID", ' +
        '"type": "GET", ' +
        '"data": "' + id + '", ' +
        '"text": "ConfigItemDescripcion"}');
    LoadComboBox(infojson);
}

function citas_constructor_listado_extra_canal() {
    $("#label_cod_listado_extra").text(EtiquetaListadoExtraGlobal);
    $("#listadoExtraContainer").removeClass('hide');
    jQuery.ajaxSetup({ async: false });
    var infojson = jQuery.parseJSON('{"input": "#cod_listado_extra", ' +
        '"url": "sucursales/getSucursalesCanal/", ' +
        '"val": "SucursalId", ' +
        '"type": "GET", ' +
        '"data": "", ' +
        '"text": "SucursalNombre"}');
    LoadComboBox(infojson);
}

var currentAgencySessionName = '';
/* Función que trae la agencia a la que esta asignado el ejecutivo */
function getUserAgencyName() {
    var path = urljs + "/Home/getAgencySessionName";
    var posting = $.post(path);
    posting.done(function (data, status, xhr) {
        console.log('data: ' + data);
        $("#idsucur").text(data);
    });
    posting.fail(function (data, status, xhr) {
        currentAgencySessionName = '';
    });
}
function citas_constructor_razones(Id) {
    $("#cod_razon").empty().append(new Option('No se ha cargado información', '-1'));
    try {
        var path = urljs + "/Razones/GetAll";
        var posting = $.post(path, { TipoId: Id });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    var contador = 0;
                    $("#cod_razon").empty().append(new Option('Ninguno', '-1'));
                    for (var i = data.length - 1; i >= 0; i--) {
                        $("#cod_razon").append(new Option(data[contador].RazonDescripcion, data[contador].RazonId));
                        contador++;
                    }
                }
                else {
                    GenerarErrorAlerta(data[0].Mensaje, "error");
                    goAlert();
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
    }
}
// #endregion Constructores

$("#cod_segmento").on('change', function (e) {
    var cod_segmento = $("#cod_segmento").val();
    if (cod_segmento != '' && cod_segmento != '-1' && cod_segmento != null) {
        jQuery.ajaxSetup({ async: false });
        citas_constructor_sucursales_por_segmento(cod_segmento);
        jQuery.ajaxSetup({ async: true });
        //$("#cod_sucursal").val(SucursalId).trigger('change')
    }
    else {
        $("#cod_sucursal").empty().append(new Option('No se ha cargado información', '-1'));
        //$("#cod_tramite").empty().append( new Option('No se ha cargado información','-1') );
    }
});

$("#cod_tramite").on('change', function (e) {
    if ($(this).val() != '' && $(this).val() != '-1') {
        jQuery.ajaxSetup({ async: false });
        GetTiempoTramite($(this).val());
        jQuery.ajaxSetup({ async: true });
    }
});

$("#cod_tipo_razon").on('change', function (e) {
    validarObligatorios('#cod_tipo_razon');
    $("#listadoExtraContainer").addClass('hide');
    var tipoId = $(this).val();
    if (tipoId != '' && tipoId != '-1') {
        checkListadoExtra(tipoId);
        jQuery.ajaxSetup({ async: false });
        citas_constructor_razones(tipoId);
        jQuery.ajaxSetup({ async: true });
    }
    else {
        $("#cod_razon").empty().append(new Option('No se ha cargado información', '-1'));
    }
});

$("#cod_razon").on('change', function (e) {
    validarObligatorios('#cod_razon');
    var tipoId = $(this).val();
    if (tipoId != '' && tipoId != '-1') {
        $("#cod_listado_extra").empty();
        if (listadoExtraGlobal == 1) {
            switch (TipoOrigenListadoExtraGlobal) {
                case 'CONFIG':
                    citas_constructor_listado_extra_config(TipoCodigoListadoExtraGlobal);
                    break;
                case 'CANAL':
                    citas_constructor_listado_extra_canal();
                    break;
            }
        }
    }
    else {
        $("#cod_listado_extra").empty().append(new Option('No se ha cargado información', '-1'));
    }
});

$("#cod_listado_extra").on('change', function (e) {
    validarObligatorios('#cod_listado_extra');
});

$(".cuentaFormato").keyup(function (event) {
    if (event.keyCode !== undefined) {
        if (event.keyCode == 27 || event.keyCode == 13) {
            $(".cuentaFormato").trigger('blur');
        }
    }
});

$(".cuentaFormato").on('blur', function (e) {
    var cuenta = $(this).val();
    if (cuenta.length < 15 || cuenta.length > 16) {
        if ($(this).hasClass('cuenta')) {
            jQuery.ajaxSetup({ async: false });
            $('#cod_segmento').val('-1').trigger('change');
            jQuery.ajaxSetup({ async: true });

            $("#emisorId").val('');
            $("#txt_marca_n").val('');
            $("#txt_producto_n").val('');
            $("#txt_familia_n").val('');
        }
        /*GenerarErrorAlerta("Formato incorrecto!", "error");
        goAlert();
        $(this).focus();*/
        $(this).parent().find('.validation-error-cuenta-emisor').addClass('hide');
        if (cuenta.trim() != "") {
            $(this).addClass('input-has-error');
            $(this).parent().find('.validation-error-cuenta-formato').removeClass('hide');
        }
        else {
            $(this).addClass('input-has-error');
            $(this).parent().find('.validation-error-cuenta-formato').addClass('hide');
        }
    }
    else {
        $(this).removeClass('input-has-error');
        $(this).parent().find('.validation-error-cuenta-formato').addClass('hide');

        if ($(this).hasClass('cuenta')) {
            var emisorCuenta = cuenta.substr(0, 10);
            jQuery.ajaxSetup({ async: false });
            buscarEmisorCuenta(emisorCuenta);
            jQuery.ajaxSetup({ async: true });
        }
        else {
            var tarjetaFormateada = formatCard($("#txt_tarjeta_n").val())

            $("#txt_tarjeta_n").addClass('hide');
            $("#txt_tarjeta_n_formato").val(tarjetaFormateada);
            $("#txt_tarjeta_n_formato").removeClass('hide');
            /*******************************************************************************************************
             * Aumentado por ricardo 2018/10/10
             * Para que al ingresar la tarjeta traiga la cuenta y complete familia, marca, etc.
             *******************************************************************************************************/
            // recuperamos la cuenta basado en la tarjeta llamando al WS
            jQuery.ajaxSetup({ async: false });
            $('#txt_cuenta_n').val('');
            $("#txt_cuenta_n_formato").val('');
            BuscarPorTarjetaLite();
            jQuery.ajaxSetup({ async: true });

            // para pruebas, quitarlo despues
            //$('#txt_cuenta_n').val("0123456789012345");

            cuenta = $('#txt_cuenta_n').val();
            if (cuenta.length < 15 || cuenta.length > 16) {
                jQuery.ajaxSetup({ async: false });
                $('#cod_segmento').val('-1').trigger('change');
                jQuery.ajaxSetup({ async: true });

                $("#emisorId").val('');
                $("#txt_marca_n").val('');
                $("#txt_producto_n").val('');
                $("#txt_familia_n").val('');

                $('#txt_cuenta_n').parent().find('.validation-error-cuenta-emisor').addClass('hide');
                if (cuenta.trim() != "") {
                    $('#txt_cuenta_n').addClass('input-has-error');
                    $('#txt_cuenta_n').parent().find('.validation-error-cuenta-formato').removeClass('hide');
                }
                else {
                    $('#txt_cuenta_n').addClass('input-has-error');
                    $('#txt_cuenta_n').parent().find('.validation-error-cuenta-formato').addClass('hide');
                }
            }
            else {
                $('#txt_cuenta_n').removeClass('input-has-error');
                $('#txt_cuenta_n').parent().find('.validation-error-cuenta-formato').addClass('hide');

                var emisorCuenta = cuenta.substr(0, 10);
                jQuery.ajaxSetup({ async: false });
                buscarEmisorCuenta(emisorCuenta);
                jQuery.ajaxSetup({ async: true });
            }
            /*******************************************************************************************************/
        }
    }
});

function formatCard(numero) {
    return (numero.toString().substr(0, 6) + ' **** **** ' + numero.toString().substring(numero.toString().length - 4, numero.toString().length));
}

$("#txt_cuenta_n_formato").keyup(function (e) {
    if (event.keyCode == 13) {
        $("#txt_cuenta_n_formato").trigger('dblclick');
    }
});
$("#txt_cuenta_n_formato").on('dblclick', function (e) {
    $("#txt_cuenta_n_formato").addClass('hide');
    $("#txt_cuenta_n").removeClass('hide');
    $("#txt_cuenta_n").focus();
});

$("#txt_tarjeta_n_formato").keyup(function (e) {
    if (event.keyCode == 13) {
        $("#txt_tarjeta_n_formato").trigger('dblclick');
    }
});
$("#txt_tarjeta_n_formato").on('dblclick', function (e) {
    $("#txt_tarjeta_n_formato").addClass('hide');
    $("#txt_tarjeta_n").removeClass('hide');
    $("#txt_tarjeta_n").focus();
});

function buscarEmisorCuenta(EmisorCuenta) {
    jQuery.ajaxSetup({ async: false, global: false });
    citas_constructor_segmentos();
    jQuery.ajaxSetup({ async: true, global: true });
    try {
        var path = urljs + "/citas/CheckEmisorCuenta";
        var posting = $.post(path, { EmisorCuenta: EmisorCuenta });
        posting.done(function (data, status, xhr) {
            if (data.length) {
                if (data[0].Accion > 0) {
                    $("#txt_cuenta_n").removeClass('input-has-error');
                    $("#txt_cuenta_n").parent().find('.validation-error-cuenta-formato').addClass('hide');
                    $("#txt_cuenta_n").parent().find('.validation-error-cuenta-emisor').addClass('hide');
                    var cuentaFormateada = formatCard($("#txt_cuenta_n").val());

                    $("#txt_cuenta_n").addClass('hide');
                    $("#txt_cuenta_n_formato").val(cuentaFormateada);
                    $("#txt_cuenta_n_formato").removeClass('hide');

                    jQuery.ajaxSetup({ async: false });
                    $("#cod_segmento").val(data[0].CitaSegmentoId).trigger('change');
                    jQuery.ajaxSetup({ async: true });
                    $("#cod_sucursal").val(SucursalId).trigger('change')
                    //$("#txt_cuenta_n").val(EmisorCuenta);
                    $("#emisorId").val(data[0].EmisorId);
                    $("#txt_marca_n").val(data[0].MarcaTarjeta);
                    $("#txt_producto_n").val(data[0].Producto);
                    $("#txt_familia_n").val(data[0].Familia);
                }
                else {
                    jQuery.ajaxSetup({ async: false });
                    $('#cod_segmento').val('-1').trigger('change');
                    jQuery.ajaxSetup({ async: true });
                    $("#txt_cuenta_n").addClass('input-has-error');
                    if ($("#txt_cuenta_n").val() != '' || $("#txt_cuenta_n").val() != null) {
                        $("#txt_cuenta_n").parent().find('.validation-error-cuenta-emisor').removeClass('hide');
                    }
                    $("#txt_cuenta_n").parent().find('.validation-error-cuenta-formato').addClass('hide');
                    //$("#txt_cuenta_n").val('');
                    $("#emisorId").val('');
                    $("#txt_marca_n").val('');
                    $("#txt_producto_n").val('');
                    $("#txt_familia_n").val('');
                    GenerarErrorAlerta(data[0].Mensaje, "error");
                    goAlert();
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
            $("#txt_tarjeta_n").focus();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        $("#txt_tarjeta_n").focus();
    }
}

$("#busqueda").keyup(function (event) {
    if (event.keyCode == 13) {
        verResultado();
    }
});

function verResultado(event) {
    $('#btn_buscarid').trigger('click');
}

function activarTab(tab) {
    $('.nav-tabs a').closest('li').addClass('hide');

    $('.nav-tabs a[href="#' + tab + '"]').closest('li').removeClass('hide');
    $('.nav-tabs a[href="#tiempo_centros_atencion"]').closest('li').removeClass('hide');
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
}

function activarTabInicio(tab) {
    $('.nav-tabs a').closest('li').addClass('hide');

    $('.nav-tabs a[href="#' + tab + '"]').closest('li').removeClass('hide');
    $('.nav-tabs a[href="#inicio"]').closest('li').removeClass('hide');
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
}

function activaTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};

function GetCitas() {
    try {
        var path = urljs + "/citas/GetAll";
        var posting = $.post(path, { param1: 'value1' });
        posting.done(function (data, status, xhr) {
            LimpiarTabla("#tableCitas");
            if (data.length > 0) {
                if (data[0].Accion > 0) {
                    var counter = 1;
                    for (var i = data.length - 1; i >= 0; i--) {
                        addRow(data[i], "#tableCitas", counter);
                        counter++;
                    }
                }
                else {
                    GenerarErrorAlerta(data[0].Mensaje, "error");
                    goAlert();
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

$("#btn_buscarid").on('click', function (e) {
    if ($("#busqueda").val() != '') {
        GetCitasByClienteId($("#busqueda").val());
    }
});

function GetCitasByClienteId(Id) {
    try {
        var path = urljs + "/citas/GetAllByCustomerId";
        var posting = $.post(path, { CitaIdentificacion: Id });
        posting.done(function (data, status, xhr) {
            dataCitas = [];
            dataCitas = data;
            LimpiarTabla("#tableCitas");
            if (data.length > 0) {
                if (data[0].Accion > 0) {
                    var counter = 1;
                    for (var i = data.length - 1; i >= 0; i--) {
                        if (data[i].flag_historico == 0) {
                            addRowCitaPendiente(data[i], "#tableCitas", counter);
                        }
                        else {
                            addRowCitaHistorica(data[i], "#tableCitas", counter);
                        }
                        counter++;
                    }
                    $("#texto_busqueda_encontrado").text(Id);
                    activarTab('resultado_busqueda_encontrado');
                }
                else {
                    $("#texto_busqueda").text(Id);
                    activarTab('resultado_busqueda_ninguno');
                    /*GenerarErrorAlerta(data[0].Mensaje, "error");
                    goAlert();*/
                }
            }
            else {
                $("#texto_busqueda").text(Id);
                activarTab('resultado_busqueda_ninguno');
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            $('.nav-tabs a[href="#ver_cita"]').closest('li').addClass('hide');
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

$('#txt_identificacion_n').keyup(function (event) {
    if (event.keyCode == 13) {
        $(this).trigger('blur');
    }
});

//$('#txt_identificacion_n').on('blur', function () {
//    if ($(this).val() != '' && $(this).val() != null) {
//        GetCitaByClienteId($(this).val());
//    }
//});

function GetCitaByClienteId(Id) {
    try {
        var path = urljs + "/atencioncitas/GetCitaByIdentificacion";
        var posting = $.post(path, { Id: Id });
        posting.done(function (data, status, xhr) {
            if (data.Accion > 0) {
                switch (data.CitaEstado) {
                    case '0':/* En fila - WalkIn*/
                    case '1':/* Pendiente - Programada*/
                    case '2':/* Pendiente - Cliente en agencia */
                    case '3':/* En proceso */
                        $("#modalCitaActiva").modal('show');
                        break;
                    default:
                        $('#txt_nombre_n').val(data.CitaNombre);
                        $('#txt_email_n').val(data.CitaCorreoElectronico);
                        $('#txt_cel_n').val(data.CitaTelefonoCelular);
                        $('#txt_tel_oficina_n').val(data.CitaTelefonoOficina);
                        $('#txt_tel_casa_n').val(data.CitaTelefonoCasa);
                        break;
                }
            }
            else {
                goAlert();
                $('#txt_nombre_n').val('');
                $('#txt_email_n').val('');
                $('#txt_cel_n').val('');
                $('#txt_tel_oficina_n').val('');
                $('#txt_tel_casa_n').val('');
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "successModalTicketWK");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            $('.nav-tabs a[href="#ver_cita"]').closest('li').addClass('hide');
        });
    }
    catch (e) {
    }
}

$("#btn_modal_cita_activa_close").on('click', function () {
    $("#modalCitaActiva").modal('hide');
    $('#txt_identificacion_n').val('').trigger('change');
    $('#txt_identificacion_n').focus();
    $('#txt_nombre_n').val('').trigger('change');
    $('#txt_email_n').val('').trigger('change');
    $('#txt_cel_n').val('').trigger('change');
    $('#txt_tel_oficina_n').val('').trigger('change');
    $('#txt_tel_casa_n').val('').trigger('change');
});

$("#btn_modal_cita_activa_view").on('click', function () {
    $("#modalCitaActiva").modal('hide');
    $("#modalCitaActiva").on('hidden.bs.modal', function (e) {
        $("#busqueda").val($('#txt_identificacion_n').val());
        GetCitasByClienteId($('#txt_identificacion_n').val());
    });
});

function GetCitaBy(id) {
    try {
        var path = urljs + "/citas/GetOne";
        var posting = $.post(path, { id: Number(id) });
        posting.done(function (data, status, xhr) {
            if (dataCitas.length > 0) {
                $('#txt_identificacion').val(data.CitaIdentificacion);
                $('#txt_nombre').val(data.Citanombre);
                $('#txt_email').val(data.CitaCorreoElectronico);
                $('#txt_cel').val(data.CitaTelefonoCelular);
                $('#txt_sucursal').val(data.sucursal);
                $('#txt_segmento').val(data.segmento);
                $('#txt_tarjeta').val(data.CitaTarjeta);
                $('#txt_fecha').val(data.CitaFecha);
                //$('#txt_Hora').val(data.CitaHora);
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

var estadosArray = [];
estadosArray = new Array('En fila', 'Pendiente', 'Pendiente', 'En proceso', 'Atendida', 'Abandonada', 'Cancelada');

function addRowCitaPendiente(ArrayData, tableID, counter) {
    var estadoString = estadosArray[parseInt(ArrayData['CitaEstado'])];
    if (ArrayData['citaVencida'] == 1) {
        ArrayData['CitaEstado'] = '-1';
        estadoString = 'Cita vencida';
    }
    var accionesHTML = '';
    var numeroGestion = ArrayData['CitaTicket'] == "" ? 'Sin número de gestión' : ArrayData['CitaTicket'];
    switch (ArrayData['CitaEstado']) {
        case '1':/* Pendiente - Programada*/
        case '2':/* Pendiente - Cliente en agencia */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Editar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='editarCita(" + ArrayData['CitaId'] + ",1)'>" +
                "<i class='fa fa-pencil'></i> Editar cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Cancelar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "data-gestion='" + numeroGestion + "'" +
                "onClick='cancelarCita(event)'>" +
                "<i class='fa fa-calendar-times-o'></i> Cancelar cita" +
                "</a>" +
                "</li>" +
                '<li role="separator" class="divider"></li>' +
                "<li>" +
                "<a class='op1 btn_notificar_cita' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Notificar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left'>" +
                "<i class='fa fa-envelope'></i> Notificar cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
        case '-1':/* Cita Vencida */
        case '0':/* En fila - WalkIn */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Cancelar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "data-gestion='" + numeroGestion + "'" +
                "onClick='cancelarCita(event)'>" +
                "<i class='fa fa-calendar-times-o'></i> Cancelar cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
        case '3':/* En Proceso */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
        default:/* 4,5,6 */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Nueva cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='editarCita(" + ArrayData['CitaId'] + ",0)'>" +
                "<i class='fa fa-calendar-plus-o'></i> Nueva cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
    }
    var newRow = $(tableID).dataTable().fnAddData([
        counter,
        numeroGestion,
        ArrayData['CitaIdentificacion'],
        ArrayData['CitaNombre'],
        ArrayData['CitaCorreoElectronico'],
        ArrayData['CitaFecha'],
        ArrayData['sucursal'],
        ArrayData['tramite'],
        estadoString,
        accionesHTML,
        ArrayData['CitaId']
    ]);

    var filaTR = $(tableID).dataTable().fnSettings().aoData[newRow[0]].nTr;
    filaTR.setAttribute('id', ArrayData['CitaId']);
    filaTR.setAttribute('class', 'smooth-transition estado-' + ArrayData['CitaEstado']);
    $('td', filaTR)[10].setAttribute('class', 'CitaId hidden');
}

function addRowCitaHistorica(ArrayData, tableID, counter) {
    var accionesHTML = '';
    var numeroGestion = ArrayData['CitaTicket'] == "" ? 'Sin número de gestión' : ArrayData['CitaTicket'];
    switch (ArrayData['CitaEstado']) {
        case '1':/* Pendiente - Programada*/
        case '2':/* Pendiente - Cliente en agencia */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Editar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='editarCita(" + ArrayData['CitaId'] + ",1)'>" +
                "<i class='fa fa-pencil'></i> Editar cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Cancelar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "data-gestion='" + numeroGestion + "'" +
                "onClick='cancelarCita(event)'>" +
                "<i class='fa fa-calendar-times-o'></i> Cancelar cita" +
                "</a>" +
                "</li>" +
                '<li role="separator" class="divider"></li>' +
                "<li>" +
                "<a class='op1 btn_notificar_cita' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Notificar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left'>" +
                "<i class='fa fa-envelope'></i> Notificar cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
        case '0':/* En fila - WalkIn */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Cancelar cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "data-gestion='" + numeroGestion + "'" +
                "onClick='cancelarCita(event)'>" +
                "<i class='fa fa-calendar-times-o'></i> Cancelar cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
        case '3':/* En Proceso */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
        default:/* 4,5,6 */
            accionesHTML = '<div class="btn-group text-center">' +
                '<button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fa fa-bars" aria-hidden="true"></i></button>' +
                '<ul class="dropdown-menu centrar-menu text-left">' +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Ver cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='verCita(" + ArrayData['CitaId'] + ")'>" +
                "<i class='fa fa-eye'></i> Ver cita" +
                "</a>" +
                "</li>" +
                "<li>" +
                "<a class='op1' href='#' data-id='" + ArrayData['CitaId'] + "' " +
                "title='Nueva cita' " +
                "data-toggle='tooltip' " +
                "data-placement='left' " +
                "onClick='editarCita(" + ArrayData['CitaId'] + ",0)'>" +
                "<i class='fa fa-calendar-plus-o'></i> Nueva cita" +
                "</a>" +
                "</li>" +
                '</ul>' +
                '</div>';
            break;
    }
    var newRow = $(tableID).dataTable().fnAddData([
        counter,
        ArrayData['CitaTicket'],
        ArrayData['CitaIdentificacion'],
        ArrayData['CitaNombre'],
        ArrayData['CitaCorreoElectronico'],
        ArrayData['CitaFecha'],
        ArrayData['sucursal'],
        ArrayData['tramite'],
        estadosArray[parseInt(ArrayData['CitaEstado'])],
        accionesHTML,
        ArrayData['CitaId']
    ]);

    var theNode = $(tableID).dataTable().fnSettings().aoData[newRow[0]].nTr;
    theNode.setAttribute('id', ArrayData['CitaId']);
    $('td', theNode)[10].setAttribute('class', 'CitaId hidden');
}

function nuevaCita() {
    $("#mensaje_cc").addClass('hide');
    nuevoRegistro = true;
    citaFueModificada = false;
    var elementos = ['.limpiar'];
    jQuery.ajaxSetup({ async: false });
    LimpiarInput(elementos, ['']);
    limpiarMensajesValidacion($('#nueva_cita'));
    jQuery.ajaxSetup({ async: true });
    $("#txt_tarjeta_n").removeClass('hide');
    $("#txt_tarjeta_n_formato").addClass('hide');
    $("#txt_cuenta_n").removeClass('hide');
    $("#txt_cuenta_n_formato").addClass('hide');
    fechaGlobal = '';
    CitaIdGlobal = '-1';
    cubiculoIdGlobal = '';
    $("#citaId").val('');
    $("#cod_tramite").val('-1').trigger('change');
    $("#cod_sucursal").empty().append(new Option('No se ha cargado información', '-1'));
    $("#cod_segmento").empty().append(new Option('No se ha cargado información', '-1'));
    citas_constructor_tipos_razon();
    activarTab('nueva_cita');
}

function verCita(id) {
    if (dataCitas.length > 0) {
        for (var i = dataCitas.length - 1; i >= 0; i--) {
            if (dataCitas[i].CitaId == id) {
                $('#txt_identificacion').val(dataCitas[i].CitaIdentificacion);
                $('#txt_nombre').val(dataCitas[i].CitaNombre);
                $('#txt_email').val(dataCitas[i].CitaCorreoElectronico);
                $('#txt_cel').val(dataCitas[i].CitaTelefonoCelular);
                $('#txt_tel_casa').val(dataCitas[i].CitaTelefonoCasa);
                $('#txt_tel_oficina').val(dataCitas[i].CitaTelefonoOficina);
                $('#txt_tramite').val(dataCitas[i].tramite);

                //var cuentaDecrypted = CryptoJS.AES.decrypt(dataCitas[i].CitaCuenta, 'BACPANAMA');
                //var tarjetaDecrypted = CryptoJS.AES.decrypt(dataCitas[i].CitaTarjeta, 'BACPANAMA');
                //$('#txt_cuenta').val(formatCard(cuentaDecrypted.toString(CryptoJS.enc.Utf8)));
                //$('#txt_tarjeta').val(formatCard(tarjetaDecrypted.toString(CryptoJS.enc.Utf8)));
                $('#txt_cuenta').val(formatCard(dataCitas[i].CitaCuenta));
                $('#txt_tarjeta').val(formatCard(dataCitas[i].CitaTarjeta));

                $('#txt_marca').val(dataCitas[i].MarcaTarjeta);
                $('#txt_producto').val(dataCitas[i].Producto);
                $('#txt_familia').val(dataCitas[i].Familia);
                $('#txt_segmento').val(dataCitas[i].segmento);
                $('#txt_sucursal').val(dataCitas[i].sucursal);
                $('#txt_fecha').val(dataCitas[i].CitaFecha);
                $('#txt_hora_vista').val(dataCitas[i].CitaHora);
                $('#btnEditarCita').data('id', id);
                $('#btn_notificar_cita').data('id', id);
            }
        }
        activarTab('ver_cita');
    }
}

$("#btnEditarCita").on('click', function (e) {
    editarCita($(this).data('id'), 1);
});

function editarCita(id, editar) {
    $("#mensaje_cc").addClass('hide');
    limpiarMensajesValidacion($('#nueva_cita'));
    if (dataCitas.length > 0) {
        for (var i = dataCitas.length - 1; i >= 0; i--) {
            if (dataCitas[i].CitaId == id) {
                $('#txt_identificacion_n').val(dataCitas[i].CitaIdentificacion);
                if (editar == 1) {
                    citaFueModificada = true;
                    $("#citaId").val(id);
                    CitaIdGlobal = id;
                    $('#emisorId').val(dataCitas[i].EmisorId);
                    SucursalId = dataCitas[i].SucursalId;

                    //var cuentaDecrypted = CryptoJS.AES.decrypt(dataCitas[i].CitaCuenta.toString(), 'BACPANAMA');
                    //var tarjetaDecrypted = CryptoJS.AES.decrypt(dataCitas[i].CitaTarjeta.toString(), 'BACPANAMA');
                    //$('#txt_cuenta_n').val(cuentaDecrypted.toString(CryptoJS.enc.Utf8));
                    //$('#txt_tarjeta_n').val(tarjetaDecrypted.toString(CryptoJS.enc.Utf8));
                    $('#txt_cuenta_n').val(dataCitas[i].CitaCuenta.toString());
                    $('#txt_tarjeta_n').val(dataCitas[i].CitaTarjeta.toString());

                    var longitudCuenta = $("#txt_cuenta_n").val().length;
                    var cuentaFormateada = $("#txt_cuenta_n").val().substr(0, 6) + ' **** **** ' + $("#txt_cuenta_n").val().substring(longitudCuenta - 4, longitudCuenta);

                    var longitudTarjeta = $("#txt_tarjeta_n").val().length;
                    var tarjetaFormateada = $("#txt_tarjeta_n").val().substr(0, 6) + ' **** **** ' + $("#txt_tarjeta_n").val().substring(longitudTarjeta - 4, longitudTarjeta);

                    $("#txt_cuenta_n").addClass('hide');
                    $("#txt_cuenta_n_formato").val(cuentaFormateada);
                    $("#txt_cuenta_n_formato").removeClass('hide');

                    $("#txt_tarjeta_n").addClass('hide');
                    $("#txt_tarjeta_n_formato").val(tarjetaFormateada);
                    $("#txt_tarjeta_n_formato").removeClass('hide');

                    jQuery.ajaxSetup({ async: false, global: false });
                    var emisorCuenta = $('#txt_cuenta_n').val().substr(0, 10);
                    buscarEmisorCuenta(emisorCuenta);
                    jQuery.ajaxSetup({ async: true });

                    if (dataCitas[i].CitaCuenta == '' || dataCitas[i].CitaCuenta == null) {
                        $("#mensaje_cc").removeClass('hide');
                        $("#segmento_cc").text(dataCitas[i].segmento);
                        $("#sucursal_cc").text(dataCitas[i].sucursal);
                    }

                    /*jQuery.ajaxSetup({ async: false });
                    $('#cod_sucursal').val(dataCitas[i].SucursalId).trigger('change');
                    jQuery.ajaxSetup({ async: true, global: true });
                    */
                    $('#cod_tramite').val(dataCitas[i].TramiteId).trigger('change');
                }
                else {
                    $('#txt_identificacion_n').trigger('blur');
                    citaFueModificada = false;
                    var elementos = ['.limpiar'];
                    jQuery.ajaxSetup({ async: false });
                    LimpiarInput(elementos, ['']);
                    limpiarMensajesValidacion($('#nueva_cita'));
                    jQuery.ajaxSetup({ async: true });
                    $("#txt_tarjeta_n").removeClass('hide');
                    $("#txt_tarjeta_n_formato").addClass('hide');
                    $("#txt_cuenta_n").removeClass('hide');
                    $("#txt_cuenta_n_formato").addClass('hide');
                    fechaGlobal = '';
                    CitaIdGlobal = '-1';
                    cubiculoIdGlobal = '';
                    $("#cod_tramite").val('-1').trigger('change');
                    $("#cod_sucursal").empty().append(new Option('No se ha cargado información', '-1'));
                    $("#cod_segmento").empty().append(new Option('No se ha cargado información', '-1'));
                    nuevoRegistro = true;
                    $("#citaId").val('');
                }
                $('#txt_identificacion_n').val(dataCitas[i].CitaIdentificacion);
                $('#txt_nombre_n').val(dataCitas[i].CitaNombre);
                $('#txt_email_n').val(dataCitas[i].CitaCorreoElectronico);
                $('#txt_cel_n').val(dataCitas[i].CitaTelefonoCelular);
                $('#txt_tel_casa_n').val(dataCitas[i].CitaTelefonoCasa);
                $('#txt_tel_oficina_n').val(dataCitas[i].CitaTelefonoOficina);
            }
        }
        citas_constructor_tipos_razon();
        activarTab('nueva_cita');
    }
}

function checkListadoExtra(tipoId) {
    try {
        var path = urljs + "/TipoRazones/GetOne";
        var posting = $.post(path, { id: Number(tipoId) });
        posting.done(function (data, status, xhr) {
            if (data.Accion == 1 && data.TipoTieneListadoExtra == 1) {
                listadoExtraGlobal = 1;
                EtiquetaListadoExtraGlobal = data.TipoEtiquetaListadoExtra;
                TipoOrigenListadoExtraGlobal = data.TipoOrigenListadoExtra;
                TipoCodigoListadoExtraGlobal = data.TipoCodigoListadoExtra;
            }
            else {
                listadoExtraGlobal = 0;
                EtiquetaListadoExtraGlobal = '';
                TipoOrigenListadoExtraGlobal = '';
                TipoCodigoListadoExtraGlobal = '';
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

function GetTiempoTramite(id) {
    try {
        var path = urljs + "/tramites/GetOne";
        var posting = $.post(path, { id: Number(id) });
        posting.done(function (data, status, xhr) {
            var tiempo = 0;
            /*if (data.length > 0) {*/
            tiempo = data.TramiteDuracion + data.TramiteTiempoMuerto;
            /*}*/
            tiempoTramite = { 'minutes': tiempo };
            TramiteSinTiempoMuerto = { 'minutes': parseInt(data.TramiteDuracion / 2) };
            TramiteDuracionMins = data.TramiteDuracion;
            $('#calendar').fullCalendar('option', 'defaultTimedEventDuration', tiempoTramite);
            $('#calendar').fullCalendar('rerenderEvents');
            $('#calendar').fullCalendar('render');
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

function GetCitasProgramadasBySucursal(id) {
    if (id != "" || id != "-1") {
        citasProgramadas = {};
        citasProgramadas.evento = [];
        var path = urljs + "citas/GetCitasProgramadasBySucursal";
        var posting = $.post(path, { sucursalid: Number(id) });
        posting.done(function (data, status, xhr) {
            if (data[0].Accion) {
                var hue = 0;
                var sat = '60%';
                for (var i = 0; i < data.length; i++) {
                    hue = data[i]["itemOrden"] * 36;
                    if (parseInt(data[i]["itemOrden"]) >= 10) {
                        hue = (parseInt(data[i]["itemOrden"]) - 10) * 36;
                        sat = '80%';
                    }
                    citasProgramadas.evento[i] = {};
                    citasProgramadas.evento[i].id = data[i]["CitaId"];
                    citasProgramadas.evento[i].title = data[i]["posicionDescripcion"];
                    citasProgramadas.evento[i].start = data[i]["CitaHoraInicioCompleta"];
                    citasProgramadas.evento[i].end = data[i]["CitaHoraFinCompleta"];
                    citasProgramadas.evento[i].inicioDescanso = data[i]["PosicionInicioDescanso"];
                    citasProgramadas.evento[i].finalDescanso = data[i]["PosicionFinalDescanso"];
                    citasProgramadas.evento[i].cubiculoId = data[i]["PosicionId"];
                    citasProgramadas.evento[i].allDay = false;
                    citasProgramadas.evento[i].feriado = false;
                    citasProgramadas.evento[i].backgroundColor = "hsl(" + hue + "," + sat + ",70%)";
                    citasProgramadas.evento[i].borderColor = "hsl(" + hue + ",40%,30%)";
                    citasProgramadas.evento[i].textColor = "hsl(" + hue + ",40%,30%)";

                    if (CitaIdGlobal == data[i]["CitaId"]) {
                        $("#fecha_cita_alert").html('<div class="alert alert-warning alert-dismissible fade in" role="alert">' +
                            '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
                            '<span aria-hidden="true">x</span>' +
                            '</button> ' +
                            '<span>Cita: <strong>' + moment(fechaGlobal, 'YYYY-MM-DD HH:mm:ss').format('DD-MM-YYYY hh:mm:ss A') + '</strong>.</span>' +
                            '</div>');
                        $(".cubiculos").removeClass('event-draggable').addClass('no-drag');
                        fechaGlobal = data[i]["CitaHoraInicioCompleta"];
                        cubiculoIdGlobal = data[i]["PosicionId"];
                        citasProgramadas.evento[i].editable = true;
                        citasProgramadas.evento[i].durationEditable = false;
                        citasProgramadas.evento[i].backgroundColor = "hsl(" + hue + "," + sat + ",70%)";
                        citasProgramadas.evento[i].borderColor = "#000";
                        citasProgramadas.evento[i].textColor = "#000";
                        citasProgramadas.evento[i].className = "animated twelveTimes rubberBand";
                    }
                    else {
                        $("#fecha_cita_alert").html('');
                        citasProgramadas.evento[i].editable = false;
                    }
                }
            }
            else {
                GenerarErrorAlerta(data[0].Mensaje, "warning");
                goAlert();
            }

            jQuery.ajaxSetup({ async: false, global: false });
            GetHorarioSucursal(id);
            jQuery.ajaxSetup({ async: true });

            jQuery.ajaxSetup({ async: false });
            GetFeriadosProgramados();
            jQuery.ajaxSetup({ async: true });

            jQuery.ajaxSetup({ async: false });
            citas_get_maxDate_schedule();
            jQuery.ajaxSetup({ async: false });

            /*jQuery.ajaxSetup({ async: false });
            citas_get_minTime_schedule();
            jQuery.ajaxSetup({ async: true });*/

            jQuery.ajaxSetup({ async: false });
            citas_get_minMaxTime_schedule();
            jQuery.ajaxSetup({ async: true });

            jQuery.ajaxSetup({ async: false });
            citas_get_slotDuration_schedule();
            jQuery.ajaxSetup({ async: true });

            $('.nav-tabs a[href="#nueva_cita_calendario"]').on('shown.bs.tab', function (e) {
                LoadEventosCalendario(citasProgramadas.evento, feriadosProgramados.evento);
            });
        });
        posting.fail(function (data, status, xhr) {
        });
    }
    else {
        GenerarErrorAlerta("Debe seleccionar un centro de fidelización!", "error");
        goAlert();
    }
}

function GetFeriadosProgramados() {
    feriadosProgramados = {};
    feriadosProgramados.evento = [];
    var path = urljs + "feriados/GetAll";
    var posting = $.post(path);
    posting.done(function (data, status, xhr) {
        if (data[0].Accion) {
            var c = 0;
            for (var i = 0; i < data.length; i++) {
                if (data[i]["FeriadoTipoId"] == 'FERDP') {
                    feriadosProgramados.evento[c] = {};
                    feriadosProgramados.evento[c].id = data[i]["FeriadoId"];
                    feriadosProgramados.evento[c].title = data[i]["FeriadoDescripcion"];
                    feriadosProgramados.evento[c].start = moment(data[i]["FeriadoFecha"] + ' ' + data[i]["FeriadoHoraInicio"], 'YYYY-MM-DD hh:mm:ss A').format('YYYY-MM-DD HH:mm:ss');
                    feriadosProgramados.evento[c].end = moment(data[i]["FeriadoFecha"] + ' ' + data[i]["FeriadoHoraFinal"], 'YYYY-MM-DD hh:mm:ss A').format('YYYY-MM-DD HH:mm:ss');
                    feriadosProgramados.evento[c].cubiculoId = 'none';
                    feriadosProgramados.evento[c].feriado = true;
                    feriadosProgramados.evento[c].allDay = false;
                    feriadosProgramados.evento[c].editable = false;
                    feriadosProgramados.evento[c].backgroundColor = '#252525';
                    feriadosProgramados.evento[c].borderColor = '#000';
                    c++;
                }
                else {
                    var feriado = data[i]["FeriadoFecha"];
                    var dowFeriado = moment(feriado, 'YYYY-MM-DD').format('d');
                    for (var bt = 0; bt < Sucursal.horario.length; bt++) {
                        var horaInicioJornada = Sucursal.horario[bt].start;
                        var horaFinalJornada = Sucursal.horario[bt].end;
                        if (dowFeriado == Sucursal.horario[bt].dow_int) {
                            feriadosProgramados.evento[c] = {};
                            feriadosProgramados.evento[c].id = data[i]["FeriadoId"];
                            feriadosProgramados.evento[c].title = data[i]["FeriadoDescripcion"];
                            feriadosProgramados.evento[c].start = moment(data[i]["FeriadoFecha"] + ' ' + horaInicioJornada, 'YYYY-MM-DD hh:mm:ss A').format('YYYY-MM-DD HH:mm:ss');
                            feriadosProgramados.evento[c].end = moment(data[i]["FeriadoFecha"] + ' ' + horaFinalJornada, 'YYYY-MM-DD hh:mm:ss A').format('YYYY-MM-DD HH:mm:ss');
                            feriadosProgramados.evento[c].cubiculoId = 'none';
                            feriadosProgramados.evento[c].feriado = true;
                            feriadosProgramados.evento[c].allDay = false;
                            feriadosProgramados.evento[c].editable = false;
                            feriadosProgramados.evento[c].backgroundColor = '#252525';
                            feriadosProgramados.evento[c].borderColor = '#000';
                            c++;
                            break;
                        }
                    }
                }
            }
            //LoadEventosCalendario(feriadosProgramados.evento);
        }
        else {
            GenerarErrorAlerta(data[0].Mensaje, "error");
            goAlert();
        }
    });
    posting.fail(function (data, status, xhr) {
    });
}

function GetHorarioSucursal(id) {
    try {
        var path = urljs + "sucursales/GetHorariosBySucursal";
        var posting = $.post(path, { id: Number(id) });
        posting.done(function (data, status, xhr) {
            var i = 0;
            for (var c = 0; c < data.length; c++) {
                if (data[c]["SucHorarioIndLaboral"]) {
                    horarioArray[i] = data[c]["Orden"];
                    var horaInicio = moment(data[c]["SucHorarioHoraInicio"], 'hh:mm:ss A').format('HH:mm:ss');
                    var horaFinal = moment(data[c]["SucHorarioHoraFinal"], 'hh:mm:ss A').format('HH:mm:ss');
                    Sucursal.horario[i] = {};
                    Sucursal.horario[i].dow = [data[c]["Orden"]];
                    Sucursal.horario[i].dow_int = data[c]["Orden"];
                    Sucursal.horario[i].start = horaInicio;
                    Sucursal.horario[i].end = horaFinal;
                    Sucursal.horario[i].horario_corrido = data[c]["SucHorarioCorrido"];
                    i++;
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
        posting.always(function (data, status, xhr) {
            //RemoveAnimation("body");
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

function setBlankSpaces() {
    for (var bt = 0; bt < Sucursal.horario.length; bt++) {
        var horaInicioJornada = Sucursal.horario[bt].start;
        var fecha = moment().format('YYYY-MM-DD');
        //var horaFinalJornada  = Sucursal.horario[bt].end;
        var horaFinalJornada = moment(Sucursal.horario[bt].start, 'hh:mm:ss A').add(tiempoTramite, 'minutes').format('HH:mm:ss');

        espaciosProgramados.evento[bt] = {};
        espaciosProgramados.evento[bt].id = 'tempBS';
        espaciosProgramados.evento[bt].title = '';
        espaciosProgramados.evento[bt].start = moment(fecha + ' ' + horaInicioJornada, 'YYYY-MM-DD hh:mm:ss A').format('YYYY-MM-DD HH:mm:ss');
        espaciosProgramados.evento[bt].end = moment(fecha + ' ' + horaFinalJornada, 'YYYY-MM-DD hh:mm:ss A').format('YYYY-MM-DD HH:mm:ss');
        espaciosProgramados.evento[bt].cubiculoId = 'none';
        espaciosProgramados.evento[bt].spaceBlank = true;
        espaciosProgramados.evento[bt].allDay = false;
        espaciosProgramados.evento[bt].editable = false;
        espaciosProgramados.evento[bt].dow = [Sucursal.horario[bt].dow_int];
        espaciosProgramados.evento[bt].backgroundColor = '#fff';
        espaciosProgramados.evento[bt].borderColor = '#EDEDED';
    }
    $('#calendar').fullCalendar('renderEvents', espaciosProgramados.evento, true);
}

var espaciosDisponibles = [];
function getAvailableSpaces(date, inicioDescanso, finalDescanso) {
    espaciosDisponibles = [];
    var fecha = moment(date).format('YYYY-MM-DD');
    var horaInicioDescanso = moment(fecha + ' ' + inicioDescanso, 'YYYY-MM-DD hh:mm A').format('YYYY-MM-DD HH:mm:ss');
    var horaFinalDescanso = moment(fecha + ' ' + finalDescanso, 'YYYY-MM-DD hh:mm A').format('YYYY-MM-DD HH:mm:ss');
    var dow = moment(date).format('d');
    var terminoRecorrido = false;

    for (var i = 0; i < Sucursal.horario.length; i++) {
        var horaFinal = moment(Sucursal.horario[i].end, 'HH:mm:ss').subtract(tiempoTramite + 30, 'minutes').format('HH:mm:ss');
        if (dow == Sucursal.horario[i].dow_int) {
            var inicioSucursal = moment(fecha + ' ' + Sucursal.horario[i].start, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');
            var finalSucursal = moment(fecha + ' ' + Sucursal.horario[i].end, 'YYYY-MM-DD HH:mm:ss').subtract(TramiteSinTiempoMuerto).format('YYYY-MM-DD HH:mm:ss');
            var horaInicioBeforeLunch = moment(fecha + ' ' + Sucursal.horario[i].start, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');
            var horaFinalBeforeLunch = moment(horaInicioBeforeLunch, 'YYYY-MM-DD HH:mm:ss').add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
            var horaInicioAfterLunch = horaFinalDescanso;
            var horaFinalAfterLunch = moment(horaInicioAfterLunch, 'YYYY-MM-DD HH:mm:ss').add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
            var c = 0;

            while (terminoRecorrido == false) {
                c++;
                if (!Sucursal.horario[i].horario_corrido) {
                    if (((horaInicioBeforeLunch >= inicioSucursal && horaInicioBeforeLunch < horaInicioDescanso)
                        || (horaFinalBeforeLunch > inicioSucursal && horaFinalBeforeLunch <= horaInicioDescanso))
                        || ((inicioSucursal >= horaInicioBeforeLunch && inicioSucursal <= horaFinalBeforeLunch)
                            && (horaInicioDescanso >= horaInicioBeforeLunch && horaInicioDescanso <= horaFinalBeforeLunch))) {
                        espaciosDisponibles[espaciosDisponibles.length] = {};
                        espaciosDisponibles[espaciosDisponibles.length - 1].inicio = horaInicioBeforeLunch;
                        espaciosDisponibles[espaciosDisponibles.length - 1].final = horaFinalBeforeLunch;

                        horaInicioBeforeLunch = horaFinalBeforeLunch;
                        horaFinalBeforeLunch = moment(horaInicioBeforeLunch, 'YYYY-MM-DD HH:mm:ss').add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
                    }
                    else {
                        if (((horaInicioAfterLunch >= horaFinalDescanso && horaInicioAfterLunch < finalSucursal)
                            || (horaFinalAfterLunch > horaFinalDescanso && horaFinalAfterLunch <= finalSucursal))
                            || ((horaFinalDescanso >= horaInicioAfterLunch && horaFinalDescanso <= horaFinalAfterLunch)
                                && (finalSucursal >= horaInicioAfterLunch && finalSucursal <= horaFinalAfterLunch))) {
                            espaciosDisponibles[espaciosDisponibles.length] = {};
                            espaciosDisponibles[espaciosDisponibles.length - 1].inicio = horaInicioAfterLunch;
                            espaciosDisponibles[espaciosDisponibles.length - 1].final = horaFinalAfterLunch;

                            horaInicioAfterLunch = horaFinalAfterLunch;
                            horaFinalAfterLunch = moment(horaInicioAfterLunch, 'YYYY-MM-DD HH:mm:ss').add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
                        }
                        else {
                            terminoRecorrido = true;
                        }
                    }
                }
                else {
                    if (((horaInicioBeforeLunch >= inicioSucursal && horaInicioBeforeLunch < finalSucursal)
                        || (horaFinalBeforeLunch > inicioSucursal && horaFinalBeforeLunch <= finalSucursal))
                        || ((inicioSucursal >= horaInicioBeforeLunch && inicioSucursal <= horaFinalBeforeLunch)
                            && (finalSucursal >= horaInicioBeforeLunch && finalSucursal <= horaFinalBeforeLunch))) {
                        espaciosDisponibles[espaciosDisponibles.length] = {};
                        espaciosDisponibles[espaciosDisponibles.length - 1].inicio = horaInicioBeforeLunch;
                        espaciosDisponibles[espaciosDisponibles.length - 1].final = horaFinalBeforeLunch;

                        horaInicioBeforeLunch = horaFinalBeforeLunch;
                        horaFinalBeforeLunch = moment(horaInicioBeforeLunch, 'YYYY-MM-DD HH:mm:ss').add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
                    }
                    else {
                        terminoRecorrido = true;
                    }
                }
            }
            break;
        }
    }
    return setEventStart(date);
}

function setEventStart(date) {
    var encontrado = false;
    var horaEvento = moment(date, 'YYYY-MM-DD HH:mm:ss');
    var indiceEspacioDisponible = 0;
    for (var i = 0; i < espaciosDisponibles.length; i++) {
        var horaInicioDisponible = moment(espaciosDisponibles[i].inicio, 'YYYY-MM-DD HH:mm:ss');
        var diferencia = Math.abs(horaEvento.diff(horaInicioDisponible, 'minutes'));
        var toleranciaTramite = TramiteDuracionMins / 2;
        if (diferencia <= toleranciaTramite) {
            indiceEspacioDisponible = i
            break;
        }
    }
    return indiceEspacioDisponible;
}

function checkDateinBussinessTime(date) {
    var dow = moment(date).format('d');
    var hora = moment(date).format('HH:mm:ss');
    var encontrado = false;
    for (var i = 0; i < Sucursal.horario.length; i++) {
        var horaFinal = moment(Sucursal.horario[i].end, 'HH:mm:ss').subtract(TramiteSinTiempoMuerto).format('HH:mm:ss');

        if (dow == Sucursal.horario[i].dow_int) {
            if (hora >= Sucursal.horario[i].start && hora <= horaFinal) {
                if (moment(date).format('YYYY-MM-DD HH:mm:ss') >= moment().format('YYYY-MM-DD HH:mm:ss')) {
                    encontrado = true;
                }
            }
        }
    }
    return encontrado;
}

function checkDateinEvents(date, cubiculo) {
    var horaInicioDate = moment(date).format('YYYY-MM-DD HH:mm:ss');
    var horaFinalDate = moment(date).add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
    var encontrado = false;
    for (var i = 0; i < citasProgramadas.evento.length; i++) {
        var horaInicioCita = moment(citasProgramadas.evento[i].start, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');
        var horaFinalCita = moment(citasProgramadas.evento[i].end, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');

        if (((horaInicioDate >= horaInicioCita && horaInicioDate < horaFinalCita)
            || (horaFinalDate > horaInicioCita && horaFinalDate <= horaFinalCita))
            || ((horaInicioCita >= horaInicioDate && horaInicioCita <= horaFinalDate)
                && (horaFinalCita >= horaInicioDate && horaFinalCita <= horaFinalDate))) {
            if (cubiculo == citasProgramadas.evento[i].cubiculoId && citasProgramadas.evento[i].id != CitaIdGlobal) {
                encontrado = true;
                break;
            }
        }
    }
    return encontrado;
}

function checkHolidayinEvents(date) {
    var horaInicioDate = moment(date).format('YYYY-MM-DD HH:mm:ss');
    var horaFinalDate = moment(date).add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
    var encontrado = false;
    for (var i = 0; i < feriadosProgramados.evento.length; i++) {
        var horaInicioCita = moment(feriadosProgramados.evento[i].start, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');
        var horaFinalCita = moment(feriadosProgramados.evento[i].end, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');
        if (((horaInicioDate >= horaInicioCita && horaInicioDate <= horaFinalCita)
            || (horaFinalDate >= horaInicioCita && horaFinalDate <= horaFinalCita))
            || ((horaInicioCita >= horaInicioDate && horaInicioCita <= horaFinalDate)
                && (horaFinalCita >= horaInicioDate && horaFinalCita <= horaFinalDate))) {
            encontrado = true;
            break;
        }
    }
    return encontrado;
}

function checkBreakinEvents(date, horaInicio, horaFinal) {
    var fecha = moment(date).format('YYYY-MM-DD');
    var dow = moment(date).format('d');
    var horaInicioDescanso = moment(fecha + ' ' + horaInicio, 'YYYY-MM-DD hh:mm A').format('YYYY-MM-DD HH:mm:ss');
    var horaFinalDescanso = moment(fecha + ' ' + horaFinal, 'YYYY-MM-DD hh:mm A').format('YYYY-MM-DD HH:mm:ss');
    var horaInicioDate = moment(date).format('YYYY-MM-DD HH:mm:ss');
    var horaFinalDate = moment(date).add(tiempoTramite, 'minutes').format('YYYY-MM-DD HH:mm:ss');
    var encontrado = false;
    for (var i = 0; i < Sucursal.horario.length; i++) {
        if (dow == Sucursal.horario[i].dow_int) {
            if (!Sucursal.horario[i].horario_corrido) {
                if (((horaInicioDate >= horaInicioDescanso && horaInicioDate < horaFinalDescanso)
                    || (horaFinalDate > horaInicioDescanso && horaFinalDate <= horaFinalDescanso))
                    || ((horaInicioDescanso >= horaInicioDate && horaInicioDescanso <= horaFinalDate)
                        && (horaFinalDescanso >= horaInicioDate && horaFinalDescanso <= horaFinalDate))) {
                    encontrado = true;
                }
            }
        }
    }
    return encontrado;
}

function getBussinessTime(feriado) {
    var dowFeriado = moment(feriado).format('d');
    var horaFeriado = moment(feriado).format('HH:mm:ss');
    var encontrado = false;
    for (var i = 0; i < Sucursal.horario.length; i++) {
        var horaFinal = moment(Sucursal.horario[i].end, 'HH:mm:ss').subtract(tiempoTramite, 'minutes').format('HH:mm:ss');
        if (dow == Sucursal.horario[i].dow_int) {
            if (hora >= Sucursal.horario[i].start && hora <= horaFinal) {
                encontrado = true;
            }
        }
    }
    return encontrado;
}

function GetCubiculosBySucursal(id) {
    if (id != "" || id != "-1") {
        $("#div_cubiculos_programar").empty();
        $("#div_cubiculos").empty();
        var path = urljs + "sucursales/GetCubiculosBySucursal";
        var posting = $.post(path, { sucursalid: Number(id) });
        posting.done(function (data, status, xhr) {
            if (data[0].Accion) {
                var hue = 0;
                var sat = '60%';
                for (var i = 0; i < data.length; i++) {
                    if (data[i]["TipoAtencionId"] == "P&WI" || data[i]["TipoAtencionId"] == "PROG") {
                        hue = data[i]["itemOrden"] * 36;
                        if (parseInt(data[i]["itemOrden"]) >= 10) {
                            hue = (parseInt(data[i]["itemOrden"]) - 10) * 36;
                            sat = '80%';
                        }
                        $("#div_cubiculos").append('<div class="col-md-3 min-padding">' +
                            '<div class="cubiculos event-draggable" data-id="' + data[i]["PosicionId"] + '" data-descripcion="' + data[i]["posicionDescripcion"] + '" data-iniciodescanso="' + data[i]["PosicionHoraInicioDesc"] + '" data-finaldescanso="' + data[i]["PosicionHoraFinalDesc"] + '" style="background: hsl(' + hue + ',' + sat + ',60%);">' +
                            '<p class="nomargin">' + data[i]["posicionDescripcion"] + '</p>' +
                            '<div class="contenedor-descanso-cubiculo">' +
                            '<p class="nomargin">Descanso</p>' +
                            '<span>' + data[i]["PosicionHoraInicioDesc"] + ' - ' + data[i]["PosicionHoraFinalDesc"] + '</span>' +
                            '</div>' +
                            '</div>' +
                            '</div>');
                    }
                }
                ini_events($('#div_cubiculos_programar div.cubiculos'));
                ini_events($('#div_cubiculos div.cubiculos'));
            }
            else {
                GenerarErrorAlerta(data[0].Mensaje, "error");
                goAlert();
            }
        });
        posting.fail(function (data, status, xhr) {
        });
    }
    else {
        GenerarErrorAlerta("Debe seleccionar una sucursal!", "error");
        GenerarErrorAlerta("Debe seleccionar un centro de fidelización!", "error");
        goAlert();
    }
}

function ini_events(ele) {
    ele.each(function () {
        var eventObject = {
            title: $.trim($(this).data('descripcion')),
            cubiculoId: $.trim($(this).data('id')),
            inicioDescanso: $.trim($(this).data('iniciodescanso')),
            finalDescanso: $.trim($(this).data('finaldescanso')),
            feriado: false,
            allDay: false,
            constraint: 'businessHours',
            eventDurationEditable: false,
            editable: true,
            durationEditable: false
        };
        // store the Event Object in the DOM element so we can get to it later
        $(this).data('eventObject', eventObject);
        // make the event draggable using jQuery UI
        $(this).draggable({
            zIndex: 1070,
            revert: true, // will cause the event to go back to its
            revertDuration: 0,
            cursorAt: { left: 1, top: 1 },
            start: function (event, ui) {
                $(ui.helper).addClass("smallCube");
            },
            stop: function (event, ui) {
                $(ui.helper).removeClass("smallCube");
            }
        });
    });
}

function LoadEventosCalendario(dataCitas, dataFeriados) {
    //$(document).ready(function () {
    //    var refreshId = setInterval(function () {
    //        $('#recargarcalendario').load(LoadEventosCalendario());//actualizas el div
    //    }, 10000);
    //});

    var citas_feriados = {};
    citas_feriados = dataCitas.concat(dataFeriados);
    jQuery.ajaxSetup({ async: false });
    $('#calendar').fullCalendar('destroy');
    jQuery.ajaxSetup({ async: true });

    jQuery.ajaxSetup({ async: false });
    $('#calendar').fullCalendar({
        height: 500,
        scrollTime: horaActualCliente,
        locale: 'es-do',
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'agendaTwoWeeks,agendaWeek,agendaDay'
        },
        defaultView: 'agendaTwoWeeks',
        views: {
            agendaTwoWeeks: {
                type: 'agenda',
                duration: { days: 15 },
                columnFormat: "ddd DD"
            }
        },
        defaultDate: hoy,
        validRange: {
            start: hoy,
            end: hoy_max_date
        },
        businessHours: Sucursal.horario,
        nowIndicator: true,
        allDay: false,
        allDaySlot: false,
        selectable: false,
        selectHelper: true,
        defaultTimedEventDuration: tiempoTramite,
        forceEventDuration: true,
        overlap: true,
        slotEventOverlap: false,
        slotDuration: slotDurationGlobal,
        snapDuration: tiempoTramite,
        minTime: minTimeScheduleGlobal,
        maxTime: maxTimeScheduleGlobal,
        eventOverlap: function (stillEvent, movingEvent) {
            return ((stillEvent.cubiculoId != movingEvent.cubiculoId) && (stillEvent.feriado == false));
        },
        events: citas_feriados,
        editable: true,
        eventLimit: true,
        eventConstraint: Sucursal.horario,
        droppable: true,
        dropAccept: '.event-draggable',
        drop: function (start) {
            cubiculoIdGlobal = '';
            fechaGlobal = '';
            var horaEvento = moment(start).format('YYYY-MM-DD HH:mm:ss');
            /* Verificar que evento este en horario laboral */
            if (checkDateinBussinessTime(horaEvento)) {
                var originalEventObject = $(this).data('eventObject');
                var copiedEventObject = $.extend({}, originalEventObject);
                /* Verificar que evento no traslape con cubiculo ya asignado */
                if (checkDateinEvents(horaEvento, originalEventObject.cubiculoId)) {
                    GenerarErrorAlerta('Cubículo ya tiene una cita asignada en horario seleccionado.', "errorCalendario");
                    copiedEventObject.id = copiedEventObject.cubiculoId + '_' + start;
                    $('#calendar').fullCalendar('removeEvents', copiedEventObject.id);
                }
                else {
                    /* Verificar que evento no traslape con feriados programados */
                    if (checkHolidayinEvents(horaEvento)) {
                        GenerarErrorAlerta('Feriado programado en horario seleccionado.', "errorCalendario");
                        copiedEventObject.id = copiedEventObject.cubiculoId + '_' + start;
                        $('#calendar').fullCalendar('removeEvents', copiedEventObject.id);
                    }
                    else {
                        /* Verificar que evento no traslape con receso y que no sea un horario corrido */
                        if (checkBreakinEvents(horaEvento, originalEventObject.inicioDescanso, originalEventObject.finalDescanso)) {
                            var horaDescanso = originalEventObject.inicioDescanso + ' - ' + originalEventObject.finalDescanso
                            GenerarErrorAlerta('Tiempo de descanso del cubículo (' + horaDescanso + ').', "errorCalendario");
                            copiedEventObject.id = copiedEventObject.cubiculoId + '_' + start;
                            $('#calendar').fullCalendar('removeEvents', copiedEventObject.id);
                        }
                        else {
                            var indice = getAvailableSpaces(horaEvento, originalEventObject.inicioDescanso, originalEventObject.finalDescanso);
                            var inicioMoment = moment(espaciosDisponibles[indice].inicio, 'YYYY-MM-DD HH:mm:ss').format('YYYY-MM-DD HH:mm:ss');
                            var finalMoment = moment(espaciosDisponibles[indice].final);
                            //cambiarCitaHorarioArray(horaEvento, horaFinalEvento);
                            copiedEventObject.start = inicioMoment;
                            copiedEventObject.id = copiedEventObject.cubiculoId + '_' + inicioMoment;
                            copiedEventObject.backgroundColor = $(this).css("background-color");
                            copiedEventObject.borderColor = $(this).css("border-color");
                            copiedEventObject.textColor = "#000";

                            $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
                            $('#div_cubiculos div.cubiculos').removeClass('event-draggable');
                            $('#div_cubiculos div.cubiculos').addClass('no-drag');
                            cubiculoIdGlobal = copiedEventObject.cubiculoId;
                            fechaGlobal = inicioMoment;
                        }
                    }
                }
            }
            else {
                GenerarErrorAlerta('Cita fuera del rango de atención.', "errorCalendario");
                var originalEventObject = $(this).data('eventObject');
                var copiedEventObject = $.extend({}, originalEventObject);
                copiedEventObject.id = copiedEventObject.cubiculoId + '_' + start;
                $('#calendar').fullCalendar('removeEvents', copiedEventObject.id);
            }
        },
        eventDrop: function (event, delta, revertFunc) {
            cubiculoIdGlobal = event.cubiculoId;
            //fechaGlobal         = moment(event.start).format('YYYY-MM-DD HH:mm:ss');
            var horaActual = moment().format('YYYY-MM-DD HH:mm:ss');
            var horaEvento = moment(event.start).format('YYYY-MM-DD HH:mm:ss');
            var horaFinalEvento = moment(event.end).format('YYYY-MM-DD HH:mm:ss');
            /* No permitir añadir eventos en horas pasadas */
            if (horaEvento < horaActual) {
                GenerarErrorAlerta('Cita fuera del rango de atención.', "errorCalendario");
                revertFunc();
            }
            else {
                if (checkDateinBussinessTime(horaEvento)) {
                    if (checkDateinEvents(horaEvento, event.cubiculoId)) {
                        GenerarErrorAlerta('Cubículo ya tiene una cita asignada en horario seleccionado.', "errorCalendario");
                        revertFunc();
                    }
                    else {
                        /* Verificar que evento no traslape con feriados programados */
                        if (checkHolidayinEvents(horaEvento)) {
                            GenerarErrorAlerta('Feriado programado en horario seleccionado.', "errorCalendario");
                            revertFunc();
                        }
                        else {
                            /* Verificar que evento no traslape con receso */
                            if (checkBreakinEvents(horaEvento, event.inicioDescanso, event.finalDescanso)) {
                                var horaDescanso = event.inicioDescanso + ' - ' + event.finalDescanso
                                GenerarErrorAlerta('Tiempo de descanso del cubículo (' + horaDescanso + ').', "errorCalendario");
                                revertFunc();
                            }
                            else {
                                var indice = getAvailableSpaces(horaEvento, event.inicioDescanso, event.finalDescanso);
                                var inicioMoment = moment(espaciosDisponibles[indice].inicio);
                                var finalMoment = moment(espaciosDisponibles[indice].final);
                                var diferencia = inicioMoment.diff(event.start, 'minutes')
                                if (diferencia >= 0) {
                                    event.start = moment(event.start).add(Math.abs(diferencia), 'minutes');
                                    event.end = moment(event.end).add(Math.abs(diferencia), 'minutes');
                                }
                                else {
                                    event.start = moment(event.start).subtract(Math.abs(diferencia), 'minutes');
                                    event.end = moment(event.end).subtract(Math.abs(diferencia), 'minutes');
                                }
                                cambiarCitaHorarioArray(horaEvento, horaFinalEvento);
                                fechaGlobal = moment(event.start).format('YYYY-MM-DD HH:mm:ss');
                            }
                        }
                    }
                }
                else {
                    GenerarErrorAlerta('Cita fuera del rango de atención.', "errorCalendario");
                    revertFunc();
                }
            }
        },
        eventClick: function (calEvent, jsEvent, view) {
            if (calEvent.editable == true) {
                var confirmar = confirm('Desea remover cubiculo?');
                if (confirmar == true) {
                    $('#calendar').fullCalendar('removeEvents', calEvent.id);
                    $('#div_cubiculos div.cubiculos').addClass('event-draggable');
                    $('#div_cubiculos div.cubiculos').removeClass('no-drag');
                }
            }
        }
    });

    jQuery.ajaxSetup({ async: true });
}

function cambiarCitaHorarioArray(horaInicio, horaFinal) {
    for (var i = citasProgramadas.evento.length - 1; i >= 0; i--) {
        if (citasProgramadas.evento[i].id == CitaIdGlobal) {
            citasProgramadas.evento[i].start = horaInicio;
            citasProgramadas.evento[i].end = horaFinal;
            break;
        }
    }
}

$('#modalcitas').on('hidden.bs.modal', function (e) {
    limpiarMensajesValidacion($('#form'));
});

$("#guardarCita").on('click', function (e) {
    //GuardarCita();
    var inputs = [];
    var mensaje = [];

    /*Recorremos el contenedor para obtener los valores*/
    $('#nueva_cita .requerido').each(function () {
        /*Llenamos los arreglos con la info para la validacion*/
        if ($(this).data('requerido') == true) {
            inputs.push('#' + $(this).attr('id'));
            mensaje.push($(this).attr('attr-message'));
        }
    });
    if (Validar(inputs, mensaje) && !$(".requerido[data-requerido='true']").hasClass('input-has-error')) {
        SucursalId = $("#cod_sucursal").val();
        if (SucursalId != '' && SucursalId != '-1' && SucursalId != null) {
            $("#calendar").empty();
            $("#div_cubiculos").empty();
            jQuery.ajaxSetup({ async: false, global: false });
            GetCubiculosBySucursal(SucursalId);
            GetCitasProgramadasBySucursal(SucursalId);
            jQuery.ajaxSetup({ async: true, global: true });
        }

        if (CitaIdGlobal != '-1') {
            totalRazones = 0;
            jQuery.ajaxSetup({ async: false, global: false });
            GetRazonesByCita(CitaIdGlobal);
            jQuery.ajaxSetup({ async: true, global: true });
        }
        else {
            if (nuevoRegistro) {
                totalRazones = 0;
                LimpiarTablaSimple("#tableRazones");
                dataRazones = [];
                dataRazonesTemp = [];
                nuevoRegistro = false;
            }
        }
        citas_get_minMax_Razones();
        activarTab('nueva_cita_razon');
    }
});

function regresarDatosRazones() {
    citas_get_minMax_Razones();
    totalRazones = 0;
    if (CitaIdGlobal != '-1') {
        jQuery.ajaxSetup({ async: false });
        GetRazonesByCita(CitaIdGlobal);
        jQuery.ajaxSetup({ async: true });
    }
    else {
        if (nuevoRegistro) {
            LimpiarTablaSimple("#tableRazones");
            dataRazones = [];
            dataRazonesTemp = [];
            nuevoRegistro = false;
        }
    }
    activarTab('nueva_cita_razon');
}

function GuardarCita() {
    try {
        var inputs = [];
        var mensaje = [];
        /*Recorremos el contenedor para obtener los valores*/
        $('#nueva_cita .requerido').each(function () {
            /*Llenamos los arreglos con la info para la validacion*/
            if ($(this).data('requerido') == true) {
                inputs.push('#' + $(this).attr('id'));
                mensaje.push($(this).attr('attr-message'));
            }
        });

        /*Si la validación es correcta ejecuta el ajax*/
        if (Validar(inputs, mensaje)) {
            var path = urljs + "citas/CitaFechaHora";
            var posting = $.post(path, { cubiculoIdGlobal: cubiculoIdGlobal, fechaGlobal: fechaGlobal, CitaIdGlobal: CitaIdGlobal });
            posting.done(function (data, status, xhr) {
                if (data[0].Accion == 1 || data[1].Accion == 1) {
                    if (cubiculoIdGlobal == '' || fechaGlobal == '') {
                        GenerarErrorAlerta('Favor asigne cita!', "error");
                        goAlert();
                    }

                    else {
                        var path = urljs + 'citas/SaveData';
                        var id = $("#citaId").val();
                        var EmisorId = $("#emisorId").val();
                        if (id == "") {
                            id = -1;
                        }
                        var cuentaEncrypted = $('#txt_cuenta_n').val().toString(); //CryptoJS.AES.encrypt($('#txt_cuenta_n').val().toString(), 'BACPANAMA');
                        var tarjetaEncrypted = $('#txt_tarjeta_n').val().toString(); //CryptoJS.AES.encrypt($('#txt_tarjeta_n').val().toString(), 'BACPANAMA');
                        var dataType = 'application/json; charset=utf-8';
                        numeroGestionGlobal = cubiculoIdGlobal + '-' + $('#cod_sucursal').val() + moment(fechaGlobal).format('YYMMDDHHmm');
                        var data = {
                            CitaId: id,
                            CitaIdentificacion: $('#txt_identificacion_n').val(),
                            CitaNombre: $('#txt_nombre_n').val(),
                            CitaCorreoElectronico: $('#txt_email_n').val(),
                            CitaCuenta: cuentaEncrypted.toString(),
                            CitaTarjeta: tarjetaEncrypted.toString(),
                            CitaTelefonoCelular: $('#txt_cel_n').val(),
                            CitaTelefonoCasa: $('#txt_tel_casa_n').val(),
                            CitaTelefonoOficina: $('#txt_tel_oficina_n').val(),
                            TramiteId: $('#cod_tramite').val(),
                            SucursalId: $('#cod_sucursal').val(),
                            CitaSegmentoId: $('#cod_segmento').val(),
                            CitaFecha: fechaGlobal,
                            CitaHora: fechaGlobal,
                            PosicionId: cubiculoIdGlobal,
                            EmisorId: EmisorId,
                            CitaTicket: numeroGestionGlobal
                        }

                        CitaIdGlobal = id;
                        CitaIdentificacionGlobal = $('#txt_identificacion_n').val();
                        CitaNombreGlobal = $('#txt_nombre_n').val();
                        CitaCorreoElectronicoGlobal = $('#txt_email_n').val();
                        CitaCuentaGlobal = $('#txt_cuenta_n').val();
                        CitaTarjetaGlobal = $('#txt_tarjeta_n').val();
                        CitaTelefonoCelularGlobal = $('#txt_cel_n').val();
                        CitaTelefonoCasaGlobal = $('#txt_tel_casa_n').val();
                        CitaTelefonoOficinaGlobal = $('#txt_tel_oficina_n').val();
                        TramiteIdGlobal = $('#cod_tramite').val();
                        TramiteGlobal = $('#cod_tramite option:selected').text();
                        SucursalIdGlobal = $('#cod_sucursal').val();
                        SucursalGlobal = $('#cod_sucursal option:selected').text();
                        CitaSegmentoIdGlobal = $('#cod_segmento').val();
                        CitaSegmentoGlobal = $('#cod_segmento option:selected').text();

                        numeroGestionGlobal = cubiculoIdGlobal + '-' + SucursalIdGlobal + moment(fechaGlobal).format('YYMMDDHHmm');
                        var posting = $.post(path, data);
                        posting.done(function (data, status, xhr) {
                            $('#modalCitas').modal('hide');
                            $("#citaId").val(data.Accion);
                            CitaIdGlobal = data.Accion;
                            $('#modalCitas').modal('hide');
                            GenerarSuccessAlerta(data.Mensaje, "success");
                            goAlert();
                            $('#txt_identificacion_vp').val(CitaIdentificacionGlobal);
                            $('#txt_nombre_vp').val(CitaNombreGlobal);
                            $('#txt_email_vp').val(CitaCorreoElectronicoGlobal);
                            $('#txt_cel_vp').val(CitaTelefonoCelularGlobal);
                            $('#txt_tel_casa_vp').val(CitaTelefonoCasaGlobal);
                            $('#txt_tel_oficina_vp').val(CitaTelefonoOficinaGlobal);
                            $('#txt_tramite_vp').val(TramiteGlobal);
                            $('#txt_cuenta_vp').val(CitaCuentaGlobal);
                            $('#txt_tarjeta_vp').val(CitaTarjetaGlobal);
                            $('#txt_sucursal_vp').val(SucursalGlobal);
                            $('#txt_segmento_vp').val(CitaSegmentoGlobal);
                            $('#txt_fecha_vp').val(moment(fechaGlobal).format('YYYY-MM-DD'));
                            $('#txt_hora_vp').val(moment(fechaGlobal).format('HH:mm:ss'));
                            guardarRazones();

                            var pathConfig = urljs + 'Citas/ConfiguracionMotor/';
                            var posting = $.post(pathConfig, null);
                            posting.done(function (resultData) {
                                if (resultData === "Motor Visible") {
                                    if ($('#cod_tramite option:selected').text() === 'MEANO') {
                                        GuardarAnualidad();
                                    }
                                    else if ($('#cod_tramite option:selected').text() === 'MEREV') {
                                        GuardarReversion();
                                    }
                                    else if ($('#cod_tramite option:selected').text() === 'METAS') {
                                        GuardarTasa();
                                    }
                                    else if ($('#cod_tramite option:selected').text() === 'MECMB') {
                                    }
                                    else {
                                        activarTab("nueva_cita_calendario");
                                    }
                                }
                                //activarTab('vista_previa_cita');
                            });
                            posting.fail(function (data, status, xhr) {
                            });
                        });
                    }
                }
                else {
                    GenerarErrorAlerta('Favor asigne otra hora que este disponible', "error");
                    goAlert();
                }
            });
            posting.fail(function (data, status, xhr) {
            });
        }
        else {
            activarTab('vista_previa_cita');
        }
    }
    catch (e) {
    }
}

function asignarCita(fromRazones) {
    if (fromRazones == 1) {
        if (totalRazones < minRazones) {
            if (totalRazones < 0) { totalRazones = 0; }
            GenerarErrorAlerta('Razones obligatorias: <b>' + minRazones + '</b><br>Razones agregadas: <b>' + totalRazones + '</b>', "error");
            goAlert();
        }
        else {
            $("#calendar").empty();
            $("#div_cubiculos").empty();
            jQuery.ajaxSetup({ async: false });
            jQuery.ajaxSetup({ async: false, global: true });
            GetCubiculosBySucursal(SucursalId);
            //jQuery.ajaxSetup({ global: false });
            GetCitasProgramadasBySucursal(SucursalId);
            jQuery.ajaxSetup({ async: true, global: true });

            var pathConfig = urljs + 'Citas/ConfiguracionMotor/';
            var posting = $.post(pathConfig, null);
            posting.done(function (resultData) {
                if (resultData === "Motor Visible") {
                    if ($('#cod_tramite option:selected').text() === 'Anualidad-Desc') {
                        activarTab("motorDeRetencionesAnualidad");
                    }
                    else if ($('#cod_tramite option:selected').text() === 'Reversion-Desc') {
                        activarTab("motorDeRetencionesReversion");
                    }
                    else if ($('#cod_tramite option:selected').text() === 'Tasa de Interes-Desc') {
                        activarTab("motorDeRetencionesTasas");
                    }
                    else if ($('#cod_tramite option:selected').text() === 'Combos-Desc') {
                    }
                    else {
                        activarTab("nueva_cita_calendario");
                    }
                }
                else {
                    activarTab("nueva_cita_calendario");
                }
            });
        }
    }
    else {
        $("#calendar").empty();
        $("#div_cubiculos").empty();
        jQuery.ajaxSetup({ async: false, global: true });
        GetCubiculosBySucursal(SucursalId);
        jQuery.ajaxSetup({ global: false });
        GetCitasProgramadasBySucursal(SucursalId);
        jQuery.ajaxSetup({ async: true, global: true });

        posting.done(function (resultData) {
            if (resultData === "Motor Visible") {
                if ($('#cod_tramite option:selected').text() === 'Anualidad-Desc') {
                    activarTab("motorDeRetencionesAnualidad");
                }
                else if ($('#cod_tramite option:selected').text() === 'Reversion-Desc') {
                    activarTab("motorDeRetencionesReversion");
                }
                else if ($('#cod_tramite option:selected').text() === 'Tasa de Interes-Desc') {
                    activarTab("motorDeRetencionesTasas");
                }
                else if ($('#cod_tramite option:selected').text() === 'Combos-Desc') {
                }
                else {
                    activarTab("nueva_cita_calendario");
                }
            }
            else {
                activarTab("nueva_cita_calendario");
            }
        });
    }
}

function ProgramarCita() {
    try {
        if (cubiculoIdGlobal == '' || fechaGlobal == '') {
            GenerarErrorAlerta('Favor asigne cita!', "error");
            goAlert();
        }
        else {
            var path = urljs + 'citas/ProgramarCita';
            var id = $("#citaId").val();
            if (id == "") {
                GenerarErrorAlerta('Ninguna cita seleccionada!', "error");
                goAlert();
            }
            else {
                var dataType = 'application/json; charset=utf-8';
                numeroGestionGlobal = cubiculoIdGlobal + '-' + SucursalIdGlobal + moment(fechaGlobal).format('YYMMDDHHmm');
                CitaTicket: numeroGestionGlobal
                var data = {
                    CitaId: id,
                    CitaFecha: fechaGlobal,
                    CitaHora: fechaGlobal,
                    PosicionId: cubiculoIdGlobal,
                    CitaTicket: numeroGestionGlobal
                }

                var posting = $.post(path, data);
                posting.done(function (data, status, xhr) {
                    $('#modalCitas').modal('hide');
                    GenerarSuccessAlerta(data.Mensaje, "success");
                    goAlert();

                    $('#txt_identificacion_vp').val(CitaIdentificacionGlobal);
                    $('#txt_nombre_vp').val(CitaNombreGlobal);
                    $('#txt_email_vp').val(CitaCorreoElectronicoGlobal);
                    $('#txt_cel_vp').val(CitaTelefonoCelularGlobal);
                    $('#txt_tel_casa_vp').val(CitaTelefonoCasaGlobal);
                    $('#txt_tel_oficina_vp').val(CitaTelefonoOficinaGlobal);
                    $('#txt_tramite_vp').val(TramiteGlobal);
                    $('#txt_cuenta_vp').val(CitaCuentaGlobal);
                    $('#txt_tarjeta_vp').val(CitaTarjetaGlobal);
                    $('#txt_sucursal_vp').val(SucursalGlobal);
                    $('#txt_segmento_vp').val(CitaSegmentoGlobal);
                    $('#txt_fecha_vp').val(moment(fechaGlobal).format('YYYY-MM-DD'));
                    $('#txt_hora_vp').val(moment(fechaGlobal).format('HH:mm:ss'));

                    activarTab('vista_previa_cita');

                    /**/
                });
                posting.fail(function (data, status, xhr) {
                });
            }
        }
    }
    catch (e) {
    }
}

function GetRazonesByCita(CitaId) {
    //totalRazones = 0;
    try {
        var path = urljs + "/citas/GetRazonesByCita";
        var posting = $.post(path, { CitaId: CitaId });
        posting.done(function (data, status, xhr) {
            LimpiarTablaSimple("#tableRazones");
            if (data.length > 0) {
                if (data[0].Accion > 0) {
                    var counter = 1;
                    dataRazones = [];
                    for (var i = data.length - 1; i >= 0; i--) {
                        addRowRazones(data[i], "#tableRazones", counter, 1);
                        totalRazones++;
                        dataRazones[dataRazones.length] = {};
                        dataRazones[dataRazones.length - 1].razon = data[i].RazonId;
                        dataRazones[dataRazones.length - 1].tipoRazon = data[i].TipoId;
                        dataRazones[dataRazones.length - 1].idListado = data[i].DatoExtraId;
                        dataRazones[dataRazones.length - 1].listadoExtra = data[i].listadoExtra;
                        dataRazones[dataRazones.length - 1].TipoOrigenListadoExtra = data[i].TipoOrigenExtraId;
                        dataRazones[dataRazones.length - 1].TipoCodigoListadoExtra = data[i].CodigoListadoOrigenExtraId;
                        dataRazones[dataRazones.length - 1].fromBDD = 1;
                        counter++;
                    }
                }
            }
            var c = 1;
            for (var i = dataRazonesTemp.length - 1; i >= 0; i--) {
                GetRazonByTipo(dataRazonesTemp[i].razon, dataRazonesTemp[i].tipoRazon, dataRazonesTemp[i].idListado, dataRazonesTemp[i].fromBDD, c);
                c++;
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

function GetRazonByTipo(razonId, tipoRazonId, datoExtraId, fromBDD, counter) {
    try {
        var path = urljs + "/citas/GetRazonByTipo";
        var posting = $.post(path, { razonId: razonId, tipoRazonId: tipoRazonId, datoExtraId: datoExtraId });
        posting.done(function (data, status, xhr) {
            //LimpiarTablaSimple("#tableRazones");
            if (data.length > 0) {
                if (data[0].Accion > 0) {
                    counter = counter + dataRazones.length;
                    for (var i = data.length - 1; i >= 0; i--) {
                        addRowRazones(data[i], "#tableRazones", counter, fromBDD);
                        totalRazones++;
                    }
                }
            }
        });
        posting.fail(function (data, status, xhr) {
            GenerarErrorAlerta(xhr, "error");
            goAlert();
        });
    }
    catch (e) {
        //RemoveAnimation("body");
    }
}

function addRowRazones(ArrayData, tableID, counter, fromBDD) {
    var citaId = $("#citaId").val();
    var deleteBtn = "<button data-tipoId='" + ArrayData['TipoId'] + "'  data-razonId='" + ArrayData['RazonId'] + "' title='Eliminar Razón' data-toggle='tooltip' onClick='eliminarRazon(" + ArrayData['TipoId'] + "," + ArrayData['RazonId'] + ",\"" + ArrayData['DatoExtraId'] + "\")' id='btnEliminarRazon" + ArrayData['TipoId'] + "' class='btn btn-danger botonVED text-center btn-sm'><i class='fa fa-trash-o'></i></button>";
    if (fromBDD != 1) {
        deleteBtn = "<button data-tipoId='" + ArrayData['TipoId'] + "'  data-razonId='" + ArrayData['RazonId'] + "' title='Eliminar Razón' data-toggle='tooltip' onClick='eliminarRazonArray(" + ArrayData['TipoId'] + "," + ArrayData['RazonId'] + ",\"" + ArrayData['DatoExtraId'] + "\")' id='btnEliminarRazon" + ArrayData['TipoId'] + "' class='btn btn-danger botonVED text-center btn-sm'><i class='fa fa-trash-o'></i></button>"
    }
    var newRow = $(tableID).dataTable().fnAddData([
        counter,
        ArrayData['tipoRazonAbreviatura'],
        ArrayData['RazonDescripcion'],
        ArrayData['TipoEtiquetaListadoExtra'],
        ArrayData['listadoExtraDescripcion'],
        deleteBtn,
        citaId
    ]);

    var theNode = $(tableID).dataTable().fnSettings().aoData[newRow[0]].nTr;
    theNode.setAttribute('id', citaId);
    $('td', theNode)[6].setAttribute('class', 'CitaId hidden');
}

$("#guardarRazon").on('click', function (e) {
    if (totalRazones < 0) { totalRazones = 0; }
    var tipoRazon = $("#cod_tipo_razon").val();
    var razon = $("#cod_razon").val();
    var idListado = $("#cod_listado_extra").val();
    if (listadoExtraGlobal == 0) {
        idListado = '';
    }
    if (tipoRazon == '-1' || razon == '-1' ||
        (listadoExtraGlobal == 1
            && (idListado == '-1' || idListado == '' || idListado == null))) {
        validarObligatorios('.AddSelects');
        GenerarErrorAlerta('Favor seleccione información necesaria!', "error");
        goAlert();
    }
    else {
        if (checkRazon(tipoRazon, razon, idListado) == false) {
            if (totalRazones >= maxRazones) {
                GenerarErrorAlerta('Razon no puede ser agregada! <br>El maximo de razones permitidas es: ' + maxRazones, "error");
                goAlert();
            }
            else {
                dataRazonesTemp[dataRazonesTemp.length] = {};
                dataRazonesTemp[dataRazonesTemp.length - 1].razon = razon;
                dataRazonesTemp[dataRazonesTemp.length - 1].tipoRazon = tipoRazon;
                dataRazonesTemp[dataRazonesTemp.length - 1].idListado = idListado;
                dataRazonesTemp[dataRazonesTemp.length - 1].listadoExtra = listadoExtraGlobal;
                dataRazonesTemp[dataRazonesTemp.length - 1].TipoOrigenListadoExtra = TipoOrigenListadoExtraGlobal;
                dataRazonesTemp[dataRazonesTemp.length - 1].TipoCodigoListadoExtra = TipoCodigoListadoExtraGlobal;
                dataRazonesTemp[dataRazonesTemp.length - 1].fromBDD = 0;

                tableRazones_hasTempItems = true;
                GetRazonByTipo(dataRazonesTemp[dataRazonesTemp.length - 1].razon, dataRazonesTemp[dataRazonesTemp.length - 1].tipoRazon, dataRazonesTemp[dataRazonesTemp.length - 1].idListado, 0, dataRazonesTemp.length);
            }
        }
        else {
            GenerarErrorAlerta('Razon ya fue agregada!', "error");
            goAlert();
        }
    }
});

function checkRazon(tipoRazonId, razonId, datoExtraId) {
    var encontrado = false;
    for (var i = dataRazonesTemp.length - 1; i >= 0; i--) {
        if (dataRazonesTemp[i].tipoRazon == tipoRazonId && dataRazonesTemp[i].razon == razonId && dataRazonesTemp[i].idListado == datoExtraId) {
            encontrado = true;
            break;
        }
    }

    for (var i = dataRazones.length - 1; i >= 0; i--) {
        datoExtraId = datoExtraId == '' ? '-NULL-' : datoExtraId;
        if (dataRazones[i].tipoRazon == tipoRazonId && dataRazones[i].razon == razonId && dataRazones[i].idListado == datoExtraId) {
            encontrado = true;
        }
    }
    return encontrado;
}

function guardarRazones() {
    for (var i = dataRazonesTemp.length - 1; i >= 0; i--) {
        jQuery.ajaxSetup({ async: false });
        AgregarRazon($("#citaId").val(), dataRazonesTemp[i].tipoRazon, dataRazonesTemp[i].razon, dataRazonesTemp[i].idListado, dataRazonesTemp[i].listadoExtra, dataRazonesTemp[i].TipoOrigenListadoExtra, dataRazonesTemp[i].TipoCodigoListadoExtra);
        jQuery.ajaxSetup({ async: true });
    }
    dataRazonesTemp = [];
    jQuery.ajaxSetup({ async: false });
    jQuery.ajaxSetup({ async: true });
    activarTab('vista_previa_cita');
}

function AgregarRazon(citaId, tipoRazon, razon, idListado, listadoExtra, TipoOrigenListadoExtra, TipoCodigoListadoExtra) {
    try {
        if (tipoRazon == '-1' || razon == '-1' || (listadoExtra == 1 && idListado == '-1')) {
            GenerarErrorAlerta('Favor seleccione información necesaria!', "error");
            goAlert();
        }
        else {
            var path = urljs + 'citas/AsignarRazon';
            if (citaId == "") {
                GenerarErrorAlerta('Ninguna cita seleccionada!', "error");
                goAlert();
            }
            else {
                var dataType = 'application/json; charset=utf-8';
                var data = {
                    CitaId: citaId,
                    TipoRazonId: tipoRazon,
                    RazonId: razon,
                    TipoOrigenExtraId: TipoOrigenListadoExtra,
                    CodigoListadoOrigenExtraId: TipoCodigoListadoExtra,
                    DatoExtraId: idListado
                }
                var posting = $.post(path, data);
                posting.done(function (data, status, xhr) {
                });
                posting.fail(function (data, status, xhr) {
                });
            }
        }
    }
    catch (e) {
    }
}

function eliminarRazon(tipoRazonId, razonId, datoExtraId) {
    $("#modalEliminarRazon #theHeaderEliminar").html("Eliminar Razon");
    $('#modalEliminarRazon').modal('show');
    $('#modalEliminarRazon #modalmessage').html('¿Realmente desea eliminar la razon seleccionada?');
    $('#btn_eliminar_razon_modal').data('tipo', tipoRazonId);
    $('#btn_eliminar_razon_modal').data('razon', razonId);
    $('#btn_eliminar_razon_modal').data('extra', datoExtraId);
    $('#btn_eliminar_razon_modal').data('fromBDD', 'true');
}

function eliminarRazonArray(tipoRazonId, razonId, datoExtraId) {
    $("#modalEliminarRazon #theHeaderEliminar").html("Eliminar Razon");
    $('#modalEliminarRazon').modal('show');
    $('#modalEliminarRazon #modalmessage').html('¿Realmente desea eliminar la razon seleccionada?');
    $('#btn_eliminar_razon_modal').data('tipo', tipoRazonId);
    $('#btn_eliminar_razon_modal').data('razon', razonId);
    $('#btn_eliminar_razon_modal').data('extra', datoExtraId);
    $('#btn_eliminar_razon_modal').data('fromBDD', 'false');
}

$('#modalEliminarRazon').on('click', '#btn_eliminar_razon_modal', function () {
    var clic = 1;
    var citaId = $('#citaId').val();
    var tipoRazonId = $('#btn_eliminar_razon_modal').data('tipo');
    var razonId = $('#btn_eliminar_razon_modal').data('razon');
    var fromBDD = $('#btn_eliminar_razon_modal').data('fromBDD');
    var datoExtraId = $('#btn_eliminar_razon_modal').data('extra');
    if (fromBDD == 'true') {
        datoExtraId = datoExtraId == null ? '-NULL-' : datoExtraId;
        var path = urljs + 'citas/deleteRazon';
        var posting = $.post(path, { citaId: Number(citaId), tipoRazonId: Number(tipoRazonId), razonId: Number(razonId), datoExtraId: datoExtraId });
        posting.done(function (data, status, xhr) {
            $('#modalEliminarRazon').modal('hide');
            if (data.Accion > 0) {
                /*$('#modalEliminarRazon').on('hidden.bs.modal', function (e) {*/
                if (clic == 1) {
                    GetRazonesByCita(citaId);
                }
                //});
            }
            else {
                $('#modalEliminarRazon').on('hidden.bs.modal', function (e) {
                    GenerarErrorAlerta(data.Mensaje, "error");
                    goAlert();
                });
            }
        });
        posting.fail(function (data, status, xhr) {
        });
    }
    else {
        for (var i = dataRazonesTemp.length - 1; i >= 0; i--) {
            if (dataRazonesTemp[i].tipoRazon == tipoRazonId && dataRazonesTemp[i].razon == razonId && dataRazonesTemp[i].idListado == datoExtraId) {
                dataRazonesTemp.splice(i, 1);
                totalRazones = totalRazones - 2;
            }
        }
        $('#modalEliminarRazon').modal('hide');
        //$('#modalEliminarRazon').on('hidden.bs.modal', function (e) {
        if (clic == 1) {
            if (CitaIdGlobal != -1) {
                GetRazonesByCita(CitaIdGlobal);
            }
            else {
                var c = 1;
                LimpiarTablaSimple("#tableRazones");
                for (var i = dataRazonesTemp.length - 1; i >= 0; i--) {
                    GetRazonByTipo(dataRazonesTemp[i].razon, dataRazonesTemp[i].tipoRazon, dataRazonesTemp[i].idListado, dataRazonesTemp[i].fromBDD, c);
                    c++;
                }
            }
        }
        //});
    }
});

function cancelarCita(e) {
    e.stopPropagation();
    var id = $(e.currentTarget).attr('data-id');
    var numeroGestion = $(e.currentTarget).attr('data-gestion');
    $('#hidden_CitaId_cancelacion').val(id);
    $("#theHeaderEliminar").html("Cancelar cita " + numeroGestion);
    $('#modalCancelarCita').modal('show');
    $('#modalmessage').html('¿Realmente desea cancelar la cita: <b>' + numeroGestion + '</b>?');
}

$('#modalCancelarCita').on('click', '#btn_cancelar', function () {
    var path = urljs + "citas/Clientecancela";
    var id = Number($('#hidden_CitaId_cancelacion').val());
    var posting = $.post(path, { id: id });
    posting.done(function (data, status, xhr) {
        $('#modalCancelarCita').modal('hide');
        if (data.Accion = 1) {
            if (dataCitas.length > 0) {
                for (var i = dataCitas.length - 1; i >= 0; i--) {
                    if (dataCitas[i].CitaId == id) {
                        CitaNombreGlobal = dataCitas[i].CitaNombre;
                        CitaCorreoElectronicoGlobal = dataCitas[i].CitaCorreoElectronico;
                        numeroGestionGlobal = dataCitas[i].CitaTicket;
                        SucursalGlobal = dataCitas[i].sucursal;
                        TramiteGlobal = dataCitas[i].tramite;
                        var hora = dataCitas[i].CitaFecha == "" ? 'N/D' : moment(dataCitas[i].CitaFecha).format('hh:mm a');
                        var fecha = dataCitas[i].CitaFecha == "" ? 'N/D' : moment(dataCitas[i].CitaFecha).format('DD/MM/YYYY');
                        var horaFinal = dataCitas[i].CitaFecha == "" ? 'N/D' : moment(dataCitas[i].CitaFecha).add(tiempoTramite, 'minutes').format('hh:mm a');
                        break;
                    }
                }
            }
            $('#modalCancelarCita').on('hidden.bs.modal', function (e) {
                var accionCita = 3;
                enviarEmail(CitaCorreoElectronicoGlobal, CitaNombreGlobal, numeroGestionGlobal, SucursalGlobal, TramiteGlobal, fecha, hora, horaFinal, accionCita);
                verResultado();
            });
        }
        else {
            $('#modalCancelarCita').on('hidden.bs.modal', function (e) {
                GenerarErrorAlerta(data.Mensaje, "error");
                goAlert();
            });
        }
    });
    posting.fail(function (data, status, xhr) {
    });
});

$(".tab-pane").on('click', '.btn_notificar_cita', function (e) {
    var accionCita = 4;
    var id = $(this).data('id');
    for (var i = dataCitas.length - 1; i >= 0; i--) {
        if (dataCitas[i].CitaId == id) {
            var hora = dataCitas[i].CitaFecha == "" ? 'N/D' : moment(dataCitas[i].CitaFecha).format('hh:mm a');
            var fecha = dataCitas[i].CitaFecha == "" ? 'N/D' : moment(dataCitas[i].CitaFecha).format('DD/MM/YYYY');
            var horaFinal = dataCitas[i].CitaFecha == "" ? 'N/D' : moment(dataCitas[i].CitaFecha).add(tiempoTramite, 'minutes').format('hh:mm a');
            enviarEmail(dataCitas[i].CitaCorreoElectronico, dataCitas[i].CitaNombre, dataCitas[i].CitaTicket, dataCitas[i].sucursal, dataCitas[i].tramite, fecha, hora, horaFinal, accionCita);
            break;
        }
    }
});

function buscarDeNuevo() {
    $("#busqueda").val('');
    activarTab("inicio");
    $("#busqueda").focus();
}

function validarObligatorios(selector) {
    $(selector).each(function (index) {
        if ($(this).val() == null || $(this).val() == '' || $(this).val() == '-1') {
            $(this).parent().find('.validation-error p').text($(this).data('message')).addClass('label label-danger inline-block');
        }
        else {
            $(this).parent().find('.validation-error p').text('').removeClass('label label-danger inline-block');
        }
    });
}

// #region Motor de Retenciones
function BuscarPorTarjeta() {
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionAnualidad/BuscarPorTarjeta/',
        data: { tarjeta: $('#txt_tarjeta_n').val() },
        success: function (result) {
            $('#CIF').val(result.dataList[0].Cif);
            $('#SaldoActual').val(result.dataList[0].SaldoVencido);
            $('#Limite').val(result.dataList[0].Limite);
            $('#Clasificacion').val(result.dataList[0].ClasificacionCuenta);
            BuscarDatosDeCatalogos(result.dataList[0].Cuenta);
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error" + status, 'error');
            goAlert();
        }
    })
}

function BuscarDatosDeCatalogos(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionAnualidad/BuscarDatosDeCatalogos/',
        data: { cuenta: cuenta },
        success: function (dataResult) {
            $('#Marca').val(dataResult["Marca"]);
            $('#MarcaId').val(dataResult["MarcaId"]);
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error" + data, 'error');
            goAlert();
        }
    })
}

function ObtenerArrayDeResultados(combo) {
    resultadoArray = [];
    var options = $(combo + 'option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    for (var i = 0; i < options.length; i++) {
        if ($(combo).val() === values[i]) {
            resultadoArray.push({
                ResultadoReversionId: values[i],
                ResultadoReversionDescripcion: options[i],
                ResultadoAceptado: true
            });
        }
        else {
            resultadoArray.push({
                ResultadoReversionId: values[i],
                ResultadoReversionDescripcion: options[i],
                ResultadoAceptado: false
            });
        }
    }

    return resultadoArray;
}

function ResetView(tabla, formulario, contenedor) {
    LimpiarTabla(tabla);

    $(formulario).trigger('reset');
    $(contenedor).html("");
}
// #endregion Motor de Retenciones

// #region Variables de Anualidades
function EvaluarVariablesAnualidad(e) {
    e.stopPropagation();
    e.preventDefault();

    var inputs = [];
    var mensaje = [];

    /*Recorremos el contenedor para obtener los valores*/
    $('#motorDeRetencionesAnualidad .requerido').each(function () {
        /*Llenamos los arreglos con la info para la validacion*/
        if ($(this).data('requerido') == true) {
            inputs.push('#' + $(this).attr('id'));
            mensaje.push($(this).attr('attr-message'));
        }
    });

    if (Validar(inputs, mensaje) && !$(".requerido[data-requerido='true']").hasClass('input-has-error')) {
        BuscarDatosDeCatalogos($('#txt_cuenta_n').val());
        BuscarPorTarjeta();

        var form = $('#anualidadForm');
        form.validate();
        if (form.valid()) {
            $.ajax({
                type: 'GET',
                url: urljs + 'EvaluacionAnualidad/EvaluarVariables/',
                data:
                {
                    tipoAnualidad: $('#cbxTipoAnualidad option:selected').text(),
                    cuenta: $('#txt_tarjeta_n').val(),
                    fechaDeCargo: $('#txt_FechaDeCargoAnualidad').val(),
                    segmento: $('#cod_segmento option:selected').text(),
                    montoAnualidad: $('#MontoAnualidad').val(),
                    identidad: $('#txt_identificacion_n').val(),
                },
                success: function (data) {
                    if (data[0].Accion) {
                        LimpiarTabla('#tableVariablesAnualidad');
                        for (var i = 0; i < data.length; i++) {
                            AgregarFilasVariablesEvaluadasAnualidad(data[i], '#tableVariablesAnualidad');
                        }

                        ObtenerResultadosAnualidad(e);
                    }
                    else {
                        GenerarErrorAlerta(data[0].Mensaje, 'error');
                        goAlert();
                    }
                },
                error: function (data, status, xhr) {
                    GenerarErrorAlerta("Se produjo un error: " + status, 'error');
                    goAlert();
                }
            });
        }
    }
    else {
        GenerarErrorAlerta('Verifique que todos los campos necesarios se han llenado', 'error');
        goAlert();
    }
}

function AgregarFilasVariablesEvaluadasAnualidad(ArrayData, table) {
    var elem = document.createElement("img");
    if (ArrayData['EvaluacionCondicion'] === true) {
        elem.setAttribute('src', urljs + 'imgs/True.png');
        elem.setAttribute('height', '16');
        elem.setAttribute('width', '16');
    }
    else {
        elem.setAttribute('src', urljs + 'imgs/False.png');
        elem.setAttribute('height', '16');
        elem.setAttribute('width', '16');
    }

    var img = "";
    var newRow = $(table).dataTable().fnAddData([
        ArrayData['VariableCodigo'],
        ArrayData['ReclamoId'],
        ArrayData['ItemDeReclamoId'],
        ArrayData['ItemDeReclamoNombre'],
        ArrayData['VariableDeItemId'],
        ArrayData['VariableNombre'],
        ArrayData['ValorActual'],
        ArrayData['CondicionLogica'],
        ArrayData['ValorAEvaluar'],
        ArrayData['EvaluacionCondicion'],
        img
    ]);

    var theNode = $(table).dataTable().dataTable().fnSettings().aoData[newRow[0]].nTr;
    theNode.setAttribute('id', ArrayData['VariableCodigo']);
    $('td', theNode)[0].setAttribute('class', 'hidden');
    $('td', theNode)[1].setAttribute('class', 'hidden');
    $('td', theNode)[2].setAttribute('class', 'hidden');
    $('td', theNode)[3].setAttribute('class', 'text-center');
    $('td', theNode)[4].setAttribute('class', 'hidden');
    $('td', theNode)[5].setAttribute('class', 'text-center');
    $('td', theNode)[6].setAttribute('class', 'text-center');
    $('td', theNode)[7].setAttribute('class', 'text-center');
    $('td', theNode)[8].setAttribute('class', 'text-center');
    $('td', theNode)[9].setAttribute('class', 'hidden');
    $('td', theNode)[10].setAttribute('class', 'text-center');
    $('td', theNode)[10].appendChild(elem);

    $(table).DataTable().order([1, 'asc']).draw();
}

function ObtenerResultadosAnualidad(e) {
    e.stopPropagation();
    e.preventDefault();

    var myData = VariablesEvaluadasData('#tableVariablesAnualidad');
    console.log(myData);

    $.ajax({
        type: 'POST',
        url: urljs + 'Citas/ObtenerResultadosAnualidad/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#txt_identificacion_n').val() }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
        success: function (data) {
            if (data['statusCode']) {
                $('#resultadosAnualidadContainer').html(data['resultadosHtml']);
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
            goAlert();
        }
    });
}

function VariablesEvaluadasData(table) {
    var myArray = $(table).DataTable().rows().data().toArray();
    var resultArray = [];
    myArray.forEach(function (item, index) {
        resultArray.push(
            {
                VariableCodigo: item[0],
                ReclamoId: item[1],
                ItemDeReclamoId: item[2],
                ItemDeReclamoNombre: item[3],
                VariableDeItemId: item[4],
                VariableNombre: item[5],
                ValorActual: item[6],
                CondicionLogica: item[7],
                ValorAEvaluar: item[8],
                EvaluacionCondicion: item[9]
            }
        );
    });

    return resultArray;
}

function GuardarAnualidad(e) {
    jQuery.ajaxSetup({ async: false });
    if (VariablesEvaluadasData('#tableVariablesAnualidad').length > 0) {
        var path = '/Citas/GuardarAnualidad/';
        var form = $('#anualidadForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        form.validate();

        var aceptado = false;
        if ($('#resultadoAceptadoAnualidad').prop('checked') === true) {
            aceptado = true;
        }

        if (form.valid()) {
            var myData = {
                __RequestVerificationToken: token,
                citaId: $('#citaId').val(),
                NumeroCuenta: $('#txt_cuenta_n').val(),
                NumeroTarjeta: $('#txt_tarjeta_n').val(),
                Identidad: $('#txt_identificacion_n').val(),
                CIF: $('#CIF').val(),
                Fecha: hoy,
                Familia: $('#txt_familia_n').val(),
                SegmentoId: $('#cod_segmento option:selected').val(),
                Segmento: $('#cod_segmento option:selected').text(),
                Marca: $('#Marca').val(),
                MarcaId: $('#MarcaId').val(),
                TipoAnualidad: $('#cbxTipoAnualidad option:selected').text(),
                TipoAnualidadId: $('#cbxTipoAnualidad option:selected').val(),
                Monto: $('#MontoAnualidad').val(),
                FechaDeCargo: $('#txt_FechaDeCargoAnualidad').val(),
                SaldoActual: $('#SaldoActual').val(),
                Limite: $('#Limite').val(),
                Observacion: $('#observacionAnualidad').val(),
                VariablesEvaluadas: VariablesEvaluadasData('#tableVariablesAnualidad'),
                Resultados: ObtenerArrayDeResultados('#cbxResultadosAnualidad'),
                ResultadoAceptadoPorCliente: aceptado,
                Flujo: 1,
                CanalOAgencia: usu_sucursalId,
            };

            var posting = $.post(path, myData);
            posting.done(function (data) {
                if (data.Accion) {
                    bootbox.alert("Datos de Evaluación guardados correctamente!");
                }
                else {
                    GenerarErrorAlerta(data.Mensaje, 'error');
                    goAlert();
                }
            });

            posting.fail(function (data, status, xhr) {
                GenerarErrorAlerta(status, 'error');
                goAlert();
            });

            posting.always(function () { });
        }
    }
    else {
        GenerarErrorAlerta("Debe Evaluar las Variables Primero para continuar", 'error');
        goAlert();
    }
    jQuery.ajaxSetup({ async: true });
}

function activarTabDesdeAnualidad(e) {
    e.stopPropagation();
    e.preventDefault();

    var aceptado = $('#resultadoAceptadoAnualidad').prop('checked');
    if (VariablesEvaluadasData('#tableVariablesAnualidad').length > 0) {
        if (aceptado) {
            activarTabInicio('tiempo_centros_atencion');
        }
        else {
            activarTab('nueva_cita_calendario');
        }
    }
    else {
        GenerarErrorAlerta("Debe Evaluar las Variables Primero para continuar", 'error');
        goAlert();
    }
}

function AceptadoAnualidadChange(e) {
    if ($('#resultadoAceptadoAnualidad').prop('checked') === true) {
        $('#GuardarAnualidadBtn').removeClass('hidden');
        $('#SiguienteAnualidadBtn').addClass('hidden');
    }
    else {
        $('#GuardarAnualidadBtn').addClass('hidden');
        $('#SiguienteAnualidadBtn').removeClass('hidden');
    }
}

function ResetFormAnualidad(e) {
    e.stopPropagation();

    ResetView('#tableVariablesAnualidad', '#anualidadForm', '#resultadosAnualidadContainer');
}

// #endregion Variables de Anualidades

// #region Variables de Reversion
function OnTipoReversion_1Change(event) {
    event.stopPropagation();
    var seleccionado = $('#TipoReversionId1 :selected').text();
    var idSeleccionado = $('#TipoReversionId1 :selected').val();
    $('#TipoReversionId2').val(seleccionado);
    $('#TipoReversion2').val(idSeleccionado);
    $('#TipoReversionId3').val(seleccionado);
    $('#TipoReversion3').val(seleccionado);
    $('#TipoReversionId4').val(idSeleccionado);
    $('#TipoReversion4').val(seleccionado);
    $('#TipoReversionId5').val(idSeleccionado);
    $('#TipoReversion5').val(seleccionado);
    $('#TipoReversionId6').val(idSeleccionado);
    $('#TipoReversion6').val(seleccionado);
}

function EvaluarVariablesReversion(e) {
    e.stopPropagation();

    BuscarPorTarjeta();

    var form = $('#reversionForm');
    form.validate();
    if (form.valid()) {
        if ($('#TipoReversionId1').val() !== "") {
            var misCargos = [];
            if (($('#Monto1').val() !== "0.00" || $('#Monto1').val() !== "0")
                && $('#TipoReversionId1').val() !== "") {
                misCargos.push({
                    NumeroCargo: 1,
                    fechaCargo: $('#txt_FechaCargo1').val(),
                    tipoReversion: $('#TipoReversionId1 option:selected').text(),
                    monto: $('#Monto1').val()
                });
            }
            if (($('#Monto2').val() !== "0.00" || $('#Monto2').val() !== "0")
                && $('#TipoReversionId2').val() !== "") {
                misCargos.push({
                    NumeroCargo: 2,
                    fechaCargo: $('#txt_FechaCargo2').val(),
                    tipoReversion: $('#TipoReversion2').val(),
                    monto: $('#Monto2').val()
                });
            }
            if (($('#Monto3').val() !== "0.00" || $('#Monto3').val() !== "0")
                && $('#TipoReversionId3').val() !== "") {
                misCargos.push({
                    NumeroCargo: 3,
                    fechaCargo: $('#txt_FechaCargo3').val(),
                    tipoReversion: $('#TipoReversion3').val(),
                    monto: $('#Monto3').val()
                });
            }
            if (($('#Monto4').val() !== "0.00" || $('#Monto4').val() !== "0")
                && $('#TipoReversionId4').val() !== "") {
                misCargos.push({
                    NumeroCargo: 4,
                    fechaCargo: $('#txt_FechaCargo4').val(),
                    tipoReversion: $('#TipoReversion4').val(),
                    monto: $('#Monto4').val()
                });
            }
            if (($('#Monto5').val() !== "0.00" || $('#Monto5').val() !== "0")
                && $('#TipoReversionId5').val() !== "") {
                misCargos.push({
                    NumeroCargo: 5,
                    fechaCargo: $('#txt_FechaCargo5').val(),
                    tipoReversion: $('#TipoReversion5').val(),
                    monto: $('#Monto5').val()
                });
            }
            if (($('#Monto6').val() !== "0.00" || $('#Monto6').val() !== "0")
                && $('#TipoReversionId6').val() !== "") {
                misCargos.push({
                    NumeroCargo: 6,
                    fechaCargo: $('#txt_FechaCargo6').val(),
                    tipoReversion: $('#TipoReversion6').val(),
                    monto: $('#Monto6').val()
                });
            }

            var Cargos = {
                cuenta: $('#txt_tarjeta_n').val(),
                segmento: $('#cod_segmento option:selected').text(),
                identidad: $('#txt_identificacion_n').val(),
                Cargos: misCargos
            };

            $.ajax({
                type: 'POST',
                url: urljs + 'EvaluacionReversion/EvaluarVariables/',
                data: JSON.stringify({ myData: Cargos }),
                contentType: 'application/json;',
                dataType: 'JSON',
                traditional: true,
                success: function (data) {
                    if (data[0].Accion) {
                        LimpiarTabla('#resultadosDeVariablesReversion');
                        for (var i = 0; i < data.length; i++) {
                            AgregarFilasATablaVariablesReversion(data[i], '#resultadosDeVariablesReversion');
                        }

                        ObtenerResultadosReversion(e);
                    }
                },
                error: function (data, status, xhr) {
                    GenerarErrorAlerta("Se produjo un error: " + data[0].Mensaje, 'error');
                    goAlert();
                }
            });
        }
        else {
            bootbox.alert("Debe llenar los datos del primer reclamo al menos!");
        }
    }
}

function AgregarFilasATablaVariablesReversion(ArrayData, table) {
    var elem = document.createElement("img");
    if (ArrayData['EvaluacionCondicion'] === true) {
        elem.setAttribute('src', urljs + 'imgs/True.png');
        elem.setAttribute('height', '16');
        elem.setAttribute('width', '16');
    }
    else {
        elem.setAttribute('src', urljs + 'imgs/False.png');
        elem.setAttribute('height', '16');
        elem.setAttribute('width', '16');
    }

    var img = "";
    var newRow = $(table).dataTable().fnAddData([
        ArrayData['CargoNumero'],
        ArrayData['VariableCodigo'],
        ArrayData['ReclamoId'],
        ArrayData['ItemDeReclamoId'],
        ArrayData['ItemDeReclamoNombre'],
        ArrayData['VariableDeItemId'],
        ArrayData['VariableNombre'],
        ArrayData['ValorActual'],
        ArrayData['CondicionLogica'],
        ArrayData['ValorAEvaluar'],
        ArrayData['EvaluacionCondicion'],
        img
    ]);

    var theNode = $(table).dataTable().dataTable().fnSettings().aoData[newRow[0]].nTr;
    theNode.setAttribute('id', ArrayData['VariableCodigo']);
    $('td', theNode)[0].setAttribute('class', 'text-center');
    $('td', theNode)[1].setAttribute('class', 'hidden');
    $('td', theNode)[2].setAttribute('class', 'hidden');
    $('td', theNode)[3].setAttribute('class', 'hidden');
    $('td', theNode)[4].setAttribute('class', 'text-center');
    $('td', theNode)[5].setAttribute('class', 'hidden');
    $('td', theNode)[6].setAttribute('class', 'text-center');
    $('td', theNode)[7].setAttribute('class', 'text-center');
    $('td', theNode)[8].setAttribute('class', 'text-center');
    $('td', theNode)[9].setAttribute('class', 'text-center');
    $('td', theNode)[10].setAttribute('class', 'hidden');
    $('td', theNode)[11].setAttribute('class', 'text-center');
    $('td', theNode)[11].appendChild(elem);

    $(table).DataTable().order([0, 'asc']).draw();
}

function ObtenerResultadosReversion(e) {
    e.stopPropagation();
    var myData = VariablesEvaluadasDataReversion('#resultadosDeVariablesReversion');

    $.ajax({
        type: 'POST',
        url: urljs + 'Citas/ObtenerResultadosReversion/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#txt_identificacion_n').val() }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
        success: function (data) {
            if (data['statusCode']) {
                $('#resultadosContainerReversion').html(data['resultadosHtml']);
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
            goAlert();
        }
    });
}

function VariablesEvaluadasDataReversion(table) {
    var myArray = $(table).DataTable().rows().data().toArray();
    var resultArray = [];
    myArray.forEach(function (item, index) {
        resultArray.push(
            {
                CargoNumero: item[0],
                VariableCodigo: item[1],
                ReclamoId: item[2],
                ItemDeReclamoId: item[3],
                ItemDeReclamoNombre: item[4],
                VariableDeItemId: item[5],
                VariableNombre: item[6],
                ValorActual: item[7],
                CondicionLogica: item[8],
                ValorAEvaluar: item[9],
                EvaluacionCondicion: item[10]
            }
        );
    });

    return resultArray;
}

function ClearFields() {
    $('#TipoReversionId1').val(0);
    $('#TipoReversionId2').val(0);
    $('#TipoReversionId3').val(0);
    $('#TipoReversionId4').val(0);
    $('#TipoReversionId5').val(0);
    $('#TipoReversionId6').val(0);
}

function ResetFormReversion(e) {
    e.stopPropagation();
    e.preventDefault();

    ClearFields();

    ResetView('#resultadosDeVariablesReversion', '#reversionForm', '#resultadosContainerReversion');
}

function GuardarReversion(e) {
    e.stopPropagation();
    e.preventDefault();

    if (VariablesEvaluadasDataReversion('#resultadosDeVariablesReversion').length > 0) {
        var path = urljs + 'Citas/GuardarReversion/';
        var form = $('#reversionForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        var aceptado = false;
        if ($('#resultadoAceptadoReversion').prop('checked') === true) {
            aceptado = true;
        }

        form.validate();
        if (form.valid()) {
            var myData = {
                __RequestVerificationToken: token,
                NumeroCuenta: $('#txt_cuenta_n').val(),
                NumeroTarjeta: $('#txt_tarjeta_n').val(),
                Identidad: $('#txt_identificacion_n').val(),
                citaId: $('#citaId').val(),
                CIF: $('#CIF').val(),
                Fecha: hoy,
                Familia: $('#txt_familia_n').val(),
                SegmentoId: $('#cod_segmento option:selected').val(),
                Segmento: $('#cod_segmento option:selected').text(),
                Marca: $('#Marca').val(),
                MarcaId: $('#MarcaId').val(),
                SaldoActual: $('#SaldoActual').val(),
                Limite: $('#Limite').val(),
                Observacion: $('#observacionReversion').val(),
                VariablesEvaluadas: VariablesEvaluadasDataReversion('#resultadosDeVariablesReversion'),
                ResultadosDeReversion: ObtenerArrayDeResultados('#cbxResultadosReversion'),
                TipoReversionId_1: $('#TipoReversionId1').val(),
                TipoReversion_1: $('#TipoReversionId1 option:selected').text(),
                FechaCargo_1: $('#txt_FechaCargo1').val(),
                Monto_1: $('#Monto1').val(),
                TipoReversionId_2: $('#TipoReversionId2').val(),
                TipoReversion_2: $('#TipoReversionId2 option:selected').text(),
                FechaCargo_2: $('#txt_FechaCargo2').val(),
                Monto_2: $('#Monto2').val(),
                TipoReversionId_3: $('#TipoReversionId3').val(),
                TipoReversion_3: $('#TipoReversionId3 option:selected').text(),
                FechaCargo_3: $('#txt_FechaCargo3').val(),
                Monto_3: $('#Monto3').val(),
                TipoReversionId_4: $('#TipoReversionId4').val(),
                TipoReversion_4: $('#TipoReversionId4 option:selected').text(),
                FechaCargo_4: $('#txt_FechaCargo4').val(),
                Monto_4: $('#Monto4').val(),
                TipoReversionId_5: $('#TipoReversionId5').val(),
                TipoReversion_5: $('#TipoReversionId5 option:selected').text(),
                FechaCargo_5: $('#txt_FechaCargo5').val(),
                Monto_5: $('#Monto5').val(),
                TipoReversionId_6: $('#TipoReversionId6').val(),
                TipoReversion_6: $('#TipoReversionId6 option:selected').text(),
                FechaCargo_6: $('#txt_FechaCargo6').val(),
                Monto_6: $('#Monto6').val(),
                Flujo: 1,
                ResultadoAceptadoPorCliente: aceptado,
                CanalOAgencia: usu_sucursalId,
            };

            var posting = $.post(path, myData);
            posting.done(function (data) {
                if (data.Accion) {
                    bootbox.alert(data.Mensaje);
                }
                else {
                    if (data.statusCode === '400') {
                        GenerarErrorAlerta(data.statusMessage, 'error');
                        goAlert();
                    }
                    else {
                        GenerarErrorAlerta(data.Mensaje, 'error');
                        goAlert();
                    }
                }
            });

            posting.fail(function (data, status, xhr) {
                GenerarErrorAlerta(status, 'error');
                goAlert();
            });

            posting.always(function () { });
        }
    }
    else {
        GenerarErrorAlerta("Debe Evaluar las Variables Primero para continuar", 'error');
        goAlert();
    }
}

function activarTabDesdeReversion(e) {
    e.stopPropagation();
    e.preventDefault();
    var aceptado = $('#resultadoAceptadoReversion').prop('checked');
    if (VariablesEvaluadasDataReversion('#resultadosDeVariablesReversion').length > 0) {
        if (aceptado) {
            activarTabInicio('tiempo_centros_atencion');
        }
        else {
            activarTab('nueva_cita_calendario');
        }
    }
    else {
        GenerarErrorAlerta("Debe Evaluar las Variables Primero para continuar", 'error');
        goAlert();
    }
}

function AceptadoReversionChange(e) {
    if ($('#resultadoAceptadoReversion').prop('checked') === true) {
        $('#GuardarReversionBtn').removeClass('hidden');
        $('#SiguienteReversionBtn').addClass('hidden');
    }
    else {
        $('#GuardarReversionBtn').addClass('hidden');
        $('#SiguienteReversionBtn').removeClass('hidden');
    }
}
// #endregion Variables de Reversion

// #region Variables de Tasas
function EvaluarVariablesTasa(e) {
    e.stopPropagation();
    e.preventDefault();

    BuscarPorTarjeta();

    var inputs = [];
    var mensaje = [];
    /*Recorremos el contenedor para obtener los valores*/
    $('#tasaForm .requerido').each(function () {
        /*Llenamos los arreglos con la info para la validacion*/
        if ($(this).data('requerido') == true) {
            inputs.push('#' + $(this).attr('id'));
            mensaje.push($(this).attr('attr-message'));
        }
    });

    if (Validar(inputs, mensaje) && !$(".requerido[data-requerido='true']").hasClass('input-has-error')) {
        var form = $('#tasaForm');
        form.validate();
        if (form.valid()) {
            $.ajax({
                type: 'GET',
                url: urljs + 'EvaluacionTasa/EvaluarVariables/',
                data:
                {
                    cuenta: $('#txt_tarjeta_n').val(),
                    fechaDelCambio: $('#txt_FechaDelCambioTasa').val(),
                    segmento: $('#cod_segmento option:selected').text(),
                    tasaActual: $('#TasaAnualizadaActual').val(),
                    identidad: $('#txt_identificacion_n').val()
                },
                success: function (data) {
                    if (data[0].Accion) {
                        LimpiarTabla('#resultadosDeVariablesTasas');
                        for (var i = 0; i < data.length; i++) {
                            AgregarFilasVariablesEvaluadasTasa(data[i], '#resultadosDeVariablesTasas');
                        }

                        ObtenerResultadosTasa(e);
                    }
                    else {
                        GenerarErrorAlerta(data[0].Mensaje, 'error');
                        goAlert();
                    }
                },
                error: function (data, status, xhr) {
                    GenerarErrorAlerta("Se produjo un error: " + status, 'error');
                    goAlert();
                }
            });
        }
    }
}

function AgregarFilasVariablesEvaluadasTasa(ArrayData, table) {
    var elem = document.createElement("img");
    if (ArrayData['EvaluacionCondicion'] === true) {
        elem.setAttribute('src', urljs + 'imgs/True.png');
        elem.setAttribute('height', '16');
        elem.setAttribute('width', '16');
    }
    else {
        elem.setAttribute('src', urljs + 'imgs/False.png');
        elem.setAttribute('height', '16');
        elem.setAttribute('width', '16');
    }

    var img = "";
    var newRow = $(table).dataTable().fnAddData([
        ArrayData['VariableCodigo'],
        ArrayData['ReclamoId'],
        ArrayData['ItemDeReclamoId'],
        ArrayData['ItemDeReclamoNombre'],
        ArrayData['VariableDeItemId'],
        ArrayData['VariableNombre'],
        ArrayData['ValorActual'],
        ArrayData['CondicionLogica'],
        ArrayData['ValorAEvaluar'],
        ArrayData['EvaluacionCondicion'],
        img
    ]);

    var theNode = $(table).dataTable().dataTable().fnSettings().aoData[newRow[0]].nTr;
    theNode.setAttribute('id', ArrayData['VariableCodigo']);
    $('td', theNode)[0].setAttribute('class', 'hidden');
    $('td', theNode)[1].setAttribute('class', 'hidden');
    $('td', theNode)[2].setAttribute('class', 'hidden');
    $('td', theNode)[3].setAttribute('class', 'text-center');
    $('td', theNode)[4].setAttribute('class', 'hidden');
    $('td', theNode)[5].setAttribute('class', 'text-center');
    $('td', theNode)[6].setAttribute('class', 'text-center');
    $('td', theNode)[7].setAttribute('class', 'text-center');
    $('td', theNode)[8].setAttribute('class', 'text-center');
    $('td', theNode)[9].setAttribute('class', 'hidden');
    $('td', theNode)[10].setAttribute('class', 'text-center');
    $('td', theNode)[10].appendChild(elem);

    $(table).DataTable().order([1, 'asc']).draw();
}

function VariablesEvaluadasDataTasa(table) {
    var myArray = $(table).DataTable().rows().data().toArray();
    var resultArray = [];
    myArray.forEach(function (item, index) {
        resultArray.push(
            {
                VariableCodigo: item[0],
                ReclamoId: item[1],
                ItemDeReclamoId: item[2],
                ItemDeReclamoNombre: item[3],
                VariableDeItemId: item[4],
                VariableNombre: item[5],
                ValorActual: item[6],
                CondicionLogica: item[7],
                ValorAEvaluar: item[8],
                EvaluacionCondicion: item[9]
            }
        );
    });

    return resultArray;
}

function ObtenerResultadosTasa(e) {
    e.stopPropagation();
    var myData = VariablesEvaluadasDataTasa('#resultadosDeVariablesTasas');

    $.ajax({
        type: 'POST',
        url: urljs + 'Cita/ObtenerResultadosTasa/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#txt_identificacion_n').val() }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
        success: function (data) {
            if (data['statusCode']) {
                $('#resultadosContainerTasa').html(data['resultadosHtml']);
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
            goAlert();
        }
    });
}

function GuardarTasa(e) {
    e.stopPropagation();
    e.preventDefault();

    if (VariablesEvaluadasDataTasa('#resultadosDeVariablesTasas').length > 0) {
        var path = urljs + 'Cita/GuardarTasa/';
        var form = $('#TasaForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();

        var aceptado = false;
        if ($('#resultadoAceptadoTasa').prop('checked') === true) {
            aceptado = true;
        }

        form.validate();
        if (form.valid()) {
            var myData = {
                __RequestVerificationToken: token,
                NumeroTarjeta: $('#txt_tarjeta_n').val(),
                NumeroCuenta: $('#txt_cuenta_n').val(),
                Identidad: $('#txt_identificacion_n').val(),
                CIF: $('#CIF').val(),
                citaId: $('#citaId').val(),
                Fecha: hoy,
                Familia: $('#txt_familia_n').val(),
                SegmentoId: $('#cod_segmento option:selected').val(),
                Segmento: $('#cod_segmento option:selected').text(),
                Marca: $('#Marca').val(),
                MarcaId: $('#MarcaId').val(),
                SaldoActual: $('#SaldoActual').val(),
                Limite: $('#Limite').val(),
                TasaAnualizadaActual: $('#TasaAnualizadaActual').val(),
                FechaDelCambio: $('#txt_FechaDelCambioTasa').val(),
                Observacion: $('#observacionTasa').val(),
                VariablesEvaluadas: VariablesEvaluadasDataTasa('#resultadosDeVariablesTasas'),
                Resultados: ObtenerArrayDeResultados(),
                CanalOAgencia: usu_sucursalId,
                ResultadoAceptadoPorCliente: aceptado,
                Flujo: 1
            };

            var posting = $.post(path, myData);
            posting.done(function (data) {
                if (data.Accion) {
                    bootbox.alert(data.Mensaje);
                }
                else {
                    GenerarErrorAlerta(data.Mensaje, 'error');
                    goAlert();
                }
            });

            posting.fail(function (data, status, xhr) {
                form.trigger('reset');
                GenerarErrorAlerta(status, 'error');
                goAlert();
            });

            posting.always(function () { });
        }
    }
    else {
        GenerarErrorAlerta("Debe Evaluar las Variables Primero para continuar", 'error');
        goAlert();
    }
}

function ResetFormTasa(e) {
    e.stopPropagation();

    ResetView('#resultadosDeVariablesTasas', '#tasaForm', '#resultadosConatinerTasa');
}

function AceptadoTasaChange(e) {
    if ($('#resultadoAceptadoTasa').prop('checked') === true) {
        $('#GuardarTasaBtn').removeClass('hidden');
        $('#SiguienteTasaBtn').addClass('hidden');
    }
    else {
        $('#GuardarTasaBtn').addClass('hidden');
        $('#SiguienteTasaBtn').removeClass('hidden');
    }
}

function activarTabDesdeTasa(e) {
    e.stopPropagation();
    e.preventDefault();

    var aceptado = $('#resultadoAceptadoTasa').prop('checked');
    if (VariablesEvaluadasDataReversion('#resultadosDeVariablesTasas').length > 0) {
        if (aceptado) {
            activarTabInicio('tiempo_centros_atencion');
        }
        else {
            activarTab('nueva_cita_calendario');
        }
    }
    else {
        GenerarErrorAlerta("Debe Evaluar las Variables Primero para continuar", 'error');
        goAlert();
    }
}
// #endregion Variables de Tasas

function RegresarPantallaAnterior(e) {
    var pathConfig = urljs + 'Citas/ConfiguracionMotor/';
    var posting = $.post(pathConfig, null);
    posting.done(function (resultData) {
        if (resultData === "Motor Visible") {
            if ($('#cod_tramite option:selected').text() === 'Anualidad-Desc') {
                activarTab("motorDeRetencionesAnualidad");
            }
            else if ($('#cod_tramite option:selected').text() === 'Reversion-Desc') {
                activarTab("motorDeRetencionesReversion");
            }
            else if ($('#cod_tramite option:selected').text() === 'Tasa de Interes-Desc') {
                activarTab("motorDeRetencionesTasas");
            }
            else if ($('#cod_tramite option:selected').text() === 'Combos-Desc') {
            }
            else {
                activarTab("nueva_cita_razon");
            }
        }
        else {
            activarTab("nueva_cita_razon");
        }
    });
}

// copia de la funcion BuscarPorTarjeta pero solo nos interesa el numero de cuenta
function BuscarPorTarjetaLite() {
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionAnualidad/BuscarPorTarjetaAutoServ/',
        data: { tarjeta: $('#txt_tarjeta_n').val() },
        success: function (result) {
            //$('#txt_cuenta_n').val(result.dataList[0].Cuenta);
            $('#txt_cuenta_n').val(result.Cuenta);
            $('#txt_nombre_n').val(result.Nombre);
            $('#txt_email_n').val(result.Email);
            $('#txt_cel_n').val(result.Telefono);
            $('#txt_identificacion_n').val(result.Identidad);
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error al recuperar el numero de cuenta " + status, 'error');
            goAlert();
        }
    });
}