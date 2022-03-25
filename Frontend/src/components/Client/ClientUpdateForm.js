import useInput from "../../hooks/use-input";
import { useDispatch } from "react-redux";
import {
  deleteClientRequest,
  putClientRequest,
  getFirstLettersArray,
} from "../../store/client/client-actions";

import InputListItem from "../UI/UpdateForm/InputListItem";
import SelectItem from "../UI/UpdateForm/SelectItem";
import UpdateButtons from "../UI/UpdateForm/UpdateButtons";

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
        <InputListItem
          labelName={"Client name:"}
          onChange={clientNameChangeHandler}
          defaultValue={props.client.name}
        />
        <InputListItem
          labelName={"Zip/Postal code:"}
          onChange={zipCodeChangeHandler}
          defaultValue={props.client.zipCode}
        />
      </ul>
      <ul className="form">
        <InputListItem
          labelName={"Address:"}
          onChange={addressChangeHandler}
          defaultValue={props.client.address}
        />
        <SelectItem
          labelName={"Country:"}
          defaultValue={props.client.countryId}
          onChange={countryChangeHandler}
          objectArray={props.countries}
        />
      </ul>
      <ul className="form last">
        <InputListItem
          labelName={"City:"}
          onChange={cityChangeHandler}
          defaultValue={props.client.city}
        />
      </ul>
      <UpdateButtons
        onSaveHandler={onSaveHandler}
        onDeleteHandler={onDeleteHandler}
      />
    </div>
  );
};

export default ClientUpdateForm;
