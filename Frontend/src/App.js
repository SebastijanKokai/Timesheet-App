import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getClientData } from "./store/client-actions";
import { getCountryData } from "./store/country/country-actions";

import "./App.css";
import "./assets/css/style.css";
import Nav from "./components/Nav";
import Footer from "./components/Footer";
import Clients from "./components/Client/Clients";

function App() {
  const dispatch = useDispatch();
  // const clients = useSelector((state) => state.client.clients);
  // console.log(clients);
  dispatch(getClientData());
  dispatch(getCountryData());

  return (
    <div className="container">
      <Nav />
      <Clients />
      <Footer />
    </div>
  );
}

export default App;
