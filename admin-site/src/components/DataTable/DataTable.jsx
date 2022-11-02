import * as React from "react";
import Box from "@mui/material/Box";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TablePagination from "@mui/material/TablePagination";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import DataTableHead from "./components/DataTableHead";
import DataTableToolbar from "./components/DataTableToolBar";
import RowAction from "./components/RowAction";

// EXAMPLE HEAD CONFIG
// const headCells = [
//   {
//     id: "name",
//     numeric: false,
//     disablePadding: true,
//     label: "Dessert (100g serving)",
//   }
// ];

export default function DataTable({
  rows,
  headCells,
  page,
  count,
  limit,
  handleChangePage,
  handleChangeRowsPerPage,
  handleSearch,
  handleAddClick,
  handleEditClick,
  handleDeleteClick,
  handleDetailClick,
}) {
  const [order, setOrder] = React.useState("asc");
  const [orderBy, setOrderBy] = React.useState("calories");

  const handleRequestSort = (event, property) => {
    const isAsc = orderBy === property && order === "asc";
    setOrder(isAsc ? "desc" : "asc");
    setOrderBy(property);
  };

  return (
    <Box sx={{ width: "100%" }}>
      <Paper sx={{ width: "100%", mb: 2 }}>
        <DataTableToolbar
          onSearchChange={handleSearch}
          onAddClick={handleAddClick}
        />
        <TableContainer>
          <Table sx={{ minWidth: 750 }} aria-labelledby="tableTitle">
            <DataTableHead
              headCells={headCells}
              order={order}
              orderBy={orderBy}
              onRequestSort={handleRequestSort}
              rowCount={rows.length}
            />
            <TableBody>
              {rows.map((row, index) => {
                return (
                  <TableRow hover role="checkbox" tabIndex={-1} key={row.name}>
                    {headCells.map((headCell) => (
                      <TableCell
                        key={`cell-${headCell.id}-${index}`}
                        align={headCell.numeric ? "right" : "left"}
                      >
                        {row[headCell.id]}
                      </TableCell>
                    ))}
                    <TableCell padding="none" sx={{ textAlign: "end" }}>
                      <RowAction
                        row={row}
                        onDetailClick={handleDetailClick}
                        onEditClick={handleEditClick}
                        onDeleteClick={handleDeleteClick}
                      />
                    </TableCell>
                  </TableRow>
                );
              })}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[5, 10, 25]}
          component="div"
          count={count}
          rowsPerPage={limit}
          page={page - 1}
          onPageChange={(event, newPage) => handleChangePage(newPage + 1)}
          onRowsPerPageChange={handleChangeRowsPerPage}
        />
      </Paper>
    </Box>
  );
}
