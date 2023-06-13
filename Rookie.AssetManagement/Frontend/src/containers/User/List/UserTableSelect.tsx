import React, { useState } from "react";
import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IUser from "src/interfaces/User/IUser";
import { useAppDispatch, useAppSelector } from 'src/hooks/redux';
import { setUser } from '../reducer';
const columns: IColumnOption[] = [
  { columnName: "", columnValue: "Radio"},
  { columnName: "Staff Code", columnValue: "StaffCode" },
  { columnName: "Full Name", columnValue: "Name" },
  { columnName: "Type", columnValue: "Type" }
];

type Props = {
  users: IPagedModel<IUser> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
  handleSelect: Function;
  code: String
};

const UserTableSelect: React.FC<Props> = ({
  users,
  handlePage,
  handleSort,
  sortState,
  handleSelect,
  code
}) => {

  const [selected, setSelected] = useState(code)
  const onSelected = (code: string) => {
    setSelected(code)
  }
  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: users?.page,
          totalPage: users?.pageCount,
          handleChange: handlePage,
        }}
      >
        {users?.items?.map((data, index) => (
          <tr 
            className={`row-select__assignment ${data.staffCode == selected ? 'selected' : ''}`} 
            key={index} 
            onClick={() => {handleSelect(data); onSelected(data.staffCode)}}
           >
            <td style={{borderBottom: "none"}}><div className={`radio__assignment ${data.staffCode == selected ? 'selected' : ''}`}></div></td>
            <td id={data.staffCode}>{data.staffCode}</td>
            <td id={data.firstName + " " + data.lastName}>
              {data.firstName + " " + data.lastName}
            </td>
            <td style={{borderBottom: "2px solid #dee2e6"}} id={data.type}>{data.type}</td>
          </tr>
        ))}
      </Table>
    </>
  );
};

export default UserTableSelect;
