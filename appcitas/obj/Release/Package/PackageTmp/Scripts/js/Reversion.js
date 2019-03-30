$(document).ready(function () {
    checkUserAccess('MTR030');
});

function BuscarDatosDeCatalogos(cuenta) {
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

function BuscarPorTarjeta(e) {
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
                BuscarDatosDeCatalogos(result.dataList[0].Cuenta);
            },
            error: function (data, status, xhr) {
                GenerarErrorAlerta("Se produjo un error" + status, 'error');
                goAlert();
            }
        });
    }
}

function AgregarFilasATablaVariables(ArrayData, table) {
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

    $(table).DataTable().order([1, 'asc']).draw();
}

function EvaluarVariables(e) {
    e.stopPropagation();

    var form = $('#ReversionForm');
    form.validate();
    if (form.valid()) {
        if ($('#TipoReversionId_1').val() !== "") {
            var misCargos = [];
            if (($('#Monto_1').val() !== "0.00" || $('#Monto_1').val() !== "0") && $('#TipoReversion_1').val() !== "") {
                misCargos.push({
                    NumeroCargo: 1,
                    fechaCargo: $('#FechaCargo_1').val(),
                    tipoReversion: $('#TipoReversion_1').val(),
                    monto: $('#Monto_1').val()
                });
            }
            if (($('#Monto_2').val() !== "0.00" || $('#Monto_2').val() !== "0") && $('#TipoReversion_2').val() !== "") {
                misCargos.push({
                    NumeroCargo: 2,
                    fechaCargo: $('#FechaCargo_2').val(),
                    tipoReversion: $('#TipoReversion_2').val(),
                    monto: $('#Monto_2').val()
                });
            }
            if (($('#Monto_3').val() !== "0.00" || $('#Monto_3').val() !== "0") && $('#TipoReversion_3').val() !== "") {
                misCargos.push({
                    NumeroCargo: 3,
                    fechaCargo: $('#FechaCargo_3').val(),
                    tipoReversion: $('#TipoReversion_3').val(),
                    monto: $('#Monto_3').val()
                });
            }
            if (($('#Monto_4').val() !== "0.00" || $('#Monto_4').val() !== "0") && $('#TipoReversion_4').val() !== "") {
                misCargos.push({
                    NumeroCargo: 4,
                    fechaCargo: $('#FechaCargo_4').val(),
                    tipoReversion: $('#TipoReversion_4').val(),
                    monto: $('#Monto_4').val()
                });
            }
            if (($('#Monto_5').val() !== "0.00" || $('#Monto_5').val() !== "0") && $('#TipoReversion_5').val() !== "") {
                misCargos.push({
                    NumeroCargo: 5,
                    fechaCargo: $('#FechaCargo_5').val(),
                    tipoReversion: $('#TipoReversion_5').val(),
                    monto: $('#Monto_5').val()
                });
            }
            if (($('#Monto_6').val() !== "0.00" || $('#Monto_6').val() !== "0") && $('#TipoReversion_6').val() !== "") {
                misCargos.push({
                    NumeroCargo: 6,
                    fechaCargo: $('#FechaCargo_6').val(),
                    tipoReversion: $('#TipoReversion_6').val(),
                    monto: $('#Monto_6').val()
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
                success: function (data) {
                    if (data[0].Accion) {
                        LimpiarTabla('#resultadosDeVariables');
                        for (var i = 0; i < data.length; i++) {
                            AgregarFilasATablaVariables(data[i], '#resultadosDeVariables');
                        }

                        ObtenerResultados(e);
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

function VariablesEvaluadasData(table) {
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

function ObtenerResultados(e) {
    e.stopPropagation();
    var myData = VariablesEvaluadasData('#resultadosDeVariables');

    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionReversion/ObtenerResultados/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#Identidad').val() }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
        success: function (data) {
            if (data['statusCode']) {
                $('#resultadosContainer').html(data['resultadosHtml']);
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
    var seleccionado = $('#TipoReversionId_1 :selected').text();
    var idSeleccionado = $('#TipoReversionId_1 :selected').val();
    $('#TipoReversion_1').val(seleccionado);
    $('#TipoReversionId_2').val(idSeleccionado);
    $('#TipoReversion_2').val(seleccionado);
    $('#TipoReversionId_3').val(idSeleccionado);
    $('#TipoReversion_3').val(seleccionado);
    $('#TipoReversionId_4').val(idSeleccionado);
    $('#TipoReversion_4').val(seleccionado);
    $('#TipoReversionId_5').val(idSeleccionado);
    $('#TipoReversion_5').val(seleccionado);
    $('#TipoReversionId_6').val(idSeleccionado);
    $('#TipoReversion_6').val(seleccionado);
}

function GuardarReversion(e) {
    e.stopPropagation();

    var path = urljs + 'EvaluacionReversion/GuardarReversion/';
    var form = $('#ReversionForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    var aceptado = false;
    if ($('#resultadoAceptado').prop('checked') === true) {
        aceptado = true;
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
            Observacion: $('#Observacion').val(),
            VariablesEvaluadas: VariablesEvaluadasData('#resultadosDeVariables'),
            ResultadosDeReversion: OntenerArrayDeResultados(),
            TipoReversionId_1: $('#TipoReversionId_1').val(),
            TipoReversion_1: $('#TipoReversion_1').val(),
            FechaCargo_1: $('#FechaCargo_1').val(),
            Monto_1: $('#Monto_1').val(),
            TipoReversionId_2: $('#TipoReversionId_2').val(),
            TipoReversion_2: $('#TipoReversion_2').val(),
            FechaCargo_2: $('#FechaCargo_2').val(),
            Monto_2: $('#Monto_2').val(),
            TipoReversionId_3: $('#TipoReversionId_3').val(),
            TipoReversion_3: $('#TipoReversion_3').val(),
            FechaCargo_3: $('#FechaCargo_3').val(),
            Monto_3: $('#Monto_3').val(),
            TipoReversionId_4: $('#TipoReversionId_4').val(),
            TipoReversion_4: $('#TipoReversion_4').val(),
            FechaCargo_4: $('#FechaCargo_4').val(),
            Monto_4: $('#Monto_4').val(),
            TipoReversionId_5: $('#TipoReversionId_5').val(),
            TipoReversion_5: $('#TipoReversion_5').val(),
            FechaCargo_5: $('#FechaCargo_5').val(),
            Monto_5: $('#Monto_5').val(),
            TipoReversionId_6: $('#TipoReversionId_6').val(),
            TipoReversion_6: $('#TipoReversion_6').val(),
            FechaCargo_6: $('#FechaCargo_6').val(),
            Monto_6: $('#Monto_6').val(),
            Flujo: 2,
            ResultadoAceptadoPorCliente: aceptado,
            CanalOAgencia: usu_sucursalId,
        };

        var posting = $.post(path, myData);
        posting.done(function (data) {
            if (data.Accion) {
                bootbox.alert({
                    message: data.Mensaje,
                    callback: function () {
                        ResetView();
                    }
                });
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

function OntenerArrayDeResultados() {
    resultadoArray = [];
    var options = $('#CBX option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    for (var i = 0; i < options.length; i++) {
        if ($('#CBX').val() === values[i]) {
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

function ClearFields() {
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
}

function ResetView() {
    LimpiarTabla('#resultadosDeVariables');

    $('#ReversionForm').trigger('reset');

    ClearFields();

    $('#resultadosContainer').html("");
}

function ResetForm(e) {
    e.stopPropagation();

    ResetView();
}