import { useDispatch } from "react-redux";
import LetterItem from "./LetterItem";
import LettersFunctions from "./LettersFunctions";

const alpha = Array.from(Array(26)).map((e, i) => i + 65);
const lettersArray = alpha.map((x) => String.fromCharCode(x));

const Letters = ({
  searchName,
  searchLetter,
  getRequest,
  firstLettersArray,
}) => {
  const dispatch = useDispatch();

  const pageNumber = 1;
  const pageSize = 3;

  const letterClickHandler = (letter) => {
    if (LettersFunctions.isLetterDisabled(letter, firstLettersArray)) {
      return;
    }
    dispatch(getRequest(pageNumber, pageSize, letter, searchName));
  };

  const getLetterClassName = (letter) => {
    if (LettersFunctions.isLetterDisabled(letter, firstLettersArray)) {
      return "disabled";
    }

    if (searchLetter === letter) {
      return "active";
    }

    return "";
  };

  return (
    <div className="alpha">
      <ul>
        {lettersArray.map((letter) => (
          <LetterItem
            key={`LetterItem_${letter}`}
            letter={letter}
            getLetterClassName={getLetterClassName}
            letterClickHandler={letterClickHandler}
          />
        ))}
      </ul>
    </div>
  );
};

export default Letters;
