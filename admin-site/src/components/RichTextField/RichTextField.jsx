import React, { useEffect, useState } from "react";
import { Editor } from "react-draft-wysiwyg";
import { EditorState } from "draft-js";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import { Paper } from "@mui/material";

function RichTextField() {
  const [editorState, setEditorState] = useState(() =>
    EditorState.createEmpty()
  );

  useEffect(() => {
    console.log(editorState);
  }, [editorState]);

  return (
    <Paper elevation={1} sx={{ p: 1, height: "100%" }}>
      <Editor editorState={editorState} onEditorStateChange={setEditorState} />
    </Paper>
  );
}

export default RichTextField;
