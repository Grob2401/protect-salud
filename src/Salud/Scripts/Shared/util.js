function mostrarMensaje(msj01) {
    var strvalue = msj01;
    var icono = '';
    console.log(msj01);
    if (strvalue != null && strvalue != "") {

        switch (strvalues.split(',')[0]) {
            case 'Correcto':
                icono = 'info';
                console.log(icono);
            default:
                icono = 'warning';
                console.log(icono);
        }



        Swal.fire({
            icon: icono,
            title: 'Mensaje',
            html: strvalue,
            showCloseButton: true
        });
    };
};


//function checkEmail(em) {
//    console.log(em);
//    var regex = /^[a-z0-9\.\_%+-]+@@[a-z0-9\.\-]+\.[a-z]{2,4}$/i;

//    if (em.search(regex)) {
//        return false;
//    }
//    else {
//        return true;
//    }
//}

function json2table(json, classes) {

    json = JSON.parse(JSON.stringify(json), dateTimeReviver);
    //json = JSON.parse(JSON.stringify(json))
    console.log(json);

    var cols = Object.keys(json[0]);

    var headerRow = '';
    var bodyRows = '';

    classes = classes || '';

    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    cols.map(function (col) {
        headerRow += '<th>' + capitalizeFirstLetter(col) + '</th>';
    });

    json.map(function (row) {
        bodyRows += '<tr>';

        cols.map(function (colName) {
            bodyRows += '<td>' + row[colName] + '</td>';
        })

        bodyRows += '</tr>';
    });

    return '<table class="table ' +
        classes +
        '"><thead class="bg-info"><tr>' +
        headerRow +
        '</tr></thead><tbody>' +
        bodyRows +
        '</tbody></table>';
}
