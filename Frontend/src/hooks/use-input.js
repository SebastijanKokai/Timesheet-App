import { useState } from "react";

const useInput = (client) => {
  const [clientName, setClientName] = useState(client.name);
  const [address, setAddress] = useState(client.address);
  const [city, setCity] = useState(client.city);
  const [zipCode, setZipCode] = useState(client.zipCode);
  const [country, setCountry] = useState(client.country);

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
    setCountry(e.target.value);
  };

  const resetValues = () => {
    setClientName("");
    setAddress("");
    setCity("");
    setZipCode("");
    setCountry("");
  };

  return {
    clientName,
    address,
    city,
    zipCode,
    country,
    clientNameChangeHandler,
    addressChangeHandler,
    cityChangeHandler,
    zipCodeChangeHandler,
    countryChangeHandler,
    resetValues,
  };
};

export default useInput;
