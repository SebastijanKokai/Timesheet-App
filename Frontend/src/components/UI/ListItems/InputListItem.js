const InputListItem = ({ labelName, onChange, defaultValue, value }) => {
  return (
    <li>
      <label>{labelName}</label>
      <input
        type="text"
        className="in-text"
        onChange={onChange}
        value={value}
        defaultValue={defaultValue}
      />
    </li>
  );
};

export default InputListItem;
