import { useState } from "react";

const ListItem = ({ name, UpdateForm, componentObject, countries }) => {
  const [itemClass, setItemClass] = useState("item");
  const [formClass, setFormClass] = useState("none");

  const toggleItemHandler = () => {
    if (itemClass === "item") {
      setItemClass("item open");
      setFormClass("block");
    } else {
      setItemClass("item");
      setFormClass("none");
    }
  };

  return (
    <div className={itemClass}>
      <div className="heading" onClick={toggleItemHandler}>
        <span>{name}</span>
        <i>+</i>
      </div>
      <UpdateForm
        formClass={formClass}
        componentObject={componentObject}
        countries={countries}
      />
    </div>
  );
};

export default ListItem;
