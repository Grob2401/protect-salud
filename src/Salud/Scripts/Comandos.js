﻿/// Carga un elemento <select> genérico a partir de una llamada Ajax
const loadDropDownList = (result, selectId, optionDataField, optionDisplayField, defaultText = '-- Seleccione --') => {
    /// Combo selector
    const select = document.querySelector(`#${selectId}`);
    select.innerHTML = '';

    /// Default element
    const defaultOption = document.createElement('option');
    defaultOption.text = defaultText;
    defaultOption.disabled = 'disabled';
    defaultOption.selected = true;
    select.appendChild(defaultOption)

    /// Other elements
    for (const elem of result) {
        /// Creating...
        const option = document.createElement('option'); // CodigoCategoria, CodigoParentesco
        option.id = elem[optionDataField];
        option.text = elem[optionDisplayField];

        /// Inserting...
        select.appendChild(option);
    }

    /// Unlock select element
    select.removeAttribute('disabled');
    select.classList.remove('pagination-disabled');
}

const fillDropDownListByAjax = (selectId, optionDataField, optionDisplayField, url, type = 'GET', data = {}, defaultText = '-- Seleccione --') => {
    $.ajax({
        type,
        url,
        data,
        datatype: 'json',
        traditional: true,
        success(result) {
            loadDropDownList(result, selectId, optionDataField, optionDisplayField, defaultText);
        },
        error(xhr, textStatus, errorThrown) {
            console.error(xhr);
        }
    });
}

const emptyDropDownList = (selectId, disabled = true, defaultText = '-- Seleccione --') => {
    /// Combo selector
    const select = document.querySelector(`#${selectId}`);
    select.innerHTML = '';
    if (disabled) {
        select.setAttribute('disabled', 'disabled');
        select.classList.add('pagination-disabled');
    }

    /// Default element
    const defaultOption = document.createElement('option');
    defaultOption.text = defaultText;
    defaultOption.disabled = 'disabled';
    defaultOption.selected = true;
    select.appendChild(defaultOption)
}

const toIntDate = (strDate) => {
    try {
        return parseInt(strDate.split('(')[1].split(')')[0]);
    } catch (e) {
        return undefined;
    }
}

const enableButton = (buttonId, enabled) => {
    const button = document.querySelector(`#${buttonId}`);
    if (enabled) {
        button.classList.remove('btn-outline-primary');
        button.classList.add('btn-outline-secondary');
        button.attributes.setNamedItem('disabled');
    } else {
        button.classList.remove('btn-outline-secondary');
        button.classList.add('btn-outline-primary');
        button.attributes.removeNamedItem('disabled');
    }
}

const loadTableHeader = (tableHeaderId, fieldNameArray = [], settings = { hasEdit: false, hasDelete: false }) => {
    /// Table Header selector and row
    const tableHeader = document.querySelector(`#${tableHeaderId}`);
    const row = document.createElement('tr');

    /// Clear
    tableHeader.innerHTML = '';

    /// Fill
    for (const field of fieldNameArray) {
        const col = document.createElement('td');
        col.classList.add('text-bold', 'bg-secondary');
        col.innerText = field.key;
        row.appendChild(col);
    }

    /// Fill if it has edit or delete button
    if (settings.hasEdit || settings.hasDelete) {
        const col = document.createElement('td');
        col.classList.add('text-bold', 'bg-secondary');
        col.innerText = '';
        col.style = "width: 15%";
        row.appendChild(col);
    }
    tableHeader.appendChild(row);
}

