import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";
import { useLocation } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from "../../../hooks/redux";
import { getUsers, setUser } from "../reducer";
import { Link } from "react-router-dom";
import UserTable from "./UesrTable";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import ISelectOption from "src/interfaces/ISelectOption";
import { FilterUserType } from "src/constants/selectOptions";
import {
  ACCSENDING,
  DECSENDING,
  DEFAULT_PAGE_LIMIT,
  DEFAULT_USER_SORT_COLUMN_NAME,
} from "src/constants/paging"
import { getLocalStorage } from "src/utils/localStorage";

const ListUser = () => {
  const dispatch = useAppDispatch();
  const { users, loading } = useAppSelector((state) => state.userReducer);
  const { account } = useAppSelector(state => state.authReducer);
  const { userResult } = useAppSelector(state => state.userReducer)
  
  const [query, setQuery] = useState({
    page: users?.items ?? 1,
    limit: DEFAULT_PAGE_LIMIT,
    Ascending: ACCSENDING,
    sortBy: DEFAULT_USER_SORT_COLUMN_NAME,
    locationId: getLocalStorage('locationID')
  } as IQueryUserModel);

  
  const output = JSON.parse(JSON.stringify(users))
  if (userResult && (query.page == 1 || typeof (query.page) == 'object')) {
    const currentUser = output.items.find(user => user.staffCode === userResult.staffCode);
    if(currentUser) {
      const index = output.items.indexOf(currentUser);
      output.items.splice(index, 1);
    }
    output.items.reverse()
    output.items.push(userResult)
    output.items.reverse()
  }

  const [keyword, setSearch] = useState("");

  const [selectedType, setSelectedType] = useState([
    { id: 1, label: "All", value: 0 },
  ] as ISelectOption[]);

  const handleType = (selected: ISelectOption[]) => {
    dispatch(setUser(undefined));
    if (selected.length === 0) {
      setQuery({
        ...query,
        type: [],
      });

      setSelectedType([FilterUserType[0]]);
      return;
    }

    const selectedAll = selected.find((item) => item.id === 1);

    setSelectedType((prevSelected) => {
      if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
        setQuery({
          ...query,
          type: [],
        });

        return [selectedAll];
      }

      const newSelected = selected.filter((item) => item.id !== 1);
      const type = newSelected.map((item) => item.value as string);

      setQuery({
        ...query,
        type,
      });

      return newSelected;
    });
  };

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
    dispatch(setUser(undefined));
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

  useEffect(() => {
    fetchData();

  }, [query]);

  return (
    <>
      <div className="primaryColor text-title intro-x">User List</div>
      <div>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center w-md mr-5">
            <ReactMultiSelectCheckboxes
              options={FilterUserType}
              hideSearch={true}
              placeholderButtonLabel="Type"
              value={selectedType}
              onChange={handleType}
            />

            <div className="border p-2">
              <FunnelFill />
            </div>
          </div>

          <div className="d-flex align-items-center w-ld ml-auto">
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

          <div className="d-flex align-items-center ml-3">
            <Link to="/user/create" type="button" className="btn btn-danger">
              Create new User
            </Link>
          </div>
        </div>

        <UserTable
          users={!userResult ? users : output}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortBy,
            orderBy: query.Ascending,
          }}
          fetchData={fetchData}
        />
      </div>
    </>
  );
};

export default ListUser;