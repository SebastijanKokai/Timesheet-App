import "../assets/css/style.css";
import logo from "../assets/img/logo.png";

const Nav = () => {
  return (
    <header className="header">
      <div className="top-bar"></div>
      <div className="wrapper">
        <a href="/" className="logo">
          <img src={logo} alt="VegaITSourcing Timesheet" />
        </a>
        <ul className="user right">
          <li>
            <a href="/">Sladjana Miljanovic</a>
            <div className="invisible"></div>
            <div className="user-menu">
              <ul>
                <li>
                  <a href="/" className="link">
                    Change password
                  </a>
                </li>
                <li>
                  <a href="/" className="link">
                    Settings
                  </a>
                </li>
                <li>
                  <a href="/" className="link">
                    Export all data
                  </a>
                </li>
              </ul>
            </div>
          </li>
          <li className="last">
            <a href="/">Logout</a>
          </li>
        </ul>
        <nav>
          <ul className="menu">
            <li>
              <a href="/" className="btn nav">
                TimeSheet
              </a>
            </li>
            <li>
              <a href="/" className="btn nav active">
                Clients
              </a>
            </li>
            <li>
              <a href="/" className="btn nav">
                Projects
              </a>
            </li>
            <li>
              <a href="/" className="btn nav">
                Categories
              </a>
            </li>
            <li>
              <a href="/" className="btn nav">
                Team members
              </a>
            </li>
            <li className="last">
              <a href="/" className="btn nav">
                Reports
              </a>
            </li>
          </ul>
          <div className="mobile-menu">
            <a href="/" className="menu-btn">
              <i className="zmdi zmdi-menu"></i>
            </a>
            <ul>
              <li>
                <a href="/">TimeSheet</a>
              </li>
              <li>
                <a href="/">Clients</a>
              </li>
              <li>
                <a href="/">Projects</a>
              </li>
              <li>
                <a href="/">Categories</a>
              </li>
              <li>
                <a href="/">Team members</a>
              </li>
              <li className="last">
                <a href="/">Reports</a>
              </li>
            </ul>
          </div>
          <span className="line"></span>
        </nav>
      </div>
    </header>
  );
};

export default Nav;
