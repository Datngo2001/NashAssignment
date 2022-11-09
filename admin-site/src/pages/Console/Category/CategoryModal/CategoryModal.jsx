import { Box, Button, Paper, Stack, TextField } from "@mui/material";
import React from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import useDataForm from "../../../../hooks/useDataForm";
import { getSrc } from "../../../../util/getSrcImg";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

const schema = yup.object({
  name: yup.string().required(),
  image: yup.string().required(),
});

const init = {
  id: "",
  name: "",
  image: "",
};

function CategoryModal({ open, onClose, onSave, category = init, action }) {
  const openConfirm = useConfirmModal();

  const {
    getValues,
    register,
    handleSubmit,
    formState,
    formState: { errors },
    reset,
    watch,
    UPDATING,
    DETAILING,
  } = useDataForm({ action, resolver: yupResolver(schema) });

  const watchImg = watch("image");

  const handleClose = () => {
    if (formState.isDirty && !DETAILING) {
      openConfirm({
        message: "Save Change ?",
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
                    value={category.id}
                    label="Category ID"
                    disabled={true}
                  />
                  <input
                    type="text"
                    defaultValue={category.id}
                    hidden
                    {...register("id")}
                  />
                </>
              )}
              <TextField
                error={errors.name}
                helperText={errors.name?.message}
                label="Category Name"
                multiline
                rows={4}
                InputProps={{
                  ...register("name"),
                  defaultValue: category.name,
                  readOnly: DETAILING,
                }}
              />
            </Stack>
            <Stack spacing={2} sx={{ flexGrow: 1 }}>
              <TextField
                label="Image"
                error={errors.image}
                helperText={errors.image?.message}
                InputProps={{
                  ...register("image"),
                  value: category.image,
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
    </BaseModal>
  );
}

export default CategoryModal;
