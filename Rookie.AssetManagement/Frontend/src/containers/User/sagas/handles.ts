import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import { Status } from "src/constants/status";
import IUser from 'src/interfaces/User/IUser'
import IError from "src/interfaces/IError";
import IQueryUserModel from "src/interfaces/User/IQueryUserModel";
import { setUser, CreateAction, setUsers, setStatus, DisableAction } from "../reducer";

import { createUserRequest, DisableUserRequest, getUsersRequest, updateUserRequest } from './requests';

export function* handleCreateUser(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(createUserRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setUser(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleUpdateUser(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {

        const { data } = yield call(updateUserRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setUser(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleGetUsers(action: PayloadAction<IQueryUserModel>) {
    const query = action.payload;
    try {
        // alert("da goi handleGetBrands");
        const { data } = yield call(getUsersRequest, query);
        
        yield put(setUsers(data));

        // alert("da goi setBrands 2");

    } catch (error: any) {
        const errorModel = error.response.data as IError;

        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}
export function* handleDisableUser(action: PayloadAction<DisableAction>) {
    const { handleResult, userId } = action.payload;

    try {
        const {data} = yield call(DisableUserRequest, userId);

        handleResult(data, '');

    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}
