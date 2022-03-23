import { createSlice } from "@reduxjs/toolkit";

const countrySlice = createSlice({
  name: "country",
  initialState: {
    countries: [],
    error: null,
  },
  reducers: {
    addCountries(state, action) {
      const data = action.payload;
      console.log(data);
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

export const allCountries = (state) => state.country.countries;

export default countrySlice;
