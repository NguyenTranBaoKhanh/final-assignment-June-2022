import React, { useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useNavigate } from "react-router";
import ButtonIcon from "src/components/ButtonIcon";
import { NotificationManager } from "react-notifications";

import Table, { SortType } from "src/components/Table";
import IColumnOption from "src/interfaces/IColumnOption";
import IPagedModel from "src/interfaces/IPagedModel";
import IUser from "src/interfaces/User/IUser";
import ConfirmModal from "src/components/ConfirmModal";
import { useAppDispatch } from "src/hooks/redux";
import {
  StaffUserType,
  StaffUserTypeLabel,
  AdminUserType,
  AdminUserTypeLabel,
} from "src/constants/User/UserConstants";
import { disableUser } from "../reducer";
import Info from "../Info";
import { EDIT_USER_ID } from "src/constants/pages";

const columns: IColumnOption[] = [
  { columnName: "Staff Code", columnValue: "StaffCode" },
  { columnName: "Full Name", columnValue: "Name" },
  { columnName: "User Name", columnValue: "UserName" },
  { columnName: "Joined Date", columnValue: "JoinedDate" },
  { columnName: "Type", columnValue: "Type" },
];

type Props = {
  users: IPagedModel<IUser> | null;
  handlePage: (page: number) => void;
  handleSort: (colValue: string) => void;
  sortState: SortType;
  fetchData: Function;
};

const UserTable: React.FC<Props> = ({
  users,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const dispatch = useAppDispatch();

  const [showDetail, setShowDetail] = useState(false);
  const [userDetail, setUserDetail] = useState(null as IUser | null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowDisable = async (id: number) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this User?',
      isDisable: true,
    });
  };

  const handleCloseDisable = () => {
    setDisable({
      isOpen: false,
      id: 0,
      title: "",
      message: "",
      isDisable: true,
    });
  };

  const handleShowInfo = (id: number) => {
    const user = users?.items.find((item) => item.id === id);

    if (user) {
      setUserDetail(user);
      setShowDetail(true);
    }
  };

  const handleResult = (result: boolean, message: string) => {
    if (result) {
      handleCloseDisable();
      fetchData();
      NotificationManager.success(
        `Remove User Successful`,
        `Remove Successful`,
        2000
      );
    } else {
      setDisable({
        ...disableState,
        title: "Can not disable User",
        message,
        isDisable: result,
      });
    }
  };

  const handleEdit = (id: number | string) => {
    navigate(EDIT_USER_ID(id));
  };
  
  const handleConfirmDisable = () => {
    dispatch(
      disableUser({
        handleResult,
        userId: disableState.id,
      })
    );
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const navigate = useNavigate();

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
          <tr key={index} className="" onClick={() => handleShowInfo(data.id)}>
            <td id={data.staffCode}>{data.staffCode}</td>
            <td id={data.firstName + " " + data.lastName}>
              {data.firstName + " " + data.lastName}
            </td>
            <td id={data.userName}>{data.userName}</td>
            <td id="date{index}">
              {(new Date(data.joinedDate).getDate() <= 9
                ? "0" + new Date(data.joinedDate).getDate()
                : new Date(data.joinedDate).getDate()) +
                "/" +
                (new Date(data.joinedDate).getMonth() < 9
                  ? "0" + (new Date(data.joinedDate).getMonth() + 1)
                  : new Date(data.joinedDate).getMonth() + 1) +
                "/" +
                new Date(data.joinedDate).getFullYear()}
            </td>
            <td id={data.type}>{data.type}</td>

            <td className="d-flex justify-content-end">
              <ButtonIcon>
                <PencilFill className="text-black" onClick={() => handleEdit(data.id)}/>
              </ButtonIcon>
              <ButtonIcon>
                <XCircle className="text-danger ml-2" onClick={() => handleShowDisable(data.id)} />
              </ButtonIcon>
            </td>
          </tr>
        ))}
      </Table>
      {userDetail && showDetail && (
        <Info user={userDetail} handleClose={handleCloseDetail} />
      )}
      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCloseDisable}
      >
        <div>
          <div className="ml-3">{disableState.message}</div>
          {disableState.isDisable && (
            <div className="ml-3 mt-3">
              <button
                className="btn btn-danger mr-3"
                onClick={handleConfirmDisable}
                type="button"
              >
                Disable
              </button>

              <button
                className="btn btn-outline-secondary"
                onClick={handleCloseDisable}
                type="button"
              >
                Cancel
              </button>
            </div>
          )}
        </div>
      </ConfirmModal>
    </>
  );
};

export default UserTable;
