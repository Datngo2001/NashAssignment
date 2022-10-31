import React from 'react';
import { createPortal } from 'react-dom';
import styles from './baseFullScreenModal.module.css';
import CloseIcon from '@mui/icons-material/Close';
import { IconButton } from '@mui/material';

function BaseFullScreenModal({ isOpen, closeModal, children }) {
  return createPortal(
    <div className={styles['modal']} style={{ display: isOpen ? 'block' : 'none' }}>
      <div className={styles['modal-header']}>
        <IconButton onClick={closeModal} color="primary" size="large" sx={{ padding: 5 }}>
          <CloseIcon sx={{ fontSize: 40 }} />
        </IconButton>
      </div>
      {children}
    </div>,
    document.getElementById('root-modal')
  );
}

export default BaseFullScreenModal;
