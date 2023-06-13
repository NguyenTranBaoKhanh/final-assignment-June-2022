import React, { lazy } from 'react';
import { Route, Routes } from 'react-router-dom';

import { CREATE, LIST} from '../../constants/pages';
import ListRequest from './List';


const NotFound = lazy(() => import("../NotFound"));
//const CreateAssignment = lazy(() => import("./Create"));
const ListAssignment = lazy(() => import("./List"))

const Assignment = () => {
    return (
        <Routes>
            <Route path={ LIST } element={<ListRequest />} />
            {/* <Route path={ CREATE } element={<CreateRequest />} /> */}
        </Routes>
    )
};

export default Assignment;