const loadTableBody = (result, tableBodyId, fieldNameArray = [], settings = { hasEdit: false, hasDelete: false }) => {
    /// Table Body selector
    const tableBody = document.querySelector(`#${tableBodyId}`);

    /// Clear
    tableBody.innerHTML = '';

    /// Default element
    for (const elem of result) {
        /// Creating row...
        const row = document.createElement('tr');

        for (const field of fieldNameArray) {
            if (field.type === 'Date') {
                elem[field.name] = moment(new Date(toIntDate(elem[field.name]))).format('DD/MM/YYYY');
            } else if (field.type === 'Int') {
                elem[field.name] = parseInt(elem[field.name]);
            }
            const col = document.createElement('td');
            col.innerText = elem[field.name];
            col.classList.add('text-uppercase');
            row.appendChild(col); /// Inserta columna en la fila
        }

        /// Adding edit or delete buttons...
        if (settings.hasEdit || settings.hasDelete) {
            /// New column...
            const col = document.createElement('td');
            col.classList.add('project-actions', 'text-center');

            /// Edit
            if (settings.hasEdit) {
                const editButton = document.createElement('button');
                editButton.textContent = 'Editar';
                editButton.classList.add('btn', 'btn-outline-info', 'btn-sm', 'mr-3');
                col.appendChild(editButton);
            }

            /// Delete
            if (settings.hasDelete) {
                const deleteButton = document.createElement('button');
                deleteButton.textContent = 'Eliminar';
                deleteButton.classList.add('btn', 'btn-outline-danger', 'btn-sm');
                col.appendChild(deleteButton);
            }

            /// Appending to row...
            row.appendChild(col);
        }

        /// Inserting...
        tableBody.appendChild(row);
    }
}

const loadButtons = (settings) => {

    for (var buttonId of settings.buttonIdList) {
        const button = document.querySelector(`#${buttonId}`);
        if (button !== null) {
            button.classList.remove('btn-outline-secondary');
            button.classList.add('btn-outline-primary');
            button.removeAttribute('disabled');
        }
    }

    /// Table loading
    document.querySelector('#tableLoading').classList.add('d-none');
}

const loadStatusPagination = (settings) => {
    let { statusPaginationId, totalRows, first, last } = settings;
    const statusPagination = document.querySelector(`#${statusPaginationId}`);
    statusPagination.textContent = `${first} al ${last} de ${totalRows} filas`;
}

const loadNavPagination = (settings) => {

    let { navPaginationId, totalRows, page, rowsPerPage, getTotalCatalogs, catalog, first, last } = settings;

    /// Main Element
    const navPagination = document.querySelector(`#${navPaginationId}`);
    const ulElement = document.createElement('ul');
    ulElement.classList.add('pagination', 'justify-content-end');

    /// Previous
    const previous = document.createElement('li');
    previous.classList.add('page-item');
    const previousButton = document.createElement('button');
    previousButton.classList.add('page-link');
    previousButton.textContent = 'Previous';
    previous.appendChild(previousButton);
    if (catalog === 1) {
        previous.classList.add('disabled', 'pagination-disabled');
    } else {
        previous.setAttribute('onclick', `fillMatrixByAjax(${first - 1})`);
    }
    ulElement.appendChild(previous);

    /// Middle
    for (let i = first; i <= last; i++) {
        const middle = document.createElement('li');
        middle.classList.add('page-item');
        const middleButton = document.createElement('button');
        middleButton.classList.add('page-link');
        middleButton.textContent = i;
        if (i !== page) {
            middleButton.setAttribute('onclick', `fillMatrixByAjax(${i})`);
        } else {
            middle.classList.add('disabled', 'pagination-disabled');
        }
        middle.appendChild(middleButton);
        ulElement.appendChild(middle);
    }

    /// Next
    const next = document.createElement('li');
    next.classList.add('page-item');
    const nextButton = document.createElement('button');
    nextButton.classList.add('page-link');
    nextButton.textContent = 'Next';
    next.appendChild(nextButton);
    if (catalog === getTotalCatalogs) {
        next.classList.add('disabled', 'pagination-disabled');
    } else {
        next.setAttribute('onclick', `fillMatrixByAjax(${last + 1})`);
    }
    ulElement.appendChild(next);

    /// Inserting...
    navPagination.textContent = '';
    navPagination.appendChild(ulElement);

}

const excessDivision = (dividend, divider) => {
    return ((dividend - 1) - (dividend - 1) % divider) / divider + 1;
}

