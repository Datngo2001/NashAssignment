import { Button, Card, CardActions, CardContent, Modal } from "@mui/material";
import { Container } from "@mui/system";
import React from "react";
import { createPortal } from "react-dom";
import { useDispatch, useSelector } from "react-redux";
import { CLOSE_CONFIRM_DIALOG } from "../store/reducer/confirm/confirmActionTypes";

function ModalContent() {
  const dispatch = useDispatch();
  const { open, message, onYes, onNo } = useSelector((state) => state.confirm);
  const handleAnswer = (result) => {
    dispatch({ type: CLOSE_CONFIRM_DIALOG, payload: { result, onYes, onNo } });
  };
  return (
    <Modal open={open} onClose={() => handleAnswer(false)}>
      <Container
        maxWidth="xs"
        sx={{
          position: "absolute",
          top: "50%",
          left: "50%",
          transform: "translate(-50%, -50%)",
        }}
      >
        <Card>
          <CardContent>{message}</CardContent>
          <CardActions sx={{ textAlign: "end" }}>
            <Button onClick={() => handleAnswer(true)}>Yes</Button>
            <Button onClick={() => handleAnswer(false)}>No</Button>
          </CardActions>
        </Card>
      </Container>
    </Modal>
  );
}

export default function ConfirmModal({ ...rest }) {
  return createPortal(
    <ModalContent {...rest} />,
    document.getElementById("root-modal")
  );
}
