$(document).ready(function () {
    checkUserAccess('MTR030');
});

function BuscarDatosDeCatalogosReversion(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionReversion/BuscarDatosDeCatalogos/',
        data: { cuenta: cuenta },
        success: function (dataResult) {
            $('#Familia').val(dataResult["Familia"]);
            $('#Segmento').val(dataResult["Segmento"]);
            $('#Marca').val(dataResult["Marca"]);
            $('#MarcaId').val(dataResult["MarcaId"]);
            $('#SegmentoId').val(dataResult["SegmentoId"]);
        },
        error: function (xhr, textstatus, error) {
            bootbox.alert(" error: " + error);
        }
    });
}

function BuscarPorTarjetaReversion(e) {
    e.stopPropagation();

    var numeroTarjeta = $('#NumeroTarjeta');
    numeroTarjeta.validate();
    if (numeroTarjeta.valid()) {
        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionReversion/BuscarPorTarjeta/',
            data: { tarjeta: numeroTarjeta.val() },
            success: function (result) {
                $('#CIF').val(result.dataList[0].Cif);
                $('#SaldoActual').val(result.dataList[0].SaldoVencido);
                $('#Limite').val(result.dataList[0].Limite);
                $('#NumeroCuenta').val(result.dataList[0].Cuenta);
                $('#Clasificacion').val(result.dataList[0].ClasificacionCuenta);
                BuscarDatosDeCatalogosReversion(result.dataList[0].Cuenta);
            },
            error: function (data, status, xhr) {
                GenerarErrorAlerta("Se produjo un error" + status, 'error');
                goAlert();
            }
        });
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
        ArrayData['CodeGroupVariable'],
        ArrayData['GroupVariable'],   
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
    $('td', theNode)[5].setAttribute('class', 'text-center');

    $('td', theNode)[6].setAttribute('class', 'text-center');   
    $('td', theNode)[7].setAttribute('class', 'hidden');
    $('td', theNode)[8].setAttribute('class', 'text-center');
    $('td', theNode)[9].setAttribute('class', 'text-center');
    $('td', theNode)[10].setAttribute('class', 'text-center');
    $('td', theNode)[11].setAttribute('class', 'text-center');
    $('td', theNode)[12].setAttribute('class', 'hidden');

    $('td', theNode)[13].setAttribute('class', 'text-center');
    $('td', theNode)[13].appendChild(elem);

    $(table).DataTable().order([0, 'asc']).draw();
}

