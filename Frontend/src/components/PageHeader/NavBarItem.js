import { Link } from "react-router-dom";

const NavBarItem = ({ linkTo, linkName, linkClassName }) => {
  return (
    <li>
      <Link to={linkTo} className={linkClassName}>
        {linkName}
      </Link>
    </li>
  );
};

export default NavBarItem;
