import React, { lazy, Suspense, useEffect } from "react";
import { Routes, Route, useNavigate } from "react-router-dom";

import {
  CHANGE_PASSWORD_FIRST_LOGIN,
  CHANGE_PASSWORD,
  HOME,
  LOGIN,
  USER,
  ASSET,
  ASSIGNMENT,
  REQUEST,
} from "../constants/pages";
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import LayoutRoute from "./LayoutRoute";
import Roles from "src/constants/roles";
import { me } from "src/containers/Authorize/reducer";
import ChangePassword from "src/containers/User/ChangePassword";
import ChangePassword1085 from "src/containers/User/changepassword1085";

const Home = lazy(() => import("../containers/Home"));
const Login = lazy(() => import("../containers/Authorize"));
const User = lazy(() => import("../containers/User"));
const Asset = lazy(() => import("../containers/Asset"));
const Assignment = lazy(() => import("../containers/Assignment"));
const Request = lazy(() => import("../containers/Request"));
const NotFound = lazy(() => import("../containers/NotFound"));
const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>{children}</Suspense>
);

const AppRoutes = () => {
  const { isAuth, account } = useAppSelector((state) => state.authReducer);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const handleResult = (isLogged: Boolean) => {
    if (!isLogged) {
      setTimeout(() => {
        navigate(CHANGE_PASSWORD_FIRST_LOGIN);
      });
    }
  };

  useEffect(() => {
    if (localStorage.getItem("token") != null) {
      dispatch(me({ handleResult }));
    } else {
      navigate(LOGIN);
    }
  }, []);

  return (
    <SusspenseLoading>
      <Routes>
        <Route
          path={HOME}
          element={
            <LayoutRoute>
              <Home />
            </LayoutRoute>
          }
        />
        <Route
          path={USER}
          element={
            <LayoutRoute>
              <User />
            </LayoutRoute>
          }
        />

        <Route
          path={ASSET}
          element={
            <LayoutRoute>
              <Asset />
            </LayoutRoute>
          }
        />

        <Route
          path={ASSIGNMENT}
          element={
            <LayoutRoute>
              <Assignment />
            </LayoutRoute>
          }
        />

        <Route
          path={REQUEST}
          element={
            <LayoutRoute>
              <Request />
            </LayoutRoute>
          }
        />

        <Route
          path={LOGIN}
          element={
            <LayoutRoute>
              <Login />
            </LayoutRoute>
          }
        />

        <Route
          path={CHANGE_PASSWORD}
          element={
            <LayoutRoute>
              <ChangePassword1085 />
            </LayoutRoute>
          }
        />

        <Route
          path={CHANGE_PASSWORD_FIRST_LOGIN}
          element={
            <LayoutRoute>
              <ChangePassword />
            </LayoutRoute>
          }
        />
      </Routes>
    </SusspenseLoading>
  );
};

export default AppRoutes;
