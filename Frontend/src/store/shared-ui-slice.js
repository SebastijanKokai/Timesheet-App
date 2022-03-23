import { createSlice } from "@reduxjs/toolkit";

const sharedUiSlice = createSlice({
  name: "ui",
  initialState: { clientModalIsVisible: false },
  reducers: {
    toggle(state) {
      state.clientModalIsVisible = !state.clientModalIsVisible;
    },
  },
});

export const sharedUiActions = sharedUiSlice.actions;

export default sharedUiSlice;
