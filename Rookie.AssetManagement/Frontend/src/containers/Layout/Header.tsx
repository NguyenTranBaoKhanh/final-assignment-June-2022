import React, { useState } from "react";
import { Dropdown } from "react-bootstrap";
import { useNavigate, useLocation } from "react-router-dom";
import ConfirmModal from "src/components/ConfirmModal";
import { HOME, LOGIN, CHANGE_PASSWORD } from "src/constants/pages";

import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { logout } from "../Authorize/reducer";

// eslint-disable-next-line react/display-name
const CustomToggle = React.forwardRef<any, any>(
  ({ children, onClick }, ref): any => (
    <a
      className="btn btn-link dropdownButton"
      ref={ref as any}
      onClick={(e) => {
        e.preventDefault();
        onClick(e);
      }}
    >
      {children} <span>&#x25bc;</span>
    </a>
  )
);

const Header = () => {
  const navigate = useNavigate();
  const { pathname } = useLocation();
  const { account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();

  const [showModalChangePasswod, setShowModalChangePasswod] = useState(false);
  const [showConfirmLogout, setShowConfirmLogout] = useState(false);

  const headerName = () => {
    if (account?.userName == null) {
      return "Online Asset Management";
    }
    const pathnameSplit = pathname.split("/");
        
    if(pathname.includes("edit")) {
      pathnameSplit.pop();
    }

    pathnameSplit.shift();
    if (pathnameSplit.length > 1){
      if( pathnameSplit[1] === "create") {
        pathnameSplit[1] = pathnameSplit[1] + ' New ' + pathnameSplit[0]
      } else {
        pathnameSplit[1] = pathnameSplit[1]+ ' ' + pathnameSplit[0]
      }
    }  
    return pathnameSplit.join(" > ").toString() || "Home";
  };

  const openModal = () => {
    setShowModalChangePasswod(true);
    navigate(CHANGE_PASSWORD)
  };

  const handleHide = () => {
    setShowModalChangePasswod(false);
  };

  const handleLogout = () => {
    setShowConfirmLogout(true);
  };

  const handleCancleLogout = () => {
    setShowConfirmLogout(false);
  };

  const handleConfirmedLogout = () => {
    navigate(LOGIN);
    setShowConfirmLogout(false);
    dispatch(logout());
  };

  const openLogin = () => {
    window.location.href = LOGIN;
    // navigate(LOGIN);
  };

  return (
    <>
      <div className="header align-items-center font-weight-bold">
        <div className="container-lg-min container-fluid d-flex pt-2" id="header__logo">
          <p className="headText">
            {!account?.userName && (
              <img src="/images/Logo_lk.png" alt="logo" id="logo-login" />
            )}
            {`${headerName()}` ==="Home" ? `${headerName()}` : ("Manage " + `${headerName()}`)}
          </p>

          <div className="ml-auto text-white">
            <Dropdown>
              <Dropdown.Toggle as={CustomToggle}>
                <a>{account?.userName}</a>
              </Dropdown.Toggle>

              <Dropdown.Menu>
                {account?.userName == null && (
                  <Dropdown.Item onClick={openLogin}>Login</Dropdown.Item>
                )}
                {account?.userName && (
                  <Dropdown.Item onClick={openModal}>
                    Change Password
                  </Dropdown.Item>
                )}
                {account?.userName && (
                  <Dropdown.Item onClick={handleLogout}>Logout</Dropdown.Item>
                )}
              </Dropdown.Menu>
            </Dropdown>
          </div>
        </div>
      </div>

      <ConfirmModal
        title="Are you sure"
        isShow={showConfirmLogout}
        onHide={handleCancleLogout}
      >
        <div>
          <div className="text-center">Do you want to log out?</div>
          <div className="text-center mt-3">
            <button
              className="btn btn-danger mr-3"
              onClick={handleConfirmedLogout}
              type="button"
            >
              Log out
            </button>
            <button
              className="btn btn-outline-secondary"
              onClick={handleCancleLogout}
              type="button"
            >
              Cancel
            </button>
          </div>
        </div>
      </ConfirmModal>
    </>
  );
};

export default Header;
