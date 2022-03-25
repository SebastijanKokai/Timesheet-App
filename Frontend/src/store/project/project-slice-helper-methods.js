export const extractNewProjectProperties = (actionPayload) => {
  const newProject = {
    id: actionPayload.id,
    clientId: actionPayload.clientId,
    name: actionPayload.projectName,
    description: actionPayload.projectDescription,
    status: actionPayload.projectStatus,
  };
  return newProject;
};
