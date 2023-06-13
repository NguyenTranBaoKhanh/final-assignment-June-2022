import { AxiosResponse } from "axios";
import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../constants/endpoints';
import IAssetForm from "../../../interfaces/Asset/IAssetForm";
import IAsset from '../../../interfaces/Asset/IAsset';
import IAssignment from "src/interfaces/Assignment/IAssignment";
import IQueryAssignmentModel from "src/interfaces/Assignment/IQueryAssignmentModel";
import IAssignmentForm from "src/interfaces/Assignment/IAssignmentForm";


export function createAssignmentRequest(assignmentForm: IAssignmentForm): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.post(EndPoints.assignment, assignmentForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function getAssignmentsRequest(query: IQueryAssignmentModel): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.get(EndPoints.assignment, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}

export function updateAssignmentRequest(assignmentForm: IAssignmentForm): Promise<AxiosResponse<IAssignment>> {
    return RequestService.axios.put(EndPoints.assignmentIdUpdate(assignmentForm.assignmentId?? ""), assignmentForm, {
        paramsSerializer: params => qs.stringify(params),
    });
}

export function DeleteAssignmentRequest(assignmentId: number): Promise<AxiosResponse<Boolean>> {
    return RequestService.axios.delete(EndPoints.deleteAssignment(assignmentId));
}