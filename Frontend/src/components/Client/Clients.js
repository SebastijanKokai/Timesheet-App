import ClientItem from "./ClientItem";
import ClientAddModal from "./ClientAddModal";
import Letters from "../UI/Letters";
import Pagination from "../UI/Pagination";
import { uiActions } from "../../store/ui-slice";
import { useDispatch, useSelector } from "react-redux";

const Clients = () => {
  const dispatch = useDispatch();
  const clients = useSelector((state) => state.client.clients);
  const countries = useSelector((state) => state.country.countries);

  const toggleClientFormHandler = () => {
    dispatch(uiActions.toggle());
  };

  const showModal = useSelector((state) => state.ui.clientModalIsVisible);

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
            <input type="search" name="search-clients" className="in-search" />
          </div>
        </div>
        {showModal && (
          <ClientAddModal
            onClose={toggleClientFormHandler}
            countries={countries}
          />
        )}
        <Letters />
        <div className="accordion-wrap clients">
          {clients.map((client) => (
            <ClientItem key={client.id} client={client} countries={countries} />
          ))}
        </div>
        <Pagination />
      </section>
    </div>
  );
};

export default Clients;
