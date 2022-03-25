import { createSlice } from "@reduxjs/toolkit";

const sharedUiSlice = createSlice({
  name: "ui",
  initialState: { clientModalIsVisible: false, projectModalIsVisible: false },
  reducers: {
    toggleClientModal(state) {
      state.clientModalIsVisible = !state.clientModalIsVisible;
    },
    toggleProjectModal(state) {
      state.projectModalIsVisible = !state.projectModalIsVisible;
    },
  },
});

export const sharedUiActions = sharedUiSlice.actions;

export default sharedUiSlice;
