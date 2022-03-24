import { createSlice } from "@reduxjs/toolkit";

const clientSlice = createSlice({
  name: "client",
  initialState: {
    clients: [],
    error: null,
  },
  reducers: {
    clientsReceived(state, action) {
      const data = action.payload;

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
