import { takeLatest } from "redux-saga/effects";
import { getRequests } from "../reducer";
import { handleGetRequests } from "./handle";

export default function* RequestSaga() {
    //yield takeLatest(createAssignment.type, handleCreateAssignment);
    yield takeLatest(getRequests.type, handleGetRequests);
    //yield takeLatest(deleteAssignment.type, handleDeleteAssignment);
}