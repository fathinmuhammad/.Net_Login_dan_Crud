﻿var gridOptions = {
    columnDefs: [
        // group cell renderer needed for expand / collapse icons
        { field: 'name', cellRenderer: 'agGroupCellRenderer' },
        { field: 'account' },
        { field: 'calls' },
        { field: 'minutes', valueFormatter: "x.toLocaleString() + 'm'" },
    ],
    defaultColDef: {
        flex: 1,
    },
    masterDetail: true,
    detailCellRendererParams: {
        detailGridOptions: {
            rowSelection: 'multiple',
            suppressRowClickSelection: true,
            enableRangeSelection: true,
            pagination: true,
            paginationAutoPageSize: true,
            columnDefs: [
                { field: 'callId', checkboxSelection: true },
                { field: 'direction' },
                { field: 'number', minWidth: 150 },
                { field: 'duration', valueFormatter: "x.toLocaleString() + 's'" },
                { field: 'switchCode', minWidth: 150 },
            ],
            defaultColDef: {
                sortable: true,
                flex: 1,
            },
        },
        getDetailRowData: function (params) {
            params.successCallback(params.data.callRecords);
        },
    },
    onFirstDataRendered: onFirstDataRendered,
};

function onFirstDataRendered(params) {
    // arbitrarily expand a row for presentational purposes
    setTimeout(function () {
        params.api.getDisplayedRowAtIndex(1).setExpanded(true);
    }, 0);
}

// setup the grid after the page has finished loading
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);

    agGrid
        .simpleHttpRequest({
            url:
                'https://raw.githubusercontent.com/ag-grid/ag-grid-docs/latest/src/javascript-grid-master-detail/simple/data/data.json',
        })
        .then(function (data) {
            gridOptions.api.setRowData(data);
        });
});