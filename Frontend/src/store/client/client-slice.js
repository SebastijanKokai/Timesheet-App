import API from "../../API/api";

import { createSlice } from "@reduxjs/toolkit";

const clientSlice = createSlice({
  name: "client",
  initialState: {
    clients: [],
    error: null,
  },
  reducers: {
    addClients(state, action) {
      const data = action.payload;

      for (const key in data) {
        state.clients.push({
          id: data[key].id,
          name: data[key].clientName,
          address: data[key].clientAddress,
          city: data[key].clientCity,
          zipCode: data[key].clientZipCode,
          country: data[key].country.countryName,
        });
      }
    },
    addClient(state, action) {
      const newClient = action.payload;
      console.log(newClient);
      state.clients.push(newClient);
    },
    updateClient(state, action) {
      const client = action.payload;

      const existingClient = state.clients.find(
        (item) => item.id === client.id
      );

      if (existingClient) {
        const idx = state.clients.indexOf(existingClient);
        state.clients[idx] = client;
      }
    },
    removeClient(state, action) {
      const id = action.payload;
      const existingClient = state.clients.find((item) => item.id === id);

      if (existingClient) {
        state.clients = state.clients.filter((item) => item.id !== id);
      }
    },
  },
});

export const clientActions = clientSlice.actions;

export const allClients = (state) => state.client.clients;

export default clientSlice;
