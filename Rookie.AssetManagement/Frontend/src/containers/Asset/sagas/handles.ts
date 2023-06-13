import { PayloadAction } from "@reduxjs/toolkit";
import { call, put } from "redux-saga/effects";
import { Status } from "src/constants/status";

import IError from "src/interfaces/IError";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";
import { setAsset, CreateAction, setAssets, setStatus, DisableAction } from "../reducer";
import { createAssetRequest, getAssetsRequest, updateAssetRequest, disableAssetRequest } from './requests';

export function* handleCreateAsset(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {
        const { data } = yield call(createAssetRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setAsset(data.result));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleGetAssets(action: PayloadAction<IQueryAssetModel>) {
    const query = action.payload;
    try {
        const { data } = yield call(getAssetsRequest, query);
        console.log('hanldes', data);
        // data = null
        // const { data } = await call(getAssetsRequest, query)
        // console.log('handle', data)
        //if (data) {
            yield put(setAssets(data))
        //}
    } catch (error: any) {
        const errorModel = error.response.data as IError;
        // yield put(setStatus({
        //     status: Status.Failed,
        //     error: errorModel,
        // }));
    }
}

export function* handleUpdateAsset(action: PayloadAction<CreateAction>) {
    const {handleResult, formValues} = action.payload;
    try {

        const { data } = yield call(updateAssetRequest, formValues);

        if (data)
        {
            handleResult(true, data.name);
        }

        yield put(setAsset(data));
        
    } catch (error: any) {
        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}

export function* handleDisableAsset(action: PayloadAction<DisableAction>) {
    const { handleResult, staffcode } = action.payload;

    try {
        const {data} = yield call(disableAssetRequest, staffcode);

        handleResult(data, '');

    } catch (error: any) {

        const errorModel = error.response.data as IError;

        handleResult(false, errorModel.message);
    }
}