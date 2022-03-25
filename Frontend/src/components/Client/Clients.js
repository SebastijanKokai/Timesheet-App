import { getClientsRequest } from "../../store/client/client-actions";
import ClientItem from "./ClientItem";
import ClientAddModal from "./ClientAddModal";
import Letters from "../UI/Letters/Letters";
import Pagination from "../UI/Pagination/Pagination";
import { sharedUiActions } from "../../store/shared-ui-slice";
import { useDispatch, useSelector } from "react-redux";

const Clients = () => {
  const dispatch = useDispatch();
  const clients = useSelector((state) => state.client.clients);
  const countries = useSelector((state) => state.country.countries);
  const searchLetter = useSelector((state) => state.client.searchLetter);
  const searchName = useSelector((state) => state.client.searchName);
  const firstLettersArray = useSelector(
    (state) => state.client.firstLettersArray
  );

  const paginationDetails = useSelector(
    (state) => state.client.paginationDetails
  );

  const showModal = useSelector((state) => state.ui.clientModalIsVisible);

  const toggleClientFormHandler = () => {
    dispatch(sharedUiActions.toggle());
  };

  const searchChangeHandler = (e) => {
    dispatch(
      getClientsRequest(
        paginationDetails.CurrentPage,
        paginationDetails.PageSize,
        searchLetter,
        e.target.value
      )
    );
  };

  return (
    <div className="wrapper">
      <section className="content">
        <h2>
          <i className="ico clients"></i>Clients
        </h2>
        <div className="grey-box-wrap reports">
          <a
            href="#new-member"
            className="link new-member-popup"
            onClick={toggleClientFormHandler}
          >
            Create new client
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
        {showModal && (
          <ClientAddModal
            onClose={toggleClientFormHandler}
            countries={countries}
          />
        )}
        <Letters
          searchName={searchName}
          searchLetter={searchLetter}
          getRequest={getClientsRequest}
          firstLettersArray={firstLettersArray}
        />
        <div className="accordion-wrap clients">
          {clients.map((client) => (
            <ClientItem key={client.id} client={client} countries={countries} />
          ))}
        </div>
        <Pagination
          paginationDetails={paginationDetails}
          searchLetter={searchLetter}
          searchName={searchName}
          getRequest={getClientsRequest}
        />
      </section>
    </div>
  );
};

export default Clients;
