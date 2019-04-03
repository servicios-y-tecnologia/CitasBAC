var hoy = moment(new Date()).format('YYYY-MM-DD');


$(document).ready(function () {
    checkUserAccess('MTR040');

    CheckUserInfo();

    $('#FechaDelCambio').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
       // daysOfWeekDisabled: [0, 6],
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

function BuscarDatosDeCatalogosTasas(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionTasa/BuscarDatosDeCatalogos/',
        data: { cuenta: cuenta },
        success: function (dataResult) {
           // debugger;
            $('#Familia').val(dataResult["Familia"]);
            $('#Segmento').val(dataResult["Segmento"]);
            $('#Marca').val(dataResult["Marca"]);
            $('#MarcaId').val(dataResult["MarcaId"]);
            $('#SegementoId').val(dataResult["SegmentoId"]);
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error" + status, 'error');
            goAlert();
        }
    });
}


function BuscarPorTarjetaTasas(e) {
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
                BuscarDatosDeCatalogosTasas(result.dataList[0].Cuenta);
            },
            error: function (data, status, xhr) {
                GenerarErrorAlerta("Se produjo un error" + status, 'error');
                goAlert();
            }
        });
    }
}

function EvaluarVariablesTasas(e,formulario='') {
    e.stopPropagation();

    var form = $('#TasaForm'+formulario);
    form.validate();
    if (form.valid()) {

        var cuenta = '';
       // console.log($("#NumeroTarjeta"));
        if ($("#NumeroTarjeta") !== null) {
            if($("#NumeroTarjeta").val() !== '') {
                cuenta = 'NumeroTarjeta';
            }
             else {
                cuenta = 'txt_tarjeta_n';
            }
        }    
       

        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionTasa/EvaluarVariables/',
            data:
            {
                cuenta: $('#'+cuenta).val(),
                fechaDelCambio: $('#txt_FechaDelCambio' + formulario).val(),
                segmento: $('#Segmento').val(),
                tasaActual: $('#TasaAnualizadaActual' + formulario).val(),
                identidad: $('#Identidad').val()
            },
            success: function (data) {
                if (data[0].Accion) {
                    LimpiarTabla('#resultadosDeVariables' + formulario);
                    for (var i = 0; i < data.length; i++) {
                        AgregarFilasVariablesEvaluadasTasas(data[i], '#resultadosDeVariables' + formulario);
                    }

                    ObtenerResultadosTasas(e,formulario);
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
    else {
        bootbox.alert("Formulario no valido: ");
    }
}

function AgregarFilasVariablesEvaluadasTasas(ArrayData, table) {
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

    $(table).DataTable().order([1, 'asc']).draw();
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

function ObtenerResultadosTasas(e,formulario='') {
    e.stopPropagation();
    var myData = VariablesEvaluadasData('#resultadosDeVariables'+formulario);

    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionTasa/ObtenerResultados/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#Identidad').val(),formulario:formulario }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
         async : false,
        success: function (data) {
          //  debugger;
            if (data['statusCode']) {
                $('#resultadosContainer' + formulario).html(data['resultadosHtml']);
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
            goAlert();
        }
    });
}

function ObtenerArrayDeResultados(formulario='') {
    resultadoArray = [];
    var options = $('#ResultadosCbx'+formulario+' option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    for (var i = 0; i < options.length; i++) {
        if ($('#ResultadosCbx' + formulario).val() === values[i]) {
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

function GuardarTasa(e,formulario='') {
    var path = urljs + 'EvaluacionTasa/GuardarTasa/';
    var form = $('#TasaForm');
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
        console.log($('#SegementoId').val());
        var myData = {
            __RequestVerificationToken: token,
            NumeroTarjeta: $('#NumeroTarjeta').val(),
            NumeroCuenta: $('#NumeroCuenta').val(),
            Identidad: $('#Identidad').val(),
            CIF: $('#CIF').val(),
            Fecha: $('#Fecha').val(),
            Familia: $('#Familia').val(),
            SegementoId: $('#SegementoId').val(),
            Segmento: $('#Segmento').val(),
            Marca: $('#Marca').val(),
            MarcaId: $('#MarcaId').val(),
            SaldoActual: $('#SaldoActual').val(),
            Limite: $('#Limite').val(),
            TasaAnualizadaActual: $('#TasaAnualizadaActual').val(),
            FechaDelCambio: $('#txt_FechaDelCambio').val(),
            Observacion: $('#Observacion' + formulario).val(),
            VariablesEvaluadas: VariablesEvaluadasData('#resultadosDeVariables' + formulario),
            Resultados: ObtenerArrayDeResultados(formulario),
            CanalOAgencia: usu_sucursalId,
            ResultadoAceptadoPorCliente: aceptado,
            Flujo: 2,
            ComboId: _lcombo
        };


        $.ajax({
            type: 'POST',
            url: path,
            data: JSON.stringify(myData),
            contentType: 'application/json;',
            dataType: 'JSON',
            async: false,
            success: function (data) {
              //  debugger;
                if (data.Accion && _lcombo === '') {
                    bootbox.alert(data.Mensaje);
                }
                else if (!data.Accion) {
                    GenerarErrorAlerta(data.Mensaje, 'error');
                    goAlert();
                }
            },
            error: function (data, status, xhr) {
                form.trigger('reset');
                GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
                goAlert();
                return;
            }
        });
        //var posting = $.post(path, myData);
        //posting.done(function (data) {
        //    if (data.Accion) {
        //        bootbox.alert({
        //            message: data.Mensaje,
        //            callback: function () {
        //                ResetViewTasas();
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

function ClearFieldsTasas() {

    $("#TasaAnualizadaActual").val(0);
    $("#Observacion").val("");
    $("#Identidad").val("");
    $("#NumeroTarjeta").val("");
}

function ResetViewTasas() {
    LimpiarTabla('#resultadosDeVariables');

    $('#ReversionForm').trigger('reset');

    ClearFieldsTasas();
    $('#resultadosContainer').html("");
}

function ResetFormTasas(e) {
    e.stopPropagation();

    ResetViewTasas();
}
