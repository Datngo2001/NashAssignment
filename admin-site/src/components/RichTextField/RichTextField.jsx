import React, { useEffect, useState } from "react";
import { Editor } from "react-draft-wysiwyg";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { Paper } from "@mui/material";
import { ContentState, convertFromHTML, EditorState } from "draft-js";

function RichTextField({ defaultValue = "", readOnly = false }, ref) {
  const blocksFromHTML = convertFromHTML(defaultValue);
  const state = ContentState.createFromBlockArray(
    blocksFromHTML.contentBlocks,
    blocksFromHTML.entityMap
  );
  const [editorState, setEditorState] = useState(() =>
    EditorState.createWithContent(state)
  );

  useEffect(() => {
    ref.current = editorState;
  }, [editorState]);

  return (
    <Paper elevation={1} sx={{ p: 1, height: "100%" }}>
      <Editor
        editorState={editorState}
        onEditorStateChange={setEditorState}
        readOnly={readOnly}
      />
    </Paper>
  );
}

export default React.forwardRef(RichTextField);
