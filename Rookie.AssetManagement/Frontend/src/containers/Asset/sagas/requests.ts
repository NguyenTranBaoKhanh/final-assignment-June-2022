import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IAssetForm from "../../../interfaces/Asset/IAssetForm";
import IAsset from '../../../interfaces/Asset/IAsset';
import IQueryAssetModel from "src/interfaces/Asset/IQueryAssetModel";


export function createAssetRequest(assetForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.post(EndPoints.asset, assetForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function getAssetsRequest(query: IQueryAssetModel): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.get(EndPoints.asset, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function updateAssetRequest(assetForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.put(EndPoints.assetCode(assetForm.assetCode?? ""), assetForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function disableAssetRequest(staffcode: string): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.delete(EndPoints.assetCode(staffcode));
}