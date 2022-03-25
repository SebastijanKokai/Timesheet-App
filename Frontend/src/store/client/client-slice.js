import { createSlice } from "@reduxjs/toolkit";

const clientSlice = createSlice({
  name: "client",
  initialState: {
    clients: [],
    paginationDetails: {},
    searchLetter: "",
    searchName: "",
    firstLettersArray: [],
  },
  reducers: {
    clientsReceived(state, action) {
      const { data, headers } = action.payload;

      state.clients = [];
      for (const key in data) {
        state.clients.push({
          id: data[key].id,
          name: data[key].clientName,
          address: data[key].clientAddress,
          city: data[key].clientCity,
          zipCode: data[key].clientZipCode,
          countryId: data[key].countryId,
        });
      }

      state.paginationDetails = JSON.parse(headers["x-pagination"]);
    },
    searchLetterChanged(state, action) {
      state.searchLetter = action.payload;
    },
    searchNameChanged(state, action) {
      state.searchName = action.payload;
    },
    firstLettersArrayChanged(state, action) {
      const { data } = action.payload;
      state.firstLettersArray = data;
    },
    clientCreated(state, action) {
      const {
        id,
        clientName,
        clientAddress,
        clientCity,
        clientZipCode,
        countryId,
      } = action.payload;

      const newClient = {
        id: id,
        name: clientName,
        address: clientAddress,
        city: clientCity,
        zipCode: clientZipCode,
        countryId: countryId,
      };

      state.clients.push(newClient);
    },
    clientUpdated(state, action) {
      const {
        id,
        clientName,
        clientAddress,
        clientCity,
        clientZipCode,
        country,
      } = action.payload;

      const newClient = {
        id: id,
        name: clientName,
        address: clientAddress,
        city: clientCity,
        zipCode: clientZipCode,
        country: country,
      };

      const existingClient = state.clients.find(
        (item) => item.id === newClient.id
      );

      if (existingClient) {
        const idx = state.clients.indexOf(existingClient);
        state.clients[idx] = newClient;
      }
    },
    clientDeleted(state, action) {
      state.clients = state.clients.filter(
        (item) => item.id !== action.payload
      );
    },
  },
});

export const clientActions = clientSlice.actions;

export default clientSlice;
