const SelectItem = ({ labelName, defaultValue, onChange, objectArray }) => {
  return (
    <li>
      <label>{labelName}</label>
      <select defaultValue={defaultValue} onChange={onChange}>
        {objectArray.map((obj) => (
          <option key={obj.id} value={obj.id}>
            {obj.name}
          </option>
        ))}
      </select>
    </li>
  );
};

export default SelectItem;
