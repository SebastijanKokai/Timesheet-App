import { useState } from "react";

const useClientInput = (client) => {
  const [clientName, setClientName] = useState(client.name);
  const [address, setAddress] = useState(client.address);
  const [city, setCity] = useState(client.city);
  const [zipCode, setZipCode] = useState(client.zipCode);
  const [countryId, setCountryId] = useState(client.countryId);

  const clientNameChangeHandler = (e) => {
    setClientName(e.target.value);
  };

  const addressChangeHandler = (e) => {
    setAddress(e.target.value);
  };

  const cityChangeHandler = (e) => {
    setCity(e.target.value);
  };

  const zipCodeChangeHandler = (e) => {
    setZipCode(e.target.value);
  };

  const countryChangeHandler = (e) => {
    setCountryId(e.target.value);
  };

  const resetValues = () => {
    setClientName("");
    setAddress("");
    setCity("");
    setZipCode("");
    setCountryId("");
  };

  return {
    clientName,
    address,
    city,
    zipCode,
    countryId,
    clientNameChangeHandler,
    addressChangeHandler,
    cityChangeHandler,
    zipCodeChangeHandler,
    countryChangeHandler,
    resetValues,
  };
};

export default useClientInput;
