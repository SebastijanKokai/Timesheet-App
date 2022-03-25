const ListHeaderInput = ({
  toggleFormHandler,
  componentName,
  searchChangeHandler,
}) => {
  return (
    <div className="grey-box-wrap reports">
      <a
        href="#new-member"
        className="link new-member-popup"
        onClick={toggleFormHandler}
      >
        Create new {componentName}
      </a>
      <div className="search-page">
        <input
          type="search"
          name="search-clients"
          className="in-search"
          onChange={searchChangeHandler}
        />
      </div>
    </div>
  );
};

export default ListHeaderInput;
