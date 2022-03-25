import useToggleClass from "../../hooks/use-toggle-class";

const ProjectItem = (props) => {
  const { itemClass, formClass, toggleItemHandler } = useToggleClass();

  return (
    <div className={itemClass}>
      <div className="heading" onClick={toggleItemHandler}>
        <span>{props.project.name}</span>
        <i>+</i>
      </div>
      {/* <ClientUpdateForm
            formClass={formClass}
            client={props.client}
            countries={props.countries}
          /> */}
    </div>
  );
};

export default ProjectItem;
