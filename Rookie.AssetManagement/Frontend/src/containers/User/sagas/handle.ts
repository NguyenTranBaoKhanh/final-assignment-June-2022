import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import IError from "../../../interfaces/IError";
import {  CreateAction, setUser } from "../reducer";
import { createUserRequest } from './requests';
import IUser from "../../../interfaces/User/IUser";

export function* handleCreateUser(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        console.log('handleCreateUser');

        const { data } = yield call(createUserRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setUser(data));
        
    } catch (error: any) {

        console.log('catch error')
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}