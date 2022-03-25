import useClientInput from "../../hooks/use-client-input";

import Modal from "../UI/Modal/Modal";

import InputListItem from "../UI/ListItems/InputListItem";
import SelectItem from "../UI/ListItems/SelectItem";

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
  } = useClientInput({
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
          <InputListItem
            labelName={"Client name:"}
            onChange={clientNameChangeHandler}
            value={clientName}
          />
          <InputListItem
            labelName={"Address:"}
            onChange={addressChangeHandler}
            value={address}
          />
          <InputListItem
            labelName={"City:"}
            onChange={cityChangeHandler}
            value={city}
          />
          <InputListItem
            labelName={"Zip/Postal code:"}
            onChange={zipCodeChangeHandler}
            value={zipCode}
          />
          <SelectItem
            labelName="Country:"
            onChange={countryChangeHandler}
            defaultValue="Default"
            objectArray={props.countries}
          />
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
