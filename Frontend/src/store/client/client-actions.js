import { clientActions } from "./client-slice";
import ClientServices from "../../services/ClientServices";

export const getClientsRequest = (
  pageNumber,
  pageSize,
  firstLetter,
  searchName
) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.getAll(
        pageNumber,
        pageSize,
        firstLetter,
        searchName
      );
      dispatch(clientActions.clientsReceived(response));
      dispatch(clientActions.searchLetterChanged(firstLetter));
      dispatch(clientActions.searchNameChanged(searchName));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const postClientRequest = (newClient) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.create(newClient);
      dispatch(clientActions.clientCreated(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const putClientRequest = (newClient) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.update(newClient);
      dispatch(clientActions.clientUpdated(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const deleteClientRequest = (id) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.delete(id);
      dispatch(clientActions.clientDeleted(id));
    } catch (error) {
      console.log(error.message);
    }
  };
};
