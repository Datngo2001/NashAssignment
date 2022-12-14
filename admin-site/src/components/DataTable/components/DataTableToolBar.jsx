import React, { useState } from "react";
import { Button, TextField, Toolbar } from "@mui/material";
import { Box } from "@mui/system";
import AddIcon from "@mui/icons-material/Add";
import { CREATE } from "../../../hooks/_dataAction";

export default function DataTableToolbar({
  onSearchChange,
  onAddClick,
  allowActions,
}) {
  const [query, setQuery] = useState("");
  return (
    <Toolbar
      sx={{
        pl: { sm: 2 },
        pr: { xs: 1, sm: 1 },
      }}
    >
      <Box sx={{ flexGrow: 1 }}>
        <TextField
          autoComplete="off"
          sx={{ width: 500 }}
          variant="standard"
          placeholder="Search ..."
          value={query}
          onChange={(e) => {
            onSearchChange(e);
            setQuery(e.target.value);
          }}
        />
      </Box>
      {allowActions.includes(CREATE) && (
        <Button
          size="large"
          color="secondary"
          variant="contained"
          onClick={onAddClick}
        >
          <AddIcon />
        </Button>
      )}
    </Toolbar>
  );
}
