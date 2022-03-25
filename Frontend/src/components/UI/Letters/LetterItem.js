const LetterItem = ({ letter, getLetterClassName, letterClickHandler }) => {
  return (
    <li
      key={`Letter_${letter}`}
      className={getLetterClassName(letter)}
      onClick={() => letterClickHandler(letter)}
    >
      <a>{letter}</a>
    </li>
  );
};

export default LetterItem;
