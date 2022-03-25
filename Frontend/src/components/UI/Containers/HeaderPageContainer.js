const HeaderPageContainer = (props) => {
  return (
    <header className="header">
      <div className="top-bar"></div>
      <div className="wrapper">{props.children}</div>
    </header>
  );
};

export default HeaderPageContainer;
