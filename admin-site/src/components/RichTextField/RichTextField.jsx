import React, { useEffect, useState } from "react";
import { Editor } from "react-draft-wysiwyg";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { Paper } from "@mui/material";
import { ContentState, convertFromHTML, EditorState } from "draft-js";

function RichTextField({ defaultValue = "", readOnly = false, onChange }) {
  const blocksFromHTML = convertFromHTML(defaultValue);
  const state = ContentState.createFromBlockArray(
    blocksFromHTML.contentBlocks,
    blocksFromHTML.entityMap
  );
  const [editorState, setEditorState] = useState(() =>
    EditorState.createWithContent(state)
  );

  useEffect(() => {
    onChange(editorState);
  }, [editorState]);

  return (
    <Paper elevation={1} sx={{ p: 1, minHeight: 500 }}>
      <Editor
        editorState={editorState}
        onEditorStateChange={setEditorState}
        readOnly={readOnly}
      />
    </Paper>
  );
}

export default RichTextField;
