import React, { useEffect, useState } from "react";
import { Search } from "react-feather";
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getUsers } from "../reducer";
import UserTableSelect from "./UserTableSelect";
import IQueryUserModel from "../../../interfaces/User/IQueryUserModel";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_PAGE_LIMIT,
  DEFAULT_USER_SORT_COLUMN_NAME,
} from "../../../constants/paging"
import { getLocalStorage } from "../../../utils/localStorage";
import { StringLiteral } from "typescript";
import IUser from "src/interfaces/User/IUser";

type Props = {
    handleSelectUser: Function;
    code: String
};

const UserSelect : React.FC<Props> = ({
    handleSelectUser, code
}) => {
  const dispatch = useAppDispatch();
  const { users, loading } = useAppSelector((state) => state.userReducer);
//   const { userResult } = useAppSelector(state => state.userReducer)

  const [query, setQuery] = useState({
    page: users?.items ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    Ascending: ACCSENDING,
    sortBy: DEFAULT_USER_SORT_COLUMN_NAME,
    locationId: getLocalStorage('locationID')
  } as IQueryUserModel);
  
//   const output = JSON.parse(JSON.stringify(users))
//   if (userResult && (query.page == 1 || typeof (query.page) == 'object')) {
//     output.items.reverse()
//     output.items.push(userResult)
//     output.items.reverse()
//   }

  const [keyword, setSearch] = useState("");

  const handleChangeSearch = (e) => {
    e.preventDefault();

    const search = e.target.value;
    setSearch(search);
  };

  const handlePage = (page: number) => {
    setQuery({
      ...query,
      page,
    });
  };

  const handleSearch = () => {
    setQuery({
      ...query,
      keyword,
    });
  };

  const handleSort = (sortBy: string) => {
    const Ascending = query.Ascending === ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortBy,
      Ascending,
    });
  };

  const fetchData = () => {
    dispatch(getUsers(query));
  }

  const handleSelect = (data) => {
    handleSelectUser(data)
  };

  useEffect(() => {
    fetchData();

  }, [query]);

  return (
    <>
      <div>
        <div className="d-flex intro-x">
          <div className="d-flex align-items-center w-ld ml-auto search-input">
            <div className="input-group">
              <input
                onChange={handleChangeSearch}
                value={keyword}
                type="text"
                className="form-control"
              />
              <span onClick={handleSearch} className="border p-2 pointer">
                <Search />
              </span>
            </div>
          </div>
        </div>

        <UserTableSelect
          users={users}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortBy,
            orderBy: query.Ascending,
          }}
          fetchData={fetchData}
          handleSelect={handleSelect}
          code={code}
        />
      </div>
    </>
  );
};

export default UserSelect;