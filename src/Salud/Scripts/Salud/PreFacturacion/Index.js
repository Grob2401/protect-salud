
//$(function () {

//    $('#dglista').DataTable({
//        "paging": true,
//        "lengthChange": false,
//        "ordering": false,
//        "info": true,
//        "autoWidth": false,
//        "responsive": true,
//        "lengthMenu": [[5, 10, 50, -1], [5, 10, 50, "Todos"]],
//        "pageLength": 50,
//        "language": {
//            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
//        }
//    });
//});

//#########################################################################
//ID SELECTOR CLASS SELECTOR
//#########################################################################

$(document).ready(function () {
    $('#dglista').DataTable({
        paging: true,
        lengthChange: false,
        ordering: false,
        info: true,
        autoWidth: false,
        responsive: false,
        lengthMenu: [[5, 10, 50, -1], [5, 10, 50, "Todos"]],
        pageLength: 50,
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Spanish.json"
        },
        //"scrollY": "500px",
        //"buttons": [
        //    { "extend": 'pdf', "text": 'Export', "className": 'btn btn-default btn-xs' }
        //],
        dom: 'Bfrtip',
        buttons: [{
            extend: 'excelHtml5',
            text: 'Exportar Excel',
            className: 'btn btn-outline-info btn-sm',
            customize: function (xlsx) {
                var sheet = xlsx.xl.worksheets['sheet1.xml'];

            }
        }]
    });
});


$('#anio').change(function () {
    $("#mes").prop('selectedIndex', 1);
    var anioi = $("#anio :selected").val();
    var mese = $("#mes :selected").val();

    var LastDay = new Date(anioi, mese, 0);
    var ultimo = LastDay.toISOString().slice(0, 10);
    //console.log(ultimo)

    $('#txtdesde').attr('value', anioi + '-' + mese + '-' + '01');
    $('#txthasta').attr('value', ultimo);
});

$('#mes').change(function () {
    var anioi = $("#anio :selected").val();
    var mese = $("#mes :selected").val();

    var LastDay = new Date(anioi, mese, 0);
    var ultimo = LastDay.toISOString().slice(0, 10);

    $('#txtdesde').attr('value', anioi + '-' + mese + '-' + '01');
    $('#txthasta').attr('value', ultimo);

});

$('.sev_check').click(function () {
    $('.sev_check').not(this).prop('checked', false);
});

//#########################################################################
//TABLE CLICK
//#########################################################################

$("body").on("click", "img[src*='plus.jpg']", function () {
    $("img[src*='minus.jpg']").click();
    //$('table#dglista tr#ad').remove();
    $(this).attr("src", "Images/plus.jpg");
    $(this).closest("tr").after("<tr id='ad'><td></td><td id='tab' colspan = '999'>" + $(this).next().html() + "</td></tr>");
    var row = $(this).closest("tr");
    var year = $('#anio').val()
    var month = $('#mes').val()
    var pcsespecial = "0";
    var pcsstatus = "0";
    var codigo = row.find(".cellCodigoCliente").html();
    var tipoasegurado = row.find(".cellDescripcionTipoAsegurado").html();
    var url_method = $('#ruta').val()

    $(this).attr("src", "Images/minus.jpg");
    $.ajax({    
        type: "GET",
        url: url_method,
        data: {
            'anoProceso': year,
            'mesProceso': month,
            'pcsEspecial': pcsespecial,
            'pcsStatus': pcsstatus,
            'CodigoCliente': codigo,
            'DescripcionTipoAsegurado': tipoasegurado
        },
        dataType: "text",
        success: function (r) {
            var dataparseada = JSON.parse(r);
            document.getElementById('tab').innerHTML = json2table(dataparseada, 'table');
        }
    });

});

//Assign Click event to Minus Image.
$("body").on("click", "img[src*='minus.jpg']", function () {
    $(this).attr("src", "Images/plus.jpg");
    $(this).closest("tr").next().remove();
});

$('#allchk').change(function () {
    if ($(this).prop('checked')) {
        $('tbody tr td input[type="checkbox"]').each(function () {
            $(this).prop('checked', true);
        });
    } else {
        $('tbody tr td input[type="checkbox"]').each(function () {
            $(this).prop('checked', false);
        });
    }
});

