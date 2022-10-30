import { Box, Toolbar } from "@mui/material";
import React from "react";
import ConsoleRoute from "../routes/ConsoleRoute";
import NavBar from "./components/NavBar/NavBar";
import SideBar from "./components/SideBar/SideBar";

function ConsoleLayout() {
  return (
    <Box sx={{ display: "flex" }}>
      <NavBar />
      <SideBar />
      <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar />
        <ConsoleRoute />
      </Box>
    </Box>
  );
}

export default ConsoleLayout;
