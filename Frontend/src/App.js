import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getClientsRequest } from "./store/client/client-actions";
import { getCountryData } from "./store/country/country-actions";

import "./App.css";
import "./assets/css/style.css";
import Nav from "./components/Nav";
import Footer from "./components/Footer";
import Clients from "./components/Client/Clients";

function App() {
  const dispatch = useDispatch();
  dispatch(getClientsRequest());
  dispatch(getCountryData());

  // useEffect(() => {

  // }, [dispatch]);

  return (
    <div className="container">
      <Nav />
      <Clients />
      <Footer />
    </div>
  );
}

export default App;
