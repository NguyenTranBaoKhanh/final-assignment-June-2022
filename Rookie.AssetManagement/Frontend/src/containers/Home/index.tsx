import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import ConfirmModal from "src/components/ConfirmModal";
import { useNavigate } from "react-router-dom";
import { CHANGE_PASSWORD_FIRST_LOGIN, LOGIN } from "src/constants/pages";
import { useAppSelector } from "src/hooks/redux";
import { cleanUp, login, me } from "../Authorize/reducer";
import UserAssignmentTable from "./list/UserAssignmentTable";
import { ACCSENDING, ACCSENDING_QUERY, DECSENDING, DECSENDING_QUERY, DEFAULT_ASSIGNMENT_SORT_COLUMN_NAME, DEFAULT_PAGE_LIMIT } from "src/constants/paging";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import { getUserAssignments } from "./reducer";

const Home = () => {

  const dispatch = useDispatch();
  const { assignments} = useAppSelector((state) => state.homeReducer);

  const [query, setQuery] = useState({
    page: assignments?.items ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING_QUERY,
    sortColumn: "DEFAULT_ASSIGNMENT_SORT_COLUMN_NAME",
  } as IQueryAssignmentModel);

  const fetchData = () => {
    dispatch(getUserAssignments(query));
}

  useEffect(() => {
      fetchData();
  }, [query]);

  const handleSort = (sortColumn: string) => {
  const sortOrder = query.sortOrder === ACCSENDING_QUERY ? DECSENDING_QUERY : ACCSENDING_QUERY;
    setQuery({
        ...query,
        sortColumn,
        sortOrder,
    });
  };

  const handlePage = (page: number) => {
    setQuery({
        ...query,
        page,
    });
  };
  

  return (
    <>
      <div className='primaryColor text-title intro-x' style={{marginTop: "5%"}}>
        My assignment      
      </div>
      <div>
        <UserAssignmentTable 
            assignments={assignments}
            handlePage={handlePage}
            handleSort={handleSort}
            sortState={{
              columnValue: query.sortColumn, 
              orderBy: query.sortOrder === DECSENDING_QUERY,
            }}
            fetchData={fetchData}
        />
      </div>
    </>
  );
};

export default Home;
