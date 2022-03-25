import HeaderPageContainer from "../UI/Containers/HeaderPageContainer";
import UserBar from "../User/UserBar";
import NavBar from "./NavBar";
import PageHeaderLogo from "./PageHeaderLogo";

const PageHeader = () => {
  return (
    <HeaderPageContainer>
      <PageHeaderLogo />
      <UserBar />
      <NavBar />
    </HeaderPageContainer>
  );
};

export default PageHeader;
