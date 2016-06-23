

export const TABLE_SORT = "TABLE_SORT";
export const ASCENDING = 1;
export const DESCENDING = -1;
export const NONSORTING = 'NONSORTING';
export const INVERTDIRECTION = -1;


export const SortBy = (column) => {
    return ({type: TABLE_SORT,
        table: "TABLENAME",
        ...InvertDirection(column)
        })
}

const InvertDirection = (column => ({
    row: column.row,
    table: column.table,
    header: column.header,
    direction: column.direction
}))