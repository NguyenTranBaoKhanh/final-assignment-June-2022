import { takeLatest } from "redux-saga/effects";
import { createAssignment, deleteAssignment, getAssignments, updateAssignment } from "../reducer";
import { handleCreateAssignment, handleDeleteAssignment, handleGetAssignments, handleUpdateAssignment } from "./handle";

export default function* AssignmentSaga() {
    yield takeLatest(createAssignment.type, handleCreateAssignment);
    yield takeLatest(getAssignments.type, handleGetAssignments);
    yield takeLatest(deleteAssignment.type, handleDeleteAssignment);
    yield takeLatest(updateAssignment.type, handleUpdateAssignment);
}