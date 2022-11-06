import {
  Avatar,
  Box,
  Button,
  List,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
  TextField,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import { getCategories } from "../../../../api/category";
import BaseModal from "../../../../components/BaseModal/BaseModal";
import useThrottle from "../../../../hooks/useThrottle";

function SearchCategoryModal({ open, onClose, onAdd, categories = [] }) {
  const [searchResult, setSearchResult] = useState([]);

  useEffect(() => {
    getCategories("", 1, 5)
      .then((res) => setSearchResult(res.data.items))
      .catch((err) => console.log(err));
  }, []);

  const handleSearch = useThrottle((e) => {
    getCategories(e.target.value, 1, 5)
      .then((res) => setSearchResult(res.data.items))
      .catch((err) => console.log(err));
  }, 250);

  const isAdded = (id) => {
    return categories.some((cate) => cate.id === id);
  };

  return (
    <BaseModal
      title={"Add Categories"}
      open={open}
      onClose={onClose}
      styles={{ width: 500, height: 500 }}
    >
      <Box>
        <TextField
          sx={{ width: "100%" }}
          placeholder="Search ..."
          variant="standard"
          onChange={handleSearch}
        />
      </Box>
      <List sx={{ width: "100%" }}>
        {searchResult.map((category) => (
          <ListItem
            key={category.id}
            disablePadding
            secondaryAction={
              <Button
                edge="end"
                onClick={() => onAdd(category)}
                variant="contained"
                disabled={isAdded(category.id)}
              >
                Add
              </Button>
            }
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
    </BaseModal>
  );
}

export default SearchCategoryModal;
