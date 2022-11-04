import { Button, Paper, TextField } from "@mui/material";
import React, { useRef } from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import { Box, Stack } from "@mui/system";
import ConfirmModal from "../../../../components/ConfirmModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import RichTextField from "../../../../components/RichTextField/RichTextField";
import { convertToRaw } from "draft-js";
import draftToHtml from "draftjs-to-html";
import useDataForm from "../../../../hooks/useDataForm";
import { getSrc } from "../../../../util/getSrcImg";

function ProductModal({ open, onClose, onSave, product, action = "create" }) {
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

  const description = useRef();

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
    data.description = draftToHtml(
      convertToRaw(description.current.getCurrentContent())
    );
    onSave(data);
    reset();
  };

  const handleCancel = () => handleClose();

  return (
    <BaseModal
      title={"Create product"}
      open={open}
      onClose={handleClose}
      styles={{ width: 1300, height: 1300 }}
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
                    value={product?.id}
                    label="Product ID"
                    disabled={true}
                  />
                  <input
                    type="text"
                    defaultValue={product?.id}
                    hidden
                    {...register("id")}
                  />
                </>
              )}
              <TextField
                label="Product Name"
                multiline
                rows={4}
                InputProps={{
                  ...register("name"),
                  defaultValue: product?.name,
                  readOnly: DETAILING,
                }}
              />
              <TextField
                label="Price"
                type="number"
                InputProps={{
                  ...register("price"),
                  defaultValue: product?.price,
                  readOnly: DETAILING,
                }}
              />
              {(UPDATING || DETAILING) && (
                <>
                  <TextField
                    label="Create Date"
                    type="text"
                    InputProps={{
                      defaultValue: product?.createDate,
                      disabled: DETAILING || UPDATING,
                    }}
                  />
                  <TextField
                    label="Update Date"
                    type="text"
                    InputProps={{
                      defaultValue: product?.updateDate,
                      disabled: DETAILING || UPDATING,
                    }}
                  />
                </>
              )}
            </Stack>
            <Stack spacing={2} sx={{ flexGrow: 1 }}>
              <TextField
                label="Image"
                InputProps={{
                  ...register("image"),
                  value: product?.image,
                  readOnly: DETAILING,
                }}
              />
              <Paper elevation={1} sx={{ textAlign: "center" }}>
                <img
                  style={{
                    height: "444px",
                    width: "444px",
                    objectFit: "contain",
                  }}
                  src={getSrc([watchImg, product?.image])}
                  alt="img"
                />
              </Paper>
            </Stack>
          </Box>
          <Box sx={{ flexGrow: 1 }}>
            <RichTextField
              defaultValue={product?.description}
              ref={description}
              readOnly={DETAILING}
            />
          </Box>
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

export default ProductModal;
