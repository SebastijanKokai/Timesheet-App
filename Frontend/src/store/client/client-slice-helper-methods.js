export const sortClientsByName = (a, b) => {
  if (a.name < b.name) {
    return -1;
  }
  if (a.name > b.name) {
    return 1;
  }
  return 0;
};

export const pushAndSortItems = (clientsState, newClient) => {
  const copyClients = [...clientsState];
  copyClients.push(newClient);
  copyClients.sort((a, b) => sortClientsByName(a, b));

  if (copyClients.length > 3) {
    copyClients.pop();
  }
  return copyClients;
};

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
