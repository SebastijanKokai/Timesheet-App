const InputListItem = ({ labelName, onChange, defaultValue }) => {
  return (
    <li>
      <label>{labelName}</label>
      <input
        type="text"
        className="in-text"
        onChange={onChange}
        defaultValue={defaultValue}
      />
    </li>
  );
};

export default InputListItem;
