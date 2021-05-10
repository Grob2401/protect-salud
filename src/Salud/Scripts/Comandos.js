/// Carga un elemento <select> genérico a partir de una llamada Ajax
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
