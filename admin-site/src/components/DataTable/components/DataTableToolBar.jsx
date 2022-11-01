import React, { useState } from "react";
import {
  Button,
  IconButton,
  TextField,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import { alpha } from "@mui/material/styles";
import { Box } from "@mui/system";
import AddIcon from "@mui/icons-material/Add";

export default function DataTableToolbar({
  numSelected,
  onSearchChange,
  onAddClick,
}) {
  const [query, setQuery] = useState("");
  return (
    <Toolbar
      sx={{
        pl: { sm: 2 },
        pr: { xs: 1, sm: 1 },
        ...(numSelected > 0 && {
          bgcolor: (theme) =>
            alpha(
              theme.palette.primary.main,
              theme.palette.action.activatedOpacity
            ),
        }),
      }}
    >
      {numSelected > 0 ? (
        <Typography
          sx={{ flex: "1 1 100%" }}
          color="inherit"
          variant="subtitle1"
          component="div"
        >
          {numSelected} selected
        </Typography>
      ) : (
        <Box sx={{ flexGrow: 1 }}>
          <TextField
            autoComplete="off"
            sx={{ width: 500 }}
            variant="standard"
            placeholder="Search Product ..."
            value={query}
            onChange={(e) => {
              onSearchChange(e);
              setQuery(e.target.value);
            }}
          />
        </Box>
      )}

      {numSelected > 0 ? (
        <Tooltip title="Delete">
          <IconButton size="large">
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      ) : (
        <Button
          size="large"
          color="secondary"
          variant="outlined"
          onClick={onAddClick}
        >
          <AddIcon />
        </Button>
      )}
    </Toolbar>
  );
}
