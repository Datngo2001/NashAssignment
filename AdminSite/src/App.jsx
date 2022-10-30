import { useState } from "react";
import { createTheme, ThemeProvider } from "@mui/material";
import LoginLayout from "./layout/LoginLayout";
import "./App.css";

const theme = createTheme({
  palette: {
    type: "light",
    primary: {
      main: "#039be5",
    },
    secondary: {
      main: "#8777d9",
    },
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <LoginLayout />
    </ThemeProvider>
  );
}

export default App;
