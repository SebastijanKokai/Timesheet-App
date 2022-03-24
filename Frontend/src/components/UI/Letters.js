import { useState, useEffect } from "react";
import { useDispatch } from "react-redux";

const Letters = (props) => {
  const [arrayOfItems, setArrayOfItems] = useState([]);
  const dispatch = useDispatch();
  const pageNumber = 1;
  const pageSize = 3;

  const getRequest = props.getRequest;

  const letterClickHandler = (letter, key) => {
    dispatch(getRequest(pageNumber, pageSize, letter));
  };

  const letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

  useEffect(() => {
    const allItemLetters = [];

    for (const key in letters) {
      // Initial first letter, so classname = active
      if (letters[key] === "C") {
        allItemLetters.push(
          <li className="active">
            <a onClick={() => letterClickHandler(letters[key])}>
              {letters[key]}
            </a>
          </li>
        );
        continue;
      }

      // Last letter so classname = last
      if (letters[key] === "Z") {
        allItemLetters.push(
          <li className="last">
            <a onClick={() => letterClickHandler(letters[key])}>
              {letters[key]}
            </a>
          </li>
        );
        continue;
      }

      // Add list items to array
      allItemLetters.push(
        <li>
          <a onClick={() => letterClickHandler(letters[key], key)}>
            {letters[key]}
          </a>
        </li>
      );
    }
    setArrayOfItems(allItemLetters);
  }, []);

  return (
    <div className="alpha">
      <ul>
        {arrayOfItems}
        {/* <li>
          <a onClick={() => letterClickHandler("a")}>a</a>
        </li>
        <li>
          <a onClick={() => letterClickHandler("b")}>b</a>
        </li>
        <li onClick={() => letterClickHandler("c")}>
          <a>c</a>
        </li>
        <li>
          <a onClick={() => letterClickHandler("d")}>d</a>
        </li>
        <li>
          <a onClick={() => letterClickHandler("e")}>e</a>
        </li>
        <li className="active">
          <a>f</a>
        </li>
        <li>
          <a>g</a>
        </li>
        <li>
          <a>h</a>
        </li>
        <li>
          <a>i</a>
        </li>
        <li>
          <a>j</a>
        </li>
        <li>
          <a>k</a>
        </li>
        <li>
          <a>l</a>
        </li>
        <li className="disabled">
          <a>m</a>
        </li>
        <li>
          <a>n</a>
        </li>
        <li>
          <a>o</a>
        </li>
        <li>
          <a onClick={() => letterClickHandler("p")}>p</a>
        </li>
        <li>
          <a>q</a>
        </li>
        <li>
          <a>r</a>
        </li>
        <li>
          <a>s</a>
        </li>
        <li>
          <a>t</a>
        </li>
        <li>
          <a>u</a>
        </li>
        <li>
          <a>v</a>
        </li>
        <li>
          <a>w</a>
        </li>
        <li>
          <a>x</a>
        </li>
        <li>
          <a>y</a>
        </li>
        <li className="last">
          <a>z</a>
        </li> */}
      </ul>
    </div>
  );
};

export default Letters;
