import { createSlice } from "@reduxjs/toolkit";

const projectSlice = createSlice({
  name: "project",
  initialState: {
    projects: [],
    paginationDetails: {},
    searchLetter: "",
    searchName: "",
    firstLettersArray: [],
  },
  reducers: {
    projectsReceived(state, action) {
      const { data, headers } = action.payload;

      state.projects = [];
      for (const key in data) {
        const newProject = {};
        state.projects.push(newProject);
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
    projectCreated(state, action) {
      const newProject = {};

      if (newProject.name === "") {
        return;
      }

      const firstLetter = newProject.name.charAt(0);

      if (!state.firstLettersArray.find((letter) => letter === firstLetter)) {
        state.firstLettersArray.push(firstLetter);
      }

      if (state.searchLetter === firstLetter) {
        // const newClientsState = pushAndSortItems(state.clients, newClient);
        // state.clients = newClientsState;
      }
    },
    projectUpdated(state, action) {
      const newProject = {};

      const existingProject = state.projects.find(
        (item) => item.id === newProject.id
      );

      if (existingProject) {
        const idx = state.projects.indexOf(existingProject);
        state.projects[idx] = newProject;
      }
    },
    clientDeleted(state, action) {
      state.projects = state.projects.filter(
        (item) => item.id !== action.payload
      );
    },
  },
});

export const projectActions = projectSlice.actions;

export default projectSlice;
