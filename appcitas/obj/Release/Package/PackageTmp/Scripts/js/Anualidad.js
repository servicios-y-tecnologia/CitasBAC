$(document).ready(function () {
    checkUserAccess('MTR020');
    CheckUserInfo();
})

function TipoAnualidadOnChange(event) {
    event.stopPropagation();
    $('#TipoAnualidad').val($('#TipoAnualidadId').text());
}

function BuscarDatosDeCatalogos(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionAnualidad/BuscarDatosDeCatalogos/',
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
            url: urljs + 'EvaluacionAnualidad/BuscarPorTarjeta/',
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

function EvaluarVariables(e) {
    e.stopPropagation();

    var form = $('#AnualidadEvalForm');
    form.validate();
    if (form.valid()) {
        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionAnualidad/EvaluarVariables/',
            data:
            {
                tipoAnualidad: $('#TipoAnualidadId option:selected').text(),
                cuenta: $('#NumeroTarjeta').val(),
                fechaDeCargo: $('#FechaDeCargo').val(),
                segmento: $('#Segmento').val(),
                montoAnualidad: $('#Monto').val(),
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
            error: function (data, status, xhr) {
                GenerarErrorAlerta("Se produjo un error: " + status, 'error');
                goAlert();
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

function ObtenerResultados(e) {
    e.stopPropagation();
    var myData = VariablesEvaluadasData('#resultadosDeVariables');

    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionAnualidad/ObtenerResultados/',
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

function GuardarAnualidad(e) {
    e.stopPropagation();

    var path = '/EvaluacionAnualidad/GuardarAnualidad/';
    var form = $('#AnualidadEvalForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    form.validate();

    var aceptado = false;
    if ($('#resultadoAceptado').prop('checked') === true) {
        aceptado = true;
    }

    if (form.valid()) {
        var myData = {
            __RequestVerificationToken: token,
            NumeroCuenta: $('#NumeroCuenta').val(),
            NumeroTarjeta: $('#NumeroTarjeta').val(),
            CIF: $('#CIF').val(),
            Fecha: $('#Fecha').val(),
            Familia: $('#Familia').val(),
            SegmentoId: $('#SegmentoId').val(),
            Segmento: $('#Segmento').val(),
            Marca: $('#Marca').val(),
            MarcaId: $('#MarcaId').val(),
            TipoAnualidad: $('#TipoAnualidad').val(),
            TipoAnualidadId: $('#TipoAnualidadId').val(),
            Monto: $('#Monto').val(),
            FechaDeCargo: $('#FechaDeCargo').val(),
            SaldoActual: $('#SaldoActual').val(),
            Limite: $('#Limite').val(),
            Observacion: $('#Observacion').val(),
            VariablesEvaluadas: VariablesEvaluadasData('#resultadosDeVariables'),
            Resultados: ObtenerArrayDeResultados(),
            ResultadoAceptadoPorCliente: aceptado,
            Flujo: 2,
            CanalOAgencia: usu_sucursalId,
            Identidad: $('#Identidad').val()
        };

        var posting = $.post(path, myData);
        posting.done(function (data) {
            if (data.Accion) {
                console.log(data.Accion);
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

function ResultadosCbxChange(e) {
    e.stopPropagation();

    resultadoArray = [];
    var options = $('#selectBox option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    for (var i = 0; i < options.length; i++) {
        if ($('#Resultados').val() === values[i]) {
            resultadoArray.push({
                ItemDeReclamoId: values[i],
                ItemDeReclamoNombre: options[i],
                ResultadoAceptado: true
            });
        }
        else {
            resultadoArray.push({
                ItemDeReclamoId: values[i],
                ItemDeReclamoNombre: options[i],
                ResultadoAceptado: false
            });
        }
    }
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

function ObtenerArrayDeResultados() {
    resultadoArray = [];
    var options = $('#Resultados option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    for (var i = 0; i < options.length; i++) {
        if ($('#Resultados').val() === values[i]) {
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

function ResetView() {
    LimpiarTabla('#resultadosDeVariables');

    $('#AnualidadEvalForm').trigger('reset');

    $('#resultadosContainer').html("");
}

function ResetForm(e) {
    e.stopPropagation();
}