const fillDataTableByAjax = (settings) => {

    let { tableHeaderId, tableBodyId, counting, pagination } = settings;

    /// Cantidad de registros
    let catchMoment;
    $.ajax({
        type: counting.type,
        url: counting.url,
        data: counting.data,
        dataType: 'json',
        traditional: true,
        success(result) {
            let { page } = counting.data;
            let manageRows = {
                page,
                counting,
                totalRows: result.totalRows ?? -1,
                rowsPerPage: result.rowsPerPage,
                pagesPerCatalog: result.pagesPerCatalog,
                getTotalPages() {
                    return excessDivision(this.totalRows, this.rowsPerPage);
                },
                getTotalCatalogs() {
                    return excessDivision(this.getTotalPages(), this.pagesPerCatalog);
                },
                getStatus(page = this.page) {
                    let catalog = excessDivision(page, this.pagesPerCatalog);
                    let firstRow = (page - 1) * this.rowsPerPage + 1;
                    let lastRow = page * this.rowsPerPage;
                    let firstPage = (catalog - 1) * this.pagesPerCatalog + 1;
                    let lastPage = catalog * this.pagesPerCatalog;
                    return {
                        page,
                        catalog,
                        rows: {
                            first: firstRow,
                            last: lastRow
                        },
                        pages: {
                            first: firstPage,
                            last: lastPage
                        }
                    };
                }
            };

            if (manageRows.totalRows === -1) throw error('Hubo un error de conexión');
            catchMoment = moment();

            /// Row Structure
            let rowStruct = [
                { key: 'Cliente', name: 'CodigoCliente', type: 'String' },
                { key: 'Cod.Titular', name: 'CodigoTitular', type: 'String' },
                { key: 'Categoría', name: 'Categoria', type: 'String' },
                { key: 'Paterno', name: 'ApellidoPaterno', type: 'String' },
                { key: 'Materno', name: 'ApellidoMaterno', type: 'String' },
                { key: 'Nombres', name: 'Nombres', type: 'String' },
                { key: 'Fecha Nac.', name: 'FechaNacimiento', type: 'Date' },
                { key: 'TipoDoc', name: 'CodigoDocumentoIdentidad', type: 'String' },
                { key: 'NroDoc', name: 'NumeroDocumentoIdentidad', type: 'String' },
                { key: 'Sexo', name: 'CodigoSexo', type: 'String' },
            ];

            /// Llamada con paginación
            $.ajax({
                type: pagination.type,
                url: pagination.url,
                data: pagination.data,
                datatype: 'json',
                traditional: true,
                success(result) {
                    //console.log(`Duration (ms): ${parseInt(moment().diff(catchMoment, 'milliseconds'))}`);
                    let { page } = pagination.data;

                    /// Table Header Loading
                    loadTableHeader(
                        tableHeaderId,
                        rowStruct,
                        {
                            hasEdit: true,
                            hasDelete: true
                        });

                    /// Enable buttons
                    loadButtons({ buttonIdList: ['btnNuevo', 'btnBuscar'] });

                    /// Table Body Loading
                    loadTableBody(
                        result,
                        tableBodyId,
                        rowStruct,
                        {
                            hasEdit: true,
                            hasDelete: true
                        });

                    /// Status pagination (1 al 15 de 1500 filas)
                    loadStatusPagination({
                        statusPaginationId: 'statusPagination',
                        totalRows: manageRows.totalRows,
                        rowsPerPage: manageRows.rowsPerPage,
                        catalog: manageRows.getStatus().catalog,
                        first: manageRows.getStatus().rows.first,
                        last: manageRows.getStatus().rows.last,
                    });

                    /// Status links (Previous - 1 - 2 - ... - 10 - Next)
                    loadNavPagination({
                        navPaginationId: 'navPagination',
                        page,
                        totalRows: manageRows.totalRows,
                        rowsPerPage: manageRows.rowsPerPage,
                        catalog: manageRows.getStatus().catalog,
                        getTotalCatalogs: manageRows.getTotalCatalogs(),
                        first: manageRows.getStatus().pages.first,
                        last: manageRows.getStatus().pages.last,
                    });
                },
                error(xhr, textStatus, errorThrown) {
                    console.error(xhr);
                }
            });

        },
        error(xhr, textStatus, errorThrown) {
            totalRows = -1;
            console.error(xhr);
        }
    });

}

const fillMatrixByAjax = (page = 1, keywords = '') => {

    /// console.log(`page: ${page}`); console.log(`keywords: ${keywords}`);
    fillDataTableByAjax(
        {
            tableHeaderId: 'headerAsegurados',
            tableBodyId: 'bodyAsegurados',
            counting: {
                url: '/SaludAsegurados/GetCantidad',
                type: 'GET',
                data: {
                    page,
                    keywords
                }
            },
            pagination: {
                url: '/SaludAsegurados/GetAsegurados',
                type: 'GET',
                data: {
                    page,
                    keywords
                }
            }
        });

}