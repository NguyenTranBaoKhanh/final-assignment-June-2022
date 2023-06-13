import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import IError from "src/interfaces/IError";
import { CreateAction, DisableAction, setAssignment, setAssignments } from "../reducer";
import { createAssignmentRequest, DeleteAssignmentRequest, getAssignmentsRequest, updateAssignmentRequest } from "./requests";

export function* handleCreateAssignment(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;

    try {
        const { data } = yield call(createAssignmentRequest, formValues);

        if(data) {
            handleResult(true, data.name);
        }

        yield put(setAssignment(data));

     } catch(error: any) {
        const errorModel = error.response.data as IError;
        handleResult(false, errorModel.message);
    }
}

export function* handleGetAssignments(action: PayloadAction<IQueryAssignmentModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getAssignmentsRequest, query);
        if (data) {
            yield put(setAssignments(data))
        }
    } catch (error: any) {
        const errorModel = error.response.data as IError;
    }
}

export function* handleDeleteAssignment(action: PayloadAction<DisableAction>) {
    const { handleResult, assignmentId } = action.payload;

    try {
        const {data} = yield call(DeleteAssignmentRequest, assignmentId);

        handleResult(data, '');

    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleUpdateAssignment(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {

        const { data } = yield call(updateAssignmentRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setAssignment(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}