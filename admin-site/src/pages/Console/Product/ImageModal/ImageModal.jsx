import {
  Button,
  Checkbox,
  FormControlLabel,
  Paper,
  Stack,
  TextField,
} from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import useDataForm from "../../../../hooks/useDataForm";
import { getSrc } from "../../../../util/getSrcImg";

const init = {
  id: "",
  url: "",
  isMain: false,
};

function ImageModal({ open, onClose, onSave, image = init, action }) {
  const openConfirm = useConfirmModal();
  const {
    getValues,
    register,
    handleSubmit,
    formState,
    reset,
    watch,
    DETAILING,
  } = useDataForm({ action });

  const watchUrl = watch("url");

  const handleClose = () => {
    if (formState.isDirty && !DETAILING) {
      openConfirm({
        message: "Save changes?",
        onYes: () => {
          onSave(getValues());
          reset();
        },
        onNo: () => {
          onClose();
          reset();
        },
      });
    } else {
      onClose();
      reset();
    }
  };

  const onSubmit = handleSubmit((data) => {
    onSave(data);
    reset();
  });

  const handleCancel = () => handleClose();

  return (
    <>
      <BaseModal
        title={"Product Image"}
        open={open}
        onClose={handleClose}
        styles={{ width: 600, height: 750 }}
      >
        <form
          autoComplete="off"
          style={{ height: "100%" }}
          onSubmit={(e) => {
            e.stopPropagation();
            onSubmit(e);
          }}
        >
          <Stack spacing={1} sx={{ height: "100%" }}>
            <input
              type="text"
              hidden
              defaultValue={image.id}
              {...register("id")}
            />
            <TextField
              label="Image"
              InputProps={{
                ...register("url"),
                defaultValue: image.url,
                readOnly: DETAILING,
              }}
            />
            <FormControlLabel
              control={
                <Checkbox
                  {...register("isMain")}
                  defaultChecked={image.isMain}
                  disabled={DETAILING}
                />
              }
              label="Main"
            />
            <Box sx={{ flexGrow: 1 }}></Box>
            <Paper elevation={1} sx={{ textAlign: "center" }}>
              <img
                style={{
                  height: "444px",
                  width: "444px",
                  objectFit: "contain",
                }}
                src={getSrc([watchUrl, image.url])}
                alt="img"
              />
            </Paper>
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
      </BaseModal>
    </>
  );
}

export default ImageModal;
