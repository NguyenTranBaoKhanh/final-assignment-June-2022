import React from "react";
import { CloseButton, Modal } from "react-bootstrap";

import IUser from "src/interfaces/User/IUser";

import {
  StaffUserType,
  StaffUserTypeLabel,
  AdminUserType,
  AdminUserTypeLabel,
} from "src/constants/User/UserConstants";

type Props = {
  user: IUser;
  handleClose: () => void;
};

const Info: React.FC<Props> = ({ user, handleClose }) => {
  const getUserTypeName = (id: number) => {
    return id == AdminUserType ? AdminUserTypeLabel : StaffUserTypeLabel;
  };
  return (
    <>
      <Modal show={true} onHide={handleClose} dialogClassName="modal-90w" centered>
        <Modal.Header>
          <Modal.Title id="login-modal">Detail User Information</Modal.Title>
          <button className="close-button"
            onClick={handleClose}
          >
            <i className="fa-solid fa-xmark"></i>
          </button>
        </Modal.Header>
        <Modal.Body>
          <div>
            <div className="row">
              <div className="col-4">Staff Code:</div>
              <div>{user.staffCode}</div>
            </div>
            <div className="row ">
              <div className="col-4">Full Name:</div>
              <div className="col-8 pl-0">{user.firstName + " " + user.lastName}</div>
            </div>
            <div className="row ">
              <div className="col-4">User Name:</div>
              <div>{user.userName}</div>
            </div>
            <div className="row ">
              <div className="col-4">Date of Birth:</div>
              <div>{(new Date(user.dateOfBirth).getDate() <=9
                ? "0" + new Date(user.dateOfBirth).getDate()
                : new Date(user.dateOfBirth).getDate()) +
                "/" +
                (new Date(user.dateOfBirth).getMonth() < 9
                  ? "0" + (new Date(user.dateOfBirth).getMonth() + 1)
                  : new Date(user.dateOfBirth).getMonth() + 1) +
                "/" +
                new Date(user.dateOfBirth).getFullYear()}</div>
            </div>
            <div className="row ">
              <div className="col-4">Gender:</div>
              <div>{user.gender ==="F" ? "Female" : "Male"}</div>
            </div>
            <div className="row ">
              <div className="col-4">Joined Date:</div>
              <div>
                {(new Date(user.joinedDate).getDate() <= 9
                  ? "0" + new Date(user.joinedDate).getDate()
                  : new Date(user.joinedDate).getDate()) +
                  "/" +
                  (new Date(user.joinedDate).getMonth() < 9
                    ? "0" + (new Date(user.joinedDate).getMonth() + 1)
                    : new Date(user.joinedDate).getMonth() + 1) +
                  "/" +
                  new Date(user.joinedDate).getFullYear()}
              </div>
            </div>
            <div className="row ">
              <div className="col-4">Type:</div>
              <div>{user.type}</div>
            </div>
            <div className="row ">
              <div className="col-4">Location:</div>
              <div>{user.location}</div>
            </div>
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default Info;
