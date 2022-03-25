const PaginationListItem = ({
  pageSize,
  pageChange,
  changePageHandler,
  itemText,
  disabled,
}) => {
  return (
    <li key={`PaginationItem_${itemText}`}>
      <button
        onClick={() => changePageHandler(pageChange, pageSize)}
        style={{ backgroundColor: "transparent", border: 0 }}
        disabled={disabled}
      >
        <a>{itemText}</a>
      </button>
    </li>
  );
};

export default PaginationListItem;
