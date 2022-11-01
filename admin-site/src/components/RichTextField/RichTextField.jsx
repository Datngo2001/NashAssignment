import React, { useEffect, useState } from "react";
import { Editor } from "react-draft-wysiwyg";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { Paper } from "@mui/material";
import { EditorState } from "draft-js";

function RichTextField({ defaultValue }, ref) {
  const [editorState, setEditorState] = useState(() =>
    EditorState.createEmpty()
  );

  useEffect(() => {
    ref.current = editorState;
  }, [editorState]);

  return (
    <Paper elevation={1} sx={{ p: 1, height: "100%" }}>
      <Editor editorState={editorState} onEditorStateChange={setEditorState} />;
    </Paper>
  );
}

export default React.forwardRef(RichTextField);
