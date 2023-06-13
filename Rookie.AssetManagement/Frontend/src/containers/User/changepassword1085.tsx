import React, { useEffect, useState } from "react";
import { Modal, Spinner } from 'react-bootstrap';
import { Form, Formik } from 'formik';

import Header from "../Layout/Header";
import "../../styles/popup.scss"

import TextField from "src/components/FormInputs/TextField";
import IChangePassword from "src/interfaces/IChangePassword";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { changePassword, cleanUp } from "../Authorize/reducer";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { HOME } from "src/constants/pages";
import ConfirmModal from "src/components/ConfirmModal";

const initialValues: IChangePassword = {
  oldPassword: '',
  newPassword: '',
}

const validationSchema = Yup.object().shape({
  newPassword: Yup.string().required('*NewPassword is required').min(6, "NewPassword is more than 6 digits"),
  oldPassword: Yup.string().required('*OldPassword is required').min(6, "OldPassword is more than 6 digits"),
});

const ChangePassword1085 = () => {
  const [newPassword, setNewPassword] = useState("");
  const [oldPassword, setOldPassword] = useState("");
  const [isShow, setShow] = useState(true);
  const [isLoading, setLoading] = useState(false);
  const [disabled, setDisabled] = useState(true);
  const navigate = useNavigate();
  const { account } = useAppSelector(state => state.authReducer);
  const dispatch = useAppDispatch();
  const { loading, error } = useAppSelector(state => state.authReducer);

  const [showModalChangePasswod, setShowModalChangePasswod] = useState(false);
  const [showConfirmLogout, setShowConfirmLogout] = useState(false);

  const handleCancleLogout = () => {
    setTimeout(() => {
      navigate(HOME);
    });
    setShowConfirmLogout(false);
  };

  const handleHide = () => {
    dispatch(cleanUp());
    setShow(false);
    navigate(HOME);
  }

  const handleResult = (result: Boolean) => {
    if (result) {
      setShow(false);
      setShowConfirmLogout(true);
    }
  }

  useEffect(() => {
    return () => {
      setShow(true);
    }
  }, []);

  const handleOldPassword = (e) => {
    setOldPassword(e.target.value);
    dispatch(cleanUp());
  }

  const handleNewPassword = (e) => {
    setNewPassword(e.target.value);
  }

  const isValid = newPassword != "";

  return (
    <>
      <div className='container' >
        <Modal
          show={isShow}
          onHide={handleHide}
          backdrop="static"
          dialogClassName="modal-90w"
          aria-labelledby="login-modal"
          style={{ marginTop: '10%' }}
        >
          <Modal.Header >
            <Modal.Title>
              Change Password
            </Modal.Title>

          </Modal.Header>

          <Modal.Body>
            <Formik
              validationSchema={validationSchema}
              initialValues={initialValues}
              onSubmit={async (values) => {
                console.log(values)
                setLoading(true);
                setTimeout(() => {
                  dispatch(changePassword({ handleResult, formValues: values }));
                  setLoading(false);
                }, 1000);
              }}
            >
              {(actions) => (
                <Form className='intro-y'>
                  <TextField id="oldPassword" name="oldPassword" label="Old Password" onKeyUp={handleOldPassword} isPassword isrequired />
                  {error?.error && (
                    <div className="invalid" id="hidden-invalid">
                      {error.message}
                    </div>
                  )}
                  <TextField id="newPassword" name="newPassword" label="New Password" onKeyUp={handleNewPassword} isPassword isrequired />

                  <div className="text-center mt-5">
                    <button className="btn btn-danger btn-change-password"
                      type="submit" disabled={!isValid}>
                      Save
                      {(isLoading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                    </button>

                    <button className="btn btn-outline-secondary"
                      onClick={handleHide}
                      >
                      Canel
                    </button>
                  </div>
                </Form>
              )}
            </Formik>
          </Modal.Body>
        </Modal>
      </div>

      <ConfirmModal
        title="Change password"
        isShow={showConfirmLogout}
        onHide={handleCancleLogout}
      >
        <div>
          <div className="text-center">Your password has been changed successfully!</div>
          <div className="text-center mt-3">
            <button id="confirm-change-password-button" className="btn btn-outline-secondary" onClick={handleCancleLogout} type="button">Close</button>
          </div>
        </div>
      </ConfirmModal>

    </>
  );
};

export default ChangePassword1085;
