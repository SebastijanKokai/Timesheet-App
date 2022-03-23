import { configureStore } from "@reduxjs/toolkit";
import uiSlice from "./ui-slice";
import clientSlice from "./client-slice";
import countrySlice from "./country/country-slice";

// const clientActions = clientSlice.actions;

const store = configureStore({
  reducer: {
    client: clientSlice.reducer,
    country: countrySlice.reducer,
    ui: uiSlice.reducer,
  },
});

// export { clientActions };
export default store;
