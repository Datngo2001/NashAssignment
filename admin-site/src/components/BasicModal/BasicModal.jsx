import React from 'react';

import styles from './modal.module.css';

function BasicModal({ onClose, children }) {
  return (
    <div className={styles['modal']} onClick={() => (onClose ? onClose() : '')}>
      <div
        className={styles['modal_content'] + ' ' + styles['custom-scroll']}
        onClick={(event) => event.stopPropagation()}>
        {children}
      </div>
    </div>
  );
}

export default BasicModal;
