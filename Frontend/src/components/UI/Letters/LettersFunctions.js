const LettersFunctions = {
  isLetterDisabled: (letter, firstLettersArray) => {
    if (firstLettersArray.includes(letter)) {
      return false;
    }

    return true;
  },
};

export default LettersFunctions;
