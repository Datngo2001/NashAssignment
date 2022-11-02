import { Box, Button, Paper, Stack, TextField } from "@mui/material";
import React from "react";
import { useForm, useWatch } from "react-hook-form";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import ConfirmModal from "../../../../components/ConfirmModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import dumpImg from "../../../../assets/dump_img.webp";

function CategoryModal({ open, onClose, onSave, category, action = "create" }) {
  const { control, getValues, register, handleSubmit, formState, reset } =
    useForm({
      defaultValues: { ...category },
    });
  useWatch({ control: control, name: "image" });

  const { confirm, openNewConfirm, onAnswer } = useConfirmModal({
    message: "Save Change ?",
  });

  const handleClose = () => {
    if (formState.isDirty) {
      openNewConfirm(
        () => {
          onSave();
          reset();
        },
        () => {
          onClose();
          reset();
        }
      );
    } else {
      onClose();
      reset();
    }
  };

  const onSubmit = (data) => {
    onSave(data);
    reset();
  };

  const handleCancel = () => handleClose();
  return (
    <BaseModal
      title={"Create category"}
      open={open}
      onClose={handleClose}
      styles={{ width: 700, height: 500 }}
    >
      <form
        autoComplete="off"
        style={{ height: "100%" }}
        onSubmit={handleSubmit(onSubmit)}
      >
        <Stack spacing={2} sx={{ height: "100%" }}>
          <Box sx={{ display: "flex", gap: 1 }}>
            <Stack spacing={2} sx={{ flexGrow: 2 }}>
              {action === "edit" && (
                <TextField
                  label="Product ID"
                  {...register("id")}
                  InputProps={{
                    readOnly: true,
                  }}
                />
              )}
              <TextField
                label="Category Name"
                multiline
                rows={4}
                {...register("name")}
              />
            </Stack>
            <Stack spacing={2} sx={{ flexGrow: 1 }}>
              <TextField label="Image" {...register("image")} />
              <Paper elevation={1} sx={{ textAlign: "center" }}>
                <img
                  style={{
                    height: "200px",
                    width: "200px",
                    objectFit: "contain",
                  }}
                  src={getValues("image") ? getValues("image") : dumpImg}
                  alt="img"
                />
              </Paper>
            </Stack>
          </Box>
          <Box sx={{ flexGrow: 1 }}></Box>
          <Box sx={{ textAlign: "end" }}>
            <Button type="submit" variant="contained">
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

export default CategoryModal;
