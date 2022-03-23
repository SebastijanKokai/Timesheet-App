import React, { useState } from "react";

import ClientUpdateForm from "./ClientUpdateForm";

const ClientItem = (props) => {
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
