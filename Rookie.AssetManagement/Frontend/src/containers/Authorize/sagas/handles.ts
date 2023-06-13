import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";

import { Status } from "src/constants/status";
import IChangePassword from "src/interfaces/IChangePassword";
import IError from "src/interfaces/IError";
import ILoginModel from "src/interfaces/ILoginModel";
import ISubmitAction from "src/interfaces/ISubmitActions";

import { GetMeAction, LoginAction, LoginChangePasswordFirstLoginAction, ChangePasswordAction, setAccount, setStatus, changePassword } from "../reducer";
import { loginRequest, getMeRequest, putChangePassword, putChangePasswordFirstLogin } from './requests';
import { createBrowserHistory } from 'history';
import { HOME } from "src/constants/pages";
export function* handleLogin(action: PayloadAction<LoginAction>) {
    const {handleResult , formValues} = action.payload;
    
    try {
        const {data} = yield call(loginRequest, formValues);

        if(data) {
            handleResult(true)
        }

        yield put(setAccount(data));
        yield put(setStatus({status: Status.Success}));
        
    } catch (error: any) {
        const errorModel = {
            error: true,
            message: error.response.status === 404 ? 
            'Username or password is incorrect. Please try again'
            : 'Your account is disabled. Please contact with IT Team',
        };
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}

export function* handleGetMe(action: PayloadAction<GetMeAction>) {
    const {handleResult} = action.payload;
    try {
        const {data} = yield call(getMeRequest);
        if (data.userName) {
            handleResult(data.isLogged);
            yield put(setAccount(data));
        }
        

    } catch (error: any) {
        // console.log('login err: ', error.response.data);
    }
}

export function* handleChangePasswordFirstLogin(action: PayloadAction<LoginChangePasswordFirstLoginAction>) {
    const {handleResult , formValues} = action.payload;

    try {
        const { data } = yield call(putChangePasswordFirstLogin, formValues);
        if (data.isLogged) {
            handleResult(true)
        }
        yield put(setAccount(data));

        yield put(setStatus({
            status: Status.Success,
        }));

    } catch (error: any) {      
        yield put(setStatus({}));
    }
}

export function* handleChangePassword(action: PayloadAction<ChangePasswordAction>) {
    const { handleResult, formValues } = action.payload;

    try {
        const { data } = yield call(putChangePassword, formValues);
        if (data.isLogged) {
            handleResult(true)
        }
        yield put(setAccount(data));
        yield put(setStatus({
            status: Status.Success,
        }));

    } catch (error: any) {
        const errorModel = {
            error: true,
            message: error.response.status === 400 ?
                'Password is incorrect' : 'Something went wrong',
        };
        yield put(setStatus({
            status: Status.Failed,
            error: errorModel,
        }));
    }
}