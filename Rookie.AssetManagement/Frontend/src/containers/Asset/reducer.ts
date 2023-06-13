import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { SetStatusType } from "../../constants/status";
import IError from "../../interfaces/IError";
import IPagedModel from "../../interfaces/IPagedModel";
import IAsset from "../../interfaces/Asset/IAsset";
import IAssetForm from "../../interfaces/Asset/IAssetForm";
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";

type AssetState = {
    loading: boolean;
    assetResult?: IAsset;
    assets: IPagedModel<IAsset> | null;
    status?: number;
    error?: IError;
    disable: boolean;
}
export type DisableAction = {
    handleResult: Function,
    staffcode: string,
}

export type CreateAction = {
    handleResult: Function,
    formValues: IAssetForm,
}

const initialState: AssetState = {
    assets: null,
    loading: false,
    disable: false,
};

const assetReducerSlice = createSlice({
    name: 'home',
    initialState,
    reducers: {
        createAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
            console.log('createAsset: ', action)
            return {
                ...state,
                loading: true,
            }
        },

        setAsset: (state, action: PayloadAction<IAsset>): AssetState => {
            const assetResult = action.payload;

            return {
                ...state,
                assetResult,
                loading: false,
            }
        },

        getAssets: (state, action: PayloadAction<IQueryAssetModel>): AssetState => {
            return {
                ...state,
                loading: true,
            }
        },

        setAssets: (state, action: PayloadAction<IPagedModel<IAsset>>): AssetState => {
            const assets = action.payload;
            return {
                ...state,
                assets,
                loading: false,
            }
        },

        setStatus: (state, action: PayloadAction<SetStatusType>): AssetState => {
            const { status, error } = action.payload;

            return {
                ...state,
                status,
                error,
                loading: false,
            }
        },

        updateAsset: (state, action: PayloadAction<CreateAction>): AssetState => {
            return {
                ...state,
                loading: true,
            }
        },

        disableAsset: (state, action: PayloadAction<DisableAction>): AssetState => {
            return {
                ...state,
                loading: true,
            }
        },

    }
})


export const {
    createAsset, setAsset, getAssets, setAssets, setStatus, disableAsset, updateAsset
} = assetReducerSlice.actions;

export default assetReducerSlice.reducer;