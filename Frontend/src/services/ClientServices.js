import API from "../API/api";

const ClientServices = {
  getAll: async (pageNumber, pageSize, firstLetter, searchName) => {
    const response = await API.get(
      `client?PageNumber=${pageNumber}
      &PageSize=${pageSize}
      &FirstLetter=${firstLetter}
      &Name=${searchName}`
    );

    return response;
  },
  getFirstLettersArray: async () => {
    const response = await API.get("client/firstlettersarray");
    return response;
  },
  create: async (newClient) => {
    const response = await API.post("client", newClient);
    return response;
  },
  update: async (newClient) => {
    const response = await API.put("client", newClient);
    return response;
  },
  delete: async (id) => {
    const response = await API.delete(`client/${id}`);
    return response;
  },
};

export default ClientServices;
