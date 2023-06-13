import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import IError from "src/interfaces/IError";
import { setUserAssignments, UpdateAction, setUserAssignment, AcceptAction} from "../reducer";
import { AcceptAssignmentRequest, DeclineAssignmentRequest, getUserAssignmentsRequest, updateUserAssignmentRequest } from "./requests";

export function* handleGetUserAssignments(action: PayloadAction<IQueryAssignmentModel>) {
    
    const query = action.payload;
    try {
        const { data } = yield call(getUserAssignmentsRequest, query);
        if (data) {
            yield put(setUserAssignments(data))
        }
    } catch (error: any) {
        const errorModel = error.response.data as IError;
    }
}

export function* handleUpdateUserAssignment(action: PayloadAction<UpdateAction>) {
    const {handleResult, assignmentId} = action.payload;
    try {
        const { data } = yield call(updateUserAssignmentRequest, assignmentId);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setUserAssignment(data.result));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleAcceptAssignment(action: PayloadAction<AcceptAction>) {
    const { handleResult, assignmentId } = action.payload;

    try {
        const {data} = yield call(AcceptAssignmentRequest, assignmentId);

        handleResult(data, '');

    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDeclineAssignment(action: PayloadAction<AcceptAction>) {
    const { handleResult, assignmentId } = action.payload;

    try {
        const {data} = yield call(DeclineAssignmentRequest, assignmentId);

        handleResult(data, '');

    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
