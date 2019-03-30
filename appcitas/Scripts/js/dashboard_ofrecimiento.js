var hoy = moment(new Date()).format('YYYY-MM-DD');

$(document).ready(function () {
    checkUserAccess('CYRS140');
    jQuery.ajaxSetup({ global: false });

    jQuery.ajaxSetup({ global: false });
    $('#tableMotorDashboard tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });
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

function format(d) {
    var elem = "";
    var miHtml = '<table class="center" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<thead>' +
        '<tr>' +
        '<th>Item</th>'+
        '<th>Variable</th>' +
        '<th>Valor Actual</th>' +
        '<th>Condicion</th>' +
        '<th>ValorAEvaluar</th>' +
        '<th>Resultado</th>' +
        '</tr></thead><tbody>';
    for (var i = 0; i < d.Variables.length; i++) {
        if (d.Variables[i].EvaluacionCondicion === true) {
            elem = '<img src="' + urljs + 'imgs/True.png" height="16" width="16"></img>'; 
        }
        else {
            elem = '<img src="' + urljs + 'imgs/False.png" height="16" width="16"></img>';
        }

        miHtml = miHtml + '<tr><td>' + d.Variables[i].Item + '</td>' +
            '<td>' + d.Variables[i].VariableNombre + '</td>' +
            '<td>' + d.Variables[i].ValorActual + '</td>' +
            '<td>' + d.Variables[i].CondicionLogica + '</td>' +
            '<td>' + d.Variables[i].ValorAEvaluar + '</td>' +
            '<td>' + elem + '</td></tr>';
    }
    miHtml = miHtml + '</tbody></table>';

    return miHtml;
}

function GenerarReporte(e) {
    e.stopPropagation();

    $.ajax({
        type: "POST",
        url: urljs + "Reportes/GenerarReporteOfrecimientos/",
        data: {
            TipoCliente: $('#IdCliente option:selected').text(),
            FechaInicio: $('#txt_fecha1').val(),
            FechaFinal: $('#txt_fecha2').val(),
            segmento: $('#Segmentos option:selected').text(),
            canal: $('#Canales option:selected').text(),
            motor: $('#MotorUtilizado option:selected').text(),
            tipoOffer: $('#TipoOfrecimiento option:selected').text()
        },
        success: function (mydata) {
            if (mydata.length > 0) {
                if (mydata[0].Accion > 0) {
                    $('#tableMotorDashboard').dataTable().fnClearTable();
                    $('#tableMotorDashboard').dataTable().fnDestroy();
                    var table = $('#tableMotorDashboard').DataTable({
                        "paging": false,
                        "lengthChange": true,
                        "searching": true,
                        "ordering": true,
                        "info": true,
                        "autoWidth": true,
                        "language": languageConf,
                        dom: 'Bfrtip',
                        data: mydata,
                        "columns": [
                            {
                                "className": 'details-control',
                                "orderable": false,
                                "data": null,
                                "defaultContent": ''
                            },
                            //{
                            //    /*
                            //     * column exists for purpose of printing/exporting
                            //     * only required when using child rows
                            //     */
                            //    "title": 'index',
                            //    "visible": false,
                            //    "data": null,
                            //    "render": function (row, type, full, meta) {
                            //        return meta.row;
                            //    }
                            //},
                            { "data": "NumeroCuenta" },
                            {
                                "data": "Fecha",
                                "type": "date ",
                                "defaultContent": '',
                                "render": function (miFecha) {
                                    return ToJavaScriptDate(miFecha);
                                }
                            },
                            { "data": "TipoOfrecimiento" },
                            { "data": "Monto" },
                            { "data": "Marca" },
                            { "data": "Familia" },
                            { "data": "Segmento" },
                            { "data": "Resultado" },
                            { "data": "ResultadoAceptado" },
                            { "data": "Canal" },
                            { "data": "IdentificacionCliente" },
                        ],
                        buttons: [
                            {
                                extend: 'collection',
                                //action: function (e, dt, button, config) {
                                //    dt_print(e, dt, button, config, true)
                                //}, 
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

                    $('#tableMotorDashboard tbody').on('click', 'td.details-control', function () {
                        var tr = $(this).closest('tr');
                        var row = table.row(tr);

                        if (row.child.isShown()) {
                            // This row is already open - close it
                            row.child.hide();
                            tr.removeClass('shown');
                        }
                        else {
                            // Open this row
                            row.child(format(row.data())).show();
                            tr.addClass('shown');
                        }
                    });
                }
                else {
                    GenerarErrorAlerta(mydata[0].Mensaje, "error");
                    goAlert();
                }
            }
        },
        error: function (data, status, xhr) {
            GenerarErrorAlerta("Error cargando datos", "error");
            goAlert();
        }
    });
}

function dt_print(e, dt, button, config, has_child_rows) {
    var data = dt.buttons.exportData(config.exportOptions);
    var addRow = function (d, tag, child_row) {
        var str = '<tr>';

        for (var i = 0, ien = d.length; i < ien; i++) {
            if (has_child_rows && !child_row && i === 0) continue;
            str += '<' + tag + '>' + d[i] + '</' + tag + '>';
        }

        return str + '</tr>';
    };

    var addSubTable = function (subtable, colspan) {
        var str = '<tr class="innertable-row">'
            + '<td class="innertable-row" colspan="' + colspan + '">';

        // If there is no subtable, there must be other child row content, display that
        if (subtable.length === 0) {
            str += '<div style="text-align: left">'
            str += $(dt.row(row_idx).child()).children().children().html();
            return str + '<div></td></tr>';
        }

        // Add header row
        var headers = subtable.find('tr').first().find('th,td');

        str += '<table class="dataTable no-footer">'
            + '<thead><tr>';

        for (var i = 0; i < headers.length; i++) {
            str += '<th>' + headers.eq(i).text() + '</th>';
        }

        str += '</tr></thead><tbody>';

        // Add body rows
        subtable.find('tbody').children('tr').each(function (index, tr) {
            var lines = $('td', tr).map(function (index, td) {
                return $(td).text();
            });
            str += addRow(lines, 'td', true);
        });

        return str + '</tbody></table></td></tr>';
    };

    // Construct a table for printing
    var html = '<table class="' + dt.table().node().className + '">';

    if (config.header) {
        html += '<thead>' + addRow(data.header, 'th') + '</thead>';
    }

    html += '<tbody>';
    for (var i = 0, ien = data.body.length; i < ien; i++) {
        html += addRow(data.body[i], 'td');

        if (has_child_rows) {
            var row_idx = data.body[i][0];
            if (dt.row(row_idx).child() && dt.row(row_idx).child.isShown()) {
                html += addSubTable($(dt.row(row_idx).child()).find('table:visible'), data.body[0].length);
            }
        }
    }
    html += '</tbody>';

    if (config.footer && data.footer) {
        html += '<tfoot>' + addRow(data.footer, 'th') + '</tfoot>';
    }

    // Open a new window for the printable table
    var win = window.open();
    var title = config.title;

    if (typeof title === 'function') {
        title = title();
    }

    if (title.indexOf('*') !== -1) {
        title = title.replace('*', $('title').text());
    }

    win.document.close();

    // Inject the title and also a copy of the style and link tags from this
    // document so the table can retain its base styling. Note that we have
    // to use string manipulation as IE won't allow elements to be created
    // in the host document and then appended to the new window.
    var head = '<title>' + title + '</title>';
    $('style, link').each(function () {
        head += _styleToAbs(this);
    });

    try {
        win.document.head.innerHTML = head; // Work around for Edge
    }
    catch (e) {
        $(win.document.head).html(head); // Old IE
    }


    // Inject the table and other surrounding information
    win.document.body.innerHTML =
        '<h1>' + title + '</h1>'
        + '<div>'
        + (typeof config.message === 'function' ?
            config.message(dt, button, config) :
            config.message
        )
        + '</div>'
        + html;


    $(win.document.body).addClass('dt-print-view');

    $('img', win.document.body).each(function (i, img) {
        img.setAttribute('src', _relToAbs(img.getAttribute('src')));
    });

    if (config.customize) {
        config.customize(win);
    }

    setTimeout(function () {
        if (config.autoPrint) {
            win.print();
            win.close();
        }
    }, 250);
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}

function AgregarFilasATabla(ArrayData, table) {
    var newRow = $(table).dataTable().fnAddData([
        "",
        ArrayData['NumeroCuenta'],
        ToJavaScriptDate(ArrayData['Fecha']),
        ArrayData['TipoOfrecimiento'],
        ArrayData['Monto'],
        ArrayData['Marca'],
        ArrayData['Familia'],
        ArrayData['Segmento'],
        ArrayData['Resultado'],
        ArrayData['ResultadoAceptado'],
        ArrayData['Canal'],
        ArrayData['IdentificacionCliente']
    ]);
    var theNode = $(table).dataTable().fnSettings().aoData[newRow[0]].nTr;
    format(ArrayData);
    $(table).DataTable().order([1, 'asc']).draw();
}