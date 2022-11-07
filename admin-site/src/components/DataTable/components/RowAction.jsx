import { IconButton, Menu, MenuItem, Popover, Typography } from "@mui/material";
import React from "react";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import InfoIcon from "@mui/icons-material/Info";
import { UPDATE, DELETE, DETAIL } from "../../../hooks/_dataAction";

function RowAction({
  row,
  onEditClick,
  onDeleteClick,
  onDetailClick,
  allowActions,
}) {
  const [anchorEl, setAnchorEl] = React.useState(null);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? "simple-popover" : undefined;

  return (
    <>
      <IconButton
        aria-describedby={id}
        variant="contained"
        onClick={handleClick}
      >
        <MoreVertIcon />
      </IconButton>
      <Popover
        id={id}
        open={open}
        anchorEl={anchorEl}
        onClose={handleClose}
        anchorOrigin={{
          vertical: "bottom",
          horizontal: "left",
        }}
      >
        <Menu anchorEl={anchorEl} open={open} onClose={handleClose}>
          {allowActions.includes(DETAIL) && (
            <MenuItem
              onClick={() => {
                handleClose();
                onDetailClick(row);
              }}
              disableRipple
            >
              <InfoIcon />
              <Typography sx={{ marginLeft: 1 }}>Detail</Typography>
            </MenuItem>
          )}
          {allowActions.includes(UPDATE) && (
            <MenuItem
              sx={{
                display: allowActions.includes(UPDATE),
              }}
              onClick={() => {
                handleClose();
                onEditClick(row);
              }}
              disableRipple
            >
              <EditIcon />
              <Typography sx={{ marginLeft: 1 }}>Edit</Typography>
            </MenuItem>
          )}
          {allowActions.includes(DELETE) && (
            <MenuItem
              sx={{
                display: allowActions.includes(DELETE),
              }}
              onClick={() => {
                handleClose();
                onDeleteClick(row);
              }}
              disableRipple
            >
              <DeleteIcon />
              <Typography sx={{ marginLeft: 1 }}>Delete</Typography>
            </MenuItem>
          )}
        </Menu>
      </Popover>
    </>
  );
}

export default RowAction;
