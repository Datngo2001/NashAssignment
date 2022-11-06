import { Button, TextField } from "@mui/material";
import React, { useRef } from "react";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import { Box, Stack } from "@mui/system";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import RichTextField from "../../../../components/RichTextField/RichTextField";
import { convertToRaw } from "draft-js";
import draftToHtml from "draftjs-to-html";
import useDataForm from "../../../../hooks/useDataForm";
import ProductImageList from "../ProductImageList/ProductImageList";
import CategoryList from "../CategoryList/CategoryList";

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

  const descriptionChange = useRef();
  const imagesChange = useRef();
  const categoriesChange = useRef();

  const openConfirm = useConfirmModal();

  const handleClose = () => {
    if (DETAILING) {
      onClose();
      reset();
    } else if (
      formState.isDirty ||
      imagesChange ||
      descriptionChange ||
      categoriesChange
    ) {
      openConfirm({
        message: "Save Changes?",
        onYes: () => {
          let data = getValues();
          data.description = draftToHtml(
            convertToRaw(descriptionChange.current.getCurrentContent())
          );
          data.images = imagesChange.current;
          data.categories = categoriesChange.current;
          onSave(data);
          reset();
        },
        onNo: () => {
          onClose();
          reset();
        },
      });
    }
  };

  const onSubmit = (data) => {
    data.description = draftToHtml(
      convertToRaw(descriptionChange.current.getCurrentContent())
    );
    data.images = imagesChange.current;
    data.categories = categoriesChange.current;
    onSave(data);
    reset();
  };

  const handleCancel = () => handleClose();

  const handleImagesChange = (newImages) => {
    imagesChange.current = newImages;
  };

  const handleCategoriesChange = (newCategories) => {
    categoriesChange.current = newCategories;
  };

  const handleDescriptionChange = (newDescription) => {
    descriptionChange.current = newDescription;
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
          <Box sx={{ display: "flex", gap: 1, height: "max-content" }}>
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
              <Box sx={{ display: "flex", gap: 1 }}>
                <Box sx={{ width: "50%" }}>
                  <CategoryList
                    action={action}
                    items={product.categories}
                    onCategoriesChange={handleCategoriesChange}
                  />
                </Box>
                <Box sx={{ width: "50%" }}>
                  <Stack
                    spacing={2}
                    sx={{ height: "100%", justifyContent: "space-between" }}
                  >
                    <TextField
                      label="Price"
                      type="number"
                      InputProps={{
                        ...register("price"),
                        defaultValue: product.price,
                        readOnly: DETAILING,
                      }}
                    />
                    <TextField
                      label="Create Date"
                      type="text"
                      InputProps={{
                        defaultValue: product.createDate,
                        disabled: true,
                      }}
                    />
                    <TextField
                      label="Update Date"
                      type="text"
                      InputProps={{
                        defaultValue: product.updateDate,
                        disabled: true,
                      }}
                    />
                  </Stack>
                </Box>
              </Box>
            </Stack>
            <Box sx={{ width: "50%" }}>
              <ProductImageList
                style={{ maxHeight: 396 }}
                items={product.images}
                action={action}
                onImagesChange={handleImagesChange}
              />
            </Box>
          </Box>
          <Box sx={{ flexGrow: 1 }}>
            <RichTextField
              defaultValue={product.description}
              onChange={handleDescriptionChange}
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
