import { Avatar, Box, Button, Paper, Typography } from "@mui/material";
import React from "react";
import { useDispatch } from "react-redux";
import { SIGNIN_REQUEST } from "../../store/reducer/user/userActionTypes";
import loginWallpager from "../../assets/loginwallpaper.webp";
import tikiImg from "../../assets/tiki.png";
import { Stack } from "@mui/system";

function LoginPage() {
  const dispatch = useDispatch();
  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100vh",
        backgroundImage: `url(${loginWallpager})`,
        backgroundSize: "cover",
        backgroundRepeat: "no-repeat",
      }}
    >
      <Paper sx={{ flexBasis: "400px", height: "400px", padding: 3 }}>
        <Stack sx={{ height: "100%" }}>
          <Avatar
            variant="square"
            src={tikiImg}
            sx={{ width: 100, height: 100, margin: "auto" }}
          />
          <Typography variant="h4" sx={{ textAlign: "center" }}>
            Tiki admin site
          </Typography>
          <Box sx={{ flexGrow: 1 }}></Box>
          <Button
            variant="contained"
            onClick={() => dispatch({ type: SIGNIN_REQUEST })}
          >
            Login
          </Button>
        </Stack>
      </Paper>
    </Box>
  );
}

export default LoginPage;
