import ClientUpdateForm from "./ClientUpdateForm";
import useToggleClass from "../../hooks/use-toggle-class";

const ClientItem = (props) => {
  const { itemClass, formClass, toggleItemHandler } = useToggleClass();

  return (
    <div className={itemClass}>
      <div className="heading" onClick={toggleItemHandler}>
        <span>{props.client.name}</span>
        <i>+</i>
      </div>
      <ClientUpdateForm
        formClass={formClass}
        client={props.client}
        countries={props.countries}
      />
    </div>
  );
};

export default ClientItem;
