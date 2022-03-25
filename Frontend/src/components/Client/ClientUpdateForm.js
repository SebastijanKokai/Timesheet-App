import useInput from "../../hooks/use-input";
import { useDispatch } from "react-redux";
import {
  deleteClientRequest,
  putClientRequest,
  getFirstLettersArray,
} from "../../store/client/client-actions";

const ClientUpdateForm = (props) => {
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
  } = useInput(props.client);

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
      Id: props.client.id,
      CountryId: countryId,
      Name: clientName,
      Address: address,
      City: city,
      ZipCode: zipCode,
    };

    dispatch(putClientRequest(newClient));
    dispatch(getFirstLettersArray());
  };

  const onDeleteHandler = async () => {
    dispatch(deleteClientRequest(props.client.id));
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
            defaultValue={props.client.countryId}
            onChange={countryChangeHandler}
          >
            {props.countries.map((country) => (
              <option key={country.id} value={country.id}>
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
