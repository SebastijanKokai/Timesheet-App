import { createSlice } from "@reduxjs/toolkit";
import { extractNewClientProperties } from "./client-slice-helper-methods";
import { pushAndSortItems } from "../helper-methods/helper-methods";

const clientSlice = createSlice({
  name: "client",
  initialState: {
    clients: [],
    allClients: [],
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
        const newClient = extractNewClientProperties(data[key]);
        state.clients.push(newClient);
      }

      state.paginationDetails = JSON.parse(headers["x-pagination"]);
    },
    allClientsReceived(state, action) {
      const { data } = action.payload;
      state.allClients = [];
      for (const key in data) {
        const newClient = extractNewClientProperties(data[key]);
        state.allClients.push(newClient);
      }
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
      const newClient = extractNewClientProperties(action.payload);

      if (newClient.name === "") {
        return;
      }

      const firstLetter = newClient.name.charAt(0);

      if (!state.firstLettersArray.find((letter) => letter === firstLetter)) {
        state.firstLettersArray.push(firstLetter);
      }

      if (state.searchLetter === firstLetter) {
        const newClientsState = pushAndSortItems(state.clients, newClient);
        state.clients = newClientsState;
      }
    },
    clientUpdated(state, action) {
      const newClient = extractNewClientProperties(action.payload);

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
