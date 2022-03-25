import PaginationListItem from "./PaginationListItem";

const PaginationFunctions = {
  returnPaginationListItems: (numberOfPages, pageSize, changePageHandler) => {
    const paginationListItems = !isNaN(numberOfPages) ? (
      [...Array(numberOfPages)].map((e, idx) => (
        <PaginationListItem
          key={`PaginationItem_${idx + 1}`}
          pageSize={pageSize}
          pageChange={idx + 1}
          changePageHandler={changePageHandler}
          itemText={idx + 1}
          disabled={false}
        />
      ))
    ) : (
      <li>
        <a href="/">1</a>
      </li>
    );
    return paginationListItems;
  },
};

export default PaginationFunctions;
