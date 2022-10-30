import {
  Box,
  Drawer,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Toolbar,
} from "@mui/material";
import React from "react";
import Inventory2Icon from "@mui/icons-material/Inventory2";
import StarRateIcon from "@mui/icons-material/StarRate";
import CategoryIcon from "@mui/icons-material/Category";
import PersonIcon from "@mui/icons-material/Person";
import { useLocation, useNavigate } from "react-router";

const drawerWidth = 240;

function SideBar() {
  const navigate = useNavigate();
  const location = useLocation();
  return (
    <Drawer
      variant="permanent"
      sx={{
        width: drawerWidth,
        flexShrink: 0,
        [`& .MuiDrawer-paper`]: {
          width: drawerWidth,
          boxSizing: "border-box",
        },
      }}
    >
      <Toolbar />
      <Box sx={{ overflow: "auto" }}>
        <List>
          <ListItem disablePadding>
            <ListItemButton
              selected={location.pathname === "/"}
              onClick={() => navigate("/")}
            >
              <ListItemIcon>
                <Inventory2Icon />
              </ListItemIcon>
              <ListItemText primary={"Product"} />
            </ListItemButton>
          </ListItem>
          <ListItem disablePadding>
            <ListItemButton
              selected={location.pathname === "/category"}
              onClick={() => navigate("/category")}
            >
              <ListItemIcon>
                <CategoryIcon />
              </ListItemIcon>
              <ListItemText primary={"Category"} />
            </ListItemButton>
          </ListItem>
          <ListItem disablePadding>
            <ListItemButton
              selected={location.pathname === "/customer"}
              onClick={() => navigate("/customer")}
            >
              <ListItemIcon>
                <PersonIcon />
              </ListItemIcon>
              <ListItemText primary={"Customer"} />
            </ListItemButton>
          </ListItem>
          <ListItem disablePadding>
            <ListItemButton
              selected={location.pathname === "/rating"}
              onClick={() => navigate("/rating")}
            >
              <ListItemIcon>
                <StarRateIcon />
              </ListItemIcon>
              <ListItemText primary={"Rating"} />
            </ListItemButton>
          </ListItem>
        </List>
      </Box>
    </Drawer>
  );
}

export default SideBar;
