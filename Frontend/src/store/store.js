import { configureStore } from "@reduxjs/toolkit";
import sharedUiSlice from "./shared-ui-slice";
import clientSlice from "./client/client-slice";
import countrySlice from "./country/country-slice";

const store = configureStore({
  reducer: {
    client: clientSlice.reducer,
    country: countrySlice.reducer,
    ui: sharedUiSlice.reducer,
  },
});

export default store;
