import React, { useState } from "react";
import {
  IconButton,
  TextField,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import { alpha } from "@mui/material/styles";
import { Box } from "@mui/system";

export default function DataTableToolbar({
  title,
  numSelected,
  onSearchChange,
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
        <Typography
          sx={{ flex: "1 1 100%" }}
          variant="h6"
          id="tableTitle"
          component="div"
        >
          {title}
        </Typography>
      )}

      {numSelected > 0 ? (
        <Tooltip title="Delete">
          <IconButton>
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      ) : (
        <Box sx={{ flexBasis: 500 }}>
          <TextField
            autoComplete="off"
            sx={{ width: "100%" }}
            variant="standard"
            placeholder="Search..."
            value={query}
            onChange={(e) => {
              onSearchChange(e);
              setQuery(e.target.value);
            }}
          />
        </Box>
      )}
    </Toolbar>
  );
}
