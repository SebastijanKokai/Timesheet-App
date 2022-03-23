import useInput from "../../hooks/use-input";
import { useDispatch } from "react-redux";
import {
  deleteClientData,
  putClientData,
} from "../../store/client/client-actions";

const ClientUpdateForm = (props) => {
  const dispatch = useDispatch();

  const {
    clientName,
    address,
    city,
    zipCode,
    country,
    clientNameChangeHandler,
    addressChangeHandler,
    cityChangeHandler,
    zipCodeChangeHandler,
    countryChangeHandler,
  } = useInput(props.client);

  const onSaveHandler = async () => {
    if (
      country === "" ||
      clientName === "" ||
      address === "" ||
      city === "" ||
      zipCode === ""
    ) {
      return;
    }

    const newClient = {
      Id: props.client.id,
      Country: country,
      Name: clientName,
      Address: address,
      City: city,
      ZipCode: zipCode,
    };

    dispatch(putClientData(newClient));
  };

  const onDeleteHandler = async () => {
    dispatch(deleteClientData(props.client.id));
  };

  return (
    <div className="details" style={{ display: props.formClass }}>
      <ul className="form">
        <li>
          <label>Client name:</label>
          <input
            type="text"
            className="in-text"
            onChange={clientNameChangeHandler}
            defaultValue={props.client.name}
          />
        </li>
        <li>
          <label>Zip/Postal code:</label>
          <input
            type="text"
            className="in-text"
            onChange={zipCodeChangeHandler}
            defaultValue={props.client.zipCode}
          />
        </li>
      </ul>
      <ul className="form">
        <li>
          <label>Address:</label>
          <input
            type="text"
            className="in-text"
            onChange={addressChangeHandler}
            defaultValue={props.client.address}
          />
        </li>
        <li>
          <label>Country:</label>
          <select
            defaultValue={props.client.country}
            onChange={countryChangeHandler}
          >
            {props.countries.map((country) => (
              <option key={country.id} value={country.name}>
                {country.name}
              </option>
            ))}
          </select>
        </li>
      </ul>
      <ul className="form last">
        <li>
          <label>City:</label>
          <input
            type="text"
            className="in-text"
            onChange={cityChangeHandler}
            defaultValue={props.client.city}
          />
        </li>
      </ul>
      <div className="buttons">
        <div className="inner">
          <button onClick={onSaveHandler} className="btn green">
            Save
          </button>
          <button onClick={onDeleteHandler} className="btn red">
            Delete
          </button>
        </div>
      </div>
    </div>
  );
};

export default ClientUpdateForm;
