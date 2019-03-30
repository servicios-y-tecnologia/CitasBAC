var hoy = moment(new Date()).format('YYYY-MM-DD');


$(document).ready(function () {
    checkUserAccess('MTR040');

    CheckUserInfo();

    $('#FechaDelCambio').datetimepicker({
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

});

function BuscarDatosDeCatalogos(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionTasa/BuscarDatosDeCatalogos/',
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


function BuscarPorTarjeta(e) {
    e.stopPropagation();

    var numeroTarjeta = $('#NumeroTarjeta');
    numeroTarjeta.validate();
    if (numeroTarjeta.valid()) {
        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionTasa/BuscarPorTarjeta/',
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
        })
    }
}

function EvaluarVariables(e) {
    e.stopPropagation();

    var form = $('#TasaForm');
    form.validate();
    if (form.valid()) {
        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionTasa/EvaluarVariables/',
            data:
                {
                    cuenta: $('#NumeroTarjeta').val(),
                    fechaDelCambio: $('#txt_FechaDelCambio').val(),
                    segmento: $('#Segmento').val(),
                    tasaActual: $('#TasaAnualizadaActual').val(),
                    identidad: $('#Identidad').val()
                },
            success: function (data) {
                if (data[0].Accion) {
                    LimpiarTabla('#resultadosDeVariables');
                    for (var i = 0; i < data.length; i++) {
                        AgregarFilasVariablesEvaluadas(data[i], '#resultadosDeVariables');
                    }

                    ObtenerResultados(e);
                }
                else {
                    GenerarErrorAlerta(data[0].Mensaje, 'error');
                    goAlert();
                }
            },
            error: function (xhr, textstatus, error) {
                bootbox.alert("Error: " + error);
            }
        });

    }
}

function AgregarFilasVariablesEvaluadas(ArrayData, table) {
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

function ObtenerResultados(e) {
    e.stopPropagation();
    var myData = VariablesEvaluadasData('#resultadosDeVariables');

    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionTasa/ObtenerResultados/',
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

function ObtenerArrayDeResultados() {
    resultadoArray = [];
    var options = $('#ResultadosCbx option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    for (var i = 0; i < options.length; i++) {
        if ($('#ResultadosCbx').val() === values[i]) {
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

function GuardarTasa(e) {
    var path = urljs + 'EvaluacionTasa/GuardarTasa/';
    var form = $('#TasaForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    var aceptado = false;
    if ($('#resultadoAceptado').prop('checked') === true) {
        aceptado = true;
    }

    form.validate();
    if (form.valid()) {
        var myData = {
            __RequestVerificationToken: token,
            NumeroTarjeta: $('#NumeroTarjeta').val(),
            NumeroCuenta: $('NumeroCuenta').val(),
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
            TasaAnualizadaActual: $('#TasaAnualizadaActual').val(),
            FechaDelCambio: $('#txt_FechaDelCambio').val(),
            Observacion: $('#Observacion').val(),
            VariablesEvaluadas: VariablesEvaluadasData('#resultadosDeVariables'),
            Resultados: ObtenerArrayDeResultados(),
            CanalOAgencia: usu_sucursalId,
            ResultadoAceptadoPorCliente: aceptado,
            Flujo: 2
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

function ResetView() {
    LimpiarTabla('#resultadosDeVariables');

    $('#ReversionForm').trigger('reset');
    $('#resultadosContainer').html("");
}

function ResetForm(e) {
    e.stopPropagation();

    ResetView();
}
