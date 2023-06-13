import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import IQueryRequestModel from "src/interfaces/Request/IQueryRequestModel";
import IError from "src/interfaces/IError";
import { CreateAction, DisableAction, setRequests } from "../reducer";
import {  getRequestsRequest } from "./requests";

export function* handleGetRequests(action: PayloadAction<IQueryRequestModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getRequestsRequest, query);
        if (data) {
            yield put(setRequests(data))
        }
    } catch (error: any) {
        const errorModel = error.response.data as IError;
    }
}
