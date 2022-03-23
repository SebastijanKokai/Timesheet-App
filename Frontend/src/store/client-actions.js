import API from "../API/api";
import { clientActions } from "./client-slice";

export const getClientData = () => {
  return async (dispatch) => {
    try {
      const response = await API.get("client");

      console.log(response.data);

      dispatch(clientActions.addClients(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const postClientData = (newClient) => {
  return async (dispatch) => {
    try {
      const response = await API.post("client", newClient);
      console.log(response.data);
      dispatch(clientActions.addClient(response.data)); // client added
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const putClientData = (newClient) => {
  return async (dispatch) => {
    try {
      const response = await API.put("client", newClient);
      console.log(response.data);
      dispatch(clientActions.updateClient(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};

export const deleteClientData = (id) => {
  return async (dispatch) => {
    try {
      const response = await API.delete(`client/${id}`);
      console.log(response.data);
      dispatch(clientActions.removeClient(id));
    } catch (error) {
      console.log(error.message);
    }
  };
};
