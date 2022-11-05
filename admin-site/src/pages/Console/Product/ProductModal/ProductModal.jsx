import { Button, TextField } from "@mui/material";
import React, { useRef } from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import { Box, Stack } from "@mui/system";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import RichTextField from "../../../../components/RichTextField/RichTextField";
import { convertToRaw } from "draft-js";
import draftToHtml from "draftjs-to-html";
import useDataForm from "../../../../hooks/useDataForm";
import ProductImages from "../ProductImages/ProductImages";

const init = {
  id: "",
  name: "",
  price: 0,
  description: "",
  createDate: "",
  updateDate: "",
  categories: [],
  images: [],
  features: [],
};

function ProductModal({ open, onClose, onSave, product = init, action }) {
  const {
    getValues,
    register,
    handleSubmit,
    formState,
    reset,
    UPDATING,
    DETAILING,
  } = useDataForm({ action });

  const description = useRef();
  const images = useRef();

  const openConfirm = useConfirmModal();

  const handleClose = () => {
    if (formState.isDirty && !DETAILING) {
      openConfirm({
        message: "Save Changes?",
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
    data.description = draftToHtml(
      convertToRaw(description.current.getCurrentContent())
    );
    data.images = images.current;
    onSave(data);
    reset();
  };

  const handleCancel = () => handleClose();

  const handleImagesChange = (newImages) => {
    images.current = newImages;
  };

  return (
    <BaseModal
      title={"Product"}
      open={open}
      onClose={handleClose}
      styles={{ width: 1300, height: "max-content" }}
    >
      <form
        autoComplete="off"
        style={{ height: "100%" }}
        onSubmit={handleSubmit(onSubmit)}
      >
        <Stack spacing={2} sx={{ height: "100%" }}>
          <Box sx={{ display: "flex", gap: 1, height: 450 }}>
            <Stack spacing={2} sx={{ width: "50%" }}>
              {(UPDATING || DETAILING) && (
                <>
                  <TextField
                    value={product.id}
                    label="Product ID"
                    disabled={true}
                  />
                  <input
                    type="text"
                    defaultValue={product.id}
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
                  defaultValue: product.name,
                  readOnly: DETAILING,
                }}
              />
              <TextField
                label="Price"
                type="number"
                InputProps={{
                  ...register("price"),
                  defaultValue: product.price,
                  readOnly: DETAILING,
                }}
              />
              {(UPDATING || DETAILING) && (
                <>
                  <TextField
                    label="Create Date"
                    type="text"
                    InputProps={{
                      defaultValue: product.createDate,
                      disabled: DETAILING || UPDATING,
                    }}
                  />
                  <TextField
                    label="Update Date"
                    type="text"
                    InputProps={{
                      defaultValue: product.updateDate,
                      disabled: DETAILING || UPDATING,
                    }}
                  />
                </>
              )}
            </Stack>
            <Box sx={{ width: "50%" }}>
              <ProductImages
                style={{ height: 396 }}
                items={product.images}
                action={action}
                onImagesChange={handleImagesChange}
              />
            </Box>
          </Box>
          <Box sx={{ flexGrow: 1 }}>
            <RichTextField
              defaultValue={product.description}
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
    </BaseModal>
  );
}

export default ProductModal;