//#########################################################################
//ON DOCUMENT READY
//#########################################################################

$(document).ready(function () {
    //$('#btnbusca').click(function () {
    //    $('#loading').css('display', 'block');
    //});
    //$('#chkTodos').click(function () {
    //    $('#loading').css('display', 'block');
    //});
    //$('#chkGenerados').click(function () {
    //    $('#loading').css('display', 'block');
    //});
    //$('#chkAprobados').click(function () {
    //    $('#loading').css('display', 'block');
    //});
    //$('#chkGenerarCuentaCorriente').click(function () {
    //    $('#loading').css('display', 'block');
    //});
    //$('#chkFacturados').click(function () {
    //    $('#loading').css('display', 'block');
    //});
    //$('#btngenera').click(function () {
    //    $('#loading').css('display', 'block');
    //});

    $("#mes").prop('selectedIndex', 1);
    var anioi = $("#anio :selected").val();
    var mese = $("#mes :selected").val();

    var LastDay = new Date(anioi, mese, 0);
    var ultimo = LastDay.toISOString().slice(0, 10);
    //console.log(ultimo)

    $('#txtdesde').attr('value', anioi + '-' + mese + '-' + '01');
    $('#txthasta').attr('value', ultimo);

});

//#########################################################################
//BOTONES
//#########################################################################

$('#btngenera').click(function (e) {
    var url = $(this).data('request-url');
    var url_generar = $('#generar_ruta').val();
    //Reference the Table.
    var grid = document.getElementById("dglista");
    var contador = 0;

    $('#dglista').find('tr').each(function () { 
        var row = $(this);
        if (row.find('input[type="checkbox"]').is(':checked')) {
            contador++;
        }
    });

    if (contador > 0) {
        //Reference the CheckBoxes in Table.
        var checkBoxes = grid.getElementsByTagName("INPUT");

        var year = $('#anio').val()
        var month = $('#mes').val()
        var pcsespecial = "0";
        var pcsstatus = "0";
        var des = $('#txtdesde').val();
        var has = $('#txthasta').val();
        e.preventDefault();

        Swal.fire({
            title: '¿Esta seguro(a) que desea generar prefacturación?',
            text: "Las pre-facturaciones serán generadas",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, generar',
            cancelButtonText: 'No'
        }).then(function (result) {
            if (result.value) {

                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked) {

                        var row = checkBoxes[i].parentNode.parentNode;
                        var codigo = row.cells[1].innerHTML;
                        var tipoasegurado = row.cells[4].innerHTML;

                        $.ajax({
                            type: "POST",
                            url: url_generar,
                            data: {
                                'anoProceso': year,
                                'mesProceso': month,
                                'txtdesde': des,
                                'txthasta': has,
                                'pcsEspecial': pcsespecial,
                                'pcsStatus': pcsstatus,
                                'CodigoCliente': codigo,
                                'DescripcionTipoAsegurado': tipoasegurado
                            },
                            dataType: "text",
                            success: function (r) {
                                const obj = JSON.parse(r);
                                var anio = obj.anio;
                                var mes = obj.mes;
                                var txtdes = obj.txtdesde;
                                var txthas = obj.txthasta;
                                var men = obj.mensajeEPF;
                                var status = obj.PcsStatus;
                                window.location.href = url + "?anio=" + anio + "&mes=" + mes + "&txtdesde=" + txtdes + "&txthasta=" + txthas + "&mensaje=" + men + "&status=" + status;
                            }
                        });
                    }
                }
                
            } else {
                //swal("Cancelado", "Acción Cancelada", "info");
            }
        });
    }
    else {
        Swal.fire({
            icon: 'info',
            title: 'Advertencia',
            text: 'No ha seleccionado ninguna opción.',
            showCloseButton: true
        });
        return false;
    }
});

