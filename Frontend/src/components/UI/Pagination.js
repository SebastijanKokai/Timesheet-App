import { useDispatch, useSelector } from "react-redux";

const Pagination = (props) => {
  const dispatch = useDispatch();

  const searchLetter = props.searchLetter;

  const { TotalCount, PageSize, CurrentPage, HasNext, HasPrevious } =
    props.paginationDetails;

  const getRequest = props.getRequest;

  const changePageHandler = (pageNumber, pageSize) => {
    dispatch(getRequest(pageNumber, pageSize, searchLetter));
  };

  const numberOfPages = Math.ceil(TotalCount / PageSize);

  let prevButtonClass = HasPrevious ? "last" : "";
  let nextButtonClass = HasNext ? "last" : "";
  return (
    <div className="pagination">
      <ul>
        <li className={prevButtonClass}>
          <button
            disabled={!HasPrevious}
            onClick={() => changePageHandler(CurrentPage - 1, PageSize)}
            style={{ backgroundColor: "transparent", border: 0 }}
          >
            <a>Previous</a>
          </button>
        </li>
        {!isNaN(numberOfPages) ? (
          [...Array(numberOfPages)].map((e, idx) => (
            <li key={idx}>
              <button
                onClick={() => changePageHandler(idx + 1, PageSize)}
                style={{ backgroundColor: "transparent", border: 0 }}
              >
                <a>{idx + 1}</a>
              </button>
            </li>
          ))
        ) : (
          <li>
            <a href="/">1</a>
          </li>
        )}
        <li className={nextButtonClass}>
          <button
            disabled={!HasNext}
            onClick={() => changePageHandler(CurrentPage + 1, PageSize)}
            style={{ backgroundColor: "transparent", border: 0 }}
          >
            <a>Next</a>
          </button>
        </li>
      </ul>
    </div>
  );
};

export default Pagination;
