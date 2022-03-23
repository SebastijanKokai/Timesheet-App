import { createSlice } from "@reduxjs/toolkit";

const uiSlice = createSlice({
  name: "ui",
  initialState: { clientModalIsVisible: false },
  reducers: {
    toggle(state) {
      state.clientModalIsVisible = !state.clientModalIsVisible;
    },
  },
});

export const uiActions = uiSlice.actions;

export default uiSlice;
