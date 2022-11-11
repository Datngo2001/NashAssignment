import {
  Avatar,
  Button,
  Divider,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
  Paper,
  Typography,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import CloseIcon from "@mui/icons-material/Close";
import { Box } from "@mui/system";
import AddIcon from "@mui/icons-material/Add";
import useDataModal from "../../../../hooks/useDataModal";
import useConfirmModal from "../../../../hooks/useConfirmModal";
import { DETAIL } from "../../../../hooks/_dataAction";
import SearchCategoryModal from "../SearchCategoryModal/SearchCategoryModal";

function CategoryList({ items = [], action, onCategoriesChange }) {
  const { dataModal, openCreateModal, closeModal } = useDataModal();
  const openConfirm = useConfirmModal();
  const [categories, setCategories] = useState(items);

  useEffect(() => {
    onCategoriesChange(categories);
  }, [categories]);

  const handleRemove = (category) => {
    openConfirm({
      message: `Do you want to remove category "${category.name}" from product?`,
      onYes: () => {
        let index = categories.findIndex((cate) => cate.id === category.id);
        categories.splice(index, 1);
        setCategories(() => [...categories]);
      },
      onNo: () => {},
    });
  };

  const handleAdd = () => {
    openCreateModal((newCate) => {
      setCategories((val) => [...val, newCate]);
    });
  };

  return (
    <Paper sx={{ padding: 1, height: "100%" }}>
      <Box sx={{ display: "flex", alignItems: "center", marginBottom: 1 }}>
        <Typography sx={{ flexGrow: 1 }}>
          {categories ? `${categories.length} categories` : "0 category"}
        </Typography>
        {action === DETAIL ? null : (
          <Button
            variant="contained"
            sx={{ textAlign: "end" }}
            onClick={handleAdd}
          >
            <AddIcon />
          </Button>
        )}
      </Box>
      <List
        sx={{ width: "100%", height: "100%", maxHeight: 147, overflow: "auto" }}
      >
        {categories.map((category) => (
          <ListItem
            key={category.id}
            secondaryAction={
              <>
                {action === DETAIL ? null : (
                  <IconButton edge="end" onClick={() => handleRemove(category)}>
                    <CloseIcon />
                  </IconButton>
                )}
              </>
            }
            disablePadding
          >
            <ListItemButton>
              <ListItemAvatar>
                <Avatar src={category.image} />
              </ListItemAvatar>
              <ListItemText primary={category.name} />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
      <SearchCategoryModal
        categories={categories}
        open={dataModal.open}
        onAdd={dataModal.handleSave}
        onClose={() => closeModal()}
      />
    </Paper>
  );
}

export default CategoryList;
