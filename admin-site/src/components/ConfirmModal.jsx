import { Button, Card, CardActions, CardContent, Modal } from '@mui/material';
import { Container } from '@mui/system';
import React from 'react';
import { createPortal } from 'react-dom';

function ModalContent({ message, open, onAnswer }) {
  return (
    <Modal open={open} onClose={() => onAnswer(false)}>
      <Container
        maxWidth="xs"
        sx={{ position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)' }}>
        <Card>
          <CardContent>{message}</CardContent>
          <CardActions sx={{ textAlign: 'end' }}>
            <Button onClick={() => onAnswer(true)}>Yes</Button>
            <Button onClick={() => onAnswer(false)}>No</Button>
          </CardActions>
        </Card>
      </Container>
    </Modal>
  );
}

export default function ConfirmModal({ ...rest }) {
  return createPortal(<ModalContent {...rest} />, document.getElementById('root-modal'));
}
