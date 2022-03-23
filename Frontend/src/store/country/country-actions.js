import API from "../../API/api";
import { countryActions } from "./country-slice";

export const getCountryData = () => {
  return async (dispatch) => {
    try {
      const response = await API.get("country");

      console.log(response.data);

      dispatch(countryActions.addCountries(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};
