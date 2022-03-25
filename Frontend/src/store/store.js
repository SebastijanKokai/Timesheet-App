import { configureStore } from "@reduxjs/toolkit";
import sharedUiSlice from "./shared-ui-slice";
import clientSlice from "./client/client-slice";
import countrySlice from "./country/country-slice";
import projectSlice from "./project/project-slice";

const store = configureStore({
  reducer: {
    client: clientSlice.reducer,
    country: countrySlice.reducer,
    project: projectSlice.reducer,
    ui: sharedUiSlice.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({ serializableCheck: false }),
});

export default store;
