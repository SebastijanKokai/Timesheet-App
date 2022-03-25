import { getProjectsRequest } from "../../store/project/project-actions";
import { sharedUiActions } from "../../store/shared-ui-slice";

import ListHeader from "../UI/ListHeader/ListHeader";
import ListHeaderInput from "../UI/ListHeader/ListHeaderInput";
import Letters from "../UI/Letters/Letters";
import Pagination from "../UI/Pagination/Pagination";
import ProjectItem from "./ProjectItem";

import { useSelector, useDispatch } from "react-redux";

const ProjectList = () => {
  const dispatch = useDispatch();

  const projects = useSelector((state) => state.project.projects);
  const paginationDetails = useSelector(
    (state) => state.project.paginationDetails
  );
  const searchLetter = useSelector((state) => state.project.searchLetter);
  const searchName = useSelector((state) => state.project.searchName);
  const firstLettersArray = useSelector(
    (state) => state.project.firstLettersArray
  );

  const showModal = useSelector((state) => state.ui.projectModalIsVisible);

  const toggleProjectFormHandler = () => {
    dispatch(sharedUiActions.toggleProjectModal());
  };

  const searchChangeHandler = (e) => {
    dispatch(
      getProjectsRequest(
        paginationDetails.CurrentPage,
        paginationDetails.PageSize,
        searchLetter,
        e.target.value
      )
    );
  };

  return (
    <div className="wrapper">
      <section className="content">
        <ListHeader pageName={"Projects"} />
        <ListHeaderInput
          toggleFormHandler={toggleProjectFormHandler}
          componentName={"Project"}
          searchChangeHandler={searchChangeHandler}
        />
        <Letters
          searchName={searchName}
          searchLetter={searchLetter}
          getRequest={getProjectsRequest}
          firstLettersArray={firstLettersArray}
        />
        <div className="accordion-wrap clients">
          {projects.map((project) => (
            <ProjectItem key={project.id} project={project} />
          ))}
        </div>
        <Pagination
          paginationDetails={paginationDetails}
          searchLetter={searchLetter}
          searchName={searchName}
          getRequest={getProjectsRequest}
        />
      </section>
    </div>
  );
};

export default ProjectList;
