import NavBarItem from "./NavBarItem";

const NavBar = () => {
  return (
    <nav>
      <ul className="menu">
        <NavBarItem
          linkTo={"/"}
          linkName={"Timesheet"}
          linkClassName={"btn nav"}
        />
        <NavBarItem
          linkTo={"/clients"}
          linkName={"Clients"}
          linkClassName={"btn nav"}
        />
        <NavBarItem
          linkTo={"/projects"}
          linkName={"Projects"}
          linkClassName={"btn nav"}
        />
        <NavBarItem
          linkTo={"/categories"}
          linkName={"Categories"}
          linkClassName={"btn nav"}
        />
        <NavBarItem
          linkTo={"/team-members"}
          linkName={"Team members"}
          linkClassName={"btn nav"}
        />
        <NavBarItem
          linkTo={"/reports"}
          linkName={"Reports"}
          linkClassName={"btn nav"}
        />
      </ul>
      <div className="mobile-menu">
        <a href="/" className="menu-btn">
          <i className="zmdi zmdi-menu"></i>
        </a>
        <ul>
          <NavBarItem linkTo={"/"} linkName={"Timesheet"} />
          <NavBarItem linkTo={"/clients"} linkName={"Clients"} />
          <NavBarItem linkTo={"/projects"} linkName={"Projects"} />
          <NavBarItem linkTo={"/categories"} linkName={"Categories"} />
          <NavBarItem linkTo={"/team-members"} linkName={"Team members"} />
          <NavBarItem linkTo={"/reports"} linkName={"Reports"} />
        </ul>
      </div>
      <span className="line"></span>
    </nav>
  );
};

export default NavBar;
