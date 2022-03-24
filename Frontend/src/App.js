import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getClientsRequest } from "./store/client/client-actions";
import { getCountriesRequest } from "./store/country/country-actions";

import "./App.css";
import "./assets/css/style.css";
import Nav from "./components/Nav";
import Footer from "./components/Footer";
import Clients from "./components/Client/Clients";

function App() {
  const dispatch = useDispatch();
  const clientPageNumber = 1;
  const clientPageSize = 3;
  // Sequence of fetching data is important!
  dispatch(getCountriesRequest());
  dispatch(getClientsRequest(clientPageNumber, clientPageSize));

  return (
    <div className="container">
      <Nav />
      <Clients />
      <Footer />
    </div>
  );
}

export default App;
