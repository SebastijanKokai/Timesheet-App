import { useDispatch } from "react-redux";
import {
  getClientsRequest,
  getFirstLettersArray,
} from "./store/client/client-actions";
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
  const clientInitialName = "";

  // Sequence of fetching data is important!
  dispatch(getCountriesRequest());
  dispatch(
    getClientsRequest(
      clientInitialPageNumber,
      clientInitialPageSize,
      clientInitialLetter,
      clientInitialName
    )
  );
  dispatch(getFirstLettersArray());

  return (
    <div className="container">
      <Nav />
      <Clients />
      <Footer />
    </div>
  );
}

export default App;
