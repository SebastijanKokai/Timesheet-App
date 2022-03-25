import Modal from "../UI/Modal/Modal";
import InputListItem from "../UI/ListItems/InputListItem";
import SelectItem from "../UI/ListItems/SelectItem";
import useProjectInput from "../../hooks/use-project-input";
import { useDispatch } from "react-redux";
import { postProjectRequest } from "../../store/project/project-actions";

const ProjectAddModal = ({ onClose, clients }) => {
  const dispatch = useDispatch();

  const {
    clientId,
    projectName,
    description,
    status,
    clientChangeHandler,
    projectNameChangeHandler,
    descriptionChangeHandler,
    statusChangeHandler,
    resetValues,
  } = useProjectInput({
    clientId: "",
    name: "",
    description: "",
    status: "",
  });

  const onSaveHandler = () => {
    if (clientId === "" || projectName === "" || description === "") {
      return;
    }

    const newProject = {
      ClientID: clientId,
      ProjectName: projectName,
      ProjectDescription: description,
      ProjectStatus: "Active",
    };

    console.log(newProject);

    dispatch(postProjectRequest(newProject));
  };

  return (
    <Modal onClose={onClose}>
      <div id="new-member" className="new-member-inner">
        <h2>Create new project</h2>
        <ul className="form">
          <InputListItem
            labelName={"Project name:"}
            onChange={projectNameChangeHandler}
            value={projectName}
          />
          <InputListItem
            labelName={"Description:"}
            onChange={descriptionChangeHandler}
            value={description}
          />
          <SelectItem
            labelName="Customer:"
            onChange={clientChangeHandler}
            defaultValue="Default"
            objectArray={clients}
          />
        </ul>
        <div className="buttons">
          <div className="inner">
            <button onClick={onSaveHandler} className="btn green">
              Save
            </button>
          </div>
        </div>
      </div>
    </Modal>
  );
};

export default ProjectAddModal;
