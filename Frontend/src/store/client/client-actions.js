import { clientActions } from "./client-slice";
import ClientServices from "../../services/ClientServices";

export const getClientData = () => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.getAll();
      dispatch(clientActions.addClients(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const postClientData = (newClient) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.create(newClient);
      dispatch(clientActions.addClient(response.data)); // client added
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const putClientData = (newClient) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.update(newClient);
      dispatch(clientActions.updateClient(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const deleteClientData = (id) => {
  return async (dispatch) => {
    try {
      const response = await ClientServices.delete(id);
      dispatch(clientActions.removeClient(id));
    } catch (error) {
      console.log(error.message);
    }
  };
};
