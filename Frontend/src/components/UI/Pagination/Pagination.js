import { useDispatch } from "react-redux";
import PaginationListItem from "./PaginationListItem";
import PaginationFunctions from "./PaginationFunctions";

const Pagination = ({
  paginationDetails: {
    TotalCount,
    PageSize,
    CurrentPage,
    HasNext,
    HasPrevious,
  },
  searchLetter,
  searchName,
  getRequest,
}) => {
  const dispatch = useDispatch();

  const changePageHandler = (pageNumber, pageSize) => {
    dispatch(getRequest(pageNumber, pageSize, searchLetter, searchName));
  };

  const numberOfPages = Math.ceil(TotalCount / PageSize);

  const paginationListItems = PaginationFunctions.returnPaginationListItems(
    numberOfPages,
    PageSize,
    changePageHandler
  );

  return (
    <div className="pagination">
      <ul>
        <PaginationListItem
          key={`PaginationItem_Previous`}
          pageSize={PageSize}
          pageChange={CurrentPage - 1}
          changePageHandler={changePageHandler}
          itemText={"Previous"}
          disabled={!HasPrevious}
        />
        {paginationListItems}
        <PaginationListItem
          key={`PaginationItem_Next`}
          pageSize={PageSize}
          pageChange={CurrentPage + 1}
          changePageHandler={changePageHandler}
          itemText={"Next"}
          disabled={!HasNext}
        />
      </ul>
    </div>
  );
};

export default Pagination;
