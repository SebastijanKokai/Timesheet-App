import API from "../API/api";

export const CountryServices = {
  getAll: async () => {
    const response = await API.get("country");
    return response;
  },
};
