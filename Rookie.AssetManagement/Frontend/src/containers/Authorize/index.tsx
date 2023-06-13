import React, { useEffect, useState } from "react";
import { Modal } from 'react-bootstrap';
import { Form, Formik } from 'formik';

import Header from "../Layout/Header";
import TextField from "src/components/FormInputs/TextField";
import ILoginModel from "src/interfaces/ILoginModel";
import { useAppDispatch, useAppSelector } from "src/hooks/redux";
import { cleanUp, login, me } from "./reducer";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import { HOME } from "src/constants/pages";
// import { borderRadius } from "react-select/src/theme";

const initialValues: ILoginModel = {
  userName: '',
  password: '',
}

const validationSchema = Yup.object().shape({
  userName: Yup.string().required('*Username is required').min(3, "Username is more than 3 digits"),
  password: Yup.string().required('*Password is required').min(5, "Password is more than 5 digits"),
});

const Login = () => {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
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
            //navigate(HOME);
            window.location.href = HOME
        });
    } 
  }

  useEffect(() => {

    const isShow = localStorage.getItem("token") == null ? true : false;
    setShow(isShow);
    if(!isShow) {
      navigate(HOME);
    }

    return () => {
      dispatch(cleanUp());
    }
  }, []);

  const handleChangeUserName = (e) => {

    setUserName(e.target.value);
  }

  const handleChangePassword= (e) => {   
      setPassword(e.target.value);
  }

  const isValid = userName != "" && password != "";

  return (
    <>
      <div className='container'>
        <Modal 
          show={isShow}
          onHide={handleHide}
          backdrop="static"
          dialogClassName="modal-90w"
          aria-labelledby="login-modal"
          id="login-modal"
        >
          <Modal.Header>
            <Modal.Title>
              Welcome to Online Asset Management
            </Modal.Title>

          </Modal.Header>

          <Modal.Body>
            <Formik
              validationSchema={validationSchema}
              initialValues={initialValues}
              onSubmit={async(values) => {
                setLoading(true);
                setTimeout(() => {
                  dispatch(login({handleResult, formValues: values}));
                  setLoading(false);
                }, 1000);
              }}
            >
              
              {(actions) => (
                <Form className='intro-y'>
                  <TextField id="userName" name="userName" label="Username" onKeyUp={handleChangeUserName} isrequired />
                  <TextField id="password" name="password" label="Password" onKeyUp ={handleChangePassword} isPassword isrequired />
                  {error?.error && (
                    <div className="invalid">
                      {error.message}
                    </div>
                  )}

                  <div className="text-center mt-5">
                    <button className="btn btn-danger btn-login"
                       type="submit" disabled={!isValid}>
                      Login
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

export default Login;
