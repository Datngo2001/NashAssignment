import React from "react";
import DataTable from "../../../../components/DataTable/DataTable";

const headCells = [
  {
    id: "id",
    numeric: true,
    disablePadding: false,
    label: "Id",
  },
  {
    id: "name",
    numeric: false,
    disablePadding: false,
    label: "Name",
  },
];

function CategoryModal() {
  return (
    <div>
      {/* <DataTable
        title={"Products"}
        rows={products}
        headCells={headCells}
        query={query}
        page={page}
        count={count}
        limit={limit}
        handleChangePage={handlePageChange}
        handleChangeRowsPerPage={handleLimitChange}
        handleSearch={handleSearch}
        handleAddClick={handleAddClick}
      />
      <CategoryModal
        open={productModal.open}
        action={productModal.action}
        onSave={handleSave}
        onClose={handleClose}
      /> */}
    </div>
  );
}

export default CategoryModal;
