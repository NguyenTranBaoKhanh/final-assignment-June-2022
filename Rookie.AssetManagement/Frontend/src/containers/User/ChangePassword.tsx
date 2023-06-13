import React, { useEffect, useState } from "react";
import { Modal, Spinner } from 'react-bootstrap';
import { Form, Formik } from 'formik';

import Header from "../Layout/Header";
import "../../styles/popup.scss"

import TextField from "src/components/FormInputs/TextField";
import IChangePasswordFirstLogin from "src/interfaces/IChangePasswordFirstLogin";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { changePasswordFirstLogin, cleanUp } from "../Authorize/reducer";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { HOME } from "src/constants/pages";

const initialValues: IChangePasswordFirstLogin = {
  newPassword: '',
}

const validationSchema = Yup.object().shape({
  newPassword: Yup.string().required('*NewPassword is required').min(6, "NewPassword is more than 6 digits"),
});

const ChangePassword = () => {
  const [newPassword, setnewPassword] = useState("");
  const [isShow, setShow] = useState(true);
  const [isLoading, setLoading] = useState(false);
  const [disabled, setDisabled] = useState(true);
  const navigate = useNavigate();
  const { account } = useAppSelector(state => state.authReducer);
  const dispatch = useAppDispatch();
  const { loading, error } = useAppSelector(state => state.authReducer);

  const handleHide = () => {
    setShow(false);
  }

  const handleResult = (result: Boolean) => {
    if (result) {
      setTimeout(() => {
        navigate(HOME);
      });
    }
  }

  useEffect(() => {
    return () => {
      setShow(true);
      dispatch(cleanUp());

    }
  }, []);

  const handleChangePassword = (e) => {
    setnewPassword(e.target.value);
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
          style={{marginTop: '10%'}}
        >
          <Modal.Header >
            <Modal.Title>
              Change password
            </Modal.Title>

          </Modal.Header>
  
        
            <p className="auth-form__notify mb-0">
              This is the first time you logged in.
            </p>
            <p className="auth-form__notify mb-3">
              You have to change your password to continue.
            </p>

          <Modal.Body>
            <Formik
              validationSchema={validationSchema}
              initialValues={initialValues}
              onSubmit={async (values) => {
                setLoading(true);
                setTimeout(() => {
                  dispatch(changePasswordFirstLogin({ handleResult, formValues: values }));
                  setLoading(false);
                }, 1000);
              }}
            >

              {(actions) => (
                <Form className='intro-y'>
                  <TextField id="newPassword" name="newPassword" label="New Password" onKeyUp={handleChangePassword} isPassword isrequired />
                  {error?.error && (
                    <div className="invalid">
                      {error.message}
                    </div>
                  )}

                  <div className="text-center mt-5">
                    <button className="btn btn-danger btn-login"
                      type="submit" disabled={!isValid}>
                      Save
                      {(isLoading) && <img src="/oval.svg" className='w-4 h-4 ml-2 inline-block' />}
                    </button>
                  </div>
                </Form>
              )}
            </Formik>
          </Modal.Body>
        </Modal>
      </div>
    </>
  );
};

export default ChangePassword;
