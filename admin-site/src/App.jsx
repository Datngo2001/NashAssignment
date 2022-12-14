import { useEffect } from "react";
import { createTheme, ThemeProvider } from "@mui/material";
import LoginLayout from "./layout/LoginLayout";
import ConsoleLayout from "./layout/ConsoleLayout";
import "./App.css";
import { useDispatch, useSelector } from "react-redux";
import { CHECK_USER_STATUS } from "./store/reducer/user/userActionTypes";
import ConfirmModal from "./components/ConfirmModal";

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
  const { user } = useSelector((state) => state.user);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch({
      type: CHECK_USER_STATUS,
    });
  }, []);

  return (
    <ThemeProvider theme={theme}>
      {user ? <ConsoleLayout /> : <LoginLayout />}
      <ConfirmModal />
    </ThemeProvider>
  );
}

export default App;
