import React, { lazy } from 'react';
import { Route, Routes } from 'react-router-dom';

import { CREATE, LIST, EDIT_ASSET } from '../../constants/pages';



const NotFound = lazy(() => import("../NotFound"));
const CreateAsset = lazy(() => import("./Create"));
const ListAsset = lazy(() => import("./List"));
const AssetFormUpdate = lazy(() => import("./Edit"));

const Asset = () => {
    return (
        <Routes>
            <Route path={LIST} element={<ListAsset />} />
            <Route path={CREATE} element={<CreateAsset />} />
            <Route path={EDIT_ASSET} element = {<AssetFormUpdate />} />
        </Routes>
    )
};

export default Asset;