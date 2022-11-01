import { Box, Divider, IconButton, Modal, Paper } from "@mui/material";
import React from "react";
import { createPortal } from "react-dom";
import CloseIcon from "@mui/icons-material/Close";
import { Stack } from "@mui/system";

function BaseModalContent({ title, open, onClose, styles, children }) {
  return (
    <Modal
      open={open}
      onClose={onClose}
      aria-labelledby="modal-modal-title"
      aria-describedby="modal-modal-description"
      sx={{
        overflow: "auto",
        display: "flex",
        justifyContent: "center",
      }}
    >
      <Paper
        sx={{
          ...styles,
          bgcolor: "background.paper",
          marginTop: 10,
          boxShadow: 24,
        }}
      >
        <Stack sx={{ height: "100%" }}>
          <Box sx={{ display: "flex", alignItems: "center", p: 2 }}>
            <h4>{title}</h4>
            <Box sx={{ flexGrow: 1 }}></Box>
            <IconButton onClick={onClose}>
              <CloseIcon />
            </IconButton>
          </Box>
          <Divider />
          <Box sx={{ p: 2, flexGrow: 1 }}>{children}</Box>
        </Stack>
      </Paper>
    </Modal>
  );
}

function BaseModal(props) {
  return createPortal(
    <BaseModalContent {...props} />,
    document.getElementById("root-modal")
  );
}

export default BaseModal;