$('#btnAprobar').click(function (e) {

    var url = $(this).data('request-url');
    var url_aprobar = $('#aprobar_ruta').val();
    //Reference the Table.
    var grid = document.getElementById("dglista");
    var contador = 0;

    $('#dglista').find('tr').each(function () {
        var row = $(this);
        if (row.find('input[type="checkbox"]').is(':checked')) {
            contador++;
        }
    });

    if (contador > 0) {
        //Reference the CheckBoxes in Table.
        var checkBoxes = grid.getElementsByTagName("INPUT");

        var year = $('#anio').val()
        var month = $('#mes').val()
        var pcsespecial = "0";
        var pcsstatus = "0";
        var des = $('#txtdesde').val();
        var has = $('#txthasta').val();
        e.preventDefault();

        Swal.fire({
            title: '¿Esta seguro(a) que desea aprobar los registros seleccionados?',
            text: "Las pre-facturaciones serán aprobadas",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, aprobar',
            cancelButtonText: 'No'
        }).then(function (result) {
            if (result.value) {

                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked) {

                        var row = checkBoxes[i].parentNode.parentNode;
                        var codigo = row.cells[1].innerHTML;
                        var tipoasegurado = row.cells[4].innerHTML;

                        $.ajax({
                            type: "POST",
                            url: url_aprobar,
                            data: {
                                'anoProceso': year,
                                'mesProceso': month,
                                'txtdesde': des,
                                'txthasta': has,
                                'pcsEspecial': pcsespecial,
                                'pcsStatus': pcsstatus,
                                'CodigoCliente': codigo,
                                'DescripcionTipoAsegurado': tipoasegurado
                            },
                            dataType: "text",
                            success: function (r) {
                                const obj = JSON.parse(r);
                                var anio = obj.anio;
                                var mes = obj.mes;
                                var txtdes = obj.txtdesde;
                                var txthas = obj.txthasta;
                                var men = obj.mensajeEPF;
                                var status = obj.PcsStatus;
                                console.log(obj);
                                window.location.href = url + "?anio=" + anio + "&mes=" + mes + "&txtdesde=" + txtdes + "&txthasta=" + txthas + "&mensaje=" + men + "&status=" + status;
                            }
                        });
                    }
                }

            } else {
                //swal("Cancelado", "Acción Cancelada", "info");
            }
        });
    }
    else {
        Swal.fire({
            icon: 'info',
            title: 'Advertencia',
            text: 'No ha seleccionado ninguna opción.',
            showCloseButton: true
        });
        return false;
    }


    
});

$('#btnGenerarCuentaCorriente').click(function (e) {

    var url = $(this).data('request-url');
    var url_ctaCorriente = $('#ctacorriente_ruta').val();
    //Reference the Table.
    var grid = document.getElementById("dglista");
    var contador = 0;

    $('#dglista').find('tr').each(function () {
        var row = $(this);
        if (row.find('input[type="checkbox"]').is(':checked')) {
            contador++;
        }
    });

    if (contador > 0) {
        //Reference the CheckBoxes in Table.
        var checkBoxes = grid.getElementsByTagName("INPUT");

        var year = $('#anio').val()
        var month = $('#mes').val()
        var pcsespecial = "0";
        var pcsstatus = "0";
        var des = $('#txtdesde').val();
        var has = $('#txthasta').val();
        e.preventDefault();

        Swal.fire({
            title: '¿Esta seguro(a) que desea generar los registros seleccionados?',
            text: "Las pre-facturaciones serán generadas",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, generar',
            cancelButtonText: 'No'
        }).then(function (result) {
            if (result.value) {

                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked) {

                        var row = checkBoxes[i].parentNode.parentNode;
                        var codigo = row.cells[1].innerHTML;
                        var tipoasegurado = row.cells[4].innerHTML;

                        $.ajax({
                            type: "POST",
                            url: url_ctaCorriente,
                            data: {
                                'anoProceso': year,
                                'mesProceso': month,
                                'txtdesde': des,
                                'txthasta': has,
                                'pcsEspecial': pcsespecial,
                                'pcsStatus': pcsstatus,
                                'CodigoCliente': codigo,
                                'DescripcionTipoAsegurado': tipoasegurado
                            },
                            dataType: "text",
                            success: function (r) {
                                const obj = JSON.parse(r);
                                var anio = obj.anio;
                                var mes = obj.mes;
                                var txtdes = obj.txtdesde;
                                var txthas = obj.txthasta;
                                var men = obj.mensajeEPF;
                                var status = obj.PcsStatus;
                                window.location.href = url + "?anio=" + anio + "&mes=" + mes + "&txtdesde=" + txtdes + "&txthasta=" + txthas + "&mensaje=" + men + "&status=" + status;
                            }
                        });
                    }
                }

            } else {
                //swal("Cancelado", "Acción Cancelada", "info");
            }
        });
    }
    else {
        Swal.fire({
            icon: 'info',
            title: 'Advertencia',
            text: 'No ha seleccionado ninguna opción.',
            showCloseButton: true
        });
        return false;
    }


});

