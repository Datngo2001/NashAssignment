import { Box, Button, Paper, Stack, TextField } from "@mui/material";
import React from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import ConfirmModal from "../../../../components/ConfirmModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import useDataForm from "../../../../hooks/useDataForm";
import { getSrc } from "../../../../util/getSrcImg";

function CategoryModal({ open, onClose, onSave, category, action }) {
  const {
    getValues,
    register,
    handleSubmit,
    formState,
    reset,
    watch,
    UPDATING,
    DETAILING,
  } = useDataForm({ action });

  const watchImg = watch("image");

  const { confirm, openNewConfirm, onAnswer } = useConfirmModal({
    message: "Save Change ?",
  });

  const handleClose = () => {
    if (formState.isDirty && !DETAILING) {
      openNewConfirm(
        () => {
          onSave(getValues());
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
              {(UPDATING || DETAILING) && (
                <>
                  <TextField
                    value={category?.id}
                    label="Category ID"
                    disabled={true}
                  />
                  <input
                    type="text"
                    defaultValue={category?.id}
                    hidden
                    {...register("id")}
                  />
                </>
              )}
              <TextField
                label="Category Name"
                multiline
                rows={4}
                InputProps={{
                  ...register("name"),
                  defaultValue: category?.name,
                  readOnly: DETAILING,
                }}
              />
            </Stack>
            <Stack spacing={2} sx={{ flexGrow: 1 }}>
              <TextField
                label="Image"
                InputProps={{
                  ...register("image"),
                  value: category?.image,
                  readOnly: DETAILING,
                }}
              />
              <Paper elevation={1} sx={{ textAlign: "center" }}>
                <img
                  style={{
                    height: "200px",
                    width: "200px",
                    objectFit: "contain",
                  }}
                  src={getSrc([watchImg, category?.image])}
                  alt="img"
                />
              </Paper>
            </Stack>
          </Box>
          <Box sx={{ flexGrow: 1 }}></Box>
          {!DETAILING && (
            <Box sx={{ textAlign: "end" }}>
              <Button type="submit" variant="contained">
                Save
              </Button>
              <Button onClick={handleCancel}>Cancel</Button>
            </Box>
          )}
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
