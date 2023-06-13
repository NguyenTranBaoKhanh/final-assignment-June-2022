import { takeLatest } from "redux-saga/effects";
import { acceptAssignment, declineAssignment, getUserAssignments, updateUserAssignment } from "../reducer";
import { handleAcceptAssignment, handleDeclineAssignment, handleGetUserAssignments,  handleUpdateUserAssignment } from "./handle";


export default function* UserAssignmentSaga() {
    yield takeLatest(getUserAssignments.type, handleGetUserAssignments);
    yield takeLatest(updateUserAssignment.type, handleUpdateUserAssignment);
    yield takeLatest(acceptAssignment.type, handleAcceptAssignment);
    yield takeLatest(declineAssignment.type, handleDeclineAssignment);
}