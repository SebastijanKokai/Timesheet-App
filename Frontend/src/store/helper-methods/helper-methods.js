export const sortClientsByName = (a, b) => {
  if (a.name < b.name) {
    return -1;
  }
  if (a.name > b.name) {
    return 1;
  }
  return 0;
};

export const pushAndSortItems = (arrayState, newObject) => {
  const copyClients = [...arrayState];
  copyClients.push(newObject);
  copyClients.sort((a, b) => sortClientsByName(a, b));

  if (copyClients.length > 3) {
    copyClients.pop();
  }
  return copyClients;
};
