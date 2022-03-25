import { useState } from "react";

const useToggleClass = () => {
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

  return { itemClass, formClass, toggleItemHandler };
};

export default useToggleClass;
