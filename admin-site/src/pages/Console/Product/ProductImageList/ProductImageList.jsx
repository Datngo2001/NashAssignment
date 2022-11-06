import React, { useEffect, useState } from "react";
import ImageList from "@mui/material/ImageList";
import ImageListItem from "@mui/material/ImageListItem";
import ImageListItemBar from "@mui/material/ImageListItemBar";
import ListSubheader from "@mui/material/ListSubheader";
import IconButton from "@mui/material/IconButton";
import AddIcon from "@mui/icons-material/Add";
import { Box, Button, Paper, Typography } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import useDataModal from "../../../../hooks/useDataModal";
import ImageModal from "../ImageModal/ImageModal";
import EditIcon from "@mui/icons-material/Edit";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import { DETAIL } from "../../../../hooks/_dataAction";

function ProductImageList({ items = [], action, onImagesChange, style }) {
  const {
    dataModal,
    openCreateModal,
    openDetailModal,
    openUpdateModal,
    closeModal,
  } = useDataModal();
  const openConfirm = useConfirmModal();

  const [images, setImages] = useState(items);

  useEffect(() => {
    onImagesChange(images);
  }, [images]);

  const handleCreateImage = () => {
    openCreateModal((newImage) => {
      newImage.id = Date.now(); // Generate unique temporary id for image
      newImage.isNew = true;

      if (newImage.isMain) {
        images.forEach((img) => {
          img.isMain = false;
        });
        setImages((val) => [newImage, ...val]);
      } else {
        setImages((val) => [...val, newImage]);
      }
    });
  };

  const handleEditImage = (image) => {
    openUpdateModal(image, (newImage) => {
      let index = images.findIndex((img) => img.id.toString() === newImage.id);

      if (newImage.isMain) {
        images.forEach((img) => {
          img.isMain = false;
        });
        setImages((val) => {
          val.splice(index, 1);
          return [newImage, ...val];
        });
      } else {
        setImages((val) => {
          val[index] = newImage;
          return [...val];
        });
      }
    });
  };

  const handleDeleteImage = (image) => {
    openConfirm({
      message: `Do you want to delete image?`,
      onYes: () => {
        let index = images.findIndex((img) => img.id === image.id);
        images.splice(index, 1);
        setImages(() => [...images]);
      },
      onNo: () => {},
    });
  };

  return (
    <Paper sx={{ padding: 1, height: "100%" }}>
      <ImageList sx={style}>
        <ImageListItem key="Subheader" cols={2}>
          <ListSubheader component="div" sx={{ padding: 0 }}>
            <Box sx={{ display: "flex", alignItems: "center" }}>
              <Typography sx={{ flexGrow: 1 }}>
                {images ? `${images.length} images` : "0 images"}
              </Typography>
              {action === DETAIL ? null : (
                <Button
                  variant="contained"
                  sx={{ textAlign: "end" }}
                  onClick={handleCreateImage}
                >
                  <AddIcon />
                </Button>
              )}
            </Box>
          </ListSubheader>
        </ImageListItem>
        {images?.map((image, index) => (
          <ImageListItem key={image.url} onClick={() => openDetailModal(image)}>
            <img
              src={`${image.url}?w=248&fit=crop&auto=format`}
              alt={image.url}
              loading="lazy"
            />
            <ImageListItemBar
              title={image.isMain ? "Main" : `Image ${index}`}
              actionIcon={
                <>
                  {action === DETAIL ? null : (
                    <>
                      <IconButton
                        onClick={(e) => {
                          e.stopPropagation();
                          handleEditImage(image);
                        }}
                        sx={{ color: "rgba(255, 255, 255, 0.54)" }}
                      >
                        <EditIcon />
                      </IconButton>
                      <IconButton
                        onClick={(e) => {
                          e.stopPropagation();
                          handleDeleteImage(image);
                        }}
                        sx={{ color: "rgba(255, 255, 255, 0.54)" }}
                      >
                        <DeleteIcon />
                      </IconButton>
                    </>
                  )}
                </>
              }
            />
          </ImageListItem>
        ))}
      </ImageList>
      <ImageModal
        open={dataModal.open}
        image={dataModal.data}
        action={dataModal.action}
        onSave={dataModal.handleSave}
        onClose={() => closeModal()}
      />
    </Paper>
  );
}

export default ProductImageList;
