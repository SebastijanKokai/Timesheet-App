import { useState } from "react";

const useProjectInput = (project) => {
  const [clientId, setClientId] = useState(project.clientId);
  const [projectName, setProjectName] = useState(project.name);
  const [description, setDescription] = useState(project.description);
  const [status, setStatus] = useState(project.status);

  const clientChangeHandler = (e) => {
    setClientId(e.target.value);
  };

  const projectNameChangeHandler = (e) => {
    setProjectName(e.target.value);
  };

  const descriptionChangeHandler = (e) => {
    setDescription(e.target.value);
  };

  const statusChangeHandler = (e) => {
    setStatus(e.target.value);
  };

  const resetValues = () => {
    setClientId("");
    setProjectName("");
    setDescription("");
    setStatus("");
  };

  return {
    clientId,
    projectName,
    description,
    status,
    clientChangeHandler,
    projectNameChangeHandler,
    descriptionChangeHandler,
    statusChangeHandler,
    resetValues,
  };
};

export default useProjectInput;
