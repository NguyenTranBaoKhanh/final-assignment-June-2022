import React, { lazy } from 'react';
import { Route, Routes } from 'react-router-dom';

import { CREATE_USER, EDIT_USER, USER_LIST } from 'src/constants/pages';


const NotFound = lazy(() => import("../NotFound"));
const CreateUser = lazy(() => import("./Create"));
const UpdateUser = lazy(() => import("./Update"))
const ListUser = lazy(() => import("./List"));
// const UpdateBrand = lazy(() => import("./Update"))

const User = () => {
    return (
        <Routes>
            <Route path={USER_LIST} element={<ListUser />} />
            <Route path={CREATE_USER} element={<CreateUser />} />
            <Route path={EDIT_USER} element={<UpdateUser />} />
        </Routes>
    )
};

export default User;