import React, { lazy } from 'react';
import { Route, Routes } from 'react-router-dom';

import { CREATE, LIST, EDIT_ASSIGNMENTS} from '../../constants/pages';


const NotFound = lazy(() => import("../NotFound"));
const CreateAssignment = lazy(() => import("./Create"));
const ListAssignment = lazy(() => import("./List"))
const EditAssignment = lazy(() => import("./Edit"))

const Assignment = () => {
    return (
        <Routes>
            <Route path={ LIST } element={<ListAssignment />} />
            <Route path={ CREATE } element={<CreateAssignment />} />
            <Route path={ EDIT_ASSIGNMENTS } element={<EditAssignment />} />
        </Routes>
    )
};

export default Assignment;