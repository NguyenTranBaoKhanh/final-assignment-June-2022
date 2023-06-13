import { createSlice, PayloadAction } from "@reduxjs/toolkit";

import { SetStatusType } from "src/constants/status";
import IAccount from "src/interfaces/IAccount";
import IChangePassword from "src/interfaces/IChangePassword";
import IChangePasswordFirstLogin from "src/interfaces/IChangePasswordFirstLogin";
import IError from "src/interfaces/IError";
import ILoginModel from "src/interfaces/ILoginModel";
import ISubmitAction from "src/interfaces/ISubmitActions";
import request from "src/services/request";
import { getLocalStorage, removeLocalStorage, setLocalStorage } from "src/utils/localStorage";

type AuthState = {
    loading: boolean;
    isAuth: boolean,
    account?: IAccount;
    status?: number;
    error?: IError;
}

const token = getLocalStorage('token');

const initialState: AuthState = {
    isAuth: !!token,
    loading: false,
};

export type LoginAction = {
    handleResult: Function,
    formValues: ILoginModel,
}

export type GetMeAction = {
    handleResult: Function,
}

export type LoginChangePasswordFirstLoginAction = {
    handleResult: Function,
    formValues: IChangePasswordFirstLogin,
}

export type ChangePasswordAction = {
    handleResult: Function,
    formValues: IChangePassword,
}

const AuthSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAccount: (state: AuthState, action: PayloadAction<IAccount>): AuthState => {
            const account = action.payload;
            if (account?.token) {
                setLocalStorage('token', account.token);
                setLocalStorage('locationID', account.location);
                request.setAuthentication(account.token);
            }

            return {
                ...state,
                // status: Status.Success,
                account,
                isAuth: true,
                loading: false,
            };
        },
        setStatus: (state: AuthState, action: PayloadAction<SetStatusType>) =>
        {
            const {status, error} = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
        me: (state: AuthState,  action: PayloadAction<GetMeAction>) => {
            if (token) {
                request.setAuthentication(token);
            }
        },
        login: (state: AuthState, action: PayloadAction<LoginAction>) => ({
            ...state,
            loading: true,
        }),
        changePasswordFirstLogin: (state: AuthState, action: PayloadAction<LoginChangePasswordFirstLoginAction>) => {
            return {
                ...state,
                loading: true,
            }
        },
        changePassword: (state: AuthState, action: PayloadAction<ChangePasswordAction>) => {
            console.log(1)
            return {
                ...state,
                loading: true,
            }
        },
        logout: (state: AuthState) => {

            removeLocalStorage('token');
            removeLocalStorage('locationID');
            request.setAuthentication('')

            return {
                ...state,
                isAuth: false,
                account: undefined,
                status: undefined,
            };
        },
        cleanUp: (state) => ({
            ...state,
            loading: false,
            status: undefined,
            error: undefined,
        }),
    }
});

export const {
    setAccount, login, setStatus, me, changePassword, changePasswordFirstLogin, logout, cleanUp,
} = AuthSlice.actions;

export default AuthSlice.reducer;
