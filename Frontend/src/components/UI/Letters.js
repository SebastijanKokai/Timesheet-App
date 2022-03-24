import { useDispatch, useSelector } from "react-redux";

const DUMMY_CLIENTS = [
  {
    letter: "B",
    count: 0,
  },
  {
    letter: "C",
    count: 2,
  },
  {
    letter: "D",
    count: 3,
  },
  {
    letter: "E",
    count: 0,
  },
  {
    letter: "F",
    count: 4,
  },
];

// const mappedData = DUMMY_CLIENTS.reduce((prevValue, currentValue) => {});

const isLetterDisabled = (letter) => {
  const foundLetter = DUMMY_CLIENTS.find(
    (dummyClient) => dummyClient.letter === letter
  );

  if (!foundLetter) {
    return false;
  }

  return foundLetter.count === 0;
};

const alpha = Array.from(Array(26)).map((e, i) => i + 65);
const lettersArray = alpha.map((x) => String.fromCharCode(x));

const Letters = ({ getRequest, searchName }) => {
  const dispatch = useDispatch();
  const selectedLetter = useSelector((state) => state.client.searchLetter);
  const pageNumber = 1;
  const pageSize = 3;

  const letterClickHandler = (letter) => {
    dispatch(getRequest(pageNumber, pageSize, letter, searchName));
  };

  const getLetterClassName = (letter) => {
    if (selectedLetter === letter) {
      return "active";
    }

    if (isLetterDisabled(letter)) {
      return "disabled";
    }

    return "";
  };

  return (
    <div className="alpha">
      <ul>
        {lettersArray.map((letter) => (
          <li
            key={`Letter_${letter}`}
            className={getLetterClassName(letter)}
            onClick={() => letterClickHandler(letter)}
          >
            <a>{letter}</a>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Letters;
