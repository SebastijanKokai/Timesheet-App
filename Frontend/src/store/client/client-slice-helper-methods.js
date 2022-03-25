export const extractNewClientProperties = (actionPayload) => {
  const newClient = {
    id: actionPayload.id,
    name: actionPayload.clientName,
    address: actionPayload.clientAddress,
    city: actionPayload.clientCity,
    zipCode: actionPayload.clientZipCode,
    countryId: actionPayload.countryId,
  };
  return newClient;
};
