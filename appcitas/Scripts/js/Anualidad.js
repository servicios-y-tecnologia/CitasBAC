$(document).ready(function () {
    checkUserAccess('MTR020');
    CheckUserInfo();
});

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
    });
}

function BuscarPorTarjetaAnualidad(e) {
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
                GenerarErrorAlerta("Se produjo un error " + status + ': ' + xhr, 'error');
                goAlert();
            }

        });
    }
}

function EvaluarVariablesAnualidad(e,formulario='') {
    e.stopPropagation();
    e.preventDefault();

    //Validar(inputs, mensaje) &&
    //if (!$(".requerido[data-requerido='true']").hasClass('input-has-error'))
    //{
      var form = $('#AnualidadEvalForm'+ formulario);
      form.validate();
        if (form.valid()) {
            var tipoanualidad = $('#TipoAnualidadId' + formulario + ' option:selected').val();
            if (tipoanualidad === "") {
                bootbox.alert("Seleccione el tipo de anualidad en: !" + formulario);
            }
            else {
                $.ajax({
                    type: 'GET',
                    async: false,
                    url: urljs + 'EvaluacionAnualidad/EvaluarVariables/',
                    data:
                    {
                        tipoAnualidad: $('#TipoAnualidadId' + formulario + ' option:selected').text(),
                        cuenta: $('#NumeroTarjeta').val(),
                        fechaDeCargo: $('#FechaDeCargo' + formulario).val(),
                        segmento: $('#Segmento').val(),
                        montoAnualidad: $('#Monto' + formulario).val(),
                        identidad: $('#Identidad' + formulario).val()
                    },
                    success: function (data) {
                        if (data[0].Accion) {
                            LimpiarTabla('#resultadosDeVariables' + formulario);
                           // debugger;
                            for (var i = 0; i < data.length; i++) {
                               AgregarFilasVariablesEvaluadas(data[i], '#resultadosDeVariables' + formulario);
                            }

                            ObtenerResultadosAnualidad(e, formulario);
                        }
                        else {
                            $("#resultadosContainer" + formulario).html('<div class="alert alert-danger"><strong>' + data[0].Mensaje + '</strong></div>');
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
            bootbox.alert("Complete la informacion del formulario!");
        }
    //}
    //else {
      
    //    bootbox.alert("Complete la informacion del formulario!");
    //}
}

function AgregarFilasVariablesEvaluadas(ArrayData, table) {
    //console.log(table);
    //console.log(ArrayData);

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

    //$('td', theNode)[3].setAttribute('class', 'hidden');
    //$('td', theNode)[4].setAttribute('class', 'hidden');
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

function ObtenerResultadosAnualidad(e,formulario='') {
    e.stopPropagation();
    var myData = VariablesEvaluadasData('#resultadosDeVariables'+formulario);

    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionAnualidad/ObtenerResultados/',
        data: JSON.stringify({ dataList: myData, clasificacion: $('#Clasificacion').val(), limite: $('#Limite').val(), id_cli: $('#Identidad').val(), formulario: formulario }),
        contentType: 'application/json;',
        dataType: 'JSON',
        traditional: true,
        async : false,
        success: function (data) {
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

function GuardarAnualidad(e,formulario='') {
    e.stopPropagation();

    var path = '/EvaluacionAnualidad/GuardarAnualidad/';
    var form = $('#AnualidadEvalForm' + formulario);
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    form.validate();

    var aceptado = false;
    if ($('#resultadoAceptado').prop('checked') === true) {
        aceptado = true;
    }

    var _lcombo = '';
    if (typeof _ComboId !== 'undefined') {
        // variable is undefined
        _lcombo = _ComboId;
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
            TipoAnualidad: $('#TipoAnualidad' + formulario).val(),
            TipoAnualidadId: $('#TipoAnualidadId' + formulario).val(),
            Monto: $('#Monto').val(),
            FechaDeCargo: $('#FechaDeCargo'+formulario).val(),
            SaldoActual: $('#SaldoActual').val(),
            Limite: $('#Limite').val(),
            Observacion: $('#Observacion' + formulario).val(),
            VariablesEvaluadas: VariablesEvaluadasData('#resultadosDeVariables' + formulario),
            Resultados: ObtenerArrayDeResultados(formulario),
            ResultadoAceptadoPorCliente: aceptado,
            Flujo: 2,
            CanalOAgencia: usu_sucursalId,
            Identidad: $('#Identidad').val(),
            ComboId: _lcombo
        };

      //  $.ajaxSetup({ async: false });  

        $.ajax({
            type: 'POST',
            url: urljs + 'EvaluacionAnualidad/GuardarAnualidad/',
            data: JSON.stringify(myData),
            contentType: 'application/json;',
            dataType: 'JSON',
            async: false,
            success: function (data) {
                debugger;
                if (data.Accion && _lcombo==='') {
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
        //        //console.log(data.Accion);
        //        bootbox.alert(data.Mensaje);
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

       // posting.always(function () { });
    }
    else {
        bootbox.alert('Revise los datos del formulario sean validos!');
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
                CargoNumero: item[0],
                VariableCodigo: item[1],
                ReclamoId: item[2],
                ItemDeReclamoId: item[3],
                CodeGroupVariable: item[4],
                GroupVariable:item[5],
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

function ObtenerArrayDeResultados(formulario='') {
    resultadoArray = [];
    var options = $('#Resultados' + formulario+' option');
    var values = $.map(options, function (option) {
        return option.value;
    });

    //for (var i = 0; i < options.length; i++) {
    // se pone desde 1 porque el item 0 es "Seleccione un Resultado"
    for (var i = 1; i < options.length; i++) {
        if ($('#Resultados' + formulario).val() === values[i]) {
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

function ResetViewAnualidad() {
    LimpiarTabla('#resultadosDeVariables');

    $('#AnualidadEvalForm').trigger('reset');

    $('#resultadosContainer').html("");
    $('#Observacion').val('');
}

function ResetFormAnualidad(e) {
    e.stopPropagation();

    ResetViewAnualidad();
}
