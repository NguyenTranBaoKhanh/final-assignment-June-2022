import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IAssetForm from "../../../interfaces/Asset/IAssetForm";
import IAsset from '../../../interfaces/Asset/IAsset';
import IRequest from "src/interfaces/Request/IRequest";
import IQueryRequestModel from "src/interfaces/Request/IQueryRequestModel";
import IRequestForm from "src/interfaces/Request/IRequestForm";


export function createRequestRequest(requestForm: IRequestForm): Promise<AxiosResponse<IRequest>> {
    return RequestService.axios.post(EndPoints.request, requestForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function getRequestsRequest(query: IQueryRequestModel): Promise<AxiosResponse<IRequest>> {
    return RequestService.axios.get(EndPoints.request, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function updateAssetRequest(assetForm: IAssetForm): Promise<AxiosResponse<IAsset>> {
    return RequestService.axios.put(EndPoints.assetCode(assetForm.assetCode?? ""), assetForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function DeleteAssignmentRequest(assignmentId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.delete(EndPoints.deleteAssignment(assignmentId));
}