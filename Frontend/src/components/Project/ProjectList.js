import ListHeader from "../UI/ListHeader/ListHeader";
import ListHeaderInput from "../UI/ListHeader/ListHeaderInput";
import Letters from "../UI/Letters/Letters";
import Pagination from "../UI/Pagination/Pagination";

const ProjectList = () => {
  return (
    <div className="wrapper">
      <section className="content">
        <ListHeader pageName={"Projects"} />
        {/* <ListHeaderInput
          toggleFormHandler={toggleClientFormHandler}
          componentName={"Client"}
          searchChangeHandler={searchChangeHandler}
        />
        <Letters
          searchName={searchName}
          searchLetter={searchLetter}
          getRequest={getClientsRequest}
          firstLettersArray={firstLettersArray}
        />
        <div className="accordion-wrap clients">
          {clients.map((client) => (
            <ClientItem key={client.id} client={client} countries={countries} />
          ))}
        </div>
        <Pagination
          paginationDetails={paginationDetails}
          searchLetter={searchLetter}
          searchName={searchName}
          getRequest={getClientsRequest}
        /> */}
      </section>
    </div>
  );
};

export default ProjectList;
