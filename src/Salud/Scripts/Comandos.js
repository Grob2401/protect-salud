function datosprovincia() {
    $.ajax({
        type: "post",
        url: "/SCTRCotizacion/GetProvincia",
        data: { dptoid: $('#drpDepartamento').val() },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var provincia = "<select id='CodigoProv'>";
            provincia = provincia + '<option value="">--Seleccionar--</option>';
            for (var i = 0; i < data.length; i++) {
                provincia = provincia + '<option value=' + data[i].CodigoProv + '>' + data[i].DescripcionProv + '</option>';
            }
            provincia = provincia + '</select>';
            $('#drpProvincia').html(provincia);
        }
    });
}

function datosdistrito()
{
    $.ajax({
        type: "post",
        url: "/SCTRCotizacion/GetDistrito",
        data: { dptoid: $('#drpDepartamento').val(), provid: $('#drpProvincia').val() },
        datatype: "json",
        traditional: true,
        success: function (data) {
            var district = "<select id='CodigoDist'>";
            district = district + '<option value="">--Seleccionar--</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].CodigoDist + '>' + data[i].DescripcionDist + '</option>';
            }
            district = district + '</select>';
            $('#drpDistrito').html(district);
        }
    });

}


