import { Button, TextField } from "@mui/material";
import React from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import { useForm } from "react-hook-form";
import { Box, Stack } from "@mui/system";
import ConfirmModal from "../../../../components/ConfirmModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";

function ProductModal({ open, onClose, onSave, product, action = "create" }) {
  const { register, handleSubmit, formState } = useForm();

  const onSubmit = (data) => console.log(data);

  const { confirm, openNewConfirm, onAnswer } = useConfirmModal({
    message: "Save Change ?",
  });

  const handleClose = () => {
    if (formState.isDirty) {
      openNewConfirm(
        () => onSave(),
        () => onClose()
      );
    } else {
      onClose();
    }
  };

  const handleSave = () => {
    onSave();
  };

  const handleCancel = () => handleClose();

  return (
    <BaseModal
      title={"Create product"}
      open={open}
      onClose={handleClose}
      styles={{ width: 500, height: 500 }}
    >
      <form style={{ height: "100%" }} onSubmit={handleSubmit(onSubmit)}>
        <Stack spacing={2} sx={{ height: "100%" }}>
          <TextField
            label="Product ID"
            {...register("id")}
            InputProps={{
              readOnly: true,
            }}
          />
          <TextField label="Product Name" {...register("name")} />
          <Box sx={{ flexGrow: 1 }}></Box>
          <Box sx={{ textAlign: "end" }}>
            <Button type="submit" variant="contained" onClick={handleSave}>
              Save
            </Button>
            <Button onClick={handleCancel}>Cancel</Button>
          </Box>
        </Stack>
      </form>
      <ConfirmModal
        open={confirm.open}
        message={confirm.message}
        onAnswer={onAnswer}
      />
    </BaseModal>
  );
}

export default ProductModal;
