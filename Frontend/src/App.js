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
  const clientInitialPageNumber = 1;
  const clientInitialPageSize = 3;
  const clientInitialLetter = "C";

  // Sequence of fetching data is important!
  dispatch(getCountriesRequest());
  dispatch(
    getClientsRequest(
      clientInitialPageNumber,
      clientInitialPageSize,
      clientInitialLetter
    )
  );

  return (
    <div className="container">
      <Nav />
      <Clients />
      <Footer />
    </div>
  );
}

export default App;