function EvaluarVariablesReversion(e,formulario='') {
    e.stopPropagation();
    debugger;
    var form = $('#ReversionForm'+formulario);
    form.validate();
    if (form.valid()) {
        if ($('#TipoReversionId_1' + formulario).val() !== "") {
            var misCargos = [];
            if (($('#Monto_1' + formulario).val() !== "0.00" || $('#Monto_1' + formulario).val() !== "0") && $('#TipoReversion_1' + formulario).val() !== "") {
                misCargos.push({
                    NumeroCargo: 1,
                    fechaCargo: $('#FechaCargo_1' + formulario).val(),
                    tipoReversion: $('#TipoReversion_1' + formulario).val(),
                    monto: $('#Monto_1' + formulario).val()
                });
            }
            if (($('#Monto_2' + formulario).val() !== "0.00" || $('#Monto_2' + formulario).val() !== "0") && $('#TipoReversion_2' + formulario).val() !== "") {
                misCargos.push({
                    NumeroCargo: 2,
                    fechaCargo: $('#FechaCargo_2' + formulario).val(),
                    tipoReversion: $('#TipoReversion_2' + formulario).val(),
                    monto: $('#Monto_2' + formulario).val()
                });
            }
            if (($('#Monto_3' + formulario).val() !== "0.00" || $('#Monto_3' + formulario).val() !== "0") && $('#TipoReversion_3' + formulario).val() !== "") {
                misCargos.push({
                    NumeroCargo: 3,
                    fechaCargo: $('#FechaCargo_3' + formulario).val(),
                    tipoReversion: $('#TipoReversion_3' + formulario).val(),
                    monto: $('#Monto_3' + formulario).val()
                });
            }
            if (($('#Monto_4' + formulario).val() !== "0.00" || $('#Monto_4' + formulario).val() !== "0") && $('#TipoReversion_4' + formulario).val() !== "") {
                misCargos.push({
                    NumeroCargo: 4,
                    fechaCargo: $('#FechaCargo_4' + formulario).val(),
                    tipoReversion: $('#TipoReversion_4' + formulario).val(),
                    monto: $('#Monto_4' + formulario).val()
                });
            }
            if (($('#Monto_5' + formulario).val() !== "0.00" || $('#Monto_5' + formulario).val() !== "0") && $('#TipoReversion_5' + formulario).val() !== "") {
                misCargos.push({
                    NumeroCargo: 5,
                    fechaCargo: $('#FechaCargo_5' + formulario).val(),
                    tipoReversion: $('#TipoReversion_5' + formulario).val(),
                    monto: $('#Monto_5' + formulario).val()
                });
            }
            if (($('#Monto_6' + formulario).val() !== "0.00" || $('#Monto_6' + formulario).val() !== "0") && $('#TipoReversion_6' + formulario).val() !== "") {
                misCargos.push({
                    NumeroCargo: 6,
                    fechaCargo: $('#FechaCargo_6' + formulario).val(),
                    tipoReversion: $('#TipoReversion_6' + formulario).val(),
                    monto: $('#Monto_6' + formulario).val()
                });
            }

            var Cargos = {
                cuenta: $('#NumeroTarjeta').val(),
                segmento: $('#Segmento').val(),
                identidad: $('#Identidad').val(),
                Cargos: misCargos
            };

            $.ajax({
                type: 'POST',
                url: urljs + 'EvaluacionReversion/EvaluarVariables/',
                data: JSON.stringify({ myData: Cargos }),
                contentType: 'application/json;',
                dataType: 'JSON',
                traditional: true,
                async: false,
                success: function (data) {
                    if (data.length > 0) {
                        if (data[0].Accion) {
                            LimpiarTabla('#resultadosDeVariables' + formulario);
                            for (var i = 0; i < data.length; i++) {
                                AgregarFilasATablaVariablesReversion(data[i], '#resultadosDeVariables' + formulario);
                            }

                            ObtenerResultadosReversion(e, formulario);
                        }
                        else {
                            GenerarErrorAlerta("Se produjo un error: " + data[0].Mensaje, 'error');
                            goAlert();
                        }
                    }
                    else {
                        GenerarErrorAlerta("No se recuperaron datos: ", 'info');
                        goAlert();
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
    else {
        bootbox.alert("Debe llenar los datos del primer reclamo al menos!");
    }
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
                CodeGroupVariable: item[4],
                GroupVariable: item[5],               
                ItemDeReclamoNombre: item[6],
                VariableDeItemId: item[7],
                VariableNombre: item[8],
                ValorActual: item[9],
                CondicionLogica: item[10],
                ValorAEvaluar: item[11],
                EvaluacionCondicion: item[12]
            }
        );
    });

    return resultArray;
}

function ObtenerResultadosReversion(e,formulario='') {
    e.stopPropagation();
    var myData = VariablesEvaluadasDataReversion('#resultadosDeVariables');

    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionReversion/ObtenerResultados/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#Identidad').val(), formulario: formulario }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
         async : false,
        success: function (data) {
            if (data['statusCode']) {
                $('#resultadosContainer'+formulario).html(data['resultadosHtml']);
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
            goAlert();
        }
    });
}

function OnTipoReversion_1Change(event) {
    event.stopPropagation();
    //  console.log(event);
    debugger;
   // console.log(event);
    //console.log(event.currentTarget);
   // console.log($(event).change);
    var formulario = '';
    var arr = event.currentTarget.id.split('_');
    if (arr.length > 2) {
        formulario = "_" + arr[2];
    }

    var seleccionado = $('#TipoReversionId_1' + formulario + ' :selected').text();
    var idSeleccionado = $('#TipoReversionId_1' + formulario+ ' :selected').val();
    $('#TipoReversion_1' + formulario).val(seleccionado);
    $('#TipoReversionId_2' + formulario).val(idSeleccionado);
    $('#TipoReversion_2' + formulario).val(seleccionado);
    $('#TipoReversionId_3' + formulario).val(idSeleccionado);
    $('#TipoReversion_3' + formulario).val(seleccionado);
    $('#TipoReversionId_4' + formulario).val(idSeleccionado);
    $('#TipoReversion_4' + formulario).val(seleccionado);
    $('#TipoReversionId_5' + formulario).val(idSeleccionado);
    $('#TipoReversion_5' + formulario).val(seleccionado);
    $('#TipoReversionId_6' + formulario).val(idSeleccionado);
    $('#TipoReversion_6' + formulario).val(seleccionado);
}

function GuardarReversion(e,formulario='') {
    e.stopPropagation();
    e.preventDefault();

    debugger;
    var path = urljs + 'EvaluacionReversion/GuardarReversion/';
    var form = $('#ReversionForm'+formulario);
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    var aceptado = false;
    if ($('#resultadoAceptado').prop('checked') === true) {
        aceptado = true;
    }

    var _lcombo = '';
    if (typeof _ComboId !== 'undefined') {
        // variable is undefined
        _lcombo = _ComboId;
    }

    form.validate();
    if (form.valid()) {
        var myData = {
            __RequestVerificationToken: token,
            NumeroCuenta: $('#NumeroCuenta').val(),
            NumeroTarjeta: $('#NumeroTarjeta').val(),
            Identidad: $('#Identidad').val(),
            CIF: $('#CIF').val(),
            Fecha: $('#Fecha').val(),
            Familia: $('#Familia').val(),
            SegmentoId: $('#SegmentoId').val(),
            Segmento: $('#Segmento').val(),
            Marca: $('#Marca').val(),
            MarcaId: $('#MarcaId').val(),
            SaldoActual: $('#SaldoActual').val(),
            Limite: $('#Limite').val(),
            Observacion: $('#Observacion' + formulario).val(),
            VariablesEvaluadas: VariablesEvaluadasDataReversion('#resultadosDeVariables' + formulario),
            ResultadosDeReversion: OntenerArrayDeResultadosReversion(formulario),
            TipoReversionId_1: $('#TipoReversionId_1'+formulario).val(),
            TipoReversion_1: $('#TipoReversion_1' + formulario).val(),
            FechaCargo_1: $('#FechaCargo_1' + formulario).val(),
            Monto_1: $('#Monto_1' + formulario).val(),
            TipoReversionId_2: $('#TipoReversionId_2' + formulario).val(),
            TipoReversion_2: $('#TipoReversion_2' + formulario).val(),
            FechaCargo_2: $('#FechaCargo_2' + formulario).val(),
            Monto_2: $('#Monto_2' + formulario).val(),
            TipoReversionId_3: $('#TipoReversionId_3' + formulario).val(),
            TipoReversion_3: $('#TipoReversion_3' + formulario).val(),
            FechaCargo_3: $('#FechaCargo_3' + formulario).val(),
            Monto_3: $('#Monto_3' + formulario).val(),
            TipoReversionId_4: $('#TipoReversionId_4' + formulario).val(),
            TipoReversion_4: $('#TipoReversion_4' + formulario).val(),
            FechaCargo_4: $('#FechaCargo_4' + formulario).val(),
            Monto_4: $('#Monto_4' + formulario).val(),
            TipoReversionId_5: $('#TipoReversionId_5' + formulario).val(),
            TipoReversion_5: $('#TipoReversion_5' + formulario).val(),
            FechaCargo_5: $('#FechaCargo_5' + formulario).val(),
            Monto_5: $('#Monto_5' + formulario).val(),
            TipoReversionId_6: $('#TipoReversionId_6' + formulario).val(),
            TipoReversion_6: $('#TipoReversion_6' + formulario).val(),
            FechaCargo_6: $('#FechaCargo_6' + formulario).val(),
            Monto_6: $('#Monto_6' + formulario).val(),
            Flujo: 2,
            ResultadoAceptadoPorCliente: aceptado,
            CanalOAgencia: usu_sucursalId,
            ComboId: _lcombo
        };

        try {
            $.ajax({
                type: 'POST',
                url: path,
                data: JSON.stringify(myData),
                contentType: 'application/json;',
                dataType: 'JSON',
                async: false,
                success: function (data) {
                    debugger;
                    if (data.Accion && _lcombo === '') {
                        bootbox.alert(data.Mensaje);
                    }
                    else if (!data.Accion) {
                        GenerarErrorAlerta(data.Mensaje, 'error');
                        goAlert();
                    }

                },
                error: function (data, status, xhr) {
                    debugger;
                    console.log(data.responseText);
                    GenerarErrorAlerta("Se produjo un error: " + data.responseText + " ", + status, 'error');
                    //form.trigger('reset');
                    goAlert();
                    return;
                }
            });

        } catch (e) {
            console.log(e);
            GenerarErrorAlerta("Se produjo un error: " + e , 'error');
        }


       // $.ajaxSetup({ async: false });  
        //var posting = $.post(path, myData);
        //posting.done(function (data) {
        //    if (data.Accion) {
        //        bootbox.alert({
        //            message: data.Mensaje,
        //            callback: function () {
        //                ResetViewReversion();
        //            }
        //        });
        //    }
        //    else {
        //        GenerarErrorAlerta(data.Mensaje, 'error');
        //        goAlert();
        //    }
        //});

        //posting.fail(function (data, status, xhr) {
        //    form.trigger('reset');
        //    GenerarErrorAlerta(status, 'error');
        //    goAlert();
        //});

        //posting.always(function () { });
    }
}

function OntenerArrayDeResultadosReversion(formulario='') {
    //resultadoArray = [];
    //var options = $('#CBX option');
    //var values = $.map(options, function (option) {
    //    return option.value;
    //});

    resultadoArray = [];
    var options = $('#Resultados' + formulario + ' option');
    var values = $.map(options, function (option) {
        return option.value;
    });

   
    //for (var i = 0; i < options.length; i++) {
    // se pone desde 1 porque el item 0 es "Seleccione un Resultado"
    for (var i = 1; i < options.length; i++) {
        //if ($('#CBX').val() === values[i]) {
        if ($('#Resultados' + formulario).val() === values[i]) {
            resultadoArray.push({
                ResultadoReversionId: values[i],
                ResultadoReversionDescripcion: options[i],
                ResultadoReversionAceptada: true
            });
        }
        else {
            resultadoArray.push({
                ResultadoReversionId: values[i],
                ResultadoReversionDescripcion: options[i],
                ResultadoReversionAceptada: false
            });
        }
    }

    return resultadoArray;
}

function ClearFieldsReversion() {
    $('#TipoReversionId_1').val(0);
    //$('#TipoReversion_1').val("");
    //$('#FechaCargo_1').datepicker().datepicker('setDate', new Date());
    //$('#Monto_1').val("0.00");

    $('#TipoReversionId_2').val(0);
    //$('#TipoReversion_2').val("");
    //$('#FechaCargo_2').datepicker().datepicker('setDate', new Date());
    //$('#Monto_2').val("0.00");

    $('#TipoReversionId_3').val(0);
    //$('#TipoReversion_3').val("");
    //$('#FechaCargo_3').datepicker().datepicker('setDate', new Date());
    //$('#Monto_3').val("0.00");

    $('#TipoReversionId_4').val(0);
    //$('#TipoReversion_4').val("");
    //$('#FechaCargo_4').datepicker().datepicker('setDate', new Date());
    //$('#Monto_4').val("0.00");

    $('#TipoReversionId_5').val(0);
    //$('#TipoReversion_5').val("");
    //$('#FechaCargo_5').datepicker().datepicker('setDate', new Date());
    //$('#Monto_5').val("0.00");

    $('#TipoReversionId_6').val(0);
    //$('#TipoReversion_6').val("");
    //$('#FechaCargo_6').datepicker().datepicker('setDate', new Date());
    //$('#Monto_6').val("0.00");

    $('#Observacion').val('');
}

function ResetViewReversion() {
    LimpiarTabla('#resultadosDeVariables');

    $('#ReversionForm').trigger('reset');

    ClearFieldsReversion();

    $('#resultadosContainer').html("");
}

function ResetFormReversion(e) {
    e.stopPropagation();

    ResetViewReversion();
}
