import { projectActions } from "./project-slice";
import ProjectServices from "../../services/ProjectServices";

export const getProjectsRequest = (
  pageNumber,
  pageSize,
  firstLetter,
  searchName
) => {
  return async (dispatch) => {
    try {
      const response = await ProjectServices.getAll(
        pageNumber,
        pageSize,
        firstLetter,
        searchName
      );
      dispatch(projectActions.projectsReceived(response));
      dispatch(projectActions.searchLetterChanged(firstLetter));
      dispatch(projectActions.searchNameChanged(searchName));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const getFirstLettersArray = () => {
  return async (dispatch) => {
    try {
      const response = await ProjectServices.getFirstLettersArray();
      dispatch(projectActions.firstLettersArrayChanged(response));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const postProjectRequest = (newProject) => {
  return async (dispatch) => {
    try {
      const response = await ProjectServices.create(newProject);
      console.log(response);
      dispatch(projectActions.projectCreated(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const putProjectRequest = (newProject) => {
  return async (dispatch) => {
    try {
      const response = await ProjectServices.update(newProject);
      dispatch(projectActions.projectUpdated(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const deleteProjectRequest = (id) => {
  return async (dispatch) => {
    try {
      const response = await ProjectServices.delete(id);
      dispatch(projectActions.projectDeleted(id));
    } catch (error) {
      console.log(error.message);
    }
  };
};
