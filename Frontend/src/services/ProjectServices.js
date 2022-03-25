import API from "../API/api";

const ProjectServices = {
  getAll: async (pageNumber, pageSize, firstLetter, searchName) => {
    const response = await API.get(
      `project?PageNumber=${pageNumber}
      &PageSize=${pageSize}
      &FirstLetter=${firstLetter}
      &Name=${searchName}`
    );

    return response;
  },
  getFirstLettersArray: async () => {
    const response = await API.get("project/firstlettersarray");
    return response;
  },
  create: async (newProject) => {
    const response = await API.post("project", newProject);
    return response;
  },
  update: async (newProject) => {
    const response = await API.put("project", newProject);
    return response;
  },
  delete: async (id) => {
    const response = await API.delete(`project/${id}`);
    return response;
  },
};

export default ProjectServices;
