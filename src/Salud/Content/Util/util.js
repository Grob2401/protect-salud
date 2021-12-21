
function mensajeRedirect(mensaje,link)
{
    if (mensaje != "") {
        console.log(mensaje);
        if (mensaje.includes("Excelente")) {
            Swal.fire({
                icon: 'success',
                title: 'Mensaje',
                html: mensaje,
                showCloseButton: true
            }).then(function () {
                window.location = link;
            });
        }
        else if (mensaje.includes("Advertencia")) {
            Swal.fire({
                icon: 'info',
                title: 'Mensaje',
                html: mensaje,
                showCloseButton: true
            }).then(function () {
                window.location = link;
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Mensaje',
                html: mensaje,
                showCloseButton: true
            }).then(function () {
                window.location = link;
            });
        }
    }
};

function checkEmail(em) {
    console.log(em);
    var regex = /^[a-z0-9\.\_%+-]+@@[a-z0-9\.\-]+\.[a-z]{2,4}$/i;

    if (em.search(regex)) {
        return false;
    }
    else {
        return true;
    }
}

function json2table(json, classes) {

    json = JSON.parse(JSON.stringify(json), dateTimeReviver);
    //json = JSON.parse(JSON.stringify(json))
    //console.log(json);

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
