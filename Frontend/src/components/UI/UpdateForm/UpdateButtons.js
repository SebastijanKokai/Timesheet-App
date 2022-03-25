const UpdateButtons = ({ onSaveHandler, onDeleteHandler }) => {
  return (
    <div className="buttons">
      <div className="inner">
        <button onClick={onSaveHandler} className="btn green">
          Save
        </button>
        <button onClick={onDeleteHandler} className="btn red">
          Delete
        </button>
      </div>
    </div>
  );
};

export default UpdateButtons;
