import { countryActions } from "./country-slice";
import { CountryServices } from "../../services/CountryServices";

export const getCountriesRequest = () => {
  return async (dispatch) => {
    try {
      const response = await CountryServices.getAll();
      dispatch(countryActions.countriesReceived(response.data));
    } catch (error) {
      console.log(error.message);
    }
  };
};
