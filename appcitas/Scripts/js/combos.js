var hoy = moment(new Date()).format('YYYY-MM-DD');

$(document).ready(function () {
    checkUserAccess('MTR020');
    CheckUserInfo();

   
    $('#FechaPrimerCargo2').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
      //  daysOfWeekDisabled: [0, 6],
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

    $('#FechaSegundoCargo').datetimepicker({
        locale: 'es',
        maxDate: hoy,
        defaultDate: hoy,
    //    daysOfWeekDisabled: [0, 6],
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


    var primero = null;
    var segundo = null;
    var general = null;
function OnTipoCombo_IChange(event) {
    event.stopPropagation();
    var seleccionado = $('#ComboOpId :selected').text();
    var idSeleccionado = $('#ComboOpId :selected').val();

    debugger;
    var opcion = seleccionado.split('+');
    for (var i = 0; i < opcion.length; i++) {

        $.ajax({
            type: 'POST',
            url: urljs + 'EvaluacionCombo/TipoCombo/',
            data: JSON.stringify({ 'opcion': opcion[i].toString().trim() }),
            contentType: 'application/json;',
            dataType: 'html',
            async: false,
            success: function (data) {
                // console.log(data);
                var nombre = "#columna" + (i).toString();
                $(nombre).html('');
                $(data).appendTo(nombre);
                // $(nombre).html(data);
                debugger;
                var id;
                var sopcion = opcion[i].toString().trim().split(' ');
                if (i === 0) {
                    primero = '_' + opcion[i].toString().trim().split(' ')[0] + (sopcion.length > 1 ? sopcion[1] : '');
                    general = primero;
                    
                    $(".columna00").attr('id', 'resultadosDeVariables' + primero);
                  //  $("#resultadosDeVariables0").attr('id', 'resultadosDeVariables' + primero);
                    $("#resultadosContainer0").attr('id', 'resultadosContainer' + primero);
                  //  $("#TipoAnualidad").attr('id', 'TipoAnualidad' + primero);

                   
                }

                if (i === 1) {
                    segundo = '_' + opcion[i].toString().trim().split(' ')[0] + (sopcion.length > 1 ? sopcion[1] : '');
                    general = segundo;
                    $(".columna01").attr('id', 'resultadosDeVariables' + segundo);
                    //$("#resultadosDeVariables1").attr('id', 'resultadosDeVariables' + segundo);
                    $("#resultadosContainer1").attr('id', 'resultadosContainer' + segundo);
                    //$("#TipoAnualidad").attr('id', 'TipoAnualidad' + segundo);
                    
                }



                $(nombre + " form").each(function () {
                    //    names.push(this.name);
                    if (this.id.toString().includes("Anualidad")) {
                        $("#TipoAnualidad").val(opcion[i].toString().trim());
                       // $("#TipoAnualidad").val(opcion[1].toString().trim());
                    }

                    $("#" + this.id).prop('id', this.id + general);
                });


                $(nombre + " :input" ).each(function (e) {                   

                    $(this).attr('id', this.id + general);
                    $(this).attr('name', this.name + general);
                });

                $("#Observacion").attr('id', 'Observacion' + general);
                


            },
            error: function (data, status, xhr) {
                debugger;
                console.log(data.responseText);
                //  GenerarErrorAlerta("Se produjo un error: " + data[0].Mensaje, 'error');
                // goAlert();
            }
        });

    }

}


function EvaluarVariablesCombo(e) {

    e.stopPropagation();
    debugger;
    // console.log('Combo Valor: '+$("#ComboOpId").val());
    if ($("#ComboOpId").val() !== "") {
        //  debugger;
        switch (primero.toUpperCase()) {
            case "_ADICIONAL":
            case "_ANUALIDADTITULAR":
                EvaluarVariablesAnualidad(e, primero);
                break;
            case "_REVERSIÓN2":
            case "_REVERSIÓN1":
            case "_REVERSIÓNSG":
            case "_REVERSIÓNMORA":
                EvaluarVariablesReversion(e, primero);
                break;
            case "_TASA":
                EvaluarVariablesTasas(e, primero);
                break;
        }

        switch (segundo.toUpperCase()) {
            case "_ADICIONAL":
            case "_ANUALIDADTITULAR":
                EvaluarVariablesAnualidad(e, segundo);
                break;
            case "_REVERSIÓN2":
            case "_REVERSIÓN1":
            case "_REVERSIÓNSG":
            case "_REVERSIÓNMORA":
                EvaluarVariablesReversion(e, segundo);
                break;
            case "_TASA":
                EvaluarVariablesTasas(e, segundo);
                break;

        }


        //EvaluarVariables(e);
    }
    else {
        bootbox.alert("Debe seleccionar el tipo de combo!");
    }

}


var _ComboId = null;
function GuardarCombo(e) {
    debugger;
    e.stopPropagation();
    if ($("#ComboOpId").val() !== "") {

        //var path = '/EvaluacionCombo/GuardarCombo/';
        //var token = $('input[name="__RequestVerificationToken"]', form).val();
        var myData = {
          //  __RequestVerificationToken: token,
            ComboTexto: $("#ComboOpId :selected").text()          
        };


        try {
           // console.log($("#ComboId").val());
            if ($("#ComboId").val() === "00000000-0000-0000-0000-000000000000") {
                $.ajax({
                    type: 'POST',
                    url: urljs + 'EvaluacionCombo/GuardarCombo/',
                    data: JSON.stringify(myData),
                    contentType: 'application/json;',
                    dataType: 'JSON',
                    async: false,
                    success: function (data) {
                        debugger;
                        if (data['ComboId'] !== '') {
                            _ComboId = data['ComboId'];
                            // $('#resultadosContainer').html(data['resultadosHtml']);
                        }
                    },
                    error: function (data, status, xhr) {
                        GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
                        goAlert();
                        return;
                    }
                });



                if (_ComboId !== '') {
                    //  debugger;
                    switch (primero.toUpperCase()) {
                        case "_ADICIONAL":
                        case "_ANUALIDADTITULAR":
                            GuardarAnualidad(e, primero);
                            break;
                        case "_REVERSIÓN2":
                        case "_REVERSIÓN1":
                        case "_REVERSIÓNSG":
                        case "_REVERSIÓNMORA":
                            GuardarReversion(e, primero);
                            break;
                        case "_TASA":
                            GuardarTasa(e, primero);
                            break;
                    }

                    switch (segundo.toUpperCase()) {
                        case "_ADICIONAL":
                        case "_ANUALIDADTITULAR":
                            GuardarAnualidad(e, segundo);
                            break;
                        case "_REVERSIÓN2":
                        case "_REVERSIÓN1":
                        case "_REVERSIÓNSG":
                        case "_REVERSIÓNMORA":
                            GuardarReversion(e, segundo);
                            break;
                        case "_TASA":
                            GuardarTasa(e, segundo);
                            break;

                    }

                    validaprocesocombo();
                    //$.ajax({
                    //    type: 'POST',
                    //    url: urljs + 'EvaluacionCombo/ValidaProcesoCombo/',
                    //    data: JSON.stringify({ ComboId: _ComboId }),
                    //    contentType: 'application/json;',
                    //    dataType: 'JSON',
                    //    async: false,
                    //    success: function (data) {
                    //        debugger;
                    //        if (data.Accion) {
                    //            //_ComboId = data['ComboId'];
                    //            $("#ComboId").val(_ComboId);
                    //            bootbox.alert(data.Mensaje);

                    //            // $('#resultadosContainer').html(data['resultadosHtml']);
                    //        }
                    //        else {
                    //            GenerarErrorAlerta("Se produjo un error: " + data.Mensaje + " ", 'error');
                    //            goAlert();
                    //        }
                    //    },
                    //    error: function (data, status, xhr) {
                    //        GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
                    //        goAlert();
                    //        return;
                    //    }
                    //});

                    // bootbox.alert("Datos Guardados Satisfactoriamente");
                }
            }
            else {
                bootbox.alert("El combo ya se ha generado, intente generando uno nuevo!");
            }

        }
        catch (e) {
         
            validaprocesocombo();
            GenerarErrorAlerta("Se produjo un error: " + e.Message, 'error');
            goAlert();
        }





        //EvaluarVariables(e);
    }
    else {
        bootbox.alert("Debe seleccionar el tipo de combo!");
    }
}

function validaprocesocombo() {
    $.ajax({
        type: 'POST',
        url: urljs + 'EvaluacionCombo/ValidaProcesoCombo/',
        data: JSON.stringify({ ComboId: _ComboId }),
        contentType: 'application/json;',
        dataType: 'JSON',
        async: false,
        success: function (data) {
            debugger;
            if (data.Accion) {
                //_ComboId = data['ComboId'];
                $("#ComboId").val(_ComboId);
                bootbox.alert(data.Mensaje);

                // $('#resultadosContainer').html(data['resultadosHtml']);
            }
            else {
                GenerarErrorAlerta("Se produjo un error: " + data.Mensaje + " ", 'error');
                goAlert();
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Se produjo un error: " + data + " ", + status, 'error');
            goAlert();
            return;
        }
    });
}

function BuscarPorTarjetaCombo(e) {
    e.stopPropagation();

    var numeroTarjeta = $('#NumeroTarjeta');
    numeroTarjeta.validate();
    if (numeroTarjeta.valid()) {
        $.ajax({
            type: 'GET',
            url: urljs + 'EvaluacionCombo/BuscarPorTarjeta/',
            data: { tarjeta: numeroTarjeta.val() },
            success: function (result) {
                $('#CIF').val(result.dataList[0].Cif);
                $('#SaldoActual').val(result.dataList[0].SaldoVencido);
                $('#Limite').val(result.dataList[0].Limite);
                $('#NumeroCuenta').val(result.dataList[0].Cuenta);
                $('#Clasificacion').val(result.dataList[0].ClasificacionCuenta);
                BuscarDatosDeCatalogosCombo(result.dataList[0].Cuenta);
            },
            error: function (data, status, xhr) {
                GenerarErrorAlerta("Se produjo un error" + status, 'error');
                goAlert();
            }
        });
    }
}

function BuscarDatosDeCatalogosCombo(cuenta) {
    cuenta = cuenta.substring(0, 10);
    $.ajax({
        type: 'GET',
        url: urljs + 'EvaluacionCombo/BuscarDatosDeCatalogos/',
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



function AgregarFilasATablaVariablesCombo(ArrayData, table) {
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