$('#btnFacturar').click(function (e) {
    var url = $(this).data('request-url');
    var url_aprobar = $('#aprobar_ruta').val();
    //Reference the Table.
    var grid = document.getElementById("dglista");
    var contador = 0;

    $('#dglista').find('tr').each(function () {
        var row = $(this);
        if (row.find('input[type="checkbox"]').is(':checked')) {
            contador++;
        }
    });

    if (contador > 0) {
        //Reference the CheckBoxes in Table.
        var checkBoxes = grid.getElementsByTagName("INPUT");

        var year = $('#anio').val()
        var month = $('#mes').val()
        var pcsespecial = "0";
        var pcsstatus = "0";
        var des = $('#txtdesde').val();
        var has = $('#txthasta').val();
        e.preventDefault();

        Swal.fire({
            title: '¿Esta seguro(a) que desea facturar los registros seleccionados?',
            text: "Los registros serán facturados",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, generar',
            cancelButtonText: 'No'
        }).then(function (result) {
            if (result.value) {

                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked) {

                        var row = checkBoxes[i].parentNode.parentNode;
                        var codigo = row.cells[1].innerHTML;
                        var tipoasegurado = row.cells[4].innerHTML;

                        $.ajax({
                            type: "POST",
                            url: url_aprobar,
                            data: {
                                'anoProceso': year,
                                'mesProceso': month,
                                'txtdesde': des,
                                'txthasta': has,
                                'pcsEspecial': pcsespecial,
                                'pcsStatus': pcsstatus,
                                'CodigoCliente': codigo,
                                'DescripcionTipoAsegurado': tipoasegurado
                            },
                            dataType: "text",
                            success: function (r) {
                                const obj = JSON.parse(r);
                                var anio = obj.anio;
                                var mes = obj.mes;
                                var txtdes = obj.txtdesde;
                                var txthas = obj.txthasta;
                                var men = obj.mensajeEPF;
                                var status = obj.PcsStatus;
                                window.location.href = url + "?anio=" + anio + "&mes=" + mes + "&txtdesde=" + txtdes + "&txthasta=" + txthas + "&mensaje=" + men + "&status=" + status;
                            }
                        });
                    }
                }

            } else {
                //swal("Cancelado", "Acción Cancelada", "info");
            }
        });
    }
    else {
        Swal.fire({
            icon: 'info',
            title: 'Advertencia',
            text: 'No ha seleccionado ninguna opción.',
            showCloseButton: true
        });
        return false;
    }
});

function listas(de,op) {
    $('#' + de).click(function (e) {
        var url = $(this).data('request-url');
        var year = $('#anio').val()
        var month = $('#mes').val()
        var pcsstatus = op;
        var mensaje = "";
        var des = $('#txtdesde').val();
        var has = $('#txthasta').val();
        window.location.href = url + "?anio=" + year + "&mes=" + month + "&txtdesde=" + des + "&txthasta=" + has + "&mensaje=" + mensaje + "&status=" + pcsstatus;
    });
}

//#########################################################################
//FUNCIONES
//#########################################################################

dateTimeReviver = function (key, value) {
    var a;
    if (typeof value === 'string') {
        a = /\/Date\((\d*)\)\//.exec(value);
        if (a) {

            var dt = new Date(+a[1]);

            var dateString = moment(dt).format('YYYY-MM-DD');

            return dateString;
        }
        //console.log(a);
    }
    return value;
}

//#########################################################################
//#########################################################################

