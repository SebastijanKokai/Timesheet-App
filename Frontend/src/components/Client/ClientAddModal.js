import useInput from "../../hooks/use-input";

import Modal from "../UI/Modal/Modal";

import { useDispatch } from "react-redux";
import {
  postClientRequest,
  getFirstLettersArray,
} from "../../store/client/client-actions";

const ClientAddModal = (props) => {
  const dispatch = useDispatch();

  const {
    clientName,
    address,
    city,
    zipCode,
    countryId,
    clientNameChangeHandler,
    addressChangeHandler,
    cityChangeHandler,
    zipCodeChangeHandler,
    countryChangeHandler,
    resetValues,
  } = useInput({
    countryId: "",
    name: "",
    address: "",
    city: "",
    zipCode: "",
  });

  const onSaveHandler = async () => {
    if (
      countryId === "" ||
      clientName === "" ||
      address === "" ||
      city === "" ||
      zipCode === ""
    ) {
      return;
    }

    const newClient = {
      CountryId: countryId,
      Name: clientName,
      Address: address,
      City: city,
      ZipCode: zipCode,
    };

    dispatch(postClientRequest(newClient));
    dispatch(getFirstLettersArray());
    resetValues();
  };

  return (
    <Modal onClose={props.onClose}>
      <div id="new-member" className="new-member-inner">
        <h2>Create new client</h2>
        <ul className="form">
          <li>
            <label>Client name:</label>
            <input
              type="text"
              className="in-text"
              onChange={clientNameChangeHandler}
              value={clientName}
            />
          </li>
          <li>
            <label>Address:</label>
            <input
              type="text"
              className="in-text"
              onChange={addressChangeHandler}
              value={address}
            />
          </li>
          <li>
            <label>City:</label>
            <input
              type="text"
              className="in-text"
              onChange={cityChangeHandler}
              value={city}
            />
          </li>
          <li>
            <label>Zip/Postal code:</label>
            <input
              type="text"
              className="in-text"
              onChange={zipCodeChangeHandler}
              value={zipCode}
            />
          </li>
          <li>
            <label>Country:</label>
            <select onChange={countryChangeHandler} defaultValue="Default">
              <option value="Default" disabled hidden>
                Select country
              </option>
              {props.countries.map((country) => (
                <option key={country.id} value={country.id}>
                  {country.name}
                </option>
              ))}
            </select>
          </li>
        </ul>
        <div className="buttons">
          <div className="inner">
            <button onClick={onSaveHandler} className="btn green">
              Save
            </button>
          </div>
        </div>
      </div>
    </Modal>
  );
};

export default ClientAddModal;
