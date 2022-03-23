import API from "../../API/api";
import { countryActions } from "./country-slice";
import { CountryServices } from "../../services/CountryServices";

export const getCountryData = () => {
  return async (dispatch) => {
    try {
      const response = await CountryServices.getAll();
      dispatch(countryActions.addCountries(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};
