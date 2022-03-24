import { createSlice } from "@reduxjs/toolkit";

const countrySlice = createSlice({
  name: "country",
  initialState: {
    countries: [],
    error: null,
  },
  reducers: {
    countriesReceived(state, action) {
      const data = action.payload;

      for (const key in data) {
        state.countries.push({
          id: data[key].id,
          name: data[key].countryName,
        });
      }
    },
  },
});

export const countryActions = countrySlice.actions;

export default countrySlice;
