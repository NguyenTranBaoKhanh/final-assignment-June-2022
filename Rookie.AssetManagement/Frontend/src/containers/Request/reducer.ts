import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { stat } from "fs";
import { SetStatusType } from "src/constants/status";
import IRequestForm from "src/interfaces/Request/IRequest";
import IError from "src/interfaces/IError";
import IPagedModel from "src/interfaces/IPagedModel";
import IRequest from "src/interfaces/Request/IRequest";
import IQueryRequestModel from "src/interfaces/Request/IQueryRequestModel"

type RequestState = {
    loading: boolean;
    requestResult?: IRequest;
    requests: IPagedModel<IRequest> | null;
    status?: number;
    error?: IError;
    disable: boolean;
}

export type CreateAction = {
    handleResult: Function,
    formValues: IRequestForm,
}

export type DisableAction = {
    handleResult: Function,
    requestId: number,
}

const initialState: RequestState = {
    requests: null,
    loading: false,
    disable: false
}

const requestReduceSlice = createSlice({
    name: 'request',
    initialState,
    reducers: {
        createRequest: (state, action: PayloadAction<CreateAction>) : RequestState => {
            return {
                ...state,
                loading: false,
            }
        },

        setRequest: (state, action: PayloadAction<IRequest | undefined>) : RequestState => {
            const requestResult = action.payload;

            return {
                ...state,
                requestResult,
                loading: false,
            }
        },

        getRequest: (state, action: PayloadAction<IPagedModel<IRequest>>): RequestState => {
            return {
                ...state,
                loading: true,
            }
        },

        getRequests: (state, action: PayloadAction<IQueryRequestModel>): RequestState => {
            return {
                ...state,
                loading: true,
            }
        },

        setRequests: (state, action: PayloadAction<IPagedModel<IRequest>>): RequestState => {
            const requests = action.payload;
            return {
                ...state,
                requests,
                loading: false,
            }
        },

        deleteRequest: (state, action: PayloadAction<DisableAction>): RequestState => {
            return {
                ...state,
                loading: true,
            }
        },

        setStatus: (state, action: PayloadAction<SetStatusType>): RequestState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },
    }
})

export const {
    createRequest, setRequest, getRequest, getRequests, setRequests, setStatus, deleteRequest
} = requestReduceSlice.actions;

export default requestReduceSlice.reducer;
