import { useDispatch } from "react-redux";
import {
  getClientsRequest,
  getFirstLettersArray,
} from "./store/client/client-actions";
import { getCountriesRequest } from "./store/country/country-actions";

import "./App.css";
import "./assets/css/style.css";
import PageHeader from "./components/PageHeader/PageHeader";
import Footer from "./components/Footer";
import ClientList from "./components/Client/ClientList";
import ProjectList from "./components/Project/ProjectList";
import MainContainer from "./components/UI/Containers/MainContainer";

import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";

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
    <Router>
      <MainContainer>
        <PageHeader />
        <Routes>
          <Route exact path="/" element={<ClientList />}></Route>
          <Route exact path="/clients" element={<ClientList />}></Route>
          <Route exact path="/projects" element={<ProjectList />}></Route>
        </Routes>
        <Footer />
      </MainContainer>
    </Router>
  );
}

export default App